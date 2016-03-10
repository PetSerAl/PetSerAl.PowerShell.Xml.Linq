using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XElement", DefaultParameterSetName = "New"), OutputType(typeof(XElement))]
    public sealed class NewXElementCmdlet : PSCmdlet {
        private XName name;
        private object content;
        private string textOrUri;
        private LoadOptions options;
        private XElement other;
        public NewXElementCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1)]
        public XName Name {
            set {
                name=value;
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
        public XElement Other {
            set {
                other=value;
            }
        }
        protected override void BeginProcessing() {
            XElement result;
            switch(ParameterSetName) {
                case "New":
                    result=new XElement(name, Common.UnwrapPSObjects(content));
                    break;
                case "Parse":
                    result=XElement.Parse(textOrUri, options);
                    break;
                case "Load":
                    result=XElement.Load(textOrUri, options);
                    break;
                case "Copy":
                    result=new XElement(other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
