using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class VideoDocument : MultimediaDocument
{
    private long? framerate;

    public VideoDocument(string name)
        : base(name)
    {
    }
    public long? Framerate
    {
        get
        {
            return this.framerate;
        }
        set
        {
            this.framerate = value;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "framerate":
                this.framerate = long.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("framerate", this.framerate));
        base.SaveAllProperties(output);
    }
}