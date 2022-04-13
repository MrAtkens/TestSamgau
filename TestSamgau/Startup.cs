using Microsoft.EntityFrameworkCore;
using TestSamgau.DataAccess;
using TestSamgau.DataAccess.EntityProvider;
using TestSamgau.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace TestSamgau
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            /*          services.AddDbContext<ApplicationContext>(options =>
                       options.UseInMemoryDatabase(Configuration.GetConnectionString("InMemoryDb")));*/
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));

            services.AddScoped<IUserProvider, EntityUserProvider>();
            services.AddScoped<UserService>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.SetIsOriginAllowed(host => true);
                    builder.AllowCredentials();
                });
            });

            services.AddSwaggerGen();
            services.AddControllers();
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseCors("CorsPolicy");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }

    }
}
