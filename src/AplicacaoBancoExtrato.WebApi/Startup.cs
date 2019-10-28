namespace AplicacaoBancoExtrato.WebApi {
    using System.IO;
    using System.Reflection;
    using Autofac.Configuration;
    using Autofac;
    using AplicacaoBancoExtrato.WebApi.Filters;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddCors (options => {
                options.AddPolicy ("CorsPolicy",
                    builder => builder.AllowAnyOrigin ()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .AllowCredentials ());
            });

            services.AddMvc (options => {
                options.Filters.Add (typeof (DomainExceptionFilter));
                options.Filters.Add (typeof (ValidateModelAttribute));
            });

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new Info { Title = "Aplicação Extrato", Version = "v1" });
            });
        }

        public void ConfigureContainer (ContainerBuilder builder) {
            builder.RegisterModule (new ConfigurationModule (Configuration));
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseCors ("CorsPolicy");

            app.UseMvc ();

            app.UseSwagger ();

            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Aplicação Extrato V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}