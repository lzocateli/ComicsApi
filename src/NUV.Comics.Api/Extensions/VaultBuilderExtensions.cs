namespace Startup.Custom;


public static class VaultBuilderExtensions
{

    public static void AddVaultBuilder(this WebApplicationBuilder builder)
    {

        var keyvaultDns = builder.Configuration.GetSection("AzureKeyVault:Dns")?.Value;
        Console.WriteLine($"KeyVault credential is {!string.IsNullOrWhiteSpace(keyvaultDns)}");

        Uri.TryCreate(keyvaultDns, UriKind.RelativeOrAbsolute, out Uri vaultDns);
        var vaultTenantId = builder.Configuration.GetSection("AzureKeyVault:TenantId")?.Value;
        var vaultClientId = builder.Configuration.GetSection("AzureKeyVault:ClientId")?.Value;
        var vaultClientSecret = builder.Configuration.GetSection("AzureKeyVault:ClientSecret")?.Value;

        TokenCredential credential = new
            ClientSecretCredential(
                tenantId: vaultTenantId,
                clientId: vaultClientId,
                clientSecret: vaultClientSecret
            );

        ConfigurationBuilder configBuilder = new();
        configBuilder.AddAzureKeyVault(vaultDns, credential);

        if (builder.Environment.IsDevelopment())
        {
            configBuilder.AddUserSecrets<Program>();
        }
    }

}