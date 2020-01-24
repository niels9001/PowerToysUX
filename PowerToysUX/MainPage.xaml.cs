using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PowerToysUX
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.SetTitleBar(Tiitlebar);
            //ShellBarShadow.Receivers.Add(ShadowReceiverGrid);
        }

        private async void LaunchSettings()
        {
            await OpenPageAsWindowAsync(typeof(Settings));
        }

        private void LaunchPowerLauncher()
        {
            OverlayGrid.Visibility = Visibility.Visible;
            PowerLauncher.Visibility = Visibility.Visible;
            Shortcuts.Visibility = Visibility.Collapsed;
            HidePowerBar();
            PowerLauncher.Focus(FocusState.Programmatic);
        }

        private void LaunchShortcuts()
        {
            OverlayGrid.Visibility = Visibility.Visible;
            Shortcuts.Visibility = Visibility.Visible;
            PowerLauncher.Visibility = Visibility.Collapsed;
            ShowPowerBar();
        }

        private void OverlayGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            OverlayGrid.Visibility = Visibility.Collapsed;
            PowerLauncher.Visibility = Visibility.Collapsed;
            HidePowerBar();
            Shortcuts.Visibility = Visibility.Collapsed;
        }

        private void ShortcutsMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            LaunchShortcuts();
        }

        private void PowerLauncherMenuItem_Click(object sender, RoutedEventArgs e)
        {
            LaunchPowerLauncher();
        }

        private void SettingsMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            LaunchSettings();
        }

        private async Task<bool> OpenPageAsWindowAsync(Type t)
        {
            CoreApplicationView view = CoreApplication.CreateNewView();
            int id = 0;

            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(t, null);
                Window.Current.Content = frame;
                Window.Current.Activate();
                view.TitleBar.ExtendViewIntoTitleBar = true;



                ApplicationView appView = ApplicationView.GetForCurrentView();

                appView.TitleBar.BackgroundColor = Colors.Transparent;

                appView.TitleBar.ButtonBackgroundColor = Colors.Transparent;
                appView.TitleBar.ButtonForegroundColor = Colors.Black;
                //appView.TitleBar.ButtonForegroundColor = ((SolidColorBrush)Application.Current.Resources["PrimaryTextColor"]).Color;
                appView.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
                appView.TitleBar.InactiveBackgroundColor = Colors.Transparent;
                appView.TitleBar.ForegroundColor = Colors.Black;


                id = ApplicationView.GetForCurrentView().Id;
            });

            return await ApplicationViewSwitcher.TryShowAsStandaloneAsync(id);
        }

        private void ShowPowerBar()
        {
            PowerBar.Margin = new Thickness(0, 24, 0, 0);
        }

        private void HidePowerBar()
        {
            PowerBar.Margin = new Thickness(0, 0, 0, 0);
        }

        private void PowerBar_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ShowPowerBar();
        }

        private void PowerBar_ToolSelected(object sender, EventArgs e)
        {
            switch (((PropertyChangedEventArgs)e).PropertyName)
            {
                case "Settings": LaunchSettings(); break;
                case "PowerLauncher": LaunchPowerLauncher(); break;
                case "Shortcuts": LaunchShortcuts(); break;
            }
        }


    }
}
