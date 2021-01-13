using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace MediatrTesteConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProgramMediatr.MainExample(args);
            //ProgramSemMediatr.MainExample(args);
            ProgramDynamicProxy.MainExample(args);
        }
    }
}
