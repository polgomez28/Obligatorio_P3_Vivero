﻿using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAcces
{
    class RepositorioPlanta : IRepositorioPlanta
    {
        private IDbConnection conneccion;

        // Constructor de RepositorioPlanta
        public RepositorioPlanta(IDbConnection con)
        {
            this.conneccion = con;
        }
        public void Delete(int id)
        {
            IDbCommand command = conneccion.CreateCommand();
            command.CommandText = "DELETE FROM dbo.Plantas WHERE Id = @Id";
            command.Parameters.Add(new SqlParameter("@Id", id));
            try
            {
                conneccion.Open();
                command.ExecuteNonQuery();
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
        }

        public IEnumerable Get()
        {
            ICollection<Planta> listadoPlantas = new List<Planta>();
            IDbCommand command = conneccion.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.Plantas";

            try
            {
                conneccion.Open();
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
                conneccion.Close();
                conneccion.Dispose();
            }
            return listadoPlantas;
        }

        public Planta GetByID(int id)
        {
            IDbCommand command = conneccion.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.Plantas WHERE Id = @Id";
            command.Parameters.Add(new SqlParameter("@Id", id));
            Planta unaPlanta = null;
            try
            {
                conneccion.Open();
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
                conneccion.Close();
                conneccion.Dispose();
            }
            return unaPlanta;
        }

        public void Insert(Planta obj)
        {
            IDbCommand command = conneccion.CreateCommand();
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
                conneccion.Open();
                command.ExecuteNonQuery();

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
    }
}
