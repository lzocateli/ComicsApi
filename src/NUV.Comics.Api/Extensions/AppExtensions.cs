using Swashbuckle.AspNetCore.SwaggerUI;

namespace Startup.Custom;


public static class AppExtensions
{

    public static IApiVersionDescriptionProvider Provider;
    public static void UseArchitectures(this WebApplication app)
    {

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseCors("Development");
        }
        else
        {
            app.UseCors("Production");
            if (DebugMode.IsDebug)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseGlobalExceptionHandlerMiddleware();
            }
            app.UseHsts();
        }

        app.UseRequestLocalization();
        app.UseHttpsRedirection();
        app.UseHandlingHeadersMiddleware();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseConfigurationHealthChecks();

        app.UseStaticFiles();


        app.UseEndpoints(config =>
        {
            config.MapDefaultControllerRoute();
        });

        // app.UseSwaggerConfiguration(app.Configuration, Provider);

        string vpath = app.Configuration.GetSection("VirtualPath")?.Value?.Trim() ?? string.Empty;
        vpath = (string.IsNullOrWhiteSpace(vpath) ? "/swagger/" : ("/" + vpath + "/swagger/"));
        app.UseSwagger();
        app.UseSwaggerUI(delegate (SwaggerUIOptions options)
        {
            foreach (ApiVersionDescription apiVersionDescription in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(vpath + apiVersionDescription.GroupName + "/swagger.json", apiVersionDescription.GroupName.ToUpperInvariant());
                options.RoutePrefix = "docs";
            }
        });


    }



}
