
namespace Startup.Custom;


public static class AppExtensions
{

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

        app.MapControllers();
        app.UseSwaggerConfiguration();



    }



}
