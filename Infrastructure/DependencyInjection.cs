using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using Domain.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Application.Common.Interfaces;
using Infrastructure.Services;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment environment)
        {
            //Cosmos Settings
            var cosmosSettings = new CosmosStoreSettings(configuration["CosmosConnectionStrings:DatabaseName"],
                configuration["CosmosConnectionStrings:Uri"], configuration["CosmosConnectionStrings:Authkey"]);
            cosmosSettings.JsonSerializerSettings = new JsonSerializerSettings();

            services.AddCosmosStore<EbatchSheet>(cosmosSettings);

            services.AddSingleton<IEbatchSheetEmailSender, EbatchSheetEmailSender>();

            return services;
        }
    }
}
