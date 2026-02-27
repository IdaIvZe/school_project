using School.Application.Services;
namespace School.Api.ExtensionsTest

{
    public static class StartupExtension
    {
        public static async Task TestDataBaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var service = scope.ServiceProvider.GetRequiredService<DataBaseConnectionService>();

            await service.CheckConnectionAsync();

        }

    }
}
