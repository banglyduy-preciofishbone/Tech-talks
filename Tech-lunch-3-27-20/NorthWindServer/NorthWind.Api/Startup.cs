using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Playground;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Api.Graph.Mutations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NorthWind.Api.Graph.Queries;
using NorthWind.Api.Models;

namespace NorthWind.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEntityFrameworkSqlServer().AddDbContext<NorthWindContext>();

            services
                .AddDataLoaderRegistry()
                .AddGraphQL(sp => {
                    return SchemaBuilder.New()
                    .AddQueryType<QueryType>()
                    .AddMutationType<MutationType>()
                    .Create();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseGraphQL("/graph");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions { GraphQLEndPoint = "/graph" });
        }
    }
}
