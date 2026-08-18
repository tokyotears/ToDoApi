using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class UserRepository(AppDbContext db) {
    public async Task<List<User>> GetUsers() => await db.Users.AsNoTracking().ToListAsync();

    private async Task<User?> GetUser(Guid id) => await db.Users.FindAsync(id);

    public async Task<User?> GetUser(string name) {
        var users = await GetUsers();
        var user = users.FirstOrDefault(u => u.Name == name);
        return user;
    }

    public async Task<bool> AddUser(User user) {
        if (await GetUser(user.Name) is not null) return false;
        db.Users.Add(user);
        await db.SaveChangesAsync();
        return true;
    }
}