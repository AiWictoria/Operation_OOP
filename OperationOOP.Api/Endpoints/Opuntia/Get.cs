using OperationOOP.Core.Models.Plants;

namespace OperationOOP.Api.Endpoints;
public class GetOpuntia : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/opuntias/{id}", Handle);

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        DateTime LastPruned,
        CareLevel CareLevel
    );

    private static Response Handle([AsParameters] Request request, IDatabase db)
    {
        var opuntia = db.Opuntias.Find(opuntia => opuntia.Id == request.Id);

        var response = new Response(
            Id: opuntia.Id,
            Name: opuntia.Name,
            Species: opuntia.Species,
            AgeYears: opuntia.AgeYears,
            LastPruned: opuntia.LastPruned,
            CareLevel: opuntia.CareLevel
            );
        return response;
    }
}