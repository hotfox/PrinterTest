using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrinterTest.Infrastructure;
using System.IO;
using System.ComponentModel.Composition.Hosting;

namespace PrinterTest.Configuration
{
    public class TestManager
    {
        [ImportMany]
        IEnumerable<Lazy<ITest,ITestData>> subtests;
        public TestStream TestStream { get; private set; } = new TestStream();
        public TestManager()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Tests";
            if(Directory.Exists(path))
            {
                AggregateCatalog catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new DirectoryCatalog(path));
                CompositionContainer container = new CompositionContainer(catalog);
                try
                {
                    container.ComposeParts(this);
                    foreach(var pair in subtests)
                    {
                        pair.Value.Name = pair.Metadata.Name;
                        TestStream.AppendTest(pair.Value);
                    }
                }
                catch(CompositionException ce)
                {
                    Console.WriteLine(ce.ToString());
                }
            }
        }
    }
}
