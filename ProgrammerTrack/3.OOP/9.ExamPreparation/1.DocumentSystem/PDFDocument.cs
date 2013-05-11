using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PDFDocument : BinaryDocument, IEncryptable
{
    private long? pages;
    private bool isEncrypted;

    public PDFDocument(string name)
        : base(name)
    {
    }

    public long? Pages
    {
        get
        {
            return this.pages;
        }
        set
        {
            this.pages = value;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "pages":
                this.pages = long.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.pages));
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
}