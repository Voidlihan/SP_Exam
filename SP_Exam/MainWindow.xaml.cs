using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SP_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool DONE;
        static readonly object LOCK = new object();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Launch(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(Operation);
            t.Start();
            t.Join();
        }        
        private void Operation()
        {
            string path = @"C:\Users\ЕсентайА\source\repos\SP_Exam\SP_Exam\bin\Debug\netcoreapp3.0\iterator.txt";
            lock (LOCK)
            {
                //int[] mas = { 1000 };
                //List<int> list = new List<int> { };
                IteratorWrite iteratorWrite = new IteratorWrite();
                for (int i = 0; i < 1000; i++)
                {
                    if (!DONE)
                    {
                        MessageBox.Show("Все!");
                        DONE = true;
                    }
                    else
                    {
                        ThreadPool.QueueUserWorkItem(iteratorWrite.TextFunc, i.ToString());
                    }
                }
                MessageBox.Show(iteratorWrite.Text);
                using(var streamWriter = new StreamWriter(path))
                {
                    streamWriter.Write(iteratorWrite.Text);
                }
            }
            //return Task.CompletedTask();
        }
    }
}
