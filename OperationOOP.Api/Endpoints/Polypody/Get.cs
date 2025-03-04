using OperationOOP.Core.Models.Plants;

namespace OperationOOP.Api.Endpoints;
public class GetPolypody : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/polypodys/{id}", Handle);

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        CareLevel CareLevel
    );

    private static Response Handle([AsParameters] Request request, IDatabase db)
    {
        var polypody = db.Polypody.Find(polypody => polypody.Id == request.Id);

        var response = new Response(
            Id: polypody.Id,
            Name: polypody.Name,
            Species: polypody.Species,
            AgeYears: polypody.AgeYears,
            LastWatered: polypody.LastWatered,
            CareLevel: polypody.CareLevel
            );
        return response;
    }
}