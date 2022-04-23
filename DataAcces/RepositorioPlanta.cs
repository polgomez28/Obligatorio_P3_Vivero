﻿using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAcces
{
    public class RepositorioPlanta : IRepositorioPlanta
    {
        private IDbConnection connection;

        // Constructor de RepositorioPlanta
        public RepositorioPlanta(IDbConnection con)
        {
            this.connection = con;
        }
        public void Delete(int id)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM dbo.Plantas WHERE Id = @Id";
            command.Parameters.Add(new SqlParameter("@Id", id));
            try
            {
                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                // comprobar que se hayan realizado cambios en la bd
                if(filasAfectadas == 0)
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
        }

        public IEnumerable Get()
        {
            ICollection<Planta> listadoPlantas = new List<Planta>();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.Plantas";

            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    Planta unaPlanta = null;
                    while (reader.Read())
                    {
                        unaPlanta = new Planta();
                        // Completar después de tener la clase planta y los demás métodos del repositorio

                        int idTipo = (int)reader["IdTipoPlanta"]; // obtengo id del tipo de planta
                        TipoPlanta unTipo = GetByIdTipo(idTipo); // llamo método que busca tipo por id
                        unaPlanta.TipoPlanta = unTipo;
                        unaPlanta.NombreCientifico = (string)reader["NomCientifico"];
                        unaPlanta.NombresVulgares = new List<NombresVulgares>(); // (string)reader["NomVulgar"]  crear un método que traiga un string con los nombres y los separe, agregarlos a la lista de nombres
                        unaPlanta.Descripcion = (string)reader["Descripcion"];
                        //unaPlanta.IdFichaCuidados = (int)reader["FichaCuidados"]; // reader trae el id de ficha, llamar método que busca ficha por id
                        unaPlanta.FotosPlanta = new List<Foto>();  // modificar luego de definir cómo se va a manejar la foto (string)reader["Foto"]
                        unaPlanta.Ambiente = (string)reader["Ambiente"];
                        unaPlanta.Altura = (int)reader["Altura"];
                        listadoPlantas.Add(unaPlanta);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
            return listadoPlantas;
        }

        public Planta GetByID(int id)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.Plantas WHERE Id = @Id";
            command.Parameters.Add(new SqlParameter("@Id", id));
            Planta unaPlanta = null;
            try
            {
                connection.Open();
                using(IDataReader reader = command.ExecuteReader())
                {                     
                    while (reader.Read())
                    {
                        unaPlanta = new Planta();
                        int idTipo = (int)reader["IdTipoPlanta"]; // obtengo id del tipo de planta
                        TipoPlanta unTipo = GetByIdTipo(idTipo); // llamo método que busca tipo por id
                        unaPlanta.TipoPlanta = unTipo;
                        unaPlanta.NombreCientifico = (string)reader["NomCientifico"];
                        unaPlanta.NombresVulgares = new List<NombresVulgares>(); // (string)reader["NomVulgar"]  crear un método que traiga un string con los nombres y los separe, agregarlos a la lista de nombres
                        unaPlanta.Descripcion = (string)reader["Descripcion"];
                        //unaPlanta.FichaCuidados = (int)reader["FichaCuidados"]; // reader trae el id de ficha, llamar método que busca ficha por id
                        unaPlanta.FotosPlanta = new List<Foto>();  // modificar luego de definir cómo se va a manejar la foto (string)reader["Foto"]
                        unaPlanta.Ambiente = (string)reader["Ambiente"];
                        unaPlanta.Altura = (int)reader["Altura"];                      
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
            return unaPlanta;
        }

        public void Insert(Planta obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"Insert into dbo.Plantas(NomCientifico, Descripcion, IdTipoPlanta, IdFichaCuidados, Ambiente, Altura) Values(@NombreCientifico,
            @Descripcion,  @IdTipo, @FichaCuidados, @Ambiente, @Altura)";

            
            command.Parameters.Add(new SqlParameter("@NombreCientifico", obj.NombreCientifico));            
            command.Parameters.Add(new SqlParameter("@Descripcion", obj.Descripcion));
            command.Parameters.Add(new SqlParameter("@IdTipo", obj.TipoPlanta.IdTipoPlanta));
            command.Parameters.Add(new SqlParameter("@IdFichaCuidados", obj.FichaCuidados.IdFichaCuidados));           
            command.Parameters.Add(new SqlParameter("@Ambiente", obj.Ambiente));
            command.Parameters.Add(new SqlParameter("@Altura", obj.Altura));        
            
            // Insertar nombres en tabla nombres
            try
            {
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Planta obj)
        {
            throw new NotImplementedException();
        }

        // Tipo de planta
        public void UpdateTipo(TipoPlanta obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE TipoPlanta SET TipoNombre = @TipoNombre, TipoDesc = @TipoDesc WHERE IdTipoPlanta = @IdTipoPlanta";

            command.Parameters.Add(new SqlParameter("@TipoNombre", obj.TipoNombre));
            command.Parameters.Add(new SqlParameter("@TipoDesc", obj.TipoDesc));
            command.Parameters.Add(new SqlParameter("@IdTipoPlanta", obj.IdTipoPlanta));
            

            try
            {
                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
        }
        public IEnumerable GetTipos()
        {
            ICollection<TipoPlanta> resultado = new List<TipoPlanta>();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.TipoPlanta";

            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    TipoPlanta unTipo = null;
                    while (reader.Read())
                    {
                        unTipo = new TipoPlanta();
                        // Completar después de tener la clase planta y los demás métodos del repositorio
                        unTipo.IdTipoPlanta = (int)reader["IdTipoPlanta"];
                        unTipo.TipoNombre = (string)reader["TipoNombre"];
                        unTipo.TipoDesc = (string)reader["TipoDesc"];

                        resultado.Add(unTipo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
            return resultado;
        }
        //Genero el insert del TipoPlanta obtenido del TipoPlantaController Siempre y cuando no exista (!ExisteTipo)
        public void InsertTipo(TipoPlanta obj)
        {
            //TipoPlanta unT = new TipoPlanta();
            
            //unT = ExisteTipo(obj);
            //if (unT == null)
            //{

                IDbCommand command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO TipoPlanta(TipoNombre, TipoDesc) VALUES(@TipoNombre, @TipoDesc)";
                command.Parameters.Add(new SqlParameter("@TipoNombre", obj.TipoNombre));
                command.Parameters.Add(new SqlParameter("@TipoDesc", obj.TipoDesc));
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo grabar el tipo" + ex.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                    command.Dispose();
                }
            //}
            //else
            //{
            //    throw new Exception("Ya existe el tipo ingresado");
            //}

        }
        // Busca si existe un Tipo por nombre en la base de datos
        public TipoPlanta ExisteTipo(TipoPlanta obj)
        {
            TipoPlanta Tipo = null;
            ICollection<TipoPlanta> resultado = new List<TipoPlanta>();
            resultado = (ICollection<TipoPlanta>)GetTipos();
            foreach (TipoPlanta unTipo in resultado)
            {
                if (obj.TipoNombre.Equals(unTipo.TipoNombre))
                {
                    Tipo = unTipo;
                }
            }
            return Tipo;
        }

        public TipoPlanta GetByIdTipo(int id)
        {
            TipoPlanta unTipo = null;
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM TipoPlanta WHERE IdTipoPlanta = @id";
            command.Parameters.Add(new SqlParameter("@id", id));
            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    unTipo = new TipoPlanta();
                    unTipo.IdTipoPlanta = (int)reader["IdTipoPlanta"];
                    unTipo.TipoNombre = (string)reader["TipoNombre"];
                    unTipo.TipoDesc = (string)reader["TipoDesc"];
                    
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
            return unTipo;
        }

        public TipoPlanta GetByNombreTipo(string TipoNombre)
        {
            TipoPlanta Tipo = null;
            ICollection<TipoPlanta> resultado = new List<TipoPlanta>();
            resultado = (ICollection<TipoPlanta>)GetTipos();
            foreach (TipoPlanta unTipo in resultado)
            {
                if (TipoNombre == unTipo.TipoNombre)
                {
                    Tipo = unTipo;
                }
            }
            return Tipo;

            //TipoPlanta unTipo = null;
            //IDbCommand command = connection.CreateCommand();
            //command.CommandText = @"SELECT * FROM TipoPlanta WHERE TipoNombre = @TipoNombre";
            //command.Parameters.Add(new SqlParameter("@TipoNombre", TipoNombre));
            //try
            //{
            //    connection.Open();
            //    using (IDataReader reader = command.ExecuteReader())
            //    {
            //        reader.Read();

            //        unTipo = new TipoPlanta();
            //        unTipo.IdTipoPlanta = (int)reader["IdTipoPlanta"];
            //        unTipo.TipoNombre = (string)reader["TipoNombre"];
            //        unTipo.TipoDesc = (string)reader["TipoDesc"];

            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    connection.Close();
            //    connection.Dispose();
            //    command.Dispose();
            //}
            //return unTipo;
        }

        public void DeleteTipo(int idTipoPlanta)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM TipoPlanta WHERE IdTipoPlanta = @idTipoPlanta";
            command.Parameters.Add(new SqlParameter("@idTipoPlanta", idTipoPlanta));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
        }

        // Ficha cuidados
        public IEnumerable GetFichas()
        {
            throw new NotImplementedException();
        }

        public void UpdateFicha(FichaCuidados obj)
        {
            throw new NotImplementedException();
        }

        public void InsertFicha(FichaCuidados obj)
        {
            throw new NotImplementedException();
        }

        public FichaCuidados GetByIdFicha(int id)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.FichaCuidados WHERE Id = @Id";
            command.Parameters.Add(new SqlParameter("@Id", id));
            FichaCuidados unaFicha = null;
            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        unaFicha = new FichaCuidados();
                        int idTipoIluminacion = (int)reader["IdTipoIluminacion"]; // obtengo id del tipo de iluminacion
                        //TipoIluminacion unTipoIlum = GetByIdTipoIluminacio(idTipoIluminacion); // llamo método que busca tipo iluminacion por id
                        //unaFicha.TipoIluminacion = unTipoIlum;
                        unaFicha.Riego = (string)reader["Riego"];
                        unaFicha.Temperatura = (int)reader["Temperatura"];                        
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
            return unaFicha;
        }
        public void DeleteFicha(int idFicha)
        {
            throw new NotImplementedException();
        }  
        

    }
}
