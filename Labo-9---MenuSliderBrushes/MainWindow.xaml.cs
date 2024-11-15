using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TestWindow
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

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            number1TextBox.Text = slider1.Value.ToString();
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            number2TextBox.Text = slider2.Value.ToString();
        }

        private void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Applicatie afsluiten?","Afsluiten",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void number1MenuItem_Click(object sender, RoutedEventArgs e)
        {
            slider1.Value = 2;
        }

        private void number2MenuItem_Click(object sender, RoutedEventArgs e)
        {
            slider2.Value = 2;
        }

        private void number1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isNumber = int.TryParse(number1TextBox.Text, out int number);

            if (number1TextBox.Text.Length == 1)
            {
                if (isNumber)
                {
                    if (number >= 1 && number <= 5)
                    {
                        slider1.Value = number;
                    }
                    else
                    {
                        MessageBox.Show("Getal moet van 1 tot en met 5 zijn", "Verkeerde ingave", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Geef een getal van 1 tot en met 5 in", "Verkeerde ingave", MessageBoxButton.OK, MessageBoxImage.Error);

                    slider1.Value = 1;
                }
            }
        }

        private void number2TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool isNumber = int.TryParse(number2TextBox.Text, out int number);

            if(number2TextBox.Text.Length == 1)
            {
                if (isNumber)
                {
                    if (number >= 1 && number <= 5)
                    {
                        slider2.Value = number;
                    }
                    else
                    {
                        MessageBox.Show("Getal moet van 1 tot en met 5 zijn", "Verkeerde ingave", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Geef een getal van 1 tot en met 5 in", "Verkeerde ingave", MessageBoxButton.OK, MessageBoxImage.Error);

                    slider2.Value = 1;
                }
            }
        }

        // Gevonden op volgende URL
        // https://stackoverflow.com/questions/59558368/how-to-select-all-text-of-a-textbox-on-mouse-click-textbox-selectall-not-wor
        private async void selectAll_OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            await Application.Current.Dispatcher.InvokeAsync(textBox.SelectAll, DispatcherPriority.Background);
        }


    }

}