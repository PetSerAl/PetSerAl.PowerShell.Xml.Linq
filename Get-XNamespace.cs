using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.Get, "XNamespace"), OutputType(typeof(XNamespace))]
    public sealed class GetXNamespaceCmdlet : PSCmdlet {
        private XNamespace ns;
        public GetXNamespaceCmdlet() { }
        [Parameter(ParameterSetName = "Namespace", Position = 1), ValidateNotNull]
        public XNamespace Namespace {
            set {
                ns=value;
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Xml")]
        public SwitchParameter Xml {
            set {
                if(value) {
                    ns=XNamespace.Xml;
                }
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = "Xmlns")]
        public SwitchParameter Xmlns {
            set {
                if(value) {
                    ns=XNamespace.Xmlns;
                }
            }
        }
        protected override void BeginProcessing() {
            WriteObject(ns??XNamespace.None);
        }
    }
}
