using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XComment", DefaultParameterSetName = "New"), OutputType(typeof(XComment))]
    public sealed class NewXCommentCmdlet : PSCmdlet {
        private string value;
        private XComment other;
        public NewXCommentCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1), AllowEmptyString]
        public string Value {
            set {
                this.value=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XComment Other {
            set {
                other=value;
            }
        }
        protected override void BeginProcessing() {
            XComment result;
            switch(ParameterSetName) {
                case "New":
                    result=new XComment(value);
                    break;
                case "Copy":
                    result=new XComment(other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
