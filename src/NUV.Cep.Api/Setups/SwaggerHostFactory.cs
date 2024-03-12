using Microsoft.Extensions.Hosting;
using System;

namespace CBL.Startup.Custom
{
    /// <summary>
    /// Essa classe é exigencia da Swagger conforme documentação do GitHub
    /// A classe precisa ter o nome SwaggerWebHostFactory
    /// Precisa ter um metodo com o nome CreateWebHost que retorne IWebHost
    /// </summary>
    public static class SwaggerHostFactory
    {
        public static string SwaggerCreateHost = "swagger";

        public static IHost CreateHost()
        {
            Console.WriteLine($"**** {typeof(SwaggerHostFactory).FullName} ****");
            var args = new string[] { SwaggerCreateHost };
            return Program.CreateHostBuilder(args).Build();
        }
    }
}