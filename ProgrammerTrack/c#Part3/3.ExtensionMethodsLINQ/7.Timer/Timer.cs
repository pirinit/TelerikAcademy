using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/* 7. Using delegates write a class Timer that has can execute certain method at each t seconds.
*/

public delegate void Del();

class Timer
{
    private int intervalInMiliseconds;
    private int cycles;
    private Del method;

    public Timer(int intervalInMiliseconds, int cycles, Del method)
    {
        this.intervalInMiliseconds = intervalInMiliseconds;
        this.cycles = cycles;
        this.method = method;
    }

    public void Start()
    {
        // straight-forward implementation of task 7
        {
            while (this.cycles > 0)
            {
                this.method();
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
    static void PrintCurrentDay()
    {
        Console.WriteLine(DateTime.Now.DayOfWeek);
    }

    static void PrintCurrentHour()
    {
        Console.WriteLine(DateTime.Now.Hour);
    }

    static void Main()
    {
        //PrintCurrentDay();
        //PrintCurrentHour();

        Del sampleDelegate = new Del(PrintCurrentDay);

        sampleDelegate += PrintCurrentHour;

        Timer timer = new Timer(500, 5, sampleDelegate);
        timer.Start();

        //multi threading test

        Console.WriteLine("\nStarting multi threading test...");
        timer = new Timer(500, 10, PrintCurrentDay);
        Timer otherTimer = new Timer(1000, 5, PrintCurrentHour);

        timer.StartMultiThread();
        otherTimer.StartMultiThread();

        int counter = 20;
        while (counter > 0)
        {
            Console.WriteLine("Main method doing some work... {0}",counter--);
            Thread.Sleep(250);
        }
   }
}