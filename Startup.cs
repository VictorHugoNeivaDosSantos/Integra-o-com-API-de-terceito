using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication5.Cliente;
using WebApplication5.Cliente.Interface;
using WebApplication5.Context;
using WebApplication5.DTO;
using WebApplication5.Repositories.RepositoryPessoa;
using WebApplication5.Services.PessoaServices;
using WebApplication5.Services.PessoaServices.Interface;
using WebApplication5.ServicesPessoa;
using WebApplication5.ServicesPessoa.Interface;

namespace WebApplication5
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
            services.AddHttpClient<viaCEP>("viacep");
            services.AddTransient<IviaCEP, viaCEP>();
            services.AddTransient<IServicePessoa, ServicePessoa>();
            services.AddTransient<IRepositoryEndereco, RepositoryEndereco>();
            services.AddTransient<IReposPessoa, ReposPessoa>();
            services.AddDbContext<PessoaContext>((options) => options.UseNpgsql(Configuration.GetConnectionString("DBase")));
            services.AddSwaggerGen();
            var mapConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperDto2Entity()));
            services.AddSingleton(mapConfig.CreateMapper());

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

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
