using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehicleDiary.Logic;
using VehiclesDiary.Controllers;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary
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
            services.AddSingleton(typeof(IRepository<string, DiaryItem>), typeof(InMemoryRepository<string, DiaryItem>));
            services.AddSingleton(typeof(IRepository<string, Car>), typeof(InMemoryRepository<string, Car>));
            services.AddSingleton<IVehiclesService, VehiclesService>();
            services.AddSingleton<IDiaryService, DiaryService>();
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

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
