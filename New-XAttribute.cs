using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, nameof(XAttribute), DefaultParameterSetName = "New"), OutputType(typeof(XAttribute))]
    public sealed class NewXAttributeCmdlet : PSCmdlet {
        public NewXAttributeCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1)]
        public XName Name { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 2)]
        public object Value { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XAttribute Other { private get; set; }
        protected override void BeginProcessing() {
            XAttribute result;
            switch(ParameterSetName) {
                case "New":
                    result=new XAttribute(Name, Utility.UnwrapPSObject(Value));
                    break;
                case "Copy":
                    result=new XAttribute(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
