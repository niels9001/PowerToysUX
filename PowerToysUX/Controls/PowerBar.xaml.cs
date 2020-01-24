//using Microsoft.Toolkit.Uwp.UI.Controls;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PowerToysUX.Controls
{
    public sealed partial class PowerBar : UserControl
    {
        public PowerBar()
        {
            this.InitializeComponent();
            ShellBarShadow.Receivers.Add(ShadowReceiverGrid);

        }

        public event EventHandler ToolSelected;

        private void OnToolSelected(string ToolName)
        {
            ToolSelected?.Invoke(this, new PropertyChangedEventArgs(ToolName));
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            OnToolSelected("Settings");
        }

        private void Shortcuts_Click(object sender, RoutedEventArgs e)
        {
            OnToolSelected("Shortcuts");
        }

        private async void ColorPicker_Click(Microsoft.UI.Xaml.Controls.SplitButton sender, Microsoft.UI.Xaml.Controls.SplitButtonClickEventArgs args)
        {
            var eyedropper = new Eyedropper();
            eyedropper.ColorChanged += Eyedropper_ColorChanged;
            var color = await eyedropper.Open();
           

        }

        private void Eyedropper_ColorChanged(Eyedropper sender, EyedropperColorChangedEventArgs args)
        {
            ColorPicker.BorderThickness = new Thickness(0, 0, 0, 2);
            ColorPicker.BorderBrush = new SolidColorBrush(args.NewColor);
        }

        private void PowerLauncher_Click(object sender, RoutedEventArgs e)
        {
            OnToolSelected("PowerLauncher");
        }
    }
}