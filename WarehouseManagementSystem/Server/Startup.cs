using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using WarehouseManagementSystem.Server.Data;
using WarehouseManagementSystem.Server.Hubs;

namespace WarehouseManagementSystem.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("mypolicy", builder => {
                    builder.WithOrigins("http://192.168.1.120:85", "http://localhost:54594", "http://localhost:50527")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddSignalR();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddResponseCompression(option =>
            {
                option.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[]{ "application/octet-stream"
                });
            });
            services.AddDbContext<AppDBContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("default"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();

            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseCors("mypolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<ProjectHub>("/ProjectHub");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
