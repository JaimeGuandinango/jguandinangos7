using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO; //para agregar permisos
using System.Reflection;
using jguandinangos7.Droid;


[assembly: Xamarin.Forms.Dependency(typeof(ClienteAndroid))]
namespace jguandinangos7.Droid
{
    public class ClienteAndroid : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta= System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments); //ruta para que se cree la base
            var BaseDatos = Path.Combine(ruta, "uisrael.db3"); //no cambiar la extension de la base
            return new SQLiteAsyncConnection(BaseDatos);
        }
    }
}