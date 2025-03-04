using Microsoft.AspNetCore.Mvc;

namespace OperationOOP.Api.Endpoints;
public class GetAllOpuntias : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/opuntias", Handle);

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        DateTime LastPruned
    );

    //Logic
    private static List<Response> Handle(IDatabase db, [FromQuery] string? query)
    {
        var opuntias = db.Opuntias.ToList();
        if (query is not null) opuntias = opuntias.Where(o => o.Name.Contains(query)).ToList();

        return opuntias
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                LastPruned: item.LastPruned
            )).ToList();
    }
}