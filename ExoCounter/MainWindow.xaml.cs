using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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

        public MainWindow(params (string, int, Brush)[] counterValues)
        {
            InitializeComponent();
            InitializeCounters(counterValues);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveCounters();

            //Hotkey stuff
            _source.RemoveHook(HwndHook);
            _source = null;
            UnregisterHotKey();
        }

        private void SaveCounters()
        {
            List<LabeledCounter> counters = new List<LabeledCounter>();

            foreach (var control in grdMain.Children)
                counters.Add((LabeledCounter)control);

            RegistryHelper.SaveRegistryValues(counters.Select(c => c.Value.ToString()).ToArray());
        }

        private void InitializeCounters(params (string, int, Brush)[] counterValues)
        {
            for (int i = 0; i < counterValues.Length; i++)
            {
                var control = new LabeledCounter($"counter{i}", counterValues[i].Item1, counterValues[i].Item2, counterValues[i].Item3);
                grdMain.Children.Add(control);
                grdMain.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(control, i);
                RegisterName(control.Name, control);
            }
        }

        #region Hotkey

        [DllImport("User32.dll")]
        private static extern bool RegisterHotKey(
            [In] IntPtr hWnd,
            [In] int id,
            [In] uint fsModifiers,
            [In] uint vk);

        [DllImport("User32.dll")]
        private static extern bool UnregisterHotKey(
            [In] IntPtr hWnd,
            [In] int id);

        private HwndSource _source;
        private const int HOTKEY_ID_0 = 694200;
        private const int HOTKEY_ID_1 = 694201;
        private const int HOTKEY_ID_2 = 694202;
        private const int HOTKEY_ID_3 = 694203;
        private const int HOTKEY_ID_4 = 694204;
        private const int HOTKEY_ID_5 = 694205;
        private const int HOTKEY_ID_6 = 694206;
        private const int HOTKEY_ID_7 = 694207;
        private const int HOTKEY_ID_8 = 694208;
        private const int HOTKEY_ID_9 = 694209;

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var helper = new WindowInteropHelper(this);
            _source = HwndSource.FromHwnd(helper.Handle);
            _source.AddHook(HwndHook);
            RegisterHotKey();
        }

        private void RegisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            const uint VK_UP = 0x26, VK_DOWN = 0x28, VK_LEFT = 0x25, VK_RIGHT = 0x27, VK_BCKSPC = 0x08;
            const uint MOD_CTRL = 0x02, MOD_SHIFT = 0x04;

            if (   !RegisterHotKey(helper.Handle, HOTKEY_ID_0, MOD_SHIFT, VK_UP)
                || !RegisterHotKey(helper.Handle, HOTKEY_ID_1, MOD_SHIFT, VK_DOWN)
                || !RegisterHotKey(helper.Handle, HOTKEY_ID_2, MOD_SHIFT, VK_LEFT)
                || !RegisterHotKey(helper.Handle, HOTKEY_ID_3, MOD_SHIFT, VK_RIGHT)
                || !RegisterHotKey(helper.Handle, HOTKEY_ID_4, MOD_SHIFT, VK_BCKSPC)
                || !RegisterHotKey(helper.Handle, HOTKEY_ID_5, MOD_CTRL, VK_UP)
                || !RegisterHotKey(helper.Handle, HOTKEY_ID_6, MOD_CTRL, VK_DOWN)
                || !RegisterHotKey(helper.Handle, HOTKEY_ID_7, MOD_CTRL, VK_LEFT)
                || !RegisterHotKey(helper.Handle, HOTKEY_ID_8, MOD_CTRL, VK_RIGHT)
                || !RegisterHotKey(helper.Handle, HOTKEY_ID_9, MOD_CTRL, VK_BCKSPC))
            {
                // handle error
            }
        }

        private void UnregisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_0);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_1);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_2);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_3);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_4);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_5);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_6);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_7);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_8);
            UnregisterHotKey(helper.Handle, HOTKEY_ID_9);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID_0:
                            OnHotKey0Pressed();
                            handled = true;
                            break;
                        case HOTKEY_ID_1:
                            OnHotKey1Pressed();
                            handled = true;
                            break;
                        case HOTKEY_ID_2:
                            OnHotKey2Pressed();
                            handled = true;
                            break;
                        case HOTKEY_ID_3:
                            OnHotKey3Pressed();
                            handled = true;
                            break;
                        case HOTKEY_ID_4:
                            OnHotKey4Pressed();
                            handled = true;
                            break;
                        case HOTKEY_ID_5:
                            OnHotKey5Pressed();
                            handled = true;
                            break;
                        case HOTKEY_ID_6:
                            OnHotKey6Pressed();
                            handled = true;
                            break;
                        case HOTKEY_ID_7:
                            OnHotKey7Pressed();
                            handled = true;
                            break;
                        case HOTKEY_ID_8:
                            OnHotKey8Pressed();
                            handled = true;
                            break;
                        case HOTKEY_ID_9:
                            OnHotKey9Pressed();
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        private void OnHotKey0Pressed()
            => ((LabeledCounter)grdMain.FindName("counter0")).CounterUp(1);

        private void OnHotKey1Pressed()
            => ((LabeledCounter)grdMain.FindName("counter0")).CounterDown(1);

        private void OnHotKey2Pressed()
            => ((LabeledCounter)grdMain.FindName("counter0")).CounterDown(5);

        private void OnHotKey3Pressed()
            => ((LabeledCounter)grdMain.FindName("counter0")).CounterUp(5);

        private void OnHotKey4Pressed()
            => ((LabeledCounter)grdMain.FindName("counter0")).CounterReset();

        private void OnHotKey5Pressed()
            => ((LabeledCounter)grdMain.FindName("counter1")).CounterUp(1);

        private void OnHotKey6Pressed()
            => ((LabeledCounter)grdMain.FindName("counter1")).CounterDown(1);

        private void OnHotKey7Pressed()
            => ((LabeledCounter)grdMain.FindName("counter1")).CounterDown(5);

        private void OnHotKey8Pressed()
            => ((LabeledCounter)grdMain.FindName("counter1")).CounterUp(5);

        private void OnHotKey9Pressed()
            => ((LabeledCounter)grdMain.FindName("counter1")).CounterReset();

        #endregion
    }
}
