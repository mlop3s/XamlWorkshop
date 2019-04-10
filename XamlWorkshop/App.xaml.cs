using System.Globalization;
using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace XamlWorkshop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("pt-BR");
            DispatcherHelper.Initialize();
        }
    }
}
