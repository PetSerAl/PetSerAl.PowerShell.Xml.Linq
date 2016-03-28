using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, nameof(XText), DefaultParameterSetName = ParameterSetNames.New), OutputType(typeof(XText))]
    public sealed class NewXTextCmdlet : PSCmdlet {
        public NewXTextCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.New, Position = 1), AllowEmptyString]
        public string Value { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Copy, Position = 1)]
        public XText Other { private get; set; }
        protected override void BeginProcessing() {
            XText result;
            switch(ParameterSetName) {
                case ParameterSetNames.New:
                    result=new XText(Value);
                    break;
                case ParameterSetNames.Copy:
                    result=new XText(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
