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

namespace PowerToysUX.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shortcuts : UserControl
    {
        List<Shortcut> ShortcutsList;
        public Shortcuts()
        {
            this.InitializeComponent();


            ShortcutsList = new List<Shortcut>
            {
                new Shortcut() { Character = "A", Title = "Open Action Center" },
                new Shortcut() { Character = "D", Title = "Display & hide the desktop" },
                new Shortcut() { Character = "E", Title = "Open File Explorer" },
                new Shortcut() { Character = "G", Title = "Open Game Bar" },
                new Shortcut() { Character = "H", Title = "Open Dictation Bar" },
                new Shortcut() { Character = "I", Title = "Open Settings" },
                new Shortcut() { Character = "K", Title = "Open the Connect quick action" },
                new Shortcut() { Character = "L", Title = "Lock your PC or switch accounts" },
                new Shortcut() { Character = "M", Title = "Minimize all windows" },
                new Shortcut() { Character = "R", Title = "Open Run dialog box" },
                new Shortcut() { Character = "S", Title = "Open Search" },
                new Shortcut() { Character = "U", Title = "Open Ease of Access Center" },
                new Shortcut() { Character = "X", Title = "Open Quick Link menu" },
                new Shortcut() { Character = ",", Title = "Temporarily peek at the desktop" },
                new Shortcut() { Character = "Ctrl", Title = "Add a virtual desktop" },
                new Shortcut() { Character = "Enter", Title = "Open Narrator" },
                new Shortcut() { Character = "+ / -", Title = "Zoom using magnifier" },
                new Shortcut() { Character = "Ptr Scn", Title = "Capture a snapshot" },
                new Shortcut() { Character = "Tab", Title = "Open Task view" }
            };
            ShortcutsView.ItemsSource = ShortcutsList;
        }
    }

    public class Shortcut
    {
        public string Title { get; set; }
        public string Character { get; set; }
    }
}
