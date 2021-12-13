using API.Configuration;
using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
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
			services.AddDbContext<ApiContext>(opt => opt.UseSqlServer(Configuration. GetConnectionString("STIVE")));
			services.AddControllers().AddNewtonsoftJson(s =>
			{
				s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			});
			//Add Mapper (Dto)
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IInventoryLineRepository, InventoryLineRepository>();
			services.AddScoped <IInventoryRepository, InventoryRepository>();
			services.AddScoped<IItemFamilyRepository, ItemFamilyRepository>();
			services.AddScoped<IItemRepository, ItemRepository>();
			services.AddScoped<IOrderLineRepository, OrderLineRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IPurchaseOrderLineRepository, PurchaseOrderLineRepository>();
			services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
			services.AddScoped<ISupplierRepository, SupplierRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<ApiContext>();
				context.Database.Migrate();
			}

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
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
