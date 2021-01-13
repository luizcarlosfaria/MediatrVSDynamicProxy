using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrTesteConsoleApp
{
    public class ProgramSemMediatr
    {
        public static void MainExample(string[] args)
        {

            var serviceProvider = BuildServiceProvider();

            serviceProvider.GetRequiredService<IServico1>().Teste(12);
        }


        private static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IServico1, Servico1>();
            services.AddSingleton<IServico2, Servico2>();

            var provider = services.BuildServiceProvider();

            return provider;
        }
    }


}
