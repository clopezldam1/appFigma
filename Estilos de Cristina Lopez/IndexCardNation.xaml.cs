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
    /// Lógica de interacción para IndexCardNation.xaml
    /// </summary>
    public partial class IndexCardNation : UserControl
    {
        public IndexCardNation()
        {
            InitializeComponent();
        }

        private void goto_ComingSoon(object sender, RoutedEventArgs e)
        {
            ComingSoon newWindow = new ComingSoon();
            Window.GetWindow(this).Close();
            newWindow.Show();
        }

        private void goto_AboutUs(object sender, RoutedEventArgs e)
        {
            AboutUs newWindow = new AboutUs();
            Window.GetWindow(this).Close();
            newWindow.Show();
        }

        private void goto_ContactForm(object sender, RoutedEventArgs e)
        {
            ContactForm newWindow = new ContactForm();
            Window.GetWindow(this).Close();
            newWindow.Show();
        }
    }
}
