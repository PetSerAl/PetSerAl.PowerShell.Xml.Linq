using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XDocument", DefaultParameterSetName = "New"), OutputType(typeof(XDocument))]
    public sealed class NewXDocumentCmdlet : PSCmdlet {
        private string textOrUri;
        public NewXDocumentCmdlet() { }
        [Parameter(ParameterSetName = "New", Position = 1)]
        public XDeclaration Declaration { private get; set; }
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
        public XDocument Other { private get; set; }
        protected override void BeginProcessing() {
            XDocument result;
            switch(ParameterSetName) {
                case "New":
                    result=new XDocument(Declaration, Utility.UnwrapPSObjects(Content));
                    break;
                case "Parse":
                    result=XDocument.Parse(textOrUri, Options);
                    break;
                case "Load":
                    result=XDocument.Load(textOrUri, Options);
                    break;
                case "Copy":
                    result=new XDocument(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
