using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fleeter.Client.Views
{
    /// <summary>
    /// Interaction logic for AppVehiclesControl.xaml
    /// </summary>
    public partial class AppVehiclesControl : UserControl
    {
        public AppVehiclesControl()
        {
            InitializeComponent();
        }

        private static readonly Regex _regex = new Regex("[^0-9.]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }
    }
}
