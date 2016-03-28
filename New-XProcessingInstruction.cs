using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, nameof(XProcessingInstruction), DefaultParameterSetName = ParameterSetNames.New), OutputType(typeof(XProcessingInstruction))]
    public sealed class NewXProcessingInstructionCmdlet : PSCmdlet {
        public NewXProcessingInstructionCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.New, Position = 1)]
        public string Target { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.New, Position = 2), AllowEmptyString]
        public string Data { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Copy, Position = 1)]
        public XProcessingInstruction Other { private get; set; }
        protected override void BeginProcessing() {
            XProcessingInstruction result;
            switch(ParameterSetName) {
                case ParameterSetNames.New:
                    result=new XProcessingInstruction(Target, Data);
                    break;
                case ParameterSetNames.Copy:
                    result=new XProcessingInstruction(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
