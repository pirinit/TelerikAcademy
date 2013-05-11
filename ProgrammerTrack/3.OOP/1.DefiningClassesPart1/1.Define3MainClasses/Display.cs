using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Define a class that holds information about a mobile phone device:
 * model, manufacturer, price, owner, battery characteristics
 * (model, hours idle and hours talk) and display characteristics (size and number of colors).
 * Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
 */
class Display
{
    private double? sizeInches;
    private int? colors;

    public Display()
        : this(null, null)
    {
    }
    public Display(double? sizeInches, int? colors)
    {
        this.SizeInches = sizeInches;
        this.Colors = colors;
    }

    public double? SizeInches
    {
        get
        {
            return this.sizeInches;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Display size should have possitive value.");
            }
            this.sizeInches = value;
        }
    }

    public int? Colors
    {
        get
        {
            return this.colors;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Display colors count should have possitive value.");
            }
            this.colors = value;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        if (this.Colors != null)
        {
            result.AppendFormat("Colors: {0}", this.Colors);
            result.AppendLine();
        }
        if (this.SizeInches != null)
        {
            result.AppendFormat("Size in inches: {0}", this.SizeInches);
            result.AppendLine();
        }
        if (result.Length == 0)
        {
            result.Append("No info.");
        }
        return result.ToString();
    }
}