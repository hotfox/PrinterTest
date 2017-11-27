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
    public class TestPresenter:DependencyObject, INotifyPropertyChanged
    {
        public ITest test;
        public TestPresenter(ITest test)
        {
            this.test = test;
        }
        public string SubTestName
        {
            get
            {
                return test.Name;
            }
        }
        public string ConfigString
        {
            get
            {
                return test.ConfigString;
            }
            set
            {
                bool r = test.SaveConfigString(value);
                if (!r)
                    MessageBox.Show("配置文件格式不正确！");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
