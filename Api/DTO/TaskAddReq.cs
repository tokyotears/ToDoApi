using TaskStatus = Api.Models.TaskStatus;

namespace Api.DTO;

public record TaskAddReq(string Name, string Task, TaskStatus Status = TaskStatus.ToDo);