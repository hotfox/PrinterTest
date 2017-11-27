using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.Windows;

namespace PrinterTest.Configuration
{
    public class TestManagerPresenter:DependencyObject
    {
        public TestManager testManager;
        public ObservableCollection<TestPresenter> SubTests { get; }
        public TestManagerPresenter()
        {
            testManager = new TestManager(); 
            SubTests = new ObservableCollection<TestPresenter>();
            foreach(var item in testManager.TestStream.Tests)
            {
                SubTests.Add(new TestPresenter(item));
            }
        }
    }
}
