using System;
using System.Management.Automation;
using System.Xml.Linq;
namespace PetSerAl.PowerShell.Xml.Linq {
    [Cmdlet(VerbsCommon.New, "XCData", DefaultParameterSetName = "New"), OutputType(typeof(XCData))]
    public sealed class NewXCDataCmdlet : PSCmdlet {
        public NewXCDataCmdlet() { }
        [Parameter(Mandatory = true, ParameterSetName = "New", Position = 1), AllowEmptyString]
        public string Value { private get; set; }
        [Parameter(Mandatory = true, ParameterSetName = "Copy", Position = 1)]
        public XCData Other { private get; set; }
        protected override void BeginProcessing() {
            XCData result;
            switch(ParameterSetName) {
                case "New":
                    result=new XCData(Value);
                    break;
                case "Copy":
                    result=new XCData(Other);
                    break;
                default:
                    throw new Exception("Invalid ParameterSetName.");
            }
            WriteObject(result);
        }
    }
}
