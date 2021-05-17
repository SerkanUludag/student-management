using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddSingleton<ITeacherService, TeacherManager>();
            services.AddSingleton<IStudentService, StudentManager>();
            services.AddSingleton<ICourseService, CourseManager>();
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IContextService, ContextManager>();
            services.AddSingleton<IAttendanceService, AttendanceManager>();

            services.AddSingleton<ITeacherDal, EfTeacherDal>();
            services.AddSingleton<IStudentDal, EfStudentDal>();
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<ICourseDal, EfCourseDal>();
            services.AddSingleton<IContextDal, EfContextDal>();
            services.AddSingleton<IAttendanceDal, EfAttendanceDal>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

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
