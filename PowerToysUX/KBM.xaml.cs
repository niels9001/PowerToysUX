using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class KBM : Page
    {
        ObservableCollection<RemappedKey> RemappedKeys { get; set; }
        ObservableCollection<RemappedShortcut> RemappedShortcuts { get; set; }
        public KBM()
        {
            this.InitializeComponent();

            RemappedKeys = new ObservableCollection<RemappedKey>();
            RemappedKeys.Add(new RemappedKey() { Original = "A", New = "B" });
            RemappedKeys.Add(new RemappedKey() { Original = "B", New = "C" });
            RemappedKeys.Add(new RemappedKey() { Original = "Shift", New = "Ctrl" });
            RemappedKeys.Add(new RemappedKey() { Original = "Enter", New = "Space" });
            RemappedKeys.Add(new RemappedKey() { Original = "B", New = "Shift" });
            RemappedKeys.Add(new RemappedKey() { Original = "T", New = "H" });

            RemappedShortcuts = new ObservableCollection<RemappedShortcut>();
            RemappedShortcuts.Add(new RemappedShortcut() { Original = new List<string>() { "Ctrl", "Shift", "A" }, New = new List<string>() { "Ctrl", "Alt", "B" } });
            RemappedShortcuts.Add(new RemappedShortcut() { Original = new List<string>() { "Ctrl", "Alt", "Y" }, New = new List<string>() { "Ctrl", "Shift", "X" } });
            RemappedShortcuts.Add(new RemappedShortcut() { Original = new List<string>() { "Ctrl", "Enter", "Y" }, New = new List<string>() { "Ctrl", "F1", "I" } });
        }

        private void SingleFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem mfi = (MenuFlyoutItem)sender;
            var x = mfi.Parent;
           
            var datacontext = mfi.DataContext;
            ListViewItem item = SingleKeysListView.ContainerFromItem(datacontext) as ListViewItem;
            Button button = FindElementInVisualTree<Button>(item);
            button.Content = mfi.Text;
        }

        private void SingleKeyOldMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem mfi = (MenuFlyoutItem)sender;
            SingleOldKeyBtn.Content = mfi.Text;

        }


        private void SingleKeyNewMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem mfi = (MenuFlyoutItem)sender;
            SingleNewKeyBtn.Content = mfi.Text;

        }

        private T FindElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
    {
        var count = VisualTreeHelper.GetChildrenCount(parentElement);
        if (count == 0) return null;

        for (int i = 0; i < count; i++)
        {
            var child = VisualTreeHelper.GetChild(parentElement, i);
            if (child != null && child is T)
                return (T)child;
            else
            {
                var result = FindElementInVisualTree<T>(child);
                if (result != null)
                    return result;
            }
        }
        return null;
    }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            await SingleKeyDialog.ShowAsync();
        }

        private void SingleKeyDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            RemappedKey K = new RemappedKey()
            {
                Original = SingleOldKeyBtn.Content.ToString(),
                New = SingleNewKeyBtn.Content.ToString()

            };

            RemappedKeys.Add(K);
        }

        private async void SingleKeysListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RemappedKey K = (RemappedKey)SingleKeysListView.SelectedItem;
            SingleOldKeyBtn.Content = K.Original;
            SingleNewKeyBtn.Content = K.New;
            await SingleKeyDialog.ShowAsync();
        }

        private async void ShortcutKeysListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RemappedShortcut S = (RemappedShortcut)ShortcutKeysListView.SelectedItem;
            OriginalItemsControl.ItemsSource = S.Original;

            NewItemsControl.ItemsSource = S.New;
            await ShortcutDialog.ShowAsync();
        }

        private void KBM_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (OriginalKeyRadioButton.IsChecked == true)
            {

            }
        }

        private void KBM_KeyDown(object sender, KeyRoutedEventArgs e)
        {
          
        }
    }

    public class RemappedKey
    {
        public string Original { get; set; }
        public string New { get; set; }
    }

    public class RemappedShortcut
    {
        public List<string> Original { get; set; }
        public List<string> New { get; set; }
    }
}
