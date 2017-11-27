using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterTest.Infrastructure
{
    [Serializable]
    public class TestStream
    {
        public IList<ITest> Tests { get; private set; } = new List<ITest>();
        public void AppendTest(ITest test)
        {
            Tests.Add(test);
        }
    }
}
