using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ProyectoADIS
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(item => item.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddControllersWithViews();
            services.AddDbContext<AplicationDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddEndpointsApiExplorer();


            

        }

    }
}
