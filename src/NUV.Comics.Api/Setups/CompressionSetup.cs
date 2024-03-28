namespace Startup.Custom
{
    //FIXME: O Servidor WEB deve fazer a compressão, precisa testar e então remover essa classe.
    public static class CompressionSetup
    {
        public static void AddCompressionSetup(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            }).AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
        }
    }
}