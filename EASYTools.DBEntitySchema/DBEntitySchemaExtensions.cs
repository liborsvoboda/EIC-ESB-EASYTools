using EASYTools.DBEntitySchema.Core.Repository;
using EASYTools.DBEntitySchema.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EASYTools.DBEntitySchema.Core {

    public static class DBEntitySchemaExtensions {

        public static void AddDBEntitySchema(this IServiceCollection services, string connectionString) {
            services.AddScoped<IBaseRepository>(serviceProvider => new BaseRepository(connectionString));
            services.AddScoped<IDBEntitySchemaService, DBEntitySchemaService>();
        }

        public static void UseDBEntitySchema(this IApplicationBuilder app, Action<DBEntitySchemaOptions> optionsHandler) {
            DBEntitySchemaOptions options = new DBEntitySchemaOptions();

            optionsHandler(options);

            app.Map($"{options.PathMatch}", app => {
                app.UseMiddleware<DBEntitySchemaUIMiddleware>(options);
            });
        }

        public static void UseDBEntitySchema(this IApplicationBuilder app) {
            app.UseDBEntitySchema(opts => { });
        }
    }
}