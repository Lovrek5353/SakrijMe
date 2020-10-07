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

namespace SakrijMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZčćđšžČĆĐŠŽ0123456789 ";
        public MainWindow()
        {
            InitializeComponent();
            MainTextBox.Focus();
        }

        private string EncryptText(string text, int key)
        {
            var sb = new StringBuilder();

            foreach (char c in text)
            {
                if (Chars.Contains(c))
                {
                    int index = (Chars.IndexOf(c) + key) % Chars.Length;
                    sb.Append((Chars[index < 0 ? index + Chars.Length : index]));
                }
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }

        private string DecryptText(string text, int key)
        {
            var sb = new StringBuilder();

            foreach (char c in text)
            {
                int index = (Chars.IndexOf(c) - key) % Chars.Length;
                char newChar = Chars[index < 0 ? index + Chars.Length : index];

                if (Chars.Contains(newChar))
                    sb.Append(newChar);
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            string encrypted = EncryptText(MainTextBox.Text, int.Parse(KeyTextBox.Text));
            new ShowText(encrypted).ShowDialog();
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            string decrypted = DecryptText(MainTextBox.Text, int.Parse(KeyTextBox.Text));
            new ShowText(decrypted).ShowDialog(); ;
        }
    }
}
