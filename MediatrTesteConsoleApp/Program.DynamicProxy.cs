using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Castle.DynamicProxy;
using System.Runtime.CompilerServices;

namespace MediatrTesteConsoleApp
{
    public class ProgramDynamicProxy
    {
        public static void MainExample(string[] args)
        {
            BuildServiceProvider().GetRequiredService<IServico1>().Teste(0);
        }


        private static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<Servico2>();
            services.AddSingleton<Servico1>();

            services.AddSingleton<ProxyGenerator>();

            services.AddSingletonWithProxy<IServico1, Servico1>();
            services.AddSingletonWithProxy<IServico2, Servico2>();

            var provider = services.BuildServiceProvider();

            return provider;
        }
    }
}
