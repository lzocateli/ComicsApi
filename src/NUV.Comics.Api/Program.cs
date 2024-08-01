
var builder = WebApplication.CreateBuilder(args);



Console.WriteLine(Environment.GetEnvironmentVariable("ENVTEST"));
Console.WriteLine($"**** Environment: {builder.Environment.EnvironmentName} ****");

var pathEnvFile = string.Empty;
if (args.NotNullOrZero())
{
    pathEnvFile = args.FirstOrDefault(x => x.StartsWith("--env="))?.Replace("--env=", "");
}
if (string.IsNullOrWhiteSpace(pathEnvFile))
{
    pathEnvFile = Path.Combine(
        builder.Environment.ContentRootPath, ".env");
}
CustomDotEnv.LoadDotEnv(pathEnvFile);


var configureProxy = new WebProxyConfigureMethod();
WebRequest.DefaultWebProxy = configureProxy.GetProxyWithVariable();
Console.WriteLine($"Proxy configured: {configureProxy.HttpProxyField} no proxy: {string.Join(",", configureProxy.HttpNoProxyField ?? new string[] { })}");

builder.AddVaultBuilder();
builder.AddArchitectures();

var app = builder.Build();

var testVault = builder.Configuration.GetSection("ApplicationInsights:ConnectionString")?.Value;
Console.WriteLine($"Get vault access is: {!string.IsNullOrWhiteSpace(testVault)}");
Console.WriteLine($"**** LogLevelDefault: {app.Configuration.GetSection("Logging:LogLevel:Default")?.Value} ****");


// app.MapEndpoints();
app.UseArchitectures();



app.Run();


