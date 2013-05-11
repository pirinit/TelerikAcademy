using System;
using System.Text;

class IsoscelesTriangle
{
    static void Main()
    {
        char copyRightSymbol = '\u00A9';
        Console.OutputEncoding = Encoding.Unicode;
        string firstLine = "  " + copyRightSymbol;
        string secondLine = " " + copyRightSymbol + copyRightSymbol + copyRightSymbol;
        string thirdLine = "" + copyRightSymbol + copyRightSymbol + copyRightSymbol + copyRightSymbol + copyRightSymbol;
        Console.WriteLine(firstLine);
        Console.WriteLine(secondLine);
        Console.WriteLine(thirdLine);
    }
}
