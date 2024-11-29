namespace OneGen.Generation.Events
{
	public class TaskCompletedEvent(Task task, string[] value)
	{
		public Task Task { get; } = task;
		public string[] Value { get; } = value;
	}
}