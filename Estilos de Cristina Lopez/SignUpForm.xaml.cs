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
            //conexionBD = ConfigurationManager.ConnectionStrings["Estilos_de_Cristina_Lopez.Properties.Settings.CreatiNation_BDConnectionString"].ConnectionString;
    
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
            if (inputNombre.Text.Length == 0)
            {
                Nombre = inputNombre.Text; }
            else
            {
                MessageBox.Show("El campo 'Nombre' no puede estar vacío.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (inputApellidos.Text.Length == 0)
            {
                Apellidos = inputApellidos.Text;
            }
            else
            {
                MessageBox.Show("El campo 'Apellidos' no puede estar vacío.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                FechaNaci = inputFechaNaci.SelectedDate.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debes seleccionar una fecha de nacimiento.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (checkHombre.IsChecked == true | checkMujer.IsChecked == true | checkOtro.IsChecked == true) 
            {
                if (checkHombre.IsChecked == true) { Genero = "Hombre"; Pronombres = "Él"; }
                if (checkMujer.IsChecked == true) { Genero = "Mujer"; Pronombres = "Ella"; }
                if (checkOtro.IsChecked == true) { Genero = "Otro"; Pronombres = inputPronombres.Text; }
            }
            else
            {
                MessageBox.Show("Marca una de las casillas de 'género', por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
                   
            try
            {
                if (inputTelefono.Text.Length == 9) { Telefono = Int32.Parse(inputTelefono.Text); }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("El número de teléfono no es válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (inputUsername.Text.Length == 0)
            {
                Username = inputUsername.Text;
            }
            else
            {
                MessageBox.Show("Introduce un nombre de usuario, por favor.","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            if (inputEmail.Text.Length == 0)
            {
                Email = inputEmail.Text;
            }
            else
            {
                MessageBox.Show("Introduce un correo electrónico, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (inputContrasena.Text.Equals(repetirContrasena.Text)) 
            { 
                Contrasena = inputContrasena.Text;
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            goto_SignUpPopUp(); //si todo es valido, sigues adelante
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
