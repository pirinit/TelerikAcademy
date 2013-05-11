using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
 * Create an instance of the GSM class.
 * Add few calls.
 * Display the information about the calls.
 * Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
 * Remove the longest call from the history and calculate the total price again.
 * Finally clear the call history and print it.
 */
class GSMCallHistoryTest
{
    public static void Test()
    {
        GSM gsm = new GSM("IPhone 4S", "Apple", 1000, "Bai Ivan",
        new Battery("the best apple battery", 80.5, 13.8, BatteryType.LiPol),
        new Display(4.1, 16000000)
        );

        gsm.AddCall(new Call(DateTime.Now, "+35902123456", 166));
        gsm.AddCall(new Call(DateTime.Now.AddHours(15), "+35902123456", 400));
        gsm.AddCall(new Call(DateTime.Now.AddMinutes(66), "+3590245456", 401));

        //problem with encapsulation!
        //List<Call> test = gsm.CallHistory;

        //test.Add(new Call(DateTime.Now, "433455", 56));

        PrintCallHistory(gsm);

        Console.WriteLine("Total value of calls: {0:f2}.",gsm.CallAllCallsPrice(0.37m));

        DeleteLongestCall(gsm);

        Console.WriteLine("Total value of calls: {0:f2}.", gsm.CallAllCallsPrice(0.37m));

        gsm.ClearCallHistory();

        PrintCallHistory(gsm);
    }
  
    private static void DeleteLongestCall(GSM gsm)
    {
        int longestCallIndex = 0;
        uint longestCal = 0;

        for (int i = 0; i < gsm.CallHistory.Count; i++)
        {
            if (gsm.CallHistory[i].DurationInSeconds > longestCal)
            {
                longestCal = gsm.CallHistory[i].DurationInSeconds;
                longestCallIndex = i;
            }
        }

        gsm.DeleteCall(longestCallIndex);
    }
  
    private static void PrintCallHistory(GSM gsm)
    {
        foreach (Call call in gsm.CallHistory)
        {
            Console.WriteLine(call);
        }
    }
}