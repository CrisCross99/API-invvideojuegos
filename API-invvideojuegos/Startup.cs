using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using API_invvideojuegos.Controllers;
using API_invvideojuegos.Filtros;
using API_invvideojuegos.Middlewares;
using API_invvideojuegos.Services;

namespace API_invvideojuegos
{
   
    
        public class Startup
        {
            public Startup(IConfiguration configuration)
            {

                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllers(opciones =>
                {
                    opciones.Filters.Add(typeof(FiltroDeExcepcion));
                }).AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));


                services.AddTransient<IService, ServiceA>();

                services.AddTransient<ServiceTransient>();

                services.AddScoped<ServiceScoped>();
                services.AddSingleton<ServiceSingleton>();
                services.AddTransient<FiltroDeAccion>();
               services.AddHostedService<EscribirEnArchivo>();
                services.AddResponseCaching();
                //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIAlumnos", Version = "v1" });
                });
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
            {

                app.UseResponseHttpMiddleware();



                app.Map("/maping", app =>
                {
                    app.Run(async context =>
                    {
                        await context.Response.WriteAsync("Interceptando las peticiones");
                    });
                });


                // Configure the HTTP request pipeline.
                if (env.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseResponseCaching();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });


            }
        }
    }