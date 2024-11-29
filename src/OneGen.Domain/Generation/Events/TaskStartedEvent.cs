namespace OneGen.Generation.Events
{
	public class TaskStartedEvent(Task task)
	{
		public Task Task { get; } = task;
	}
}