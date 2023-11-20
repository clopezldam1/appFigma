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

namespace Estilos_de_Cristina_Lopez
{
    /// <summary>
    /// Lógica de interacción para Banner.xaml
    /// </summary>
    public partial class Banner : UserControl
    {
        public Banner()
        {
            InitializeComponent();
        }

        private void goto_Back(object sender, RoutedEventArgs e)
        {

        }

        private void goto_Home(object sender, RoutedEventArgs e)
        {
            homePage home = new homePage();
            Window.GetWindow(this).Close();
            home.Show();
        }

        private void goto_Index(object sender, RoutedEventArgs e)
        {
            Index index = new Index();
            Window.GetWindow(this).Close();
            index.Show();
        }

        private void goto_AboutUs(object sender, RoutedEventArgs e)
        {

        }

        private void goto_Account(object sender, RoutedEventArgs e)
        {

        }
    }
}
