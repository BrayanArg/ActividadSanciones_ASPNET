
namespace ActividadSanciones_ASPNET
{
    using ActividadSanciones_ASPNET.DAL.Entities.DBContext;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Reflection;
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
            //AddSwagger(services);
            services.AddControllers();
            services.AddDbContext<multasDbContext>(
            options=> options.UseSqlServer("name=ConnectionStrings:myConection"));
            services.AddMvc().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }

        private void AddSwagger(IServiceCollection services)
        {
            throw new NotImplementedException();
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
