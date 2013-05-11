using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Document : IDocument
{
    private string name;
    private string content;

    public Document(string name)
    {
        this.name = name;
    }
        

    public string Name
    {
        get
        {
            return this.name;
        }
    }

    public string Content
    {
        get
        {
            return this.content;
        }
    }

    public virtual void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "name":
                this.name = value;
                break;
            case "content":
                this.content = value;
                break;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.name));
        output.Add(new KeyValuePair<string, object>("content", this.content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(properties);
        var sorted = properties.OrderBy(x => x.Key);
        StringBuilder text = new StringBuilder();
        text.Append(this.GetType().Name);
        text.Append('[');
        if (this is IEncryptable && (this as IEncryptable).IsEncrypted)
        {
            text.Append("encrypted");
        }
        else
        {
            foreach (var prop in sorted)
            {
                if (prop.Value != null)
                {
                    text.AppendFormat("{0}={1};", prop.Key, prop.Value);
                }
            }
            text.Length = text.Length - 1;
        }
        text.Append(']');
        return text.ToString();
    }
}