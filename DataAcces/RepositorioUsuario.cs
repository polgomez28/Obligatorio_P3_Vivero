using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Dominio;

namespace DataAcces
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private IDbConnection conneccion;

        public RepositorioUsuario(IDbConnection con)
        {
            this.conneccion = con;
        }

        public IList<Usuario> GetUsuarios()
        {
            IList<Usuario> resultado = new List<Usuario>();
            IDbCommand command = conneccion.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.Usuario";

            try
            {
                conneccion.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    Usuario usuario = null;
                    while (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.IdUsuario = (int)reader["IdUsuario"];
                        usuario.Email = (string)reader["Email"];
                        usuario.Contraseña = (string)reader["Contraseña"];

                        resultado.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conneccion.Close();
                conneccion.Dispose();
                command.Dispose();
            }
            return resultado;
        }
    }
}
