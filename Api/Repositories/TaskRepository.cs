using Api.Models;
using Api.Data;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class TaskRepository(AppDbContext db) {
    public async Task<List<ToDoTask>> GetTasks() => await db.Tasks.AsNoTracking().ToListAsync();
    
    private async Task<ToDoTask?> GetTask(Guid id) => await db.Tasks.FindAsync(id);
    
    public async Task AddTask(ToDoTask task) { 
        db.Tasks.Add(task);
        await db.SaveChangesAsync();
    }

    public async Task<bool> DeleteTask(Guid id) {
        var task = await GetTask(id);
        if (task is null) return false;
        db.Tasks.Remove(task);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditTask(Guid id, TaskChangeReq req) {
        var task = await GetTask(id);
        if (task is null) return false;
        if (!string.IsNullOrEmpty(req.Name)) task.Name = req.Name;
        if (!string.IsNullOrEmpty(req.Task)) task.Task = req.Task;
        if (req.Status.HasValue) task.Status = req.Status.Value;
        await db.SaveChangesAsync();
        return true;
    }
}
