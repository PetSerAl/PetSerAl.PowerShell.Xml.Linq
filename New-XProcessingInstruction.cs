using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XProcessingInstruction", DefaultParameterSetName = "New"), OutputType(typeof(XProcessingInstruction))]
    public sealed class NewXProcessingInstructionCmdlet : PSCmdlet {
        private string target;
        private string data;
        private XProcessingInstruction other;
        public NewXProcessingInstructionCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1)]
        public string Target {
            set {
                target=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 2), AllowEmptyString]
        public string Data {
            set {
                data=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XProcessingInstruction Other {
            set {
                other=value;
            }
        }
        protected override void BeginProcessing() {
            XProcessingInstruction result;
            switch(ParameterSetName) {
                case "New":
                    result=new XProcessingInstruction(target, data);
                    break;
                case "Copy":
                    result=new XProcessingInstruction(other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
