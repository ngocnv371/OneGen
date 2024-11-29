namespace OneGen.Generation.Events
{
	public class TaskFailedEvent(Task task)
	{
		public Task Task { get; } = task;
	}
}