﻿using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.Get, "XName"), OutputType(typeof(XName))]
    public sealed class GetXNameCmdlet : PSCmdlet {
        private string name;
        private XNamespace ns;
        public GetXNameCmdlet() { }
        [Parameter(Mandatory = true, Position = 1)]
        public string Name {
            set {
                name=value;
            }
        }
        [Parameter(ParameterSetName = "Namespace", Position = 2), ValidateNotNull]
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
            WriteObject((ns??XNamespace.None)+name);
        }
    }
}
