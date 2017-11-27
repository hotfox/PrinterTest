using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterTest.Infrastructure
{
    public interface ITest
    {
        int Execute(Context context);
        string Name { get; set; }
        string ConfigString { get; }
        bool SaveConfigString(string config);
        void LoadDefaultConfigString();
    }
    public interface ITestData
    {
        string Name { get; }
    }
}
