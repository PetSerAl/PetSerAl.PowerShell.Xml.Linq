using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XAttribute", DefaultParameterSetName = "New"), OutputType(typeof(XAttribute))]
    public sealed class NewXAttributeCmdlet : PSCmdlet {
        private XName name;
        private object value;
        private XAttribute other;
        public NewXAttributeCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1)]
        public XName Name {
            set {
                name=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 2)]
        public object Value {
            set {
                this.value=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XAttribute Other {
            set {
                other=value;
            }
        }
        protected override void BeginProcessing() {
            XAttribute result;
            switch(ParameterSetName) {
                case "New":
                    result=new XAttribute(name, Common.UnwrapPSObject(value));
                    break;
                case "Copy":
                    result=new XAttribute(other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
