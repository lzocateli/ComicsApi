namespace NUV.Comics.Api.Endpoints;

public static class HomeEndpoints
{

    public static void MapHomeEndpoints(this WebApplication app)
    {

        app.MapGet("/", () => "HelloWorld");

    }
}