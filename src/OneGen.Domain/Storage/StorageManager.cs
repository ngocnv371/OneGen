using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Content;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;

namespace OneGen.Storage
{
	public class StorageManager(ImagingService imaging, IGuidGenerator guidGenerator) : DomainService
	{
		public async Task<Guid> UploadFileAsync(IRemoteStreamContent file)
		{
			using var normalizedStream = await imaging.NormalizeImage(file);
			var id = guidGenerator.Create();
			var folder = Path.Combine(
				AppDomain.CurrentDomain.BaseDirectory,
				OneGenConsts.TempStorageFolder
				);
			var ext = Path.GetExtension(file.FileName);
			var fileName = $"{id}.{ext}";
			var filePath = Path.Combine(folder, fileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await normalizedStream.CopyToAsync(stream);
			}
			return id;
		}

		public async Task<string> UploadFileAsync(Guid id, string base64, string ext)
		{
			var folder = Path.Combine(
				AppDomain.CurrentDomain.BaseDirectory,
				OneGenConsts.TempStorageFolder
				);
			var fileName = $"{id}.{ext}";
			var filePath = Path.Combine(folder, fileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				var decoded = Convert.FromBase64String(base64);
				await stream.WriteAsync(decoded);
			}
			return fileName;
		}

		public async Task<IRemoteStreamContent> GetFileAsync(Guid id)
		{
			var folder = Path.Combine(
				AppDomain.CurrentDomain.BaseDirectory,
				OneGenConsts.TempStorageFolder
				);
			var files = Directory.GetFiles(folder, $"{id}.*");
			var fileName = files.FirstOrDefault();
			if (fileName.IsNullOrEmpty())
			{
				throw new Exception("File not found");
			}

			var filePath = Path.Combine(folder, fileName);
			var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			return new RemoteStreamContent(fs, fileName);
		}
	}
}