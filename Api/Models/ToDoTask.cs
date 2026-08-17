namespace Api.Models;

public enum TaskStatus {
    ToDo,
    InProgress,
    Done
}

public class ToDoTask(Guid id, string name, string task, TaskStatus status) {
    public Guid Id { get; init; } = id;
    public string Name { get; set; } = name;
    public string Task { get; set; } = task;
    public TaskStatus Status { get; set; } = status;
}