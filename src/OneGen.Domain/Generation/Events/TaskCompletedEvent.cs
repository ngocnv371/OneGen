namespace OneGen.Generation.Events
{
	public class TaskCompletedEvent(Task task, Subject subject, string[] value)
	{
		public Subject Subject { get; } = subject;
		public Task Task { get; } = task;
		public string[] Value { get; } = value;
	}
}