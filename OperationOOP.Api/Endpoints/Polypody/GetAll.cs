using Microsoft.AspNetCore.Mvc;
namespace OperationOOP.Api.Endpoints;
public class GetAllPolypodys : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/polypodys", Handle);

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        DateTime LastWatered
    );

    // Gets all plants from polypody unless there is a name query
    private static List<Response> Handle(IDatabase db, [FromQuery] string? query)
    {
        var polypodys = db.Polypody.ToList();

        if (query is not null) polypodys = polypodys.Where(p => p.Name.Contains(query)).ToList();
        
        return db.Polypody
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                LastWatered: item.LastWatered
            )).ToList();
    }
}