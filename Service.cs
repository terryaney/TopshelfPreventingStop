using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopshelfPreventingStop
{
    internal class Service : ServiceControl
    {
        int shutdownRequests;

        public bool Start(HostControl hostControl)
        {
            // Nothing to do here...
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            shutdownRequests++;

            return shutdownRequests >= 3;
        }
    }
}
