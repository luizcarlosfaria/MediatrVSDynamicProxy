using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

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

            services.AddSingleton<IServico2>(sp => {
                var proxyGen = new ProxyGenerator();
                return proxyGen.CreateInterfaceProxyWithTarget<IServico2>(new Servico2(), new ExceptionLogInterceptor());
            });

            var provider = services.BuildServiceProvider();

            return provider;
        }
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
