using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace jguandinangos7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection connection;
        public Login()
        {
            InitializeComponent();
            connection = DependencyService.Get<Database>().GetConnection();
        }
        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, String usuario, string contraseña)
        {
        return db.Query<Estudiante>("SELECT * FROM Estudiante Where Usuario =? and Contraseña =?", usuario, contraseña);
        }

        private void btnInicio_Clicked(object sender, EventArgs e)
        {
            try 
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();

                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContraseña.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistros());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario/Contraseña incorrectos", "cerrar");
                
                }
            }
            catch(Exception)
            {
            
            }

        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}