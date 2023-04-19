using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Day08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OkBtnOnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder data= new StringBuilder();
            for(int i=0; i<InputsParent.Children.Count; i++)
            {
                TextBox text = (TextBox)InputsParent.Children[i];
                Label label = (Label)LabelsParent.Children[i];
                data.AppendLine($"{label.Content} = {text.Text}");
            }
            var result = MessageBox.Show($"You've Entered:\n{data}", "Personal Information",MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.Cancel)
                foreach (TextBox item in InputsParent.Children)
                    item.Clear();
            else
                MessageBox.Show("Data Saved", "Success!");
        }

        private void CancleBtnOnClick(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }
    }
}
