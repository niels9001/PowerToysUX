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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace App4.Controls
{
    public sealed partial class Systray : UserControl
    {
        public Systray()
        {
            this.InitializeComponent();
        }


        private void CameraMuteToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            CameraMuteToggleBtn.Content = "Camera on";
            CameraMuteToggleBtn.Tag = "\uE714";

        }

        private void CameraMuteToggleBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            CameraMuteToggleBtn.Content = "Camera off";
            CameraMuteToggleBtn.Tag = "\uE43C";
        }

        private void MicrophoneMuteToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            MicrophoneMuteToggleBtn.Content = "Microphone on";
            MicrophoneMuteToggleBtn.Tag = "\uE720";
        }

        private void MicrophoneMuteToggleBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            MicrophoneMuteToggleBtn.Content = "Microphone off";
            MicrophoneMuteToggleBtn.Tag = "\uF781";
        }
    }
}
