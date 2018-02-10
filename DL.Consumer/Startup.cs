using System;
using System.Threading;
using System.Threading.Tasks;
using DL.Consumer.Model;
using DL.Consumer.Provider;
using DL.Consumer.Repository;
using DL.RabbitMQ.Core;
using DL.RabbitMQ.Core.Infrastructure;
using DL.RabbitMQ.Domain.Command;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace DL.Consumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private IServiceProvider _serviceProvider;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = Configuration["connectionStrings:schoolDBConnectionString"];
            services.AddDbContext<ConsumerContext>(o => o.UseNpgsql(connectionString));

            ConfigureDependencies(services);
            Thread.Sleep(5000);
            var sp = services.BuildServiceProvider();
            this._serviceProvider = sp;
            var rabbitReceiver = sp.GetService<IRabbitMQReceiver>();
            try
            {
              rabbitReceiver.CreateReceiver<Student>(this.HandleCommand, "docker.test.queue", ExchangeType.Direct, "docker.test.exchange");
            }
            catch (Exception e)
            {
            
            }
        }

        private bool HandleCommand(Student student)
        {
            var dbContext = this._serviceProvider.GetService<ConsumerContext>();
            var studentInfo = new StudentInfo
            {
              Name = student.Name,
              Email = student.Email,
              Age = student.Age
            };
            dbContext.StudentInfos.Add(studentInfo);
            dbContext.SaveChanges();
            return true;
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddSingleton<IRabbitConfigurationProvider, RabbitConfigurationProvider>();
            RabbitDependencies.RegisterDependencies(services);
            services.AddScoped<IStudentInfoRepository, StudentInfoRepository>();  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
