﻿using System;

namespace StrategyPattern
{
    //The idea behind the strategy pattern is to encapsulate behaviors(usually methods/functions) within a class that
    //are likely to change, together.

    //The strategy pattern revolves around the idea of 'programming to an interface'. This is referring to the general definition of an interface,
    //and not the C# interface. It is designing what your code does, as opposed to how it does it. This is because the how is likely to change
    //over time. It adds flexibility to your code by preventing the need to change code in multiple areas of your codebase to make just one
    //change to a class's behavior. 

    //Lets take an example of a SpaceShip class for a video game or some such:
    //Let's go through each method and see if we can decide if they are likely to be modified in the future. 
    public class SpaceShip
    {
        //These are the properties of our spaceship. For this exercise I'm going to define, but ignore them.
        public string Color { get; set; }
        public string Name { get; set; }
        public string Captain { get; set; } = "Picard";

        //This method is to set the destination of your ship. I don't see a reason to want to change the way I 
        //set it (Commander Riker is the best space First Officer after all).

        //KEEP
        public void SetNavigation(string destination)
        {
            Console.WriteLine($"Set destination to {destination}, make it so number one!");
        }

        //Spaceships fly in space right? Well what if we want to enter the atmosphere of a planet? Flight would be dictated
        //by aerodynamics as apposed to the vaccuum of space. It's flight characteristics will change dramatically.
        //What if we want to add the ability to enter a planet's oceans later? It's safe to say we should pull this one.

        //TAKE
        public void Fly()
        {
            Console.WriteLine("ZOOOOOM!");
        }

        //Sure taking physics into account, missiles are the preferred weapon option in space. What if we want to be able to
        //fire cannons? What if we wanted to fire an interdimensional rift capable of tearing even the largest capital ships
        //in twain? Yeah it's safe to say this one is coming with us as well.

        //TAKE
        public void Fire()
        {
            Console.WriteLine("Fire ze missiles!");
        }
    }
    

    public interface WeaponType
    {
        void Fire();
    }

    public class Missile : WeaponType
    {
        public void Fire()
        {
            Console.WriteLine("Fire ze Missiles!");
        }
    }

    public class InterdimensionalRiftCannon : WeaponType
    {
        public void Fire()
        {
            Console.WriteLine("Charging cannon...dividing 1 by 0...FIR-");
        }
    }

    public interface FlightType
    {
        void Fly();
    }

    public class SpaceFlight : FlightType
    {
        public void Fly()
        {
            Console.WriteLine("Thrust set, RCS engaged");
        }
    }

    public class AtmosphereFlight : FlightType
    {
        public void Fly()
        {
            Console.WriteLine("Thrust set, flight controls unlocked.");
        }
    }

    public class SpaceShipStrategy
    {
        public FlightType flightType;
        public WeaponType weaponType;
    }
}
