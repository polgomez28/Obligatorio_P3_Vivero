using Dominio;
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
                        // unaPlanta.Tipo = (string)reader["Tipo"]; reader trae el nombre del tipo. llamar método que busca tipo por id(nombre)
                        // unaPlanta.NombreCientifico = (string)reader["NombreCientifico"];
                        // unaPlanta.NombresVulgares = (striing)reader["NombresVulgares"]; hay que corregir, nombres vulgares sería una lista
                        // unaPlanta.Descripcion = (string)reader["Descripcion"];
                        // unaPlanta.FichaCuidados = (int)reader["FichaCuidados"]; reader trae el id de ficha, llamar método que busca ficha por id
                        // unaPlanta.Foto = (string)reader["Foto"]; modificar luego de definir cómo se va a manejar la foto
                        // unaPlanta.Ambiente = (string)reader["Ambiente"];
                        // unaPlanta.Altura = (int)reader["Altura"]; cambiar int por tipo de valor que se defina en la bd
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
                        // Completar después de tener la clase planta y los demás métodos del repositorio
                        // unaPlanta.Tipo = (string)reader["Tipo"]; reader trae el nombre del tipo. llamar método que busca tipo por id(nombre)
                        // unaPlanta.NombreCientifico = (string)reader["NombreCientifico"];
                        // unaPlanta.NombresVulgares = (striing)reader["NombresVulgares"]; hay que corregir, nombres vulgares sería una lista
                        // unaPlanta.Descripcion = (string)reader["Descripcion"];
                        // unaPlanta.FichaCuidados = (int)reader["FichaCuidados"]; reader trae el id de ficha, llamar método que busca ficha por id
                        // unaPlanta.Foto = (string)reader["Foto"]; modificar luego de definir cómo se va a manejar la foto
                        // unaPlanta.Ambiente = (string)reader["Ambiente"];
                        // unaPlanta.Altura = (int)reader["Altura"]; cambiar int por tipo de valor que se defina en la bd                        
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
            }
            return unaPlanta;
        }

        public void Insert(Planta obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"Insert into dbo.Plantas(Tipo, NombreCientifico, NombresVulgares, Descripcion, FichaCuidados, Foto, Ambiente, Altura) Values(@Tipo, @NombreCientifico,
            @NombresVulgares, @Descripcion, @FichaCuidados, @Foto, @Ambiente, @Altura)";

            //command.Parameters.Add(new SqlParameter("@Tipo", obj.Tipo));
            //command.Parameters.Add(new SqlParameter("@NombreCientifico", obj.NombreCientifico));
            //command.Parameters.Add(new SqlParameter("@NombresVulgares", obj.NombresVulgares));
            //command.Parameters.Add(new SqlParameter("@Descripcion", obj.Descripcion));
            //command.Parameters.Add(new SqlParameter("@FichaCuidados", obj.FichaCuidados));
            //command.Parameters.Add(new SqlParameter("@Foto", obj.Foto));
            //command.Parameters.Add(new SqlParameter("@Ambiente", obj.Ambiente));
            //command.Parameters.Add(new SqlParameter("@Altura", obj.Altura));            
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
            }
            return resultado;
        }
        //Genero el insert del TipoPlanta obtenido del TipoPlantaController Siempre y cuando no exista (!ExisteTipo)
        public void InsertTipo(TipoPlanta obj)
        {
            TipoPlanta unT = new TipoPlanta();
            
            unT = ExisteTipo(obj);
            if ( unT == null)
            {

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
                    Console.WriteLine($"Se controló la excepción {ex.Message} en el método invocado InvocarCodigoExcepción()");
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            else
            {
                throw new Exception();
            }

        }
        // Busca si existe un Tipo por nombre en la base de datos
        public TipoPlanta ExisteTipo(TipoPlanta obj)
        {
            //TipoPlanta Tipo = new TipoPlanta();
            TipoPlanta Tipo = null;
            ICollection<TipoPlanta> resultado = new List<TipoPlanta>();
            resultado = (ICollection<TipoPlanta>)GetTipos();
            foreach (TipoPlanta unTipo in resultado)
            {
                if (obj.TipoNombre == unTipo.TipoNombre)
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

        bool IRepositorio<Planta>.ExisteTipo(TipoPlanta unTipo)
        {
            throw new NotImplementedException();
        }
    }
}
