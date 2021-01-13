using System;
using Castle.DynamicProxy;

namespace MediatrTesteConsoleApp
{
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
