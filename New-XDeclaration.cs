using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, nameof(XDeclaration), DefaultParameterSetName = ParameterSetNames.New), OutputType(typeof(XDeclaration))]
    public sealed class NewXDeclarationCmdlet : PSCmdlet {
        public NewXDeclarationCmdlet() { }
        [Parameter(ParameterSetName = ParameterSetNames.New, Position = 1)]
        public string Version { private get; set; }
        [Parameter(ParameterSetName = ParameterSetNames.New, Position = 2)]
        public string Encoding { private get; set; }
        [Parameter(ParameterSetName = ParameterSetNames.New, Position = 3)]
        public string Standalone { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Copy, Position = 1)]
        public XDeclaration Other { private get; set; }
        protected override void BeginProcessing() {
            XDeclaration result;
            switch(ParameterSetName) {
                case ParameterSetNames.New:
                    result=new XDeclaration(Version, Encoding, Standalone);
                    break;
                case ParameterSetNames.Copy:
                    result=new XDeclaration(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
