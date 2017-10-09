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
    [Serializable]
    public class SubTestManager
    {
        [ImportMany]
        [NonSerialized]
        IEnumerable<Lazy<ISubTest,ISubTestData>> subtests;
        public ICollection<ISubTest> SubTests { get; }
        public SubTestManager()
        {
            SubTests = new List<ISubTest>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "SubTests";
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
                        SubTests.Add(pair.Value);
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
