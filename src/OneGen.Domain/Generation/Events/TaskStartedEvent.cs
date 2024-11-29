namespace OneGen.Generation.Events
{
	internal class TaskStartedEvent(Task task)
	{
		public Task Task { get; } = task;
	}
}