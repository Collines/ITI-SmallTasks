using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using static Day09.DBHandler;

namespace Day09
{
    /// <summary>
    /// Interaction logic for DetailedView.xaml
    /// </summary>
    public partial class DetailedView : Window
    {
        SqlCommand SQLCMD;
        SqlDataAdapter SQLDA;
        DataTable DT;
        SqlCommandBuilder SQLBuilder;
        public DetailedView()
        {
            InitializeComponent();
            SQLCMD = new SqlCommand();
            SQLDA = new SqlDataAdapter();
            DT = new DataTable();
            SQLBuilder = new SqlCommandBuilder();
            SQLCMD.Connection = DBH;
            Load();
        }

        private void Load()
        {
            if (!listView.Items.IsEmpty)
                listView.ItemsSource = null;
            SQLCMD.CommandText = "Select * from products";
            SQLDA.SelectCommand = SQLCMD;
            SQLDA.Fill(DT);
            listView.ItemsSource = DT.AsDataView();
            listView.DisplayMemberPath = "ProductName";
            listView.SelectedValuePath = "ProductID";
            listView.SelectionChanged += (sender, e) => StackPanelCustom.DataContext = listView.SelectedItem;
            PrdID.SetBinding(ContentProperty, new Binding("ProductID"));
            PrdName.SetBinding(TextBox.TextProperty, new Binding("ProductName"));
            PrdUnitPrice.SetBinding(TextBox.TextProperty, new Binding("UnitPrice"));
            listView.DataContext= DT;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var Result = MessageBox.Show("Do you want to save?", "Confirmation", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                SQLBuilder.DataAdapter = SQLDA;
                if (listView == null || SQLDA == null) return;
                SQLDA.Update(DT);
            }
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            var Result = MessageBox.Show("Do you want to reload?", "Confirmation", MessageBoxButton.YesNo);
            if(Result == MessageBoxResult.Yes)
            {
                DT.Clear();
                Load();
            }
        }
    }
}
