using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XText", DefaultParameterSetName = "New"), OutputType(typeof(XText))]
    public sealed class NewXTextCmdlet : PSCmdlet {
        private string value;
        private XText other;
        public NewXTextCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1), AllowEmptyString]
        public string Value {
            set {
                this.value=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XText Other {
            set {
                other=value;
            }
        }
        protected override void BeginProcessing() {
            XText result;
            switch(ParameterSetName) {
                case "New":
                    result=new XText(value);
                    break;
                case "Copy":
                    result=new XText(other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
