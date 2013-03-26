using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MultimediaDocument : BinaryDocument
{
    private long? length;

    public MultimediaDocument(string name)
        : base(name)
    {
    }

    public long? Length
    {
        get
        {
            return this.length;
        }
        set
        {
            this.length = value;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "length":
                this.length = long.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("length", this.length));
        base.SaveAllProperties(output);
    }
}