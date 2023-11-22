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
        /* REFERENCIAS:
         https://learn.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqldataadapter?view=dotnet-plat-ext-7.0
        https://learn.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqldataadapter.insertcommand?view=dotnet-plat-ext-7.0#system-data-sqlclient-sqldataadapter-insertcommand
        https://learn.microsoft.com/es-es/dotnet/framework/data/adonet/generating-commands-with-commandbuilders
        https://learn.microsoft.com/es-es/sql/t-sql/statements/insert-transact-sql?view=sql-server-ver16
        https://learn.microsoft.com/es-es/visualstudio/data-tools/create-a-simple-data-application-with-wpf-and-entity-framework-6?view=vs-2022

        https://es.stackoverflow.com/questions/16804/c%C3%B3mo-asignar-el-valor-seleccionado-de-un-radio-button-a-un-campo-en-la-base-de
         */
        SqlConnection sqlConnection;
        string conexionBD;

        string Nombre, Apellidos, Genero, Pronombres, Username, Email, Contrasena;
        DateTime FechaNaci;
        int Telefono;

        public SignUpForm()
        { 
            InitializeComponent();
             conexionBD = ConfigurationManager.ConnectionStrings["Estilos_de_Cristina_Lopez.Properties.Settings.CreatiNation_BD"].ConnectionString;
            //sqlConnection = new SqlConnection(conexionBD);
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

            ValidarFormulario();
            RegistrarUser();
        }

        private void ValidarFormulario()
        {
            Nombre = inputNombre.Text;
            Apellidos = inputApellidos.Text;
            FechaNaci = inputFechaNaci.SelectedDate.Value;

            // Genero;
            // Pronombres;

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

            DataSet dataSet = new DataSet();
            string insertar = "INSERT INTO CreatiNation_BD.Usuarios ";
            hacerInsert(dataSet, insertar, conexionBD);




        }

        private static void hacerInsert(DataSet dataset, string connectionString, string queryString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(queryString, connection);
            }
        }
    }
}
