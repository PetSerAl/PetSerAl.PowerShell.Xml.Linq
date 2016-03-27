using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, nameof(XDeclaration), DefaultParameterSetName = "New"), OutputType(typeof(XDeclaration))]
    public sealed class NewXDeclarationCmdlet : PSCmdlet {
        public NewXDeclarationCmdlet() { }
        [Parameter(ParameterSetName = "New", Position = 1)]
        public string Version { private get; set; }
        [Parameter(ParameterSetName = "New", Position = 2)]
        public string Encoding { private get; set; }
        [Parameter(ParameterSetName = "New", Position = 3)]
        public string Standalone { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XDeclaration Other { private get; set; }
        protected override void BeginProcessing() {
            XDeclaration result;
            switch(ParameterSetName) {
                case "New":
                    result=new XDeclaration(Version, Encoding, Standalone);
                    break;
                case "Copy":
                    result=new XDeclaration(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
