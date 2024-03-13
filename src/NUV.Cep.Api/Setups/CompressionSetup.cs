namespace CBL.Startup.Custom.Setups
{
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