using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService
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
            services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderConsumer>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq((cfg) =>
                {
                    var uri = new Uri(Configuration["ServiceBus:Uri"]);
                    cfg.Host(uri, host =>
                    {
                        host.Username(Configuration["ServiceBus:Username"]);
                        host.Password(Configuration["ServiceBus:Password"]);
                    });
                   

                    cfg.ReceiveEndpoint(Configuration["ServiceBus:Queue"], c =>
                    {
                        c.PrefetchCount = 20;
                        c.UseMessageRetry(r => r.Interval(2, 100));
                        c.ConfigureConsumer<OrderConsumer>(provider);
                    });
                }));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
