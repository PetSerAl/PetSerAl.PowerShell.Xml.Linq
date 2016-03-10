using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XCData", DefaultParameterSetName = "New"), OutputType(typeof(XCData))]
    public sealed class NewXCDataCmdlet : PSCmdlet {
        private string value;
        private XCData other;
        public NewXCDataCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1), AllowEmptyString]
        public string Value {
            set {
                this.value=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XCData Other {
            set {
                other=value;
            }
        }
        protected override void BeginProcessing() {
            XCData result;
            switch(ParameterSetName) {
                case "New":
                    result=new XCData(value);
                    break;
                case "Copy":
                    result=new XCData(other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
