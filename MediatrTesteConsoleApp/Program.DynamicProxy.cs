using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using System.Runtime.CompilerServices;

namespace MediatrTesteConsoleApp
{
    public class ProgramDynamicProxy
    {
        public static void MainExample(string[] args)
        {

            var serviceProvider = BuildServiceProvider();

            serviceProvider.GetRequiredService<IServico1>().Teste(0);
        }


        private static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IServico1, Servico1>();

            services.AddSingleton<Servico2>();

            services.AddSingleton<ProxyGenerator>();

            services.AddSingletonWithProxy<IServico2, Servico2>();

            var provider = services.BuildServiceProvider();

            return provider;
        }
    }

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


    public class ExceptionLogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.ToString());
                throw;
            }
        }
    }
}
