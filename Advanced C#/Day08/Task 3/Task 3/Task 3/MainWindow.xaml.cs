using System;
using System.Collections.Generic;
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

namespace Task_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StdLst.ItemsSource = new List<Student>() 
            { 
                new() {Id=1,Name="Mohamed Salah",Age=26,Grade='A',Image="/mido.jpg"},
                new() {Id=2,Name="Omar Salah",Age=23,Grade='A',Image="/omar.png"},
                new() {Id=3,Name="Mahmoud Salah",Age=19,Grade='C',Image="/momo.png"},
                new() {Id=4,Name="Mazen Salah",Age=12,Grade='B',Image="/mezo.png"}
            };
        }
    }
}
