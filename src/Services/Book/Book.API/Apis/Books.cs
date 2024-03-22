using Microsoft.AspNetCore.Http.HttpResults;

namespace Book.API;

public static class Books
{
    public static IEndpointRouteBuilder MapBookApi(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("api/v1/books", GetAll)
            .Produces(StatusCodes.Status200OK)
            .WithName("books")
            .WithOpenApi();

        return builder;
    }

    public static async Task<Ok> GetAll()
    {
        await Task.CompletedTask;

        return TypedResults.Ok();
    }
}