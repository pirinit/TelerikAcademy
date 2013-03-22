using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. Define a class that holds information about a mobile phone device:
 * model, manufacturer, price, owner, battery characteristics
 * (model, hours idle and hours talk) and display characteristics (size and number of colors).
 * Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
 * 
 * 2.Define several constructors for the defined classes that take different sets of arguments
 * (the full information for the class or part of it). Assume that model and manufacturer
 * are mandatory (the others are optional). All unknown data fill with null.
 */
class GSM
{
    public static GSM IPhone4S = new GSM("IPhone 4S", "Apple", 1000, "Bai Ivan",
        new Battery("the best apple battery", 80.5, 13.8, BatteryType.LiPol),
        new Display(4.1, 16000000)
        );
    private string model;
    private string manufacturer;
    private decimal? price;
    private string owner;
    private Battery battery;
    private Display display;
    private List<Call> callHistory;

    public GSM(string model, string manufacturer)
        : this(model, manufacturer, null, null, null, null)
    {
    }

    public GSM(string model, string manufacturer, Battery battery, Display display)
        : this(model, manufacturer, null, null, battery, display)
    {
    }

    public GSM(string model, string manufacturer, decimal? price)
        : this(model, manufacturer, price, null, null, null)
    {
    }

    public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.price = price;
        this.owner = owner;
        this.battery = battery;
        this.display = display;
        this.CallHistory = new List<Call>();
    }

    public List<Call> CallHistory
    {
        get
        {
            return this.callHistory;
        }
        private set
        {
            this.callHistory = value;
        }
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

    public string Manufacturer
    {
        get
        {
            return this.manufacturer;
        }
        set
        {
            this.manufacturer = value;
        }
    }

    public decimal? Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Price should have possitive value.");
            }
            this.price = value;
        }
    }

    public string Owner
    {
        get
        {
            return this.owner;
        }
        set
        {
            this.owner = value;
        }
    }

    public Battery Battery
    {
        get
        {
            return this.battery;
        }
        set
        {
            this.battery = value;
        }
    }

    public Display Display
    {
        get
        {
            return this.display;
        }
        set
        {
            this.display = value;
        }
    }

    public void AddCall(Call call)
    {
        this.CallHistory.Add(call);
    }

    public bool DeleteCall(int callIndex)
    {
        if (callIndex < 0 || callIndex > this.CallHistory.Count - 1)
        {
            string exceptionText = String.Format("Call index must be non-negative and less than calls count-1({0}).", this.CallHistory.Count - 1);
            throw new ArgumentOutOfRangeException(exceptionText);
        }
        this.CallHistory.RemoveAt(callIndex);
        return true;
    }

    public void ClearCallHistory()
    {
        this.CallHistory.Clear();
    }

    public decimal CallAllCallsPrice(decimal pricePerMinute)
    {
        decimal callsPrice = 0;
        List<Call> history = this.CallHistory;
        for (int i = 0; i < history.Count; i++)
        {
            callsPrice += history[i].DurationInSeconds * pricePerMinute;
        }
        return callsPrice / 60;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendFormat("Model: {0}", this.Model);
        result.AppendLine();
        result.AppendFormat("Manufacturer: {0}", this.Manufacturer);
        result.AppendLine();
        if (this.Price != null)
        {
            result.AppendFormat("Price: {0}", this.Price);
            result.AppendLine();
        }
        if (this.Owner != null)
        {
            result.AppendFormat("Owner: {0}", this.Owner);
            result.AppendLine();
        }
        if (this.Battery != null)
        {
            result.AppendFormat("Battery info:\n{0}", this.Battery);
            result.AppendLine();
        }
        if (this.Display != null)
        {
            result.AppendFormat("Display info:\n{0}", this.Display);
            result.AppendLine();
        }
        return result.ToString();
    }

}
