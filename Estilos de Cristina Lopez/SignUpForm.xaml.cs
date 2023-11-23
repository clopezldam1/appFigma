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
        
        SqlConnection conexionSQL;
        string conexionBD;

        string Nombre, Apellidos, Genero, Pronombres, Username, Email, Contrasena;
        DateTime FechaNaci;
        int Telefono;

        public SignUpForm()
        { 
            InitializeComponent();
            conexionBD = ConfigurationManager.ConnectionStrings["Estilos_de_Cristina_Lopez.Properties.Settings.CreatiNation_BDConnectionString"].ConnectionString;
    
            conexionSQL = new SqlConnection(conexionBD);
        }

        private void boton_home(object sender, RoutedEventArgs e)
        {
            homePage home = new homePage();
            this.Close();
            home.Show();
        }

        private void boton_Registrar(object sender, RoutedEventArgs e)
        {
            goto_SignUpPopUp();
            ValidarFormulario();
            RegistrarUser();
        }

        private void goto_SignUpPopUp()
        {
            SignUpPopUp signUpPopUp = new SignUpPopUp();
            this.Close();
            signUpPopUp.Show();
        }

        private void ValidarFormulario()
        {
            Nombre = inputNombre.Text;
            Apellidos = inputApellidos.Text;

            FechaNaci = inputFechaNaci.SelectedDate.Value.Date;

            if (checkHombre.IsChecked == true | checkMujer.IsChecked == true | checkOtro.IsChecked == true) 
            {
                if (checkHombre.IsChecked == true) { Genero = "Hombre"; Pronombres = "Él"; }
                if (checkMujer.IsChecked == true) { Genero = "Mujer"; Pronombres = "Ella"; }
                if (checkOtro.IsChecked == true) { Genero = "Otro"; Pronombres = inputPronombres.Text; }
            }
            else
            {
                MessageBox.Show("Marca una de las casillas de 'género', por favor.");
            }
                   
            try
            {
                if (inputTelefono.Text.Length == 9) { Telefono = Int32.Parse(inputTelefono.Text); }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ERROR: El número de teléfono no es válido.");
            }
           
            Username = inputUsername.Text;
            Email = inputEmail.Text;

            if (inputContrasena.Text.Equals(repetirContrasena.Text)) { Contrasena = inputContrasena.Text; }
          
        }

        private void RegistrarUser()
        {
            string insertar = string.Format("INSERT INTO Usuarios VALUES {0},{1},{2},{3},{4},{5},{6},{7},{8}", Nombre, Apellidos, FechaNaci, Genero, Pronombres, Telefono, Username, Email, Contrasena);

            SqlDataAdapter adapter = new SqlDataAdapter(insertar, conexionSQL);
            using (adapter)
            {
                adapter.InsertCommand = new SqlCommand(insertar, conexionSQL);
            }
        }

    }
}
