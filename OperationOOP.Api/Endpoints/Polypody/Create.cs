using OperationOOP.Core.Models.Plants;

namespace OperationOOP.Api.Endpoints;
public class CreatePolypody : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/polypodys", Handle)
        .WithSummary("Polypody plants");

    public record Request(
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        CareLevel CareLevel
        );
    public record Response(int id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var newId = db.Polypody.Any()
            ? db.Polypody.Max(polypody => polypody.Id) + 1
            : 1;

        var polypody = new Polypody(        
            id: newId,
            name: request.Name,
            species: request.Species,
            age: request.AgeYears,
            lastWatered: request.LastWatered,
            careLevel: request.CareLevel
            );

        db.Polypody.Add(polypody);

        return TypedResults.Ok(new Response(polypody.Id));
    }
}

