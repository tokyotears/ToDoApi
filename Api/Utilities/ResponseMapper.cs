using Api.DTO;

namespace Api.Utilities;

public static class ResponseMapper {
    public static IResult ToIRes(Response res) {
        return res.Error switch {
            ErrorType.NotFound => Results.NotFound(res.Message),
            _ => Results.BadRequest()
        };
    }
}