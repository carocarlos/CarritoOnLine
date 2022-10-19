using CapaPresentacionAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CapaPresentacionAdmin.DataAccess
{
    public class DA_Users
    {
        /// <summary>
        /// Metodo encargado de obtener todos los usuarios registrados
        /// </summary>
        /// <returns>retorna todos los registros configurados en la tabla usuario
        /// de la BD BDCARRITO</returns>
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> ListUsers = new List<Usuario>();
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CrearConexion();
                SqlCommand cmd = new SqlCommand("SP_GetUsuarios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario ObjUsers = new Usuario();
                    ObjUsers.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    ObjUsers.Nombres = dr["Nombres"].ToString();
                    ObjUsers.Apellidos = dr["Apellidos"].ToString();
                    ObjUsers.Correo = dr["Correo"].ToString();
                    ObjUsers.Restablecer = dr["Restablecer"].ToString();
                    ObjUsers.Activo = Convert.ToBoolean(dr["Activo"]);
                    ObjUsers.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    ListUsers.Add(ObjUsers);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return ListUsers;
        }
        
    }
}