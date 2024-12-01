using OneGen.Generation.Jobs;
using OneGen.Storage;
using System;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;
using T = System.Threading.Tasks;

namespace OneGen.Generation
{
	public class GenerationManager(
		IGuidGenerator guidGenerator,
		IBackgroundJobManager backgroundJobManager,
		StorageManager storageManager,
		IRepository<Task> taskRepository,
		IRepository<Variant> variantRepository,
		IRepository<Subject> subjectRepository
		) : IDomainService
	{
		/// <summary>
		/// Create a generation task for this subject
		/// </summary>
		/// <param name="subject"></param>
		/// <returns></returns>
		public async T.Task CreateTask(Subject subject)
		{
			var id = guidGenerator.Create();
			var task = new Task(id, subject.Id);
			await taskRepository.InsertAsync(task, true);
		}

		/// <summary>
		/// Schedule a generation job to handle this task
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public async T.Task ScheduleJob(Task task)
		{
			var subject = await subjectRepository.GetAsync(s => s.Id == task.SubjectId);
			if (subject == null)
			{
				throw new SubjectNotFoundException(task.SubjectId);
			}

			switch (subject.Type)
			{
				case SubjectType.Text:
					await backgroundJobManager.EnqueueAsync(new GenerateTextArgs(task.TenantId, task.Id));
					break;

				case SubjectType.Image:
					await backgroundJobManager.EnqueueAsync(new GenerateImageArgs(task.TenantId, task.Id));
					break;

				case SubjectType.Audio:
					await backgroundJobManager.EnqueueAsync(new GenerateAudioArgs(task.TenantId, task.Id));
					break;
			}
		}

		/// <summary>
		/// Bubble up the status of a task to its original Subject
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public async T.Task UpdateSubjectStatus(Task task)
		{
			var subject = await subjectRepository.GetAsync(s => s.Id == task.SubjectId);
			if (subject == null)
			{
				throw new SubjectNotFoundException(task.SubjectId);
			}

			subject.Status = task.Status;
			await subjectRepository.UpdateAsync(subject, true);
		}

		public static string ConvertSubjectTypeToExtension(SubjectType type)
		{
			return type switch
			{
				SubjectType.Audio => "wav",
				SubjectType.Image => "png",
				_ => string.Empty,
			};
		}

		public async T.Task CreateVariant(Task task, Subject subject, string[] value)
		{
			foreach (var v in value)
			{
				var id = guidGenerator.Create();
				var ext = ConvertSubjectTypeToExtension(subject.Type);
				Variant variant;
				if (!ext.IsNullOrEmpty())
				{
					var path = await storageManager.UploadFileAsync(id, v, ext);
					variant = new Variant(id, task.Id, path);
				}
				else
				{
					variant = new Variant(id, task.Id, v);
				}
				await variantRepository.InsertAsync(variant, true);
			}
		}
	}
}