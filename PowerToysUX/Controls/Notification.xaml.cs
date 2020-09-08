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

namespace PowerToysUX.Controls
{
    public sealed partial class MuteNotification : UserControl
    {
        public MuteNotification()
        {
            this.InitializeComponent();
            ShellBarShadow.Receivers.Add(ShadowReceiverGrid);
        }

        private void MicButton_Checked(object sender, RoutedEventArgs e)
        {
            MicText.Text = "Audio on";
            MicIcon.Glyph = "\uE720";

        }

        private void MicButton_Unchecked(object sender, RoutedEventArgs e)
        {
            MicText.Text = "Audio off";
            MicIcon.Glyph = "\uF781";
        }

        private void CameraButton_Checked(object sender, RoutedEventArgs e)
        {
            CameraText.Text = "Camera on";
            CameraIcon.Glyph = "\uE714";
        }

        private void CameraButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CameraText.Text = "Camera off";
            CameraIcon.Glyph = "\uE43C";
        }
    }
}