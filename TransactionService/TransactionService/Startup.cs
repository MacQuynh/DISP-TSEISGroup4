using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TransactionService.Clients;
using TransactionService.Data;

namespace TransactionService
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
            services.AddHttpClient<UserCatalogClient>();
            services.AddHttpClient<ShareCatalogClient>();


            services.AddControllers();

            //localDb:
            //services.AddDbContext<TransactionContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("TransactionDbConnection")));

            // using SQLServer to kubenetes
            services.AddDbContext<TransactionContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TransactionSQLServerKubernetesConnection")));
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
