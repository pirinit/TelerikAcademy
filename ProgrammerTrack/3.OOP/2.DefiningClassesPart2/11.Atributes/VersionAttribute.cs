using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 8. Create a [Version] attribute that can be applied to structures, classes, 
 * nterfaces, enumerations and methods and holds a version in the format
 * major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.
 */

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface
    | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple= false)]
public class VersionAttribute : System.Attribute
{
    public int Major { get; private set;}
    public int Minor { get; private set; }
    public string Version { get; private set; }

    public VersionAttribute(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
        this.Version = String.Format("{0}.{1}", major, minor);
    }
}