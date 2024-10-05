using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Screen_Saver_Controller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ObservableObject]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            IsScreenSaverActive = true;
        }

        [ObservableProperty]
        private string _buttonText = "Disable Screen Saver";

        [ObservableProperty]
        private bool _isScreenSaverActive;

        partial void OnIsScreenSaverActiveChanged(bool value)
        {
            if (value)
            {
                PreventScreenSaver.IsActive = true;
                ButtonText = "Screen Saver Disabled";
            }
            else
            {
                PreventScreenSaver.IsActive = false;
                ButtonText = "Disable Screen Saver";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            PreventScreenSaver.IsActive = false;
        }
    }
}