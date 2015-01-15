using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Foundation.Messaging.AzureServiceBus.Configuration;

namespace TAB.Order.Webjob
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class OrderQueueConfiguration : ConventionServiceBusConfiguration
    {
        public override string ConnectionString
        {
            get
            {
                throw new NotImplementedException();

            }
        }

        public override string ServiceIdentifier
        {
            get { throw new NotImplementedException(); }
        }
    }
}
