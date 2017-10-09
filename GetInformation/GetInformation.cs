using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrinterTest.Infrastructure;
using System.ComponentModel.Composition;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace PrinterTest.SubTests
{
    [Export(typeof(ISubTest))]
    [ExportMetadata("Name", "GetInformation")]
    [Serializable]
    public class GetInformation : ISubTest
    { 
        [Serializable]
        private class Configuration
        {
            public bool HasLan { get; set; }
            public bool HasWlan { get; set; }
        }
        private Configuration con;

        public string Name { get; set; }

        public string ConfigurationString { get; set; } = @"{
'HasLan': 'True',                                                             
'HasWlan': 'True'
}";

        public int Execute(IPrinter printer)
        {
            con = JsonConvert.DeserializeObject<Configuration>(ConfigurationString);
            printer.SN = Interaction.InputBox("Input SN:");
            printer.SKU = Interaction.InputBox("Input SKU:");
            if (con.HasLan)
            {
                printer.LanMac = Interaction.InputBox("Input Lan Mac:");
            }
            else
                printer.LanMac = null;
            if (con.HasWlan)
            {
                printer.WlanMac = Interaction.InputBox("Input Wlan Mac:");
            }
            else
                printer.WlanMac = null;
            return 0;
        }
    }
}
