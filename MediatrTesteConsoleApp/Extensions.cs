using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace MediatrTesteConsoleApp
{
    public static class Extensions
    {
        public static IServiceCollection AddSingletonWithProxy<IInterface, TImpl>(this IServiceCollection services)
        where IInterface : class
        where TImpl : IInterface
        =>
            services.AddSingleton(sp =>
                sp.GetRequiredService<ProxyGenerator>()
                .CreateInterfaceProxyWithTarget<IInterface>(sp.GetRequiredService<TImpl>(), new ExceptionLogInterceptor())
            );

    }
}
