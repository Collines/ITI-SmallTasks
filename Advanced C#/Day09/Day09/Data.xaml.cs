using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Data.xaml
    /// </summary>
    public partial class Data : Window
    {
        SqlCommand SQLProductsCMD;
        SqlCommand SQLCategoriesCMD;
        SqlCommand SQLSuppliersCMD;
        SqlDataAdapter SQLProductsDA;
        SqlDataAdapter SQLCategoriesDA;
        SqlDataAdapter SQLSuppliersDA;
        DataTable ProductsDT;
        DataTable CategoryDT;
        DataTable SupplierDT;
        SqlCommandBuilder SQLProductBuilder;
        SqlCommandBuilder SQLCategoryBuilder;
        SqlCommandBuilder SQLSupplierBuilder;
        public Data()
        {
            InitializeComponent();
            SQLProductsCMD= new SqlCommand();
            SQLCategoriesCMD= new SqlCommand();
            SQLSuppliersCMD= new SqlCommand();
            SQLProductsDA= new SqlDataAdapter();
            SQLCategoriesDA= new SqlDataAdapter();
            SQLSuppliersDA= new SqlDataAdapter();
            ProductsDT = new DataTable();
            CategoryDT = new DataTable();
            SupplierDT = new DataTable();
            SQLProductBuilder = new SqlCommandBuilder();
            SQLCategoryBuilder = new SqlCommandBuilder();
            SQLSupplierBuilder = new SqlCommandBuilder();

            SQLProductsCMD.Connection = DBH;
            SQLCategoriesCMD.Connection = DBH;
            SQLSuppliersCMD.Connection = DBH;
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            if (!dataGrid.Items.IsEmpty)
            {
                dataGrid.ItemsSource = null;
                dataGrid.Columns.Clear();
                dataGrid.Items.Clear();
            }
            
            //Products
            SQLProductsCMD.CommandText = "Select * from products";
            SQLProductsDA.SelectCommand = SQLProductsCMD;
            SQLProductsDA.Fill(ProductsDT);
            // Categories
            SQLCategoriesCMD.CommandText = "Select CategoryID, CategoryName from categories";
            SQLCategoriesDA.SelectCommand = SQLCategoriesCMD;
            SQLCategoriesDA.Fill(CategoryDT);
            // Suppliers
            SQLSuppliersCMD.CommandText = "Select SupplierID as Supplier, CompanyName from suppliers";
            SQLSuppliersDA.SelectCommand = SQLSuppliersCMD;
            SQLSuppliersDA.Fill(SupplierDT);

            DataGridComboBoxColumn CategoryComboBox = new()
            {
                Header ="Category",
                ItemsSource = CategoryDT.AsDataView(),
                DisplayMemberPath= "CategoryName",
                SelectedValuePath= "CategoryID",
                SelectedValueBinding=new Binding("CategoryID"),
            };
            DataGridComboBoxColumn SupplierComboBox = new()
            {
                Header = "Supplier",
                ItemsSource = SupplierDT.AsDataView(),
                DisplayMemberPath = "CompanyName",
                SelectedValuePath = "Supplier",
                SelectedValueBinding = new Binding("SupplierID")
            };


            dataGrid.ItemsSource = ProductsDT.AsDataView();
            dataGrid.Columns.ElementAt(2).IsReadOnly = true;
            dataGrid.Columns.ElementAt(3).IsReadOnly = true;
            dataGrid.Columns.Add(CategoryComboBox);
            dataGrid.Columns.Add(SupplierComboBox);
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            SQLProductBuilder.DataAdapter = SQLProductsDA;
            //SQLCategoryBuilder.DataAdapter = SQLCategoriesDA;
            //SQLSupplierBuilder.DataAdapter = SQLSuppliersDA;
            if (dataGrid== null || SQLProductsDA == null /*|| SQLCategoriesDA==null || SQLSuppliersDA==null*/) return;
            dataGrid.CommitEdit();
            SQLProductsDA.Update(ProductsDT);
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            if (!dataGrid.Items.IsEmpty)
            {
                dataGrid.ItemsSource = null;
                dataGrid.Columns.Clear();
                dataGrid.Items.Clear();
            }
        }
    }
}
