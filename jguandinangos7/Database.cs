using System;
using System.Collections.Generic;
using System.Text;
using SQLite;  //para utilizar los metodos de la base de datos

namespace jguandinangos7
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection(); //definir la conexion
    }
}
