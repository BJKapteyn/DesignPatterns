using System;

namespace StrategyPattern
{
    //The idea behind the strategy pattern is to encapsulate behaviors(usually methods) within a class together that
    //are likely to change.

    //It prevents the need to change code in multiple areas of your codebase to make just one change to a class. 

    //Lets take an example of a SpaceShip class for a video game or some such:
    //Let's go through each method and see if we can decide if they are likely to be modified in the future. 
    public class SpaceShip
    {
        //These are the properties of our spaceship to set later. For this exercise, I'm going to ignore them.
        public string Color { get; set; }
        public string Name { get; set; }
        public string Captain { get; set; } = "Picard";

        //This method is to set the destination of your ship. I don't see a reason to want to change the way we 
        //set it (Commander Riker is the best space First Officer of all time after all)
        public void SetNavigation(string destination)
        {
            Console.WriteLine($"Set destination to {destination}, make it so number one!");
        }


        public void Fly()
        {
            Console.WriteLine("ZOOOOOM!");
        }

        public void Fire()
        {
            Console.WriteLine("Fire ze missiles!");
        }
    }
    public abstract class SpaceShipStrategy
    {
        public virtual void Fly()
        {

        } 

        public virtual void Fire()
        {

        }
    }
}
