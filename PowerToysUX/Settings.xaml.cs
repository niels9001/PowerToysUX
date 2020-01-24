using PowerToysUX.Views.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PowerToysUX
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();

            NavView.SelectedItem = NavView.MenuItems[0];
        }

        private void NvSample_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {

            switch (((Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem).Tag.ToString())
            {
                case "General": contentFrame.Navigate(typeof(General)); NavView.Header = "General"; break;
                case "FancyZones": contentFrame.Navigate(typeof(PowerRename)); NavView.Header = "FancyZones"; break;
                case "PowerRename": contentFrame.Navigate(typeof(PowerRename)); NavView.Header = "Power Rename"; break;
                case "Shortcuts": contentFrame.Navigate(typeof(Shortcuts)); NavView.Header = "Shortcuts Guide"; break;
                case "PowerLauncher": contentFrame.Navigate(typeof(PowerLauncher)); NavView.Header = "Power Launcher"; break;

            }
        }
    }
}
