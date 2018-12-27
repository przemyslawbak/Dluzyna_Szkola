using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DluzynaSzkola2.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DluzynaSzkola2
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //database context
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:DluzynaSzkolaApp:ConnectionString"]));
            //repositories
            services.AddTransient<IAktualnosciRepository, EFAktualnosciRepository>();
            services.AddTransient<IHistoriaRepository, EFHistoriaRepository>();
            services.AddTransient<IDokumentyRepository, EFDokumentyRepository>();
            services.AddTransient<IRadaRodzicowRepository, EFRadaRodzicowRepository>();
            services.AddTransient<IPodrecznikiRepository, EFPodrecznikiRepository>();
            services.AddTransient<IWyprawkaRepository, EFWyprawkaRepository>();
            services.AddTransient<IRekrutacjaRepository, EFRekrutacjaRepository>();
            services.AddTransient<ISamorzadRepository, EFSamorzadRepository>();
            services.AddTransient<IZajeciaDodatkoweRepository, EFZajeciaDodatkoweRepository>();
            services.AddTransient<IPlanRepository, EFPlanRepository>();
            services.AddTransient<IAutobusRepository, EFAutobusRepository>();
            services.AddTransient<IKonkursyRepository, EFKonkursyRepository>();
            services.AddTransient<ISportRepository, EFSportRepository>();
            services.AddTransient<IBibliotekaRepository, EFBibliotekaRepository>();
            services.AddTransient<IGronoPedagogiczneRepository, EFGronoPedagogiczneRepository>();
            services.AddTransient<ISukcesyRepository, EFSukcesyRepository>();
            services.AddTransient<IWydarzeniaRepository, EFWydarzeniaRepository>();
            services.AddTransient<ISolectwoRepository, EFSolectwoRepository>();
            services.AddTransient<IApplicationDisplay, EFApplicationDisplay>();
            services.AddTransient<IKontaktRepository, EFKontaktRepository>();
            services.AddTransient<IZmianaPlanuRepository, EFZmianaPlanuRepository>();
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:DluzynaSzkolaIdentity:ConnectionString"]));
            services.AddIdentity<AppUser, IdentityRole>(opts => {
                //password requirements options
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>()
            //generates tokens for passwords
            .AddDefaultTokenProviders();
            services.Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromSeconds(10));
            services.AddAuthentication()
            .Services.ConfigureApplicationCookie(options =>
                {
                    //delay logoff when processed
                    options.SlidingExpiration = true;
                    //logoff after 30min
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });
            services.AddMvc(config =>
            {
                config.Filters.Add<CommonViewBagInitializerActionFilter>();
            });
            services.AddScoped<CommonViewBagInitializerActionFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //authentication when routing
            app.UseAuthentication();
            //exceptions and error page
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}
            //for wwwroot
            app.UseStaticFiles();
            //routing options
            app.UseMvc(routes => {
                routes.MapRoute(name: "Error", template: "Error",
                defaults: new { controller = "Error", action = "Error" });
                routes.MapRoute(
                name: "default", template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Aktualnosci", action = "Index" });
            });
        }
    }
}
