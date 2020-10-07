using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SakrijMe
{
    /// <summary>
    /// Interaction logic for ShowText.xaml
    /// </summary>
    public partial class ShowText : Window
    {
        public ShowText()
        {
            InitializeComponent();
        }

        public ShowText(string text)
        {
            InitializeComponent();

            MainTextBox.Text = text;
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(MainTextBox.Text);
        }
    }
}
