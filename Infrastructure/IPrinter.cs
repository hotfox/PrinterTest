using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterTest.Infrastructure
{
    public interface IPrinter
    {
        string SendCommand(string command);
    }
    public interface IPrinterData
    {
        string Type { get; }
    }
}
