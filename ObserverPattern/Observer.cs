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
            void AddObserver();
            void RemoveObserver();
            void UpdateObservers();
        }

        public interface Observer
        {
            void Update(float snowfall);
        }

        //for the sake of flexability, I'm going to creat an abstract class that implements the Observer interface. This way if I can think of different things
        //(like going to school or driving) that are dependent on snowfall later, I can just inherit from the Observer class rather than build another Observer.
        public abstract class Snowsport : Observer
        {
            public float Snowfall { get; set; }
            //I'll auto initialize to IsAdvisable false, better safe than sorry when it comes to snow.
            public bool IsAdvisable { get; set; } = false;
            public void Update(float snowfall)
            {
                Snowfall = snowfall;
            }
        }
        //Next I'm going to create an instrument 
    }
}
