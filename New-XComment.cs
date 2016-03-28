using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, nameof(XComment), DefaultParameterSetName = ParameterSetNames.New), OutputType(typeof(XComment))]
    public sealed class NewXCommentCmdlet : PSCmdlet {
        public NewXCommentCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.New, Position = 1), AllowEmptyString]
        public string Value { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Copy, Position = 1)]
        public XComment Other { private get; set; }
        protected override void BeginProcessing() {
            XComment result;
            switch(ParameterSetName) {
                case ParameterSetNames.New:
                    result=new XComment(Value);
                    break;
                case ParameterSetNames.Copy:
                    result=new XComment(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
