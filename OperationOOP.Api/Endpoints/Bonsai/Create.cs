using OperationOOP.Core.Models.Plants;

namespace OperationOOP.Api.Endpoints;
public class CreateBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    public record Request(
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
        );
    public record Response(int id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var newId = db.Bonsais.Any()
            ? db.Bonsais.Max(bonsai => bonsai.Id) + 1
            : 1;

        var bonsai = new Bonsai(        
            id: newId,
            name: request.Name,
            species: request.Species,
            age: request.AgeYears,
            lastWatered: request.LastWatered,
            lastPruned: request.LastPruned,
            bonsaiStyle: request.Style,
            careLevel: request.CareLevel
            );

        db.Bonsais.Add(bonsai);

        return TypedResults.Ok(new Response(bonsai.Id));
    }
}

