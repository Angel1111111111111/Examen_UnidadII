using Microsoft.EntityFrameworkCore;
using BackendIMC.DataBase;
using BackendIMC.Services.Interfaces;
using BackendIMC.Services;
using AutoMapper;

namespace todo_list_backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Agrega el servicio de controladores MVC
            services.AddControllers();

            // Configura el DbContext para Entity Framework Core
            services.AddDbContext<PacienteDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add Custom Services
            services.AddTransient<IPacienteServices, PacienteServices>();

            // Add Automapper Service
            services.AddAutoMapper(typeof(Startup));

            // Configura CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(Configuration["FrontendURL"])
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
