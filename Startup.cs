using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.DI;
using Microsoft.AspNetCore.Http;

namespace ECDC.MIS.API
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
            //Seb : for authentication from Angular to WebService
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", p => p
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });

            //Needed for Web API to avoid circulare serialization
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            //Needed to get current user connected
            //Needed to get current user connected
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ILookupRepository, LookupRepository>();
            services.AddTransient<LookupRepository>();
            services.AddTransient<ILookupUser, LookupUser>();
            services.AddTransient<LookupUser>();
            services.AddTransient<ILookupExpense, LookupExpense>();
            services.AddTransient<LookupExpense>();

            services.AddDbContextPool<MISContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            
        }
    }
}
