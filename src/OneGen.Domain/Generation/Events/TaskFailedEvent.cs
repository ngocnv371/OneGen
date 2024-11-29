namespace OneGen.Generation.Events
{
	internal class TaskFailedEvent(Task task)
	{
		public Task Task { get; } = task;
	}
}