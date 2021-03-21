using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ExoCounter
{
    /// <summary>
    /// Interaction logic for LabeledCounter.xaml
    /// </summary>
    public partial class LabeledCounter : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Label { get; set; }
        private int _Value;
        public int Value
        {
            get => _Value;
            set
            {
                _Value = value;
                OnPropertyChanged();
            }
        }

        public LabeledCounter(string name, string label, int value, Brush foregroundColor)
        {
            InitializeComponent();
            
            this.Name = name;
            this.Label = label;
            this.Value = value;
            lblLabel.Foreground = lblCounter.Foreground = foregroundColor;

            BindLabels();
        }

        private void BindLabels()
        {
            Binding labelBinding = new Binding("Label");
            labelBinding.Mode = BindingMode.OneWay;
            lblLabel.SetBinding(ContentProperty, labelBinding);

            Binding valueBinding = new Binding("Value");
            valueBinding.Mode = BindingMode.OneWay;
            valueBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            lblCounter.SetBinding(ContentProperty, valueBinding);

            DataContext = this;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void CounterUp(int incr)
        {
            Value += incr;
        }

        public void CounterDown(int incr)
        {
            Value = Value - incr > 0 
                ? (Value - incr) 
                : 0;
        }

        public void CounterReset()
        {
            Value = 0;
        }
    }
}
