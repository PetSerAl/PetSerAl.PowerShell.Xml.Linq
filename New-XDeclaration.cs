using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XDeclaration", DefaultParameterSetName = "New"), OutputType(typeof(XDeclaration))]
    public sealed class NewXDeclarationCmdlet : PSCmdlet {
        private string version;
        private string encoding;
        private string standalone;
        private XDeclaration other;
        public NewXDeclarationCmdlet() { }
        [Parameter(ParameterSetName = "New", Position = 1)]
        public string Version {
            set {
                version=value;
            }
        }
        [Parameter(ParameterSetName = "New", Position = 2)]
        public string Encoding {
            set {
                encoding=value;
            }
        }
        [Parameter(ParameterSetName = "New", Position = 3)]
        public string Standalone {
            set {
                standalone=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XDeclaration Other {
            set {
                other=value;
            }
        }
        protected override void BeginProcessing() {
            XDeclaration result;
            switch(ParameterSetName) {
                case "New":
                    result=new XDeclaration(version, encoding, standalone);
                    break;
                case "Copy":
                    result=new XDeclaration(other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
