using Microsoft.AspNetCore.Mvc;

namespace OperationOOP.Api.Endpoints;
public class GetAllBonsais : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        DateTime LastWatered,
        DateTime LastPruned
    );

    // Gets all plants from bonsai unless there is a name query
    private static List<Response> Handle(IDatabase db,[FromQuery] string? query)
    {
        var bonsais = db.Bonsais.ToList();
        if (query is not null) bonsais = bonsais.Where(b => b.Name.Contains(query)).ToList();

        return bonsais
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                LastWatered: item.LastWatered,
                LastPruned: item.LastPruned
            )).ToList();

    }
}