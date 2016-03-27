﻿using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.Get, nameof(XNamespace)), OutputType(typeof(XNamespace))]
    public sealed class GetXNamespaceCmdlet : PSCmdlet {
        public GetXNamespaceCmdlet() { }
        [Parameter(ParameterSetName = nameof(Namespace), Position = 1), ValidateNotNull]
        public XNamespace Namespace { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = nameof(Xml))]
        public SwitchParameter Xml {
            set {
                if(value) {
                    Namespace=XNamespace.Xml;
                }
            }
        }
        [Parameter(Mandatory = true, ParameterSetName = nameof(Xmlns))]
        public SwitchParameter Xmlns {
            set {
                if(value) {
                    Namespace=XNamespace.Xmlns;
                }
            }
        }
        protected override void BeginProcessing() {
            WriteObject(Namespace??XNamespace.None);
        }
    }
}
