using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XElement", DefaultParameterSetName = "New"), OutputType(typeof(XElement))]
    public sealed class NewXElementCmdlet : PSCmdlet {
        private string textOrUri;
        public NewXElementCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1)]
        public XName Name { private get; set; }
        [Parameter(ParameterSetName = "New", ValueFromRemainingArguments = true)]
        public object Content { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "Parse")]
        public string Text {
            set {
                textOrUri=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Load")]
        public string Uri {
            set {
                textOrUri=value;
            }
        }
        [Parameter(ParameterSetName = "Parse", Position = 1), Parameter(ParameterSetName = "Load", Position = 1)]
        public LoadOptions Options { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XElement Other { private get; set; }
        protected override void BeginProcessing() {
            XElement result;
            switch(ParameterSetName) {
                case "New":
                    result=new XElement(Name, Utility.UnwrapPSObjects(Content));
                    break;
                case "Parse":
                    result=XElement.Parse(textOrUri, Options);
                    break;
                case "Load":
                    result=XElement.Load(textOrUri, Options);
                    break;
                case "Copy":
                    result=new XElement(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
