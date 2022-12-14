using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyWebApiApp
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
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyDB"));
                //options.UseLazyLoadingProxies(true);
            });
         
            //services.AddDbContext<MyDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("MyDB")).UseLazyLoadingProxies());

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            //Moi Tao
            services.AddScoped<IDmDonviRepository, DmDonviRepository>();
            services.AddScoped<IDmChucvuRepository, DmChucvuRepository>();
            services.AddScoped<IDmCapbacRepository, DmCapbacRepository>();
            services.AddScoped<ICanboRepository, CanboRepository>();
            services.AddScoped<IDmRoleRepository, DmRoleRepository>();
            services.AddScoped<IDmThongbaoRepository, DmThongbaoRepository>();
            services.AddScoped<IDangkykenhRepository, DangkykenhRepository>();
            services.AddScoped<IDmAppRepository, DmAppRepository>();
            services.AddScoped<IDmUngdungRepository, DmUngdungRepository>();
            services.AddScoped<IDangkykenh_DuyetRepository, Dangkykenh_DuyetRepository>();
            services.AddScoped<ISoquanlykenhRepository, SoquanlykenhRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IDmBlackWordRepository, DmBlackWordRepository>();
            services.AddScoped<IThongsohethongRepository, ThongsohethongRepository>();
            services.AddScoped<IDanhsachnguoidungRepository, DanhsachnguoidungRepository>();
            services.Configure<AppSetting>(Configuration.GetSection("AppSettings"));
            services.Configure<SMSService>(Configuration.GetSection("SMSServices"));
            services.Configure<Datadiodeconfig>(Configuration.GetSection("DatadiodeConfig"));
            var secretKey = Configuration["AppSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //tự cấp token
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    //ký vào token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                    ClockSkew = TimeSpan.Zero
                };
            });
            //moi them
            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebApiApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApiApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
