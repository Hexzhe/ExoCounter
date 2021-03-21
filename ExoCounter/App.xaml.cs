using System.Windows;

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

            new MainWindow(("Succès", registryValues.Item1), ("Échecs", registryValues.Item2)).Show();
        }
    }
}
