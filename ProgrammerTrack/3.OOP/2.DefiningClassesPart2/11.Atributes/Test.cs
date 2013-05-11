using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Version(1,5)]
class Test
{
    static void Main(string[] args)
    {
        Type type = typeof(Test);
        object[] attributes = type.GetCustomAttributes(false);

        //only one attribute of VersionAttribute type can be applied
        Console.WriteLine("Version is: {0}",((VersionAttribute)attributes[0]).Version);
    }
}