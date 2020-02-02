//using Microsoft.Toolkit.Uwp.UI.Controls;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PowerToysUX.Controls
{
    public sealed partial class PowerBar : UserControl
    {
        ObservableCollection<PowerColor> Colors { get; set; }
        public PowerBar()
        {
            this.InitializeComponent();
            ShellBarShadow.Receivers.Add(ShadowReceiverGrid);
            Colors = new ObservableCollection<PowerColor>();
            ColorList.ItemsSource = Colors;
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
            eyedropper.PickCompleted += Eyedropper_PickCompleted;   
            var color = await eyedropper.Open();


        }

        private void Eyedropper_PickCompleted(Eyedropper sender, EventArgs args)
        {
         

                 ColorPicker.BorderThickness = new Thickness(0, 0, 0, 2);
            ColorPicker.BorderBrush = new SolidColorBrush(sender.Color);
            Colors.Add(new PowerColor() { Brush = new SolidColorBrush(sender.Color), Hex = ToHex(sender.Color), Hsl = ToHSL(sender.Color), Hsv = ToHSV(sender.Color), RGB = ToRGB(sender.Color) });

            Colors.Reverse();
        }

        private void Eyedropper_ColorChanged(Eyedropper sender, EyedropperColorChangedEventArgs args)
        {
           
        }

        private void PowerLauncher_Click(object sender, RoutedEventArgs e)
        {
            OnToolSelected("PowerLauncher");
        }

        private string ToRGB(Color SelectedColor)
        {
            return String.Format("{0}, {1}, {2}", SelectedColor.R, SelectedColor.G, SelectedColor.B);
        }

        private string ToHex(Color SelectedColor)
        {
            return Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToHex(SelectedColor);
        }

        private string ToHSV(Color SelectedColor)
        {
            HsvColor Hsv = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToHsv(SelectedColor);
            return String.Format("{0}°, {1}%, {2}%", Hsv.H, Hsv.S, Hsv.V);
        }

        private string ToHSL(Color SelectedColor)
        {
            HslColor Hsl = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToHsl(SelectedColor);
            return String.Format("{0}°, {1}%, {2}%", Hsl.H, Hsl.S, Hsl.L);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox SelectedTextbox = sender as TextBox;
            SelectedTextbox.SelectAll();
        }
    }

    public class PowerColor
    {
        public SolidColorBrush Brush { get; set; }
        public string RGB { get; set; }
        public string Hex { get; set; }
        public string Hsv { get; set; }
        public string Hsl { get; set; }
    }
}