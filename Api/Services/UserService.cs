using Api.Models;
using Api.Repositories;
using Api.DTO;

namespace Api.Services;

public class UserService {
    public async Task<Response<List<User>>> GetUsers(UserRepository userRep) {
        var users = await userRep.GetUsers();
        return new Response<List<User>>(users, "Retrieved users successfully");
    }

    public async Task<Response> Register(UserRepository userRep, PasswordService passwordService, UserAuthReq req) {
        User user = new(Guid.NewGuid(), req.Name, passwordService.Hash(req.Password));
        var res = await userRep.AddUser(user);
        return res ? new Response("User added successfully") : new Response("User already exists", ErrorType.UserAlreadyExists);
    }

    public async Task<Response> Login(UserRepository userRep, PasswordService passwordService, UserAuthReq req) {
        var user = await userRep.GetUser(req.Name);
        if (user is null) return new Response("User doesn't exist", ErrorType.UserNotFound);
        return passwordService.Verify(req.Password, user.HashedPassword) ? new Response("User logged in successfully") : new Response("Wrong password", ErrorType.WrongPassword);
    }
}