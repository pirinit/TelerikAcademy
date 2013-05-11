using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


/* 7. Using delegates write a class Timer that has can execute certain method at each t seconds. 
 * 8. Read in MSDN about the keyword event in C# and how to publish events.
 * Re-implement the above using .NET events and following the best practices.
 */
namespace _8.EventTimer
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    class EventTimer
    {
        private int intervalInMiliseconds;
        private int cycles;
        public event ChangedEventHandler Changed;

        public EventTimer(int intervalInMiliseconds, int cycles)
        {
            this.intervalInMiliseconds = intervalInMiliseconds;
            this.cycles = cycles;
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        public void Start()
        {
            // straight-forward implementation of task 8
            {
                while (this.cycles > 0)
                {
                    OnChanged(EventArgs.Empty);
                    Thread.Sleep(this.intervalInMiliseconds);
                    this.cycles--;
                }
            }
        }

        public void StartMultiThread()
        {
            // using different threads for every timer
            ThreadStart toExecute = Start;
            Thread newThread = new Thread(toExecute);
            newThread.Start();
        }
    }

    class Test
    {
        //some dummy methods to test with
        static void PrintCurrentDay(object sender, EventArgs e)
        {
            Console.WriteLine("First timer's event fired. {0}",DateTime.Now.DayOfWeek);
        }

        static void PrintCurrentHour(object sender, EventArgs e)
        {
            Console.WriteLine("Second timer's event fired. {0}", DateTime.Now.Hour);
        }

        
        static void Main()
        {
            EventTimer timer = new EventTimer(500, 5);
            //adding delegates to be executed
            timer.Changed += PrintCurrentDay;
            //starting the event based timer 
            timer.Start();

            //multi threading test

            Console.WriteLine("\nStarting multi threading test...");

            //preparing two different event timer, which are going to work simultaneously
            timer = new EventTimer(500, 10);
            EventTimer otherTimer = new EventTimer(1000, 5);

            //adding some delegates to be executed
            timer.Changed += PrintCurrentDay;
            otherTimer.Changed += PrintCurrentHour;

            timer.StartMultiThread();
            otherTimer.StartMultiThread();

            //performing other tasks while the timers are running in two other threads
            int counter = 20;
            while (counter > 0)
            {
                Console.WriteLine("Main method doing some work... {0}", counter--);
                Thread.Sleep(250);
            }
        }
    }
}
