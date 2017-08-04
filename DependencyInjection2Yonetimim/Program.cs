using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DependencyInjection2Yonetimim
{
    public interface IFlightProvider
    {
        void GetFlight(string sehir);
    }

     class PegasusProvider : IFlightProvider
    {
        public void GetFlight(string sehir)
        {
            var result = "18:30 Dubai";
            Console.WriteLine("Uçuş : " + result + " uçuşumuz vardır.");
        }
    }

     class EmiratesProvider : IFlightProvider
    {
        public void GetFlight(string sehir)
        {
            var result = "18:30 Budapest";
            Console.WriteLine("Uçuş : " + result + " uçuşumuz vardır.");
        }
    }

    class UcanAdamFactory
    {
        public IFlightProvider CreateProvider(string providerType)
        {
            IFlightProvider provider = null;
            switch (providerType)
            {
                case "Emirates": provider = new EmiratesProvider();
                    break;
                case "Pegasus": provider = new PegasusProvider();
                    break;
            }

            return provider;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            var providerType = ConfigurationManager.AppSettings["providerType"];
            var factory = new UcanAdamFactory();
            var provider = factory.CreateProvider(providerType);
            provider.GetFlight("istanbul");
            



        }
    }
}
