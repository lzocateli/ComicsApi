namespace CBL.Common.IoC
{
    /// <summary>
    /// Essa classe é necessario para executar os programas no Linux com uso de proxy <br/>
    /// use para configurar suas injeções do HttpClient.
    /// </summary>
    /// <example>
    /// <code>
    ///     services.AddHttpClient("SuaApi", client =>
    ///     {
    ///          client.BaseAddress = new Uri(configuration.GetSection("AppConfig:AppURLs:UrlSuaApi")?.Value);
    ///          client.DefaultRequestHeaders.Add("Accept", "application/json");
    ///     })
    ///     .ConfigurePrimaryHttpMessageHandler(() =>
    ///     {
    ///         return new MyHttpClientHandler(WebRequest.DefaultWebProxy).SetMyClientHandler();
    ///     })
    ///     .AddPolicyWithTokenHandlers(services, retryTotal: 2, breakDurationMilliSeconds: 2000);
    /// </code>
    /// </example>
    public class MyHttpClientHandler : HttpClientHandler
    {
        private IWebProxy WebProxyConfig { get; set; }
        public HttpClientHandler MyClientHandler { get; set; }

        /// <summary>
        /// Informe o proxy, que normalmente esta configurado no program.cs <br/>
        /// da seguinte forma: <c>WebRequest.DefaultWebProxy = new WebProxyConfigureMethod().GetProxyWithVariable();</c><br/>
        /// Foi necessario incluir ServerCertificateCustomValidationCallback para que dentro do container <br/>
        /// o dotnet não faça a verificação de SSL, pois os certificados não podem ser verificados no container
        /// </summary>
        /// <param name="webProxy">WebRequest.DefaultWebProxy</param>
        public MyHttpClientHandler(IWebProxy webProxy)
        {
            WebProxyConfig = webProxy;
            MyClientHandler = new HttpClientHandler
            {
                Proxy = WebProxyConfig,
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
        }
    }
}