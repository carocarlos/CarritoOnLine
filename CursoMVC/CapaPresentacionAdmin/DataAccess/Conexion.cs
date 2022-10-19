using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CapaPresentacionAdmin.DataAccess
{
    public class Conexion
    {
        private string connectionString;
        private static Conexion Con = null;

        /// <summary>
        /// Metodo encargado de obtener la cadena de conexión
        /// hacia la BD, de una llave configurada en el .config
        /// </summary>
        private Conexion()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["DBCARRITO"].ConnectionString;
        }

        public SqlConnection CrearConexion()
        {
            //se debe agregar la referencia using System.Data.SqlClient;
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = connectionString;
            }
            catch (Exception e)
            {
                Cadena = null;
                throw e;
            }
            return Cadena;
        }

        public static Conexion GetInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }

            return Con;
        }
    }
}