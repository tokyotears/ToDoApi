using Api.Repositories;
using Api.Services;
using Api.Utilities;
using Api.DTO;

namespace Api.Endpoints;

public static class UserEndpoints {
    public static void MapUserEndpoints(this WebApplication app) {
        app.MapGet("/users", async (UserRepository userRep, UserService userService) => {
            var res = await userService.GetUsers(userRep);
            return Results.Ok(res.Data);
        });
        app.MapPost("/register", async (UserRepository userRep, UserService userService, PasswordService passwordService, UserAuthReq req) => {
            var res = await userService.Register(userRep, passwordService, req);
            return res.IsSuccess ? Results.Ok(res.Message) : ResponseMapper.ToIRes(res);
        });
        app.MapPost("/login", async (UserRepository userRep, UserService userService, PasswordService passwordService, UserAuthReq req) => {
            var res = await userService.Login(userRep, passwordService, req);
            return res.IsSuccess ? Results.Ok(res.Message) : ResponseMapper.ToIRes(res);
        });
    }
}