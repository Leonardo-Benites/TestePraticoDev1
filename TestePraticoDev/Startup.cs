using TestePraticoDev.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using TestePraticoDev.Models;
using TestePraticoDev.ViewModels;
using TestePraticoDev.AutoMapper.Profiles;
using TestePraticoDev.Services;
using TestePraticoDev.Services.Interfaces;

namespace TestePraticoDev
{
    public class Startup
    {
        readonly string _home = "index";
        readonly string _controller = "Pedido";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(sqlConnection));

            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(MappingProfile)); // Adiciona o perfil do AutoMapper

            services.AddTransient<IPedidoService, PedidoService>();

            services.AddControllers();
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddMvc(x => x.EnableEndpointRouting = false);
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
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=" + _controller + "}/{action=" + _home + "}/{id?}");
            });

            var configuration = new MapperConfiguration(mapper =>
            {
                mapper.CreateMap<Pedido, PedidoViewModel>().ReverseMap();

                mapper.AddProfile<MappingProfile>();
            });

        }
    }
}
