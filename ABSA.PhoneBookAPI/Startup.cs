using ABSA.PhoneBookAPI.Data.Models;
using ABSA.PhoneBookAPI.Data.Repositories;
using ABSA.PhoneBookAPI.Services;
using ABSA.PhoneBookAPI.Models.Request;
using ABSA.PhoneBookAPI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using NSwag;
using NSwag.AspNetCore;

namespace ABSA.PhoneBookAPI
{
    public class Startup
    {
         /// <summary>
        ///     Gets an <see cref="IConfiguration" /> representing the application's configuration.
        /// </summary>
        private IConfiguration Configuration { get; }

        /// <summary>
        ///     Gets an <see cref="IWebHostEnvironment" /> representing the application's hosting environment.
        /// </summary>
        private IWebHostEnvironment Env { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">An <see cref="IConfiguration" /> representing the application's configuration.</param>
        /// <param name="env">An <see cref="IWebHostEnvironment" /> representing the application's hosting environment.</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region CORS
            services.AddCors(options =>
            {
                var corsOrigins = Configuration["CorsOrigins"];
                if (corsOrigins == "*")
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                }
                else
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.WithOrigins(corsOrigins)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
                }
            });
            #endregion

            #region Fluent Validation
            services.AddMvc().AddFluentValidation(fv => {
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

            services.AddTransient<IValidator<ContactRequest>, ContactRequestValidator>();
            services.AddTransient<IValidator<ContactSearchRequest>, ContactSearchRequestValidator>();
            #endregion

            #region Database and Repositories
            
            // DB
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PhoneBookContext>(c => c.UseNpgsql(connectionString));
            // Repository
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IContactRepository, ContactRepository>();
            // Services
            services.AddTransient<IContactService, ContactService>();
            #endregion

            #region Swagger / Open API
            services.AddOpenApiDocument(config =>
            {
                // Set the document name to the APIs current version.
                config.DocumentName = Configuration["Swagger:DocumentName"];

                // Configure the Swagger document.
                config.PostProcess = document =>
                {
                    // Set the document's base path.
                    document.BasePath = "/";

                    //! Set the document Info
                    document.Info.Title = Configuration["Swagger:Info:Title"];
                    document.Info.Version = Configuration["Swagger:Info:Version"];
                    document.Info.Description = Configuration["Swagger:Info:Description"];
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = Configuration["Swagger:Info:Contact:Name"],
                        Email = Configuration["Swagger:Info:Contact:Email"],
                        Url = Configuration["Swagger:Info:Contact:Url"],
                    };
                    
                    //! Add Https and remove HTTP in production environment
                    document.Schemes.Add(OpenApiSchema.Https);
                    if (!Env.IsDevelopment()) document.Schemes.Remove(OpenApiSchema.Http);
                };
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add CORS.
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Add Swagger Middleware.
            app.UseOpenApi(config => { config.Path = Configuration["Swagger:OpenApi:Path"]; });
            app.UseSwaggerUi3(config =>
            {
                // Allow "Try it out" in development only.
                config.EnableTryItOut = Env.IsDevelopment();

                // Set Swagger website path and document route to match the controllers' base route.
                config.Path = Configuration["Swagger:SwaggerUi3:Path"];
                config.SwaggerRoutes.Add(new SwaggerUi3Route(
                    Configuration["Swagger:SwaggerUi3:SwaggerRoutes:Name"],
                    Configuration["Swagger:SwaggerUi3:SwaggerRoutes:Url"]
                ));
            });
        }
    }
}
