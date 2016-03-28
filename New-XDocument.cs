using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, nameof(XDocument), DefaultParameterSetName = ParameterSetNames.New), OutputType(typeof(XDocument))]
    public sealed class NewXDocumentCmdlet : PSCmdlet {
        public NewXDocumentCmdlet() { }
        [Parameter(ParameterSetName = ParameterSetNames.New, Position = 1)]
        public XDeclaration Declaration { private get; set; }
        [Parameter(ParameterSetName = ParameterSetNames.New, ValueFromRemainingArguments = true)]
        public object Content { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Parse)]
        public string Text { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Load)]
        public string Uri { private get; set; }
        [Parameter(ParameterSetName = ParameterSetNames.Parse, Position = 1), Parameter(ParameterSetName = ParameterSetNames.Load, Position = 1)]
        public LoadOptions Options { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.Copy, Position = 1)]
        public XDocument Other { private get; set; }
        protected override void BeginProcessing() {
            XDocument result;
            switch(ParameterSetName) {
                case ParameterSetNames.New:
                    result=new XDocument(Declaration, Utility.UnwrapPSObjects(Content));
                    break;
                case ParameterSetNames.Parse:
                    result=XDocument.Parse(Text, Options);
                    break;
                case ParameterSetNames.Load:
                    result=XDocument.Load(Uri, Options);
                    break;
                case ParameterSetNames.Copy:
                    result=new XDocument(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
