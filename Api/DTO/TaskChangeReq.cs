using TaskStatus = Api.Models.TaskStatus;

namespace Api.DTO;

public record TaskChangeReq(string? Name, string? Task, TaskStatus? Status);