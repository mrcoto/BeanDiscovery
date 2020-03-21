using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscoveryTest.BeanAttribute.Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MrCoto.BeanDiscoveryTest
{
    public class FakeStartup
    {
        public FakeStartup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.UseBeanDiscovery(options =>
            {
                options.IgnoreBean<Spanish2LangBean>();
            });
            services.BuildServiceProvider();
            ServiceDescriptors.Generate(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

        }

    }
}
