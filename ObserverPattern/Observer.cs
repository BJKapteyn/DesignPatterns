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
            void Update(float snowfall);
        }

        //for the sake of flexability, I'm going to create an abstract class that implements the Observer interface, rather than including the snowsport's methods
        //directly in the observer class. This way if I can think of different things that are dependent on snowfall later, (like going to school or driving) I can 
        //just inherit from the Observer class.
        public abstract class Snowsport : Observer
        {
            public float Snowfall { get; set; }
            //I'll auto initialize IsAdvisable to false, better safe than sorry when it comes to snow.
            public bool IsAdvisable { get; set; } = false;
            public void Update(float snowfall)
            {
                Snowfall = snowfall;
            }
        }
        //Next I'm going to create an instrument class as our Subject

        public class SnowfallMeasurement : Subject
        {
            //let's set a little bit of logic for setting the snowfall.
            public float SnowFall
            {
                get
                {
                    return this.SnowFall;
                }
                set
                {
                    this.SnowFall = value;
                    //Here we go, every time we set a value for snowfall, all of the ovservers will be updated automatically. Noice.
                    UpdateObservers();
                }
            }
            //our list of observers to be interated through to update.
            public List<Observer> ObserverList;
            public void AddObserver(Observer o)
            {
                ObserverList.Add(o);
            }
            public void RemoveObserver(Observer o)
            {
                ObserverList.Remove(o);
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
