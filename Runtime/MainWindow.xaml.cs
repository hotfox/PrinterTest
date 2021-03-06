﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using PrinterTest.Infrastructure;

namespace PrinterTest.Runtime
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Test Files|*.test";
            if(dialog.ShowDialog()==true)
            {
                TestStream ts;
                using (var s = File.OpenRead(dialog.FileName))
                {
                    var bf = new BinaryFormatter();
                    ts = bf.Deserialize(s) as TestStream;
                }
                Context context = new Context();
                foreach(ITest test in ts.Tests)
                {
                    test.Execute(context);
                }
            }
        }
    }
}
