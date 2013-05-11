using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OfficeDocument : BinaryDocument
{
    private string version;

    public OfficeDocument(string name)
        : base(name)
    {
    }
    public string Version
    {
        get
        {
            return this.version;
        }
        set
        {
            this.version = value;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "version":
                this.version = value;
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("version", this.version));
        base.SaveAllProperties(output);
    }
}

