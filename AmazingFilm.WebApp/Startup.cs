using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.Infrastructure.DataAccess.Repositories;
using AmazingFilm.DomainService.Interfaces;
using AmazingFilm.DomainService;
using AmazingComment.DomainService;
using AmazingFilmRating.DomainService;
using System.Security.Claims;
using System.Threading;

namespace AmazingFilm.WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IFilmGroupRepository, FilmGroupEntityFrameworkRepository>();
            services.AddScoped<IFilmGroupService, FilmGroupService>();

            services.AddScoped<IFilmRepository, FilmEntityFrameworkRepository>();
            services.AddScoped<IFilmService, FilmService>();

            services.AddScoped<ICommentRepository, CommentEntityFrameworkRepository>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IProfileRepository, ProfileEntityFrameworkRepository>();
            services.AddScoped<IProfileService, ProfileService>();


            services.AddScoped<IFilmRatingRepository, FilmRatingEntityFrameworkRepository>();
            services.AddScoped<IFilmRatingService, FilmRatingService>();


            UserAutentication();

        }

        private void UserAutentication()
        {
            Claim claim2 = new Claim(ClaimTypes.Name, "Fabio Rodrigues Fonseca");
            Claim claim3 = new Claim(ClaimTypes.Role, "Administrador");
            Claim claim4 = new Claim(ClaimTypes.Email, "fabison@ig.com.br");
            IList<Claim> Claims = new List<Claim>() {
     claim2,
     claim3,
     claim4
  };

            //Criando uma Identidade e associando-a ao ambiente.
            ClaimsIdentity identity = new ClaimsIdentity(Claims);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;

            //Criando uma Identidade e associando-a ao ambiente.
            ClaimsIdentity identity2 = new ClaimsIdentity(Claims, "Devimedia", ClaimTypes.Email, ClaimTypes.Role);

            ClaimsPrincipal principal2 = new ClaimsPrincipal(identity2);
            Thread.CurrentPrincipal = principal2;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
             

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Films}/{action=Index}/{id?}");
            });
        }
    }
}
