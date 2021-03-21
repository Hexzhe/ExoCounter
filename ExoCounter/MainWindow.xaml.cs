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

namespace ExoCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCounters();
        }

        public MainWindow(params (string, string)[] counterValues)
        {
            InitializeComponent();
            InitializeCounters(counterValues);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveCounters();
        }

        private void SaveCounters()
        {
            List<LabeledCounter> counters = new List<LabeledCounter>();

            foreach (var control in grdMain.Children)
                counters.Add((LabeledCounter)control);

            RegistryHelper.SaveRegistryValues(counters.Select(c => c.Value).ToArray());
        }

        private void InitializeCounters(params (string, string)[] counterValues)
        {
            for (int i = 0; i < counterValues.Length; i++)
            {
                var control = new LabeledCounter($"counter{i}", counterValues[i].Item1, counterValues[i].Item2);
                grdMain.Children.Add(control);
                grdMain.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(control, i);
            }
        }
    }
}
