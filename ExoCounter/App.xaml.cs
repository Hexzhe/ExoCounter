using System.Windows;
using System.Windows.Media;

namespace ExoCounter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var registryValues = RegistryHelper.GetRegistryValues();

            new MainWindow(
                ("Succès", int.Parse(registryValues.Item1), Brushes.Green), 
                ("Échecs", int.Parse(registryValues.Item2), Brushes.DarkRed))
                .Show();
        }
    }
}
