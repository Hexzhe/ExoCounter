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
    /// Interaction logic for LabeledCounter.xaml
    /// </summary>
    public partial class LabeledCounter : UserControl
    {
        public string Label { get; set; }
        public string Value { get; set; }

        public LabeledCounter(string name, string label, string value)
        {
            InitializeComponent();
            
            this.Name = name;
            this.Label = label;
            this.Value = value;

            BindLabels();
        }

        private void BindLabels()
        {
            Binding labelBinding = new Binding("Label");
            labelBinding.Mode = BindingMode.OneWay;
            lblLabel.SetBinding(ContentProperty, labelBinding);

            Binding valueBinding = new Binding("Value");
            valueBinding.Mode = BindingMode.OneWay;
            lblCounter.SetBinding(ContentProperty, valueBinding);

            DataContext = this;
        }
    }
}
