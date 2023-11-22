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
             //conexionBD = ConfigurationManager.ConnectionStrings["Estilos_de_Cristina_Lopez.Properties.Settings.CreatiNation_BD.mdf"].ConnectionString;
            //StringBuilder sb;
          //SqlConnectionStringBuilder("Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename='CreatiNation_DB.mdf';Integrated Security=True;Connect Timeout=30"); //ConnectionStrings[1].ConnectionString;
            //sqlConnection = new SqlConnection(conexionBD);
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

            DataSet dataSet = new DataSet();
            string insertar = string.Format("INSERT INTO Usuarios VALUES {0},{1},{2},{3},{4},{5},{6},{7},{8};", Nombre, Apellidos, FechaNaci, Genero, Pronombres, Telefono, Username, Email, Contrasena);

            string connectionString = "Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename='C: /Users/clope/Desktop/Asignaturas/desarrollo interfaces/UT1/wpf/Entrega5_tarea1.11/Estilos de Cristina Lopez/Estilos de Cristina Lopez/BBDD/CreatiNation_DB.mdf';Integrated Security=True;Connect Timeout=30";

            //hacerInsert(dataSet, insertar, connectionString);
            //al hacer la inserción salta error porque el ConnectionString no es correcto

         


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
