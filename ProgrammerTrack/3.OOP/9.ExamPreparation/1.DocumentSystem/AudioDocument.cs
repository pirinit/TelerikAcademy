using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AudioDocument : MultimediaDocument
{
    private long? samplerate;

    public AudioDocument(string name)
        : base(name)
    {
    }

    public long? Samplerate
    {
        get
        {
            return this.samplerate;
        }
        set
        {
            this.samplerate = value;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "samplerate":
                this.samplerate = long.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.samplerate));
        base.SaveAllProperties(output);
    }
}