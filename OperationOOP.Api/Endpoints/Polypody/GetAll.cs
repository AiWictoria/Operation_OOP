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

    //Logic
    private static List<Response> Handle(IDatabase db)
    {
        return db.Polypody
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                LastWatered: item.LastWatered
            )).ToList();
    }
}