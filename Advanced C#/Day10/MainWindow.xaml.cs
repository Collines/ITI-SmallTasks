using Day10.Entities;
using Microsoft.EntityFrameworkCore;
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

namespace Day10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        pubsContext Context;
        public MainWindow()
        {
            Context = new pubsContext();
            InitializeComponent();
            Closing += (sender, e) => Context.Dispose();
        }

        private void DataGridLoaded(object sender, RoutedEventArgs e)
        {
            DataGridComboBoxColumn ComboCol = new();
            ComboCol.SelectedValueBinding = new Binding("pub_id");
            Context.titles.Load(); // Select * from Titles, result stored in local dbSet
            Context.publishers.Load();
            ComboCol.ItemsSource = Context.publishers.Local.ToBindingList();
            ComboCol.Header = "Publisher";
            ComboCol.DisplayMemberPath = "pub_name";
            ComboCol.SelectedValuePath = "pub_id";
            //
            dataGrid.ItemsSource = Context.titles.Local.ToBindingList();
            dataGrid.Columns.ElementAt(3).IsReadOnly = true;
            dataGrid.Columns.ElementAt(3).Header = "Publisher";
            dataGrid.Columns.ElementAt(8).Width= 100;
            dataGrid.Columns.ElementAt(1).Width= 100;
            dataGrid.Columns.RemoveAt(10);
            dataGrid.Columns.Add(ComboCol);
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            var Result = MessageBox.Show("Do you want to reload?", "Confirmation", MessageBoxButton.YesNo);
            if(Result == MessageBoxResult.Yes)
            {
                Context = new pubsContext();
                dataGrid.ItemsSource = null;
                dataGrid.Columns.Clear();
                dataGrid.Items.Clear();
                DataGridLoaded(sender, e);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var Result = MessageBox.Show("Do you want to save?", "Confirmation", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                Context.SaveChanges();
            }
        }
    }
}
