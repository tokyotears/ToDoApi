using Api.Services;
using Api.Repositories;
using Api.DTO;
using Api.Utilities;

namespace Api.Endpoints;

public static class TaskEndpoints {
    public static void MapTaskEndpoints(this WebApplication app) {
        app.MapGet("/", () => "This is new");
        app.MapGet("/tasks", async (TaskRepository taskRep, TaskService taskService) => {
            var res = await taskService.GetTasks(taskRep);
            if (res.IsSuccess) return Results.Ok(res.Data);
            return ResponseMapper.ToIRes(res);
        });
        app.MapPost("/tasks", async (TaskRepository taskRep, TaskService taskService, TaskAddReq req) => {
            var res = await taskService.AddTask(taskRep, req);
            if (res.IsSuccess) return Results.Ok(res.Message);
            return ResponseMapper.ToIRes(res);
        });
    }
}