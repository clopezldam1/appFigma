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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Estilos_de_Cristina_Lopez
{
    /// <summary>
    /// Lógica de interacción para SignUpForm.xaml
    /// </summary>
    public partial class SignUpForm : Window
    {
        SqlConnection sqlConnection;
        public SignUpForm()
        { 
            InitializeComponent();
            string conexionBD = ConfigurationManager.ConnectionStrings["Estilos_de_Cristina_Lopez.Properties.Settings.CreatiNation_BD"].ConnectionString;
            sqlConnection = new SqlConnection(conexionBD);
        }

        private void boton_home(object sender, RoutedEventArgs e)
        {
            homePage home = new homePage();
            this.Close();
            home.Show();
        }

        private void boton_popUp_signup(object sender, RoutedEventArgs e)
        {
            SignUpPopUp signUpPopUp = new SignUpPopUp();
            this.Close();
            signUpPopUp.Show();
            RegistrarUser();
        }

        private void RegistrarUser()
        {
            string insertar = "";
        }
    }
}
