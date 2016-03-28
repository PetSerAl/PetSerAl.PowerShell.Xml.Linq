using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, nameof(XAttribute), DefaultParameterSetName = ParameterSetNames.New), OutputType(typeof(XAttribute))]
    public sealed class NewXAttributeCmdlet : PSCmdlet {
        public NewXAttributeCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.New, Position = 1)]
        public XName Name { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.New, Position = 2)]
        public object Value { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Copy, Position = 1)]
        public XAttribute Other { private get; set; }
        protected override void BeginProcessing() {
            XAttribute result;
            switch(ParameterSetName) {
                case ParameterSetNames.New:
                    result=new XAttribute(Name, Utility.UnwrapPSObject(Value));
                    break;
                case ParameterSetNames.Copy:
                    result=new XAttribute(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
