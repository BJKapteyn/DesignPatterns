using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            MissileShip MS = new MissileShip();

            MS.FireWeapon();
            MS.FlyShip();

            Console.ReadKey();

            MS.weaponType = new InterdimensionalRiftCannon();

            MS.FireWeapon();

            Console.ReadKey();
        }
    }
}
