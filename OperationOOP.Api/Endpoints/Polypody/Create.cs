using OperationOOP.Core.Models.Plants;

namespace OperationOOP.Api.Endpoints;
public class CreateOpuntia : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/opuntias", Handle)
        .WithSummary("Opuntia plants");

    public record Request(
        string Name,
        string Species,
        int AgeYears,
        DateTime LastPruned,
        CareLevel CareLevel
        );
    public record Response(int id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var newId = db.Opuntias.Any()
            ? db.Opuntias.Max(opuntia => opuntia.Id) + 1
            : 1;

        var opuntia = new Opuntia(        
            id: newId,
            name: request.Name,
            species: request.Species,
            age: request.AgeYears,
            lastPruned: request.LastPruned,
            careLevel: request.CareLevel
            );

        db.Opuntias.Add(opuntia);

        return TypedResults.Ok(new Response(opuntia.Id));
    }
}

