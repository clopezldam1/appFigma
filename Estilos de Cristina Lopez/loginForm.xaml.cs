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
            //Aquí iniciamos la aplicación mostrando la primera página que sale al lanzarla: el login
            Frame rootFrame = new Frame();
            rootFrame.NavigationService.Navigate(new SignUpForm());
            // MainWindow.pageFrame.NavigationService.Navigate(new loginForm());
        }
    }
}
