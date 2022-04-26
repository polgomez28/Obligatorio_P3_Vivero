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

        // DELETE PLANTA
        public void Delete(int id)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM dbo.Planta WHERE IdPlanta = @Id";
            command.Parameters.Add(new SqlParameter("@Id", id));
            try
            {
                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                // comprobar que se hayan realizado cambios en la bd
                if (filasAfectadas == 0)
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

        // GET PLANTA
        public IList<Planta> Get()
        {
            IList<Planta> listaPlantas = new List<Planta>();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT p.IdPlanta, p.NomCientifico, p.Descripcion, p.Ambiente, p.Altura, p.NombresVulgares, tp.IdTipoPlanta, tp.TipoNombre, tp.TipoDesc, fc.IdFichaCuidados, fc.Riego, fc.Temperatura, ti.IdTipoIluminacion, ti.Tipo FROM dbo.Planta p INNER JOIN dbo.TipoPlanta tp ON p.IdTipoPlanta = tp.IdTipoPlanta INNER JOIN dbo.FichaCuidados fc ON p.IdFichaCuidados = fc.IdFichaCuidados INNER JOIN dbo.TipoIluminacion ti ON fc.IdTipoIluminacion = ti.IdTipoIluminacion";

            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    Planta planta = null;
                    List<Foto> listaFotos = new List<Foto>();
                    while (reader.Read())
                    {
                        planta = new Planta();
                        planta.IdPlanta = (int)reader["IdPlanta"];
                        planta.NombreCientifico = (string)reader["NomCientifico"];
                        planta.Descripcion = (string)reader["Descripcion"];
                        planta.Ambiente = (string)reader["Ambiente"];
                        planta.Altura = (int)reader["Altura"];
                        planta.NombresVulgares = (string)reader["NombresVulgares"];
                        planta.TipoPlanta = new TipoPlanta();
                        planta.TipoPlanta.IdTipoPlanta = (int)reader["IdTipoPlanta"];
                        planta.TipoPlanta.TipoNombre = (string)reader["TipoNombre"];
                        planta.TipoPlanta.TipoDesc = (string)reader["TipoDesc"];
                        planta.FichaCuidados = new FichaCuidados();
                        planta.FichaCuidados.IdFichaCuidados = (int)reader["IdFichaCuidados"];
                        planta.FichaCuidados.Riego = (string)reader["Riego"];
                        planta.FichaCuidados.Temperatura = (int)reader["Temperatura"];
                        planta.FichaCuidados.TipoIluminacion = new TipoIluminacion();
                        planta.FichaCuidados.TipoIluminacion.IdIluminacion = (int)reader["IdTipoIluminacion"];
                        planta.FichaCuidados.TipoIluminacion.DescripcionTipoIlum = (string)reader["Tipo"];
                        planta.ListaFotos = listaFotos; //Agregar la lista de fotos de cada planta

                        listaPlantas.Add(planta);
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
            return listaPlantas;
        }

        // GET BY ID PLANTA
        public Planta GetByID(int id)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT p.IdPlanta, p.NomCientifico, p.Descripcion, p.Ambiente, p.Altura, p.NombresVulgares, tp.IdTipoPlanta, tp.TipoNombre, tp.TipoDesc, fc.IdFichaCuidados, fc.Riego, fc.Temperatura,
            ti.IdTipoIluminacion, ti.Tipo FROM dbo.Planta p INNER JOIN dbo.TipoPlanta tp ON p.IdTipoPlanta = tp.IdTipoPlanta INNER JOIN dbo.FichaCuidados fc ON p.IdFichaCuidados = fc.IdFichaCuidados INNER JOIN dbo.TipoIluminacion
            ti ON fc.IdTipoIluminacion = ti.IdTipoIluminacion WHERE IdPlanta = @Id";
            command.Parameters.Add(new SqlParameter("@Id", id));
            Planta unaPlanta = null;

            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {                    
                    List<Foto> listaFotos = new List<Foto>();
                    while (reader.Read())
                    {
                        unaPlanta = new Planta();
                        unaPlanta.IdPlanta = (int)reader["IdPlanta"];                        
                        unaPlanta.NombreCientifico = (string)reader["NomCientifico"];
                        unaPlanta.Descripcion = (string)reader["Descripcion"];
                        unaPlanta.Ambiente = (string)reader["Ambiente"];
                        unaPlanta.Altura = (int)reader["Altura"];
                        unaPlanta.NombresVulgares = (string)reader["NombresVulgares"];
                        unaPlanta.TipoPlanta = new TipoPlanta();
                        unaPlanta.TipoPlanta.IdTipoPlanta = (int)reader["IdTipoPlanta"];
                        unaPlanta.TipoPlanta.TipoNombre = (string)reader["TipoNombre"];
                        unaPlanta.TipoPlanta.TipoDesc = (string)reader["TipoDesc"];
                        unaPlanta.FichaCuidados = new FichaCuidados();
                        unaPlanta.FichaCuidados.IdFichaCuidados = (int)reader["IdFichaCuidados"];
                        unaPlanta.FichaCuidados.Riego = (string)reader["Riego"];
                        unaPlanta.FichaCuidados.Temperatura = (int)reader["Temperatura"];
                        unaPlanta.FichaCuidados.TipoIluminacion = new TipoIluminacion();
                        unaPlanta.FichaCuidados.TipoIluminacion.IdIluminacion = (int)reader["IdTipoIluminacion"];
                        unaPlanta.FichaCuidados.TipoIluminacion.DescripcionTipoIlum = (string)reader["Tipo"];
                        unaPlanta.ListaFotos = listaFotos;
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

        // INSERT PLANTA
        public void Insert(Planta obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"Insert into dbo.Planta(NomCientifico, Descripcion, IdTipoPlanta, IdFichaCuidados, Ambiente, Altura) Values(@NombreCientifico,
            @Descripcion,  @IdTipo, @FichaCuidados, @Ambiente, @Altura)";


            command.Parameters.Add(new SqlParameter("@NombreCientifico", obj.NombreCientifico));
            command.Parameters.Add(new SqlParameter("@Descripcion", obj.Descripcion));
            command.Parameters.Add(new SqlParameter("@IdTipo", obj.TipoPlanta.IdTipoPlanta));
            command.Parameters.Add(new SqlParameter("@IdFichaCuidados", obj.FichaCuidados.IdFichaCuidados));
            command.Parameters.Add(new SqlParameter("@Ambiente", obj.Ambiente));
            command.Parameters.Add(new SqlParameter("@Altura", obj.Altura));

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

        // UPDATE PLANTA
        public void Update(Planta obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE FichaCuidados SET NomCientifico = @NombreCien, Descripcion = @Desc, IdTipoPlanta = @IdTipo, IdFichaCuidados = @IdFicha, Ambiente = @Ambiente, Altura = @Altura, NombresVulgares = @Nombres
            WHERE IdPlanta = @Id";

            command.Parameters.Add(new SqlParameter("@NombreCien", obj.NombreCientifico));
            command.Parameters.Add(new SqlParameter("@Desc", obj.Descripcion));
            command.Parameters.Add(new SqlParameter("@IdTipo", obj.TipoPlanta.IdTipoPlanta));
            command.Parameters.Add(new SqlParameter("@IdFicha", obj.FichaCuidados.IdFichaCuidados));
            command.Parameters.Add(new SqlParameter("@Ambiente", obj.Ambiente));
            command.Parameters.Add(new SqlParameter("@Altura", obj.Altura));
            command.Parameters.Add(new SqlParameter("@Nombres", obj.NombresVulgares));
            command.Parameters.Add(new SqlParameter("@Id", obj.IdPlanta));


            try
            {
                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas == 0)
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
        public IList<TipoPlanta> GetTipos()
        {
            IList<TipoPlanta> resultado = new List<TipoPlanta>();
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
        public bool InsertTipo(TipoPlanta obj)
        {
            bool exist = false;
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "declare @exist bit if NOT EXISTS(select * from dbo.TipoPlanta tp where (tp.TipoNombre = @TipoNombre)) begin insert into TipoPlanta(TipoNombre, TipoDesc) values(@TipoNombre, @TipoDesc) set @exist = 0 end else begin set @exist = 1 end select @exist as exist";
            command.Parameters.Add(new SqlParameter("@TipoNombre", obj.TipoNombre));
            command.Parameters.Add(new SqlParameter("@TipoDesc", obj.TipoDesc));
            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exist = (bool)reader["exist"];
                    }
                }

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
            return exist;

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
            catch (Exception ex)
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

        // GET FICHAS
        public IEnumerable GetFichas()
        {
            ICollection<FichaCuidados> listadoFichas = new List<FichaCuidados>();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT f.IdFichaCuidados, f.Riego, f.Temperatura, ti.IdTipoIluminacion, ti.Tipo FROM dbo.FichaCuidados f INNER JOIN dbo.TipoIluminacion ti on f.IdTipoIluminacion = ti.IdTipoIluminacion";

            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    FichaCuidados unaFicha = null;
                    while (reader.Read())
                    {
                        unaFicha = new FichaCuidados();
                        unaFicha.IdFichaCuidados = (int)reader["IdFichaCuidados"];
                        unaFicha.Riego = (string)reader["Riego"];
                        unaFicha.Temperatura = (int)reader["Temperatura"];
                        unaFicha.TipoIluminacion = new TipoIluminacion();
                        unaFicha.TipoIluminacion.IdIluminacion = (int)reader["IdTipoIluminacion"];
                        unaFicha.TipoIluminacion.DescripcionTipoIlum = (string)reader["Tipo"];
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
            return listadoFichas;
        }

        // UPDATE FICHA
        public void UpdateFicha(FichaCuidados obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE FichaCuidados SET Riego = @Riego, IdTipoIluminacion = @IdTipoIlum, Temperatura = @Temperatura WHERE IdFichaCuidados = @IdFicha";

            command.Parameters.Add(new SqlParameter("@Riego", obj.Riego));
            command.Parameters.Add(new SqlParameter("@IdTipoIlum", obj.TipoIluminacion.IdIluminacion));
            command.Parameters.Add(new SqlParameter("@Temperatura", obj.Temperatura));
            command.Parameters.Add(new SqlParameter("@IdFicha", obj.IdFichaCuidados));


            try
            {
                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas == 0)
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

        // INSERT FICHA
        public void InsertFicha(FichaCuidados obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"Insert into dbo.FichaCuidados(Riego, IdTipoIluminacion, Temperatura) Values(@Riego,
            @IdTipoIlum, @Temperatura)";


            command.Parameters.Add(new SqlParameter("@Riego", obj.Riego));
            command.Parameters.Add(new SqlParameter("@IdTipoIlum", obj.TipoIluminacion.IdIluminacion));
            command.Parameters.Add(new SqlParameter("@Temperatura", obj.Temperatura));

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

        // GET BY ID FICHA
        public FichaCuidados GetByIdFicha(int id)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT f.IdFichaCuidados, f.Riego, f.Temperatura, ti.IdTipoIluminacion, ti.Tipo FROM dbo.FichaCuidados f INNER JOIN dbo.TipoIluminacion ti on f.IdTipoIluminacion = ti.IdTipoIluminacion
            WHERE IdFichaCuidados = @Id";
            command.Parameters.Add(new SqlParameter("@Id", id));
            FichaCuidados unaFicha = null;
            try
            {
                if (connection.State.Equals(0))
                {
                    connection.Open();
                }
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        unaFicha = new FichaCuidados();
                        unaFicha.IdFichaCuidados = (int)reader["IdFichaCuidados"];                        
                        unaFicha.Riego = (string)reader["Riego"];
                        unaFicha.Temperatura = (int)reader["Temperatura"];
                        unaFicha.TipoIluminacion = new TipoIluminacion();
                        unaFicha.TipoIluminacion.IdIluminacion = (int)reader["IdTipoIluminacion"];
                        unaFicha.TipoIluminacion.DescripcionTipoIlum = (string)reader["Tipo"];
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

        // DELETE FICHA
        public void DeleteFicha(int idFicha)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM dbo.FichaCuidados WHERE IdFichaCuidados = @Id";
            command.Parameters.Add(new SqlParameter("@Id", idFicha));
            try
            {
                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                // comprobar que se hayan realizado cambios en la bd
                if (filasAfectadas == 0)
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

        // Tipo iluminacion

        // GET TIPOS ILUMINACION
        public IEnumerable GetTiposIlum()
        {
            ICollection<TipoIluminacion> listadoTipos = new List<TipoIluminacion>();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.TipoIluminacion";

            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    TipoIluminacion unTipo = null;
                    while (reader.Read())
                    {
                        unTipo = new TipoIluminacion();
                        unTipo.IdIluminacion = (int)reader["IdTipoIluminacion"];
                        unTipo.DescripcionTipoIlum = (string)reader["Tipo"];
                        listadoTipos.Add(unTipo);
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
            return listadoTipos;
        }

        // DELETE TIPO ILUMINACION
        public void DeleteTipoILum(int idTipoIlum)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM dbo.TipoIluminacion WHERE IdTipoIluminacion = @Id";
            command.Parameters.Add(new SqlParameter("@Id", idTipoIlum));
            try
            {
                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                // comprobar que se hayan realizado cambios en la bd
                if (filasAfectadas == 0)
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

        // UPDATE TIPO ILUMINACION
        public void UpdateTipoIlum(TipoIluminacion obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE TipoIluminacion SET Tipo = @TipoNombre WHERE IdTipoIluminacion = @IdTipoIlum";

            command.Parameters.Add(new SqlParameter("@TipoNombre", obj.DescripcionTipoIlum));
            command.Parameters.Add(new SqlParameter("@IdTipoIlum", obj.IdIluminacion));

            try
            {
                connection.Open();
                int filasAfectadas = command.ExecuteNonQuery();
                if (filasAfectadas == 0)
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

        // INSERT TIPO ILUMINACION
        public void InsertTipoIlum(TipoIluminacion obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO TipoIluminacion(Tipo) VALUES(@TipoNombre)";
            command.Parameters.Add(new SqlParameter("@TipoNombre", obj.DescripcionTipoIlum));

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

        // GET BY ID TIPO ILUMINACION
        public TipoIluminacion GetByIdTipoIlum(int idTipoIlum)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.TipoIluminacion WHERE IdTipoIluminacion = @Id";
            command.Parameters.Add(new SqlParameter("@Id", idTipoIlum));
            TipoIluminacion unTipoIlum = null;
            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        unTipoIlum = new TipoIluminacion();
                        unTipoIlum.DescripcionTipoIlum = (string)reader["Tipo"];
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
            return unTipoIlum;
        }

        public IList<Planta> SearchPlantas(string NombreCientifico, string TipoNombre, string Ambiente, int Altura, int Altura2)
        {

            IList<Planta> listaPlantas = new List<Planta>();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT p.IdPlanta, p.NomCientifico, p.Descripcion, p.Ambiente, p.Altura, tp.IdTipoPlanta, tp.TipoNombre, tp.TipoDesc, fc.IdFichaCuidados, fc.Riego, fc.Temperatura, ti.IdTipoIluminacion, ti.Tipo FROM dbo.Planta p INNER JOIN dbo.TipoPlanta tp ON p.IdTipoPlanta = tp.IdTipoPlanta INNER JOIN dbo.FichaCuidados fc ON p.IdFichaCuidados = fc.IdFichaCuidados INNER JOIN dbo.TipoIluminacion ti ON fc.IdTipoIluminacion = ti.IdTipoIluminacion WHERE (P.NomCientifico like '%' + @NombreCientifico + '%' OR P.NomCientifico  is null) and (P.Altura < CASE WHEN @Altura <> 0 THEN @Altura ELSE P.Altura END) and (P.Altura >= CASE WHEN @Altura2 <> 0 THEN @Altura2 ELSE P.Altura END) and tp.TipoNombre = @TipoNombre and p.Ambiente = @Ambiente ";

            command.Parameters.Add(new SqlParameter("@NombreCientifico", NombreCientifico));
            
            command.Parameters.Add(new SqlParameter("@Altura", Altura));
            command.Parameters.Add(new SqlParameter("@Altura2", Altura2));
            command.Parameters.Add(new SqlParameter("@TipoNombre", TipoNombre));
            command.Parameters.Add(new SqlParameter("@Ambiente", Ambiente));

            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    Planta planta = null;
                    //List<Foto> listaFotos = new List<Foto>();
                    while (reader.Read())
                    {
                        planta = new Planta();
                        planta.IdPlanta = (int)reader["IdPlanta"];
                        planta.NombreCientifico = (string)reader["NomCientifico"];
                        planta.Descripcion = (string)reader["Descripcion"];
                        planta.Ambiente = (string)reader["Ambiente"];
                        planta.Altura = (int)reader["Altura"];
                        planta.TipoPlanta = new TipoPlanta();
                        planta.TipoPlanta.IdTipoPlanta = (int)reader["IdTipoPlanta"];
                        planta.TipoPlanta.TipoNombre = (string)reader["TipoNombre"];
                        planta.TipoPlanta.TipoDesc = (string)reader["TipoDesc"];
                        planta.FichaCuidados = new FichaCuidados();
                        planta.FichaCuidados.IdFichaCuidados = (int)reader["IdFichaCuidados"];
                        planta.FichaCuidados.Riego = (string)reader["Riego"];
                        planta.FichaCuidados.Temperatura = (int)reader["Temperatura"];
                        planta.FichaCuidados.TipoIluminacion = new TipoIluminacion();
                        planta.FichaCuidados.TipoIluminacion.IdIluminacion = (int)reader["IdTipoIluminacion"];
                        planta.FichaCuidados.TipoIluminacion.DescripcionTipoIlum = (string)reader["Tipo"];
                        //planta.ListaFotos = listaFotos; //Agregar la lista de fotos de cada planta

                        listaPlantas.Add(planta);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }
            return listaPlantas;
        }


        public Planta GetListas()
        {
            IList<FichaCuidados> listaFichas = new List<FichaCuidados>();
            IList<TipoPlanta> listaTipos = new List<TipoPlanta>();
            IList<Foto> listaFotos = new List<Foto>();
            Planta planta = new Planta();
            planta.ListaFotos = (List<Foto>)listaFotos;
            planta.ListaTipoPlantas = (List<TipoPlanta>)listaTipos;
            planta.ListaFichas = (List<FichaCuidados>)listaFichas;

            IDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.TipoPlanta SELECT * FROM dbo.FichaCuidados SELECT * FROM dbo.Foto";

            try
            {
                connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    FichaCuidados ficha = null;
                    TipoPlanta tipo = null;
                    Foto foto = null;
                    while (reader.Read())
                    {
                        tipo = new TipoPlanta();
                        tipo.IdTipoPlanta = (int)reader["IdTipoPlanta"];
                        tipo.TipoNombre = (string)reader["TipoNombre"];
                        tipo.TipoDesc = (string)reader["TipoDesc"];
                        listaTipos.Add(tipo);                        
                    }
                    while (reader.Read())
                    {
                        ficha = new FichaCuidados();
                        ficha.IdFichaCuidados = (int)reader["IdFichaCuidados"];
                        listaFichas.Add(ficha);
                    }
                    while (reader.Read())
                    {
                        foto = new Foto();
                        foto.IdFoto = (int)reader["IdFoto"];
                        foto.Nombre = (string)reader["Nombre"];
                        listaFotos.Add(foto);
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
            return planta;
        }


        public void Insert(Foto obj)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = @"Insert into dbo.Plantas(NomCientifico, Descripcion, IdTipoPlanta, IdFichaCuidados, Ambiente, Altura) Values(@NombreCientifico,
            @Descripcion,  @IdTipo, @FichaCuidados, @Ambiente, @Altura)";

            command.Parameters.Add(new SqlParameter("@Imagen", obj.Imagen));

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
    }
}
