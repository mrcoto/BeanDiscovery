using BeanDiscovery;
using BeanDiscoveryTest.BeanAttribute.Factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeanDiscoveryTest
{
    public class FakeStartupEnglishLang
    {
        public FakeStartupEnglishLang(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.UseBeanDiscovery(options =>
            {
                options.IgnoreBean<Spanish2LangBean>();
                options.UseBeanName<ILangBean>("English");
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
