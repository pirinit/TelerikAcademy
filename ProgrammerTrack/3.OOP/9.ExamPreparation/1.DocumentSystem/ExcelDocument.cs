using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExcelDocument : OfficeDocument, IEncryptable
{
    private long? rows;
    private long? cols;
    private bool isEncrypted;

    public ExcelDocument(string name)
        : base(name)
    {
    }

    public long? Rows
    {
        get
        {
            return this.rows;
        }
        set
        {
            this.rows = value;
        }
    }

    public long? Cols
    {
        get
        {
            return this.cols;
        }
        set
        {
            this.cols = value;
        }
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "rows":
                this.rows = long.Parse(value); ;
                break;
            case "cols":
                this.cols = long.Parse(value); ;
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("rows", this.rows));
        output.Add(new KeyValuePair<string, object>("cols", this.cols));
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