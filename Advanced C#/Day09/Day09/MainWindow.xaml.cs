using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
using System.Data;
using Microsoft.Data.SqlClient;
using static Day09.DBHandler;

namespace Day09
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            SqlCommand SQLCmd = new();
        public MainWindow()
        {
            InitializeComponent();
            SQLCmd.Connection = DBH;
            SQLCmd.CommandText = "Select * from Products";
            SQLCmd.CommandType = CommandType.Text;
        }
        public void test()
        {
            DBH.Open();
            ConnectionState x = DBH.State;
        }

        private void btn_Execute(object sender, RoutedEventArgs e)
        {
            if (DBH.State == ConnectionState.Closed)
                DBH.Open();
            SqlDataReader SReader= SQLCmd.ExecuteReader();
            while (SReader.Read())
            {
                ListBoxItem Li = new();
                Li.Content = SReader.GetString("ProductName");
                Li.Padding = new Thickness(5);
                LBox.Items.Add(Li);
            }
            Button? s = sender as Button;
            DBH.Close();
        }


        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem? Li = sender as ListBoxItem;
            if (Li != null)
                Li.Background = new SolidColorBrush(Colors.Beige);
        }

        private void Test(object sender, MouseEventArgs e)
        {
            ListBoxItem? Li = sender as ListBoxItem;
            if (Li != null)
                Li.Background = new SolidColorBrush(Colors.Beige);
        }

        private void btn_Cancle(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
        }
    }
}
