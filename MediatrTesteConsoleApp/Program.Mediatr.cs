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
    public class ProgramMediatr
    {
        public static void MainExample(string[] args)
        {

            var mediator = BuildMediator();

            var response = mediator.Send(new Ping());
        }


        private static IMediator BuildMediator()
        {
            var services = new ServiceCollection();

            //services.AddSingleton<TextWriter>(writer);

            services.AddMediatR(typeof(Ping));

            services.AddScoped(typeof(IPipelineBehavior<Ping, string>), typeof(GenericPipelineBehavior));
            //services.AddScoped(typeof(IRequestPreProcessor<>), typeof(GenericRequestPreProcessor<>));
            //services.AddScoped(typeof(IRequestPostProcessor<,>), typeof(GenericRequestPostProcessor<,>));

            var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<IMediator>();
        }


    }

    public class Ping : IRequest<string> { }

    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }

    public class GenericPipelineBehavior : IPipelineBehavior<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken, RequestHandlerDelegate<string> next)
        {
            return next();
        }
    }

}
