using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProiectMDS.Contexts;
using ProiectMDS.Repositories.ApartmentRepository;
using ProiectMDS.Repositories.CityRepository;
using ProiectMDS.Repositories.FavouriteRepository;
using ProiectMDS.Repositories.OwnerRepository;
using ProiectMDS.Repositories.PropertyRepository;
using ProiectMDS.Repositories.ReservationRepository;
using ProiectMDS.Repositories.UserRepository;

namespace ProiectMDS
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IApartmentRepository, ApartmentRepository>();
            services.AddTransient<IFavouriteRepository, FavouriteRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseMvc();

        }
    }
}