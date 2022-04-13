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
                        unParam.TipoDescMin = (int)reader["TipoDescMin"];
                        unParam.TipoDescMax = (int)reader["TipoDescMax"];
                        unParam.PlantaDescMin = (int)reader["PlantaDescMin"];
                        unParam.PlantaDescMax = (int)reader["PlantaDescMax"];
                        unParam.TasaIVA = (int)reader["TasaIVA"];
                        unParam.TasaImpuesto = (int)reader["TasaImpuesto"];
                        unParam.TasaArancelaria = (int)reader["TasaArancelaria"];

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
            }
            return resultado;
        }

        public ParamSistema GetByID(int id)
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
            throw new NotImplementedException();
        }
    }
}
