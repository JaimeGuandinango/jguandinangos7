using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace jguandinangos7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        private int idSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<Estudiante> RActualizar;
        IEnumerable<Estudiante> REliminar;
        public Elemento(int id, string nombre, string usuario, string contraseña)
        {
            InitializeComponent();
            txtId.Text= id.ToString();
            txtNombre.Text= nombre;
            txtUsuario.Text= usuario;
            txtContraseña.Text = contraseña;
            conexion = DependencyService.Get<Database>().GetConnection();
            idSeleccionado = id;
        }
        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where id =?", id);
        }
        public static IEnumerable<Estudiante> Actualizar(SQLiteConnection db, string nombre, string usuario, string contraseña, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante set Nombre =?, Usuario=?, Contraseña=? where id=?", nombre, usuario, contraseña, id);
        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db= new SQLiteConnection(ruta);
                RActualizar = Actualizar(db, txtNombre.Text, txtUsuario.Text, txtContraseña.Text, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());

            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");


            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                REliminar = Eliminar(db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());

            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
 
            }
        }
    }
}