using WebRecruitment.WebApi.Configuration;
using WebRecruitment.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// IConfiguration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .Build();


builder.Services
    .AddWebAPIService(configuration);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebRecruitment.WebApi");
});
app.UseRouting();
app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseCors();
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/healthchecks");
    endpoints.MapControllers();
});

app.Run();

