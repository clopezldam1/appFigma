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
using System.Windows.Shapes;

namespace Estilos_de_Cristina_Lopez
{
    /// <summary>
    /// Lógica de interacción para ContactForm.xaml
    /// </summary>
    public partial class ContactForm : Window
    {
        public ContactForm()
        {
            InitializeComponent();
        }

        private void Boton_popUp_contact(object sender, RoutedEventArgs e)
        {
            ContactPopUp popUpContact = new ContactPopUp();
            this.Close();
            popUpContact.Show();
        }

        private void boton_home(object sender, RoutedEventArgs e)
        {

        }

        private void clearTextBox(object sender, RoutedEventArgs e)
        {
           
                //this = (Textbox) this.Clear();
               
        }
    }
}
