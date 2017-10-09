using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterTest.Infrastructure
{
    [Flags]
    public enum PrinterInterface
    {
        RS232=1,
        USB=2,
        LAN=4,
        WLAN=8,
        BT=16,
    }
    public interface IPrinter
    {
        string SKU { get; set; }
        string SN { get; set; }
        string LanMac { get; set; }
        string WlanMac { get; set; }
        //string BTMac { get; set; }
        //bool CheckSN();
        //bool CheckSKU();
        //bool CheckLanMac();
        //bool CheckWlanMac();
        //bool CheckBTMac();
        //PrinterInterface GetSupportedInterface();
        //int SwitchInterface(PrinterInterface pi);
    }
    public interface IPrinterData
    {
        string Type { get; }
    }
}
