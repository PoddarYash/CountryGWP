using CountryGWP.API.Context;
using CountryGWP.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CountryGWP.Test
{
    public class Program
    {
        #region Fields + Properties 
        private static Lazy<IServiceProvider> _serviceProvider = new Lazy<IServiceProvider>(() => InitDependencyInjection());
        protected static IServiceProvider ServiceProvider => _serviceProvider.Value;
        protected static ApplicationDbContext _DbContext => ServiceProvider.GetRequiredService<ApplicationDbContext>();
        protected static IGWPRepository _GWPRepository => ServiceProvider.GetRequiredService<IGWPRepository>();
        #endregion Fields + Properties

        // Private Methods
        private static IServiceProvider InitDependencyInjection()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
            services.AddScoped<IGWPRepository, GWPRepository>();

            return services.BuildServiceProvider();
        }
    }
}
