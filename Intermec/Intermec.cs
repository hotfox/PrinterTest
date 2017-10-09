using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrinterTest.Infrastructure;
using System.ComponentModel.Composition;

namespace PrinterTest.Printers
{
    [Export(typeof(IPrinter))]
    [ExportMetadata("Type","Intermec")]
    public class Intermec : IPrinter
    {
        public string LanMac { get; set; }
        public string SKU { get; set; }
        public string SN { get; set; }
        public string WlanMac { get; set; }
    }
}
