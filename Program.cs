using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopshelfPreventingStop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = HostFactory.Run(x =>
            {
                x.Service<Service>();

                x.RunAsLocalSystem();

                x.SetDescription("Service displaying conditional shutdown.");
                x.SetDisplayName("KAT Conditional Shutdown");
                x.SetServiceName("KATShutdown");

                x.EnableShutdown();
                x.SetStopTimeout(TimeSpan.FromSeconds(1));
                x.StartAutomaticallyDelayed();
            });

            var exitCode = (int)Convert.ChangeType(service, service.GetTypeCode());  //11
            Environment.ExitCode = exitCode;
        }
    }
}
