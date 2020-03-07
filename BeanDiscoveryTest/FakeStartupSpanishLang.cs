using BeanDiscovery;
using BeanDiscoveryTest.BeanAttribute.Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeanDiscoveryTest
{
    public class FakeStartupSpanishLang
    {
        public FakeStartupSpanishLang(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.UseBeanDiscovery(options =>
            {
                options.IgnoreBean<Spanish2LangBean>();
                options.UseBeanName<ILangBean>("Spanish");
            });
            services.BuildServiceProvider();
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
