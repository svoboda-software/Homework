using Homework.Data.Repositories.DelimiterRepository;
using Homework.Data.Repositories.DelimiterRepository.Implementation;
using Homework.Data.Repositories.FileRepository;
using Homework.Data.Repositories.FileRepository.Implementation;
using Homework.Data.Repositories.RecordRepository;
using Homework.Data.Repositories.RecordRepository.Implementation;
using Homework.Services.DelimiterService;
using Homework.Services.DelimiterService.Implementation;
using Homework.Services.FileService;
using Homework.Services.FileService.Implementation;
using Homework.Services.RecordService;
using Homework.Services.RecordService.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Homework.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddScoped<IDelimiterService, DelimiterService>()
				.AddScoped<IFileService, FileService>()
				.AddScoped<IRecordService, RecordService>()
				.AddScoped<IDelimiterRepository, DelimiterRepository>()
				.AddScoped<IFileRepository, FileRepository>()
				.AddScoped<IRecordRepository, RecordRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Record/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Record}/{action=Index}/{id?}");
			});
		}
	}
}