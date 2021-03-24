
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dynamo.Services.Interfaces;
using Dynamo.Services.Services;
using Dynamo.Core.Repositories;
using Dynamo.Core.Interfaces;
using Dynamo.Core.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Dynamo.Services.Profiles;
using Newtonsoft.Json;

namespace Dynamo
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

            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddResponseCaching();
            services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DynamoProfiles>())));
            services.AddDbContext<DynamoDbContext>(opts =>
             opts.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));          
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<IContactsService, ContactsService>();
            services.AddScoped<IContactsRepository, ContactsRepository>();
            services.AddScoped<IDynamoDbContext, DynamoDbContext>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyCorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/ErrorDev");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseHttpsRedirection();

            app.UseResponseCaching();
            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAnyCorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
