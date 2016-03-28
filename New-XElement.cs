using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, nameof(XElement), DefaultParameterSetName = ParameterSetNames.New), OutputType(typeof(XElement))]
    public sealed class NewXElementCmdlet : PSCmdlet {
        public NewXElementCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.New, Position = 1)]
        public XName Name { private get; set; }
        [Parameter(ParameterSetName = ParameterSetNames.New, ValueFromRemainingArguments = true)]
        public object Content { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Parse)]
        public string Text { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Load)]
        public string Uri { private get; set; }
        [Parameter(ParameterSetName = ParameterSetNames.Parse, Position = 1), Parameter(ParameterSetName = ParameterSetNames.Load, Position = 1)]
        public LoadOptions Options { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Copy, Position = 1)]
        public XElement Other { private get; set; }
        protected override void BeginProcessing() {
            XElement result;
            switch(ParameterSetName) {
                case ParameterSetNames.New:
                    result=new XElement(Name, Utility.UnwrapPSObjects(Content));
                    break;
                case ParameterSetNames.Parse:
                    result=XElement.Parse(Text, Options);
                    break;
                case ParameterSetNames.Load:
                    result=XElement.Load(Uri, Options);
                    break;
                case ParameterSetNames.Copy:
                    result=new XElement(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
