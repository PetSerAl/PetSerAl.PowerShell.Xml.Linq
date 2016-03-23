using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.Get, "XName"), OutputType(typeof(XName))]
    public sealed class GetXNameCmdlet : PSCmdlet {
        public GetXNameCmdlet() { }
        [Parameter(Mandatory = true, Position = 1)]
        public string Name { private get; set; }
        [Parameter(ParameterSetName = "Namespace", Position = 2), ValidateNotNull]
        public XNamespace Namespace { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "Xml")]
        public SwitchParameter Xml {
            set {
                if(value) {
                    Namespace=XNamespace.Xml;
                }
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Xmlns")]
        public SwitchParameter Xmlns {
            set {
                if(value) {
                    Namespace=XNamespace.Xmlns;
                }
            }
        }
        protected override void BeginProcessing() {
            WriteObject((Namespace??XNamespace.None)+Name);
        }
    }
}
