using Capital_placement_assessment.Models;
using Capital_placement_assessment.Repositories.Abstraction;
using Capital_placement_assessment.Repositories.Implementation;
using Microsoft.Azure.Cosmos;

namespace Capital_placement_assessment.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCosmos(this IServiceCollection serviceCollection, IConfiguration _config)
        {
            serviceCollection.AddOptions<CosmosConfig>().BindConfiguration("CosmosDB");
            var cosmosConfig = new CosmosConfig();
            _config.GetSection("CosmosDB").Bind(cosmosConfig);

            if (string.IsNullOrEmpty(cosmosConfig.Endpoint) || string.IsNullOrEmpty(cosmosConfig.PrimaryKey)
                || string.IsNullOrEmpty(cosmosConfig.DatabaseId))
            {
                throw new Exception("Unable to read cosmos database config");
            }

            var cosmosClient = new CosmosClient(cosmosConfig.Endpoint, cosmosConfig.PrimaryKey, new CosmosClientOptions
            {
                SerializerOptions = new CosmosSerializationOptions
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase,
                },
                ConnectionMode = ConnectionMode.Gateway
            });

            serviceCollection.AddScoped<IProfileService, ProfileService>();
            serviceCollection.AddScoped<IProfileRepository, ProfileRepository>(p =>
            {
                return new ProfileRepository(cosmosClient, cosmosConfig.DatabaseId, cosmosConfig.ContainerId);
            });

            serviceCollection.AddSingleton(cosmosClient);


            serviceCollection.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://example.com");
                });
            });

        }
    }
}