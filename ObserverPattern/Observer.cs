using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    class ObserverPat
    {
        //The Observer Pattern defines a one-to-many dependency between objects so that when one object changes state, all of its dependents are
        //notified and updated automatically. When the state of the 'subject' object changes, any object that is observing('observer') it will be notified and can then 
        //update, execute etc. These relationships are loosly coupled, or operate with little dependency on each other. This helps allow the object's continued use
        //with relative independence, and increases flexability.

        //Let's see here, I can imagine a bunch of snow sports that depend on snow in various depths. I'm going to create a snowfall instrument class as the Subject
        //and various snow activities that are observers. Each one will have a boolean property that decides if you should do that sport. It will be dependent on the 
        //snowfall and update each time a new snowfall is reported.

        //I'll start by creating a subject and observer interface.
        public interface Subject
        {
            void AddObserver(Observer o);
            void RemoveObserver(Observer o);
            void UpdateObservers();
        }

        public interface Observer
        {
            string ObserverName { get; set; }
            void Update(double snowfall);
        }

        //for the sake of flexability, I'm going to create an abstract class that implements the Observer interface, rather than including the snowsport's methods
        //directly in the observer class. This way if I can think of different things that are dependent on snowfall later, (like going to school or driving) I can 
        //just inherit from the Observer class, and therefore the subject interface.
        public abstract class Snowsport : Observer
        {
            public string ObserverName { get; set; }
            //I'm going to make snowfall abstract because I want IsAdvisable to change depending on what the snowfall is set as. You'll see how this works in a second.
            public abstract double Snowfall { get; set; }
            //This boolean property will tell us whether or not we should do this sport based on the snowfall. I'll auto-initialize it to false, better safe than sorry
            //when it comes to snow.
            public bool IsAdvisable { get; set; } = false;
            public void Update(double snowfall)
            {
                Snowfall = snowfall;
            }
            //This method will be used to log to the console what we should do depending on how much snow we get.
            public abstract void GoOrNoGo();
        }
        //I'm now going to build my first snowsport that will observe snowfall.
        public class Snowboard : Snowsport
        {
            public Snowboard()
            {
                ObserverName = "Snowboarding";
            }
            public override double Snowfall
            {
                get
                {
                    return this.Snowfall;
                }
                set
                {
                    Snowfall = value;
                    //Here I can set our IsAdvisable property logic. If it snows more than 2 inches, we're going snowboarding.
                    if(Snowfall > 2.0)
                    {
                        this.IsAdvisable = true;
                    }
                    else
                    {
                        IsAdvisable = false;
                    }
                }
            }
            public override void GoOrNoGo()
            {
                if(IsAdvisable)
                {
                    Console.WriteLine("Let's shred!");
                }
                else
                {
                    Console.WriteLine("Not enough snow");
                }
            }
        }
        //I'll do a couple more so we can have a few observers.
        public class IceSkating : Snowsport
        {
            //I don't think this sport will change anytime soon.
            public IceSkating()
            {
                ObserverName = "Ice skating";
            }
            public override double Snowfall
            {
                get
                {
                    return Snowfall;
                }
                set
                {
                    Snowfall = value;
                    
                    if (Snowfall > 1.0)
                    {
                        IsAdvisable = false;
                    }
                    else
                    {
                        IsAdvisable = true;
                    }
                }
            }
            public override void GoOrNoGo()
            {
                if (IsAdvisable)
                {
                    Console.WriteLine("It's a good day for a triple sow-cow");
                }
                else
                {
                    Console.WriteLine("It snowed too much, wait until the snow is cleared");
                }
            }
        }

        public class CrossCountrySkiing : Snowsport
        {
            //I don't think this sport will change anytime soon.
            public CrossCountrySkiing()
            {
                ObserverName = "Cross Country Skiing";
            }
            public override double Snowfall
            {
                get
                {
                    return Snowfall;
                }
                set
                {
                    Snowfall = value;

                    if (Snowfall > 8.0)
                    {
                        IsAdvisable = false;
                    }
                    else
                    {
                        IsAdvisable = true;
                    }
                }
            }
            public override void GoOrNoGo()
            {
                if (IsAdvisable)
                {
                    Console.WriteLine("Let's excercise!");
                }
                else
                {
                    Console.WriteLine("It snowed too much, better wait for the trail groomers");
                }
            }
        }

        //Next I'm going to create a measurement class as our Subject

        public class SnowfallMeasurement : Subject
        {
            //let's set a little bit of logic for setting the snowfall.
            public double SnowFall
            {
                get
                {
                    return this.SnowFall;
                }
                set
                {
                    this.SnowFall = (Math.Round(value, 2));
                    Console.WriteLine($"It has snowed {SnowFall}");
                    //Here we go, every time we set a value for snowfall, all of the ovservers will be updated automatically. Noice.
                    UpdateObservers();
                }
            } 
            //our list of observers to be interated through to update.
            public List<Observer> ObserverList;
            public void AddObserver(Observer o)
            {
                ObserverList.Add(o);
                Console.WriteLine($"{o.ObserverName} has started observing snow-fall");
            }
            public void RemoveObserver(Observer o)
            {
                ObserverList.Remove(o);
                Console.WriteLine($"{o.ObserverName} has stopped observing snow-fall");
            }
            //run through all of our observers and update them.
            public void UpdateObservers()
            {
                foreach(Observer o in ObserverList)
                {
                    o.Update(this.SnowFall);
                }
            }
        }
    }
}
