using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WordDocument : OfficeDocument, IEncryptable, IEditable
{
    private long? chars;
    private bool isEncrypted;

    public WordDocument(string name)
        : base(name)
    {
    }

    public long? Chars
    {
        get
        {
            return this.chars;
        }
        set
        {
            this.chars = value;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "chars":
                this.chars = long.Parse(value); ;
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.chars));
        base.SaveAllProperties(output);
    }

    public bool IsEncrypted
    {
        get { return this.isEncrypted; }
    }

    public void Encrypt()
    {
        this.isEncrypted = true;
    }

    public void Decrypt()
    {
        this.isEncrypted = false;
    }

    public void ChangeContent(string newContent)
    {
        this.LoadProperty("content", newContent);
    }
}