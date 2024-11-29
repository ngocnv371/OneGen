namespace OneGen.Generation.Events
{
	internal class TaskCompletedEvent(Task task, string[] value)
	{
		public Task Task { get; } = task;
		public string[] Value { get; } = value;
	}
}