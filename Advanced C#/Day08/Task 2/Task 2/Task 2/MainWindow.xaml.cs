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

namespace Task_2
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

        private void SetTxt(object sender, RoutedEventArgs e)
        {
            clearTxt(sender,e);
            txtBox.AppendText("Replace default text with initial text value");
        }

        private void clearTxt(object sender, RoutedEventArgs e)
        {
            //TextSelection x = txtBox.Selection;
            txtBox.Document.Blocks.Clear();
        }

        private void SelectAll(object sender, RoutedEventArgs e)
        {
            txtBox.SelectAll();
            txtBox.Focus();
        }

        private void PrenpendTxt(object sender, RoutedEventArgs e)
        {
            Paragraph x = (Paragraph)txtBox.Document.Blocks.ElementAt(0);
            var y = x.Inlines;
            Run z = (Run)y.ElementAt(0);
            var oldText = z.Text;
            z.Text = " *** Prepended text *** " + oldText;
            //FlowDocument document= new FlowDocument();
            //string Text = " *** Prepended text *** " +new TextRange(txtBox.Document.ContentStart, txtBox.Document.ContentEnd).Text;
            //Paragraph PText = new Paragraph(new Run(Text));
            //document.Blocks.Add(PText);
            //txtBox.Document = document;
        }

        private void InsertTxt(object sender, RoutedEventArgs e) => txtBox.CaretPosition.InsertTextInRun(" *** inserted text *** ");

        private void AppendTxt(object sender, RoutedEventArgs e) => txtBox.AppendText(" *** appended text *** ");
        //{
        //    //Paragraph x = (Paragraph)txtBox.Document.Blocks.ElementAt(0);
        //    //var y = x.Inlines;
        //    //Run z = (Run)y.ElementAt(0);
        //    //var oldText = z.Text;
        //    //z.Text = oldText + " *** appended text *** ";
        //    txtBox.AppendText(" *** appended text *** ");
        //}

        private void CutTxt(object sender, RoutedEventArgs e)
        {
            if (txtBox.Selection.IsEmpty)
                MessageBox.Show("Make sure you selected text to cut", "Warning");
            else
            {
                var result = MessageBox.Show($"You're going to cut \"{txtBox.Selection.Text}\" are you sure?", "Warning", MessageBoxButton.OKCancel);
                if(result == MessageBoxResult.OK)
                {
                    Clipboard.SetText(txtBox.Selection.Text);
                    txtBox.Selection.Text = "";
                }
            }
        }

        private void PasteTxt(object sender, RoutedEventArgs e)
        {
            txtBox.CaretPosition.InsertTextInRun(Clipboard.GetText());
        }

        private void UndoTxt(object sender, RoutedEventArgs e)
        {
            txtBox.Undo();
        }

        private void editableEnable(object sender, RoutedEventArgs e)
        {
            txtBox.IsReadOnly= false;
        }

        private void ReadOnly(object sender, RoutedEventArgs e)
        {
            txtBox.IsReadOnly = true;
        }

        private void LeftAlign(object sender, RoutedEventArgs e)
        {
            txtBox.Document.TextAlignment= TextAlignment.Left;
        }
        private void RightAlign(object sender, RoutedEventArgs e)
        {
            txtBox.Document.TextAlignment = TextAlignment.Right;
        }

        private void CenterAlign(object sender, RoutedEventArgs e)
        {
            List<(string, int, bool)> x = new()
            {
                ("ahmed",1,true)
            };
            txtBox.Document.TextAlignment = TextAlignment.Center;
        }

    }
}
