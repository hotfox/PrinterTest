using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrinterTest.Infrastructure;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrinterTest.Configuration
{
    public class SubTestPresenter:DependencyObject, INotifyPropertyChanged
    {
        public ISubTest subTest;
        public SubTestPresenter(ISubTest subTest)
        {
            this.subTest = subTest;
        }
        public string SubTestName
        {
            get
            {
                return subTest.Name;
            }
        }
        public string ConfigurationString
        {
            get
            {
                return subTest.ConfigurationString;
            }
            set
            {
                try
                {
                    subTest.ConfigurationString = value;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
