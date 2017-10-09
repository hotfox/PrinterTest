using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterTest.Infrastructure
{
    public interface ISubTest
    {
        int Execute(IPrinter printer);
        string Name { get; set; }
        string ConfigurationString { get; set; }
    }
    public interface ISubTestData
    {
        string Name { get; }
    }
}
