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
    /// Lógica de interacción para loginForm.xaml
    /// </summary>
    public partial class loginForm : Window
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void boton_signUp(object sender, RoutedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            this.Close();
            signUpForm.Show();
        }

        private void boton_home(object sender, RoutedEventArgs e)
        {
            homePage home = new homePage();
            this.Close();
            home.Show();
        }

        private void goto_ContactForm(object sender, RoutedEventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            this.Close();
            contactForm.Show();
        }
    }
}
