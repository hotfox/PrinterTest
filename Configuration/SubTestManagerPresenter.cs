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
    public class SubTestManagerPresenter:DependencyObject
    {
        public SubTestManager subTestManager;
        public ObservableCollection<SubTestPresenter> SubTests { get; }
        public SubTestManagerPresenter()
        {
            subTestManager = new SubTestManager(); 
            SubTests = new ObservableCollection<SubTestPresenter>();
            foreach(var item in subTestManager.SubTests)
            {
                SubTests.Add(new SubTestPresenter(item));
            }
        }
    }
}
