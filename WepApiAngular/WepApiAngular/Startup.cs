using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WepApiAngular.DBOperations;
using WepApiAngular.Middlewares;
using FluentValidation;
using System.Reflection;
using WepApiAngular.Services;

namespace WepApiAngular
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
            // Add services to the container.

            services.AddControllers()
                .AddNewtonsoftJson(); // httppatch için eklendi
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
           
            // dbcontentext servicelere eklendi ve inmemory oluşturuldu
            services.AddDbContext<AngularDbContext>(Options => Options.UseInMemoryDatabase(databaseName:"AngularDb"));
            services.AddScoped<IAngularDbContext>(provider => provider.GetService<AngularDbContext>());
            // autoMapper Dto için eklendi
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<ILoggerService, ConsoleLogger>();
            //services.AddSingleton<ILoggerService, DBLogger>(); // depedency İnjection yapılarak bagımlılıklar azaltılır.
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            //middlewaare
            app.UseCustomExceptionMiddleware();

            app.UseEndpoints(x => { x.MapControllers(); });
        }
    }
}
