using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace jguandinangos7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistros : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<Estudiante> tablaEstudiante;
        public ConsultaRegistros()
        {
            InitializeComponent();
            conexion = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            ObtenerEstudiante();
        }

        public async void ObtenerEstudiante()
        {
            var ResulEstudiantes = await conexion.Table<Estudiante>().ToListAsync();
            tablaEstudiante= new ObservableCollection<Estudiante>(ResulEstudiantes);
            ListaEstudiantes.ItemsSource = tablaEstudiante;

        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante= (Estudiante)e.SelectedItem;
            var ItemId= objetoEstudiante.Id.ToString();
            int id = Convert.ToInt32(ItemId); //id
            string nombre= objetoEstudiante.Nombre.ToString();
            string usuario = objetoEstudiante.Usuario.ToString();
            string contraseña= objetoEstudiante.Contraseña.ToString();
            Navigation.PushAsync(new Elemento(id, nombre, usuario, contraseña));

        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}