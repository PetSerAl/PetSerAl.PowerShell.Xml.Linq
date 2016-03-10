using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XDocument", DefaultParameterSetName = "New"), OutputType(typeof(XDocument))]
    public sealed class NewXDocumentCmdlet : PSCmdlet {
        private XDeclaration declaration;
        private object content;
        private string textOrUri;
        private LoadOptions options;
        private XDocument other;
        public NewXDocumentCmdlet() { }
        [Parameter(ParameterSetName = "New", Position = 1)]
        public XDeclaration Declaration {
            set {
                declaration=value;
            }
        }
        [Parameter(ParameterSetName = "New", ValueFromRemainingArguments = true)]
        public object Content {
            set {
                content=value;
            }
        }
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
        public LoadOptions Options {
            set {
                options=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XDocument Other {
            set {
                other=value;
            }
        }
        protected override void BeginProcessing() {
            XDocument result;
            switch(ParameterSetName) {
                case "New":
                    result=new XDocument(declaration, Common.UnwrapPSObjects(content));
                    break;
                case "Parse":
                    result=XDocument.Parse(textOrUri, options);
                    break;
                case "Load":
                    result=XDocument.Load(textOrUri, options);
                    break;
                case "Copy":
                    result=new XDocument(other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
