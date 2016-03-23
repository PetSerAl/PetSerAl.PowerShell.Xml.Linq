using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XComment", DefaultParameterSetName = "New"), OutputType(typeof(XComment))]
    public sealed class NewXCommentCmdlet : PSCmdlet {
        public NewXCommentCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1), AllowEmptyString]
        public string Value { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XComment Other { private get; set; }
        protected override void BeginProcessing() {
            XComment result;
            switch(ParameterSetName) {
                case "New":
                    result=new XComment(Value);
                    break;
                case "Copy":
                    result=new XComment(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
