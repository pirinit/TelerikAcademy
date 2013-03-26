using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BinaryDocument : Document
{
    private long? size;

    public BinaryDocument(string name)
        : base(name)
    {
        this.size = size;
    }

    public long? Size
    {
        get
        {
            return this.size;
        }
        set
        {
            this.size = value;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "size":
                this.size = long.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("size", this.size));
        base.SaveAllProperties(output);
    }
}
