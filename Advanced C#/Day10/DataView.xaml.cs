using Day10.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

namespace Day10
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : Window
    {
        pubsContext Context;
        public DataView()
        {
            Context = new pubsContext();
            InitializeComponent();
            Closing += (sender, e) => Context.Dispose();
            Load();
        }

        private void Load()
        {
            if (!listView.Items.IsEmpty)
                listView.ItemsSource = null;
            Context.titles.Load();
            Context.publishers.Load();
            listView.ItemsSource = Context.titles.Local.ToBindingList();
            listView.DisplayMemberPath = "title1";
            listView.SelectedValuePath = "title_id";
            listView.SelectionChanged += (sender, e) => StackPanelCustom.DataContext = listView.SelectedItem;
            PrdID.SetBinding(ContentProperty, new Binding("title_id"));
            PrdName.SetBinding(TextBox.TextProperty, new Binding("title1"));
            PrdUnitPrice.SetBinding(TextBox.TextProperty, new Binding("price"));
            CmbBox.ItemsSource = Context.publishers.Local.ToBindingList();
            CmbBox.SelectedValuePath = "pub_id";
            CmbBox.DisplayMemberPath = "pub_name";
            CmbBox.SetBinding(ComboBox.SelectedValueProperty, new Binding("pub_id"));
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            Context.Dispose();
            Context = new pubsContext();
            Load();
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
