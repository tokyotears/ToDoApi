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
            return res.IsSuccess ? Results.Ok(res.Data) : ResponseMapper.ToIRes(res);
        });
        app.MapPost("/tasks", async (TaskRepository taskRep, TaskService taskService, TaskAddReq req) => {
            var res = await taskService.AddTask(taskRep, req);
            return res.IsSuccess ? Results.Ok(res.Message) : ResponseMapper.ToIRes(res);
        });
        app.MapDelete("/tasks/{id:guid}", async (TaskRepository taskRep, TaskService taskService, Guid id) => {
            var res = await taskService.DeleteTask(taskRep, id);
            return res.IsSuccess ? Results.Ok(res.Message) : ResponseMapper.ToIRes(res);
        });
        app.MapPatch("/tasks/{id:guid}", async (TaskRepository taskRep, TaskService taskService, TaskChangeReq req, Guid id) => {
            var res = await taskService.EditTask(taskRep, req, id);
            return res.IsSuccess ? Results.Ok(res.Message) : ResponseMapper.ToIRes(res);
        });
    }
}