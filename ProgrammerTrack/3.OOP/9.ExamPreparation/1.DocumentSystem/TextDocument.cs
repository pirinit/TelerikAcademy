using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TextDocument : Document, IEditable
{
    private string charset;

    public TextDocument(string name)
        : base(name)
    {
        this.charset = charset;
    }

    public string CharSet
    {
        get
        {
            return this.charset;
        }
        set
        {
            this.charset = value;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "charset":
                this.charset = value;
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("charset", this.charset));
        base.SaveAllProperties(output);
    }

    public void ChangeContent(string newContent)
    {
        this.LoadProperty("content",newContent);
    }
}