using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using PrinterTest.Infrastructure;
using System.Windows;

namespace PrinterTest.SubTests
{
    [Export(typeof(ISubTest))]
    [ExportMetadata("Name", "PrintInformation")]
    [Serializable]
    public class PrintInformation : ISubTest
    {
        public string ConfigurationString { get; set; } = "{}";

        public string Name { get; set; }

        public int Execute(IPrinter printer)
        {
            if(printer.SN!=null)
                MessageBox.Show("SN:" + printer.SN);
            if(printer.SKU!=null)
                MessageBox.Show("SKU:" + printer.SKU);
            if(printer.LanMac!=null)
                MessageBox.Show("LanMac:" + printer.LanMac);
            if(printer.WlanMac!=null)
                MessageBox.Show("WlanMac:" + printer.WlanMac);
            return 0;
        }
    }
}
