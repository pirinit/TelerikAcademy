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
class Battery
{
    private string model;
    private double? idleHours;
    private double? talkHours;
    private BatteryType batteryType; // task 3

    public Battery()
        : this(null, null, null, 0)
    {
    }
    public Battery(string model, double? idleHours, double? talkHours, BatteryType batteryType)
    {
        this.model = model;
        this.idleHours = idleHours;
        this.talkHours = talkHours;
        this.batteryType = batteryType;
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            this.model = value;
        }
    }

    public double? IdleHours
    {
        get
        {
            return this.idleHours;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Idle hours should have possitive value.");
            }
            this.idleHours = value;
        }
    }

    public double? TalkHours
    {
        get
        {
            return this.talkHours;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Talk hours should have possitive value.");
            }
            this.talkHours = value;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        if (this.Model != null)
        {
            result.AppendFormat("Model: {0}", this.Model);
            result.AppendLine();
        }
        if (this.IdleHours != null)
        {
            result.AppendFormat("Idle hours: {0}", this.IdleHours);
            result.AppendLine();
        }
        if (this.TalkHours != null)
        {
            result.AppendFormat("Talk hours: {0}", this.TalkHours);
            result.AppendLine();

        }
        if (this.batteryType != BatteryType.Default)
        {
            result.AppendFormat("Battery type: {0}", this.batteryType);
            result.AppendLine();
        }
        if (result.Length == 0)
        {
            result.Append("No info.");
        }
        return result.ToString();
    }
}