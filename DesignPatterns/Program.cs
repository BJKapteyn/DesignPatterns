using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern;
using ObserverPattern;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            SnowfallMeasurement SnowfallInstrument = new SnowfallMeasurement();
            Observer S = new Snowboard();
            Observer CCS = new CrossCountrySkiing();
            Observer IS = new IceSkating();

            SnowfallInstrument.AddObserver(S);
            SnowfallInstrument.AddObserver(CCS);
            SnowfallInstrument.AddObserver(IS);

            Console.ReadKey();

            SnowfallInstrument.SnowFall = 3.245324;

            foreach(Snowsport s in SnowfallInstrument.ObserverList)
            {
                Console.WriteLine(s.ObserverName);
                s.GoOrNoGo();
            }

            Console.ReadKey();
        }
    }
}
