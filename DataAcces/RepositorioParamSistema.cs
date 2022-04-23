using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class RepositorioParamSistema : IRepositorioParamSistema
    {
        private IDbConnection conneccion;

        // Constructor de RepositorioPlanta
        public RepositorioParamSistema(IDbConnection con)
        {
            this.conneccion = con;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTipo(int idTipoPlanta)
        {
            throw new NotImplementedException();
        }

        public bool ExisteTipo(TipoPlanta unTipo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable Get()
        {
            ICollection<ParamSistema> resultado = new List<ParamSistema>();
            IDbCommand command = conneccion.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.ParamSistema";

            try
            {
                conneccion.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    ParamSistema unParam = null;
                    while (reader.Read())
                    {
                        unParam = new ParamSistema();
                        // Completar después de tener la clase planta y los demás métodos del repositorio
                        unParam.IdParam = (int)reader["IdParam"];
                        unParam.Nombre = (string)reader["Nombre"];
                        unParam.Descripcion = (string)reader["Descripcion"];
                        unParam.ValorMin = (int)reader["ValorMin"];
                        unParam.ValorMax = (int)reader["ValorMax"];
                        
                        resultado.Add(unParam);
                    }
                }
            }
            catch (Exception)
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

        public ParamSistema GetByID(int id)
        {
            ParamSistema unParam = null;
            IDbCommand command = conneccion.CreateCommand();
            command.CommandText = @"SELECT * FROM dbo.ParamSistema WHERE IdParam = @id";
            command.Parameters.Add(new SqlParameter("@id", id));
            try
            {
                conneccion.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    unParam = new ParamSistema();
                    unParam.IdParam = (int)reader["IdParam"];
                    unParam.Nombre = (string)reader["Nombre"];
                    unParam.Descripcion = (string)reader["Descripcion"];
                    unParam.ValorMin = (int)reader["ValorMin"];
                    unParam.ValorMax = (int)reader["ValorMax"];
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conneccion.Close();
                conneccion.Dispose();
                command.Dispose();
            }
            return unParam;
        }

        public TipoPlanta GetByIdTipo(int id)
        {
            throw new NotImplementedException();
        }

        public TipoPlanta GetByNombreTipo(string tipoNombre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetTipos()
        {
            throw new NotImplementedException();
        }

        public void Insert(ParamSistema obj)
        {
            throw new NotImplementedException();
        }

        public void InsertTipo(TipoPlanta unTipo)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ParamSistema obj)
        {
            
            IDbCommand command = conneccion.CreateCommand();
            command.CommandText = @"UPDATE ParamSistema SET Nombre = @Nombre, Descripcion = @Descripcion, ValorMin = @ValorMin, ValorMax = @ValorMax WHERE IdParam = @IdParam";
            
            command.Parameters.Add(new SqlParameter("@Nombre", obj.Nombre));
            command.Parameters.Add(new SqlParameter("@Descripcion", obj.Descripcion));
            command.Parameters.Add(new SqlParameter("@ValorMin", obj.ValorMin));
            command.Parameters.Add(new SqlParameter("@ValorMax", obj.ValorMax));
            command.Parameters.Add(new SqlParameter("@IdParam", obj.IdParam));

            try
            {
                conneccion.Open();
                int filasAfectadas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conneccion.Close();
                conneccion.Dispose();
                command.Dispose();
            }
        }

        public void UpdateTipo(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }

        TipoPlanta IRepositorio<ParamSistema>.ExisteTipo(TipoPlanta unTipo)
        {
            throw new NotImplementedException();
        }
    }
}
