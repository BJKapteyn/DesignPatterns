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
            //Build us a missile ship.
            MissileShip MS = new MissileShip();

            MS.FireWeapon();
            MS.FlyShip();

            Console.ReadKey();
            //Swap out weapons during runtime.
            MS.weaponType = new InterdimensionalRiftCannon();

            MS.FireWeapon();

            Console.ReadKey();
        }
    }
}
