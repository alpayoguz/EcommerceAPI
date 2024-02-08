using DependencyInjection.Services;

namespace DependencyInjection.IOC
{
    public class IoC
    {
        public IoC() { 
            IServiceCollection services = new ServiceCollection();
            services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog()));
            services.Add(new ServiceDescriptor(typeof (TestLog), new TestLog()));

            IServiceProvider provider = services.BuildServiceProvider();
            provider.GetService<ConsoleLog>();
        }
    }
}
