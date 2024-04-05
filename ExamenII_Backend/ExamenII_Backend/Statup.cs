using ExamenII_Backend.Database;
using ExamenII_Backend.Services;
using ExamenII_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            services.AddControllers();

            // Add DbContext estos son los pasos cuando cambie de pestaña
            services.AddDbContext<TodoListDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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

            app.UseEndpoints(Endpoint =>
            {
                Endpoint.MapControllers();
            });
        }
    }
}
