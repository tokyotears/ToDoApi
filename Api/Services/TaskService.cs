using Api.Models;
using Api.Repositories;
using Api.DTO;

namespace Api.Services;

public class TaskService {
    public async Task<Response> AddTask(TaskRepository taskRep, TaskAddReq req) {
        ToDoTask task = new(Guid.NewGuid(), req.Name, req.Task, req.Status);
        await taskRep.AddTask(task);
        return new Response("Task added successfully");
    }

    public async Task<Response<List<ToDoTask>>> GetTasks(TaskRepository taskRep) {
        var tasks = await taskRep.GetTasks();
        return new Response<List<ToDoTask>>(tasks, "Retrieved tasks successfully");
    }

    public async Task<Response> DeleteTask(TaskRepository taskRep, Guid id) {
        var task = await taskRep.DeleteTask(id);
        return !task ? new Response("Task not found", ErrorType.NotFound) : new Response("Task deleted successfully");
    }
}