using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 7. Write a class GSMTest to test the GSM class:
 * Create an array of few instances of the GSM class.
 * Display the information about the GSMs in the array.
 * Display the information about the static property IPhone4S.
 */
class GSMTest
{
    public static void Test()
    {
        GSM[] gsms = new GSM[5];
        gsms[0] = new GSM("IPhone 4S", "Apple", 1000, "Bai Ivan",
        new Battery("the best apple battery", 80.5, 13.8, BatteryType.LiPol),
        new Display(4.1, 16000000)
        );

        gsms[1] = new GSM("IPhone 4S", "Apple", 1000, "Bai Ivan",
        new Battery("the best apple battery", 80.5, 13.8, BatteryType.LiPol),
        new Display(4.1, 16000000)
        );

        gsms[2] = new GSM("IPhone 4S", "Apple", 1000, "Bai Ivan",
        new Battery("the best apple battery", 80.5, 13.8, BatteryType.LiPol),
        new Display(4.1, 16000000)
        );

        gsms[3] = new GSM("rock solid", "nokia");

        gsms[4] = new GSM("One", "HTC", new Battery(), new Display());

        foreach (var gsm in gsms)
        {
            Console.WriteLine(gsm);
        }
    }
}