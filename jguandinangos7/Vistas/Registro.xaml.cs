using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace jguandinangos7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public Registro()
        {
            InitializeComponent();
            conexion= DependencyService.Get<Database>().GetConnection();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datos = new Estudiante {
                    Nombre= txtNombre.Text,
                    Usuario= txtUsuario.Text,
                    Contraseña= txtContraseña.Text

                };
                conexion.InsertAsync(datos);

                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtContraseña.Text = "";

            }
            catch (Exception ex)
            {

                DisplayAlert("alerta", ex.Message, "cerrar");
            }

        }
    }
}