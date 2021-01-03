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

namespace Binary_Calculator_Game_MOO_ICT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random rand = new Random();
        int total;
        int randomInt;


        public MainWindow()
        {
            InitializeComponent();
            btnCheck.IsEnabled = false;
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            randomInt = rand.Next(0, 511);

            txtQuestion.Content = "What is " + randomInt + " in Binary?";
            btnCheck.IsEnabled = true;

            txtAnswer.Content = "";

            foreach(var x in mainGrid.Children.OfType<TextBox>())
            {
                x.Text = "0";
            }

        }

        private void ShowHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Click on the start button to begin" + Environment.NewLine +
                "Enter 1 or 0 into the boxes " + Environment.NewLine +
                "if you enter 1 into a box it will represent the value mentioned above it " + Environment.NewLine +
                "If you enter 0 into a box it will not count towards the total " + Environment.NewLine +
                "Once you are satisfied with your numbers click on check button to see if its correct" + Environment.NewLine +
                "You can retry unlimited times " + Environment.NewLine +
                "Have Fun." + Environment.NewLine +
                "MOO ICT", "Help for the Binary Game"
                );
        }

        private void CheckGame(object sender, RoutedEventArgs e)
        {
            total = 0;

            txtAnswer.Content = "";

            foreach (var x in mainGrid.Children.OfType<TextBox>())
            {
                if (x.Text == "1")
                {
                    total += Convert.ToInt32(x.Tag);
                }

                txtAnswer.Content += x.Text;
            }

            if (total == randomInt)
            {
                btnCheck.IsEnabled = false;
                txtAnswer.Content += " is correct";
            }
            else
            {
                txtAnswer.Content += " is incorrect";
            }


        }
    }
}
