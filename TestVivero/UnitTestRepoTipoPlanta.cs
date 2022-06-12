using DataAccesEF;
using Dominio;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestVivero
{
    public class Tests
    {
        ViveroContext dbcontex = null;
        private RepositorioTipoPlantaEF repoTipo;

        //Repositorio
        //IRepositorioTipoPlanta repoTipo = null;
        [SetUp]
        public void Setup()
        {
            //Instancio el repositorio
            repoTipo = new RepositorioTipoPlantaEF(dbcontex);
        }

        [Test]
        public void TestInsertTipoPlanta()
        {
            //Creamos el tipo a insertar
            TipoPlanta tipo = new TipoPlanta()
            {
                TipoNombre = "Matas",
                TipoDesc = "Probando insert de desc tipo"
                
            };
            //Insertamos
            bool ok = repoTipo.Add(tipo);

            // Validaciones
            Assert.IsTrue(ok);
            Assert.AreNotEqual(0, tipo.IdTipoPlanta);
            Assert.IsNotNull(tipo);
        }
        [Test]
        public void TestUpdateTipo()
        {
            TipoPlanta tipo = new TipoPlanta();
            tipo.IdTipoPlanta = 1;
            tipo = repoTipo.GetByID(tipo.IdTipoPlanta);
            //Modificamos la descripcion
            tipo.TipoDesc = "Prueba Modificacion";
            repoTipo.Update(tipo);
            tipo = null;
            //Me traigo nuevamente el tipo por id y hago el test
            tipo = repoTipo.GetByID(tipo.IdTipoPlanta);

            //Validaciones
            Assert.IsNotNull(tipo);
            Assert.AreEqual("Prueba Modificacion", tipo.TipoDesc);

        }

        [Test]
        public void TestGetByIDTipo()
        {
            TipoPlanta tipo = new TipoPlanta();
            tipo = repoTipo.GetByID(1);

            //Validaciones
            Assert.IsNotNull(tipo);
            Assert.AreNotEqual(0, tipo.IdTipoPlanta);
        }

        [Test]
        public void TestGetByNombreTipo()
        {
            TipoPlanta tipo = new TipoPlanta();
            string nombre = "Matas";
            tipo = repoTipo.GetByNombreTipo(nombre);

            //Validaciones
            Assert.IsNotNull(tipo);
            Assert.AreNotEqual(0, tipo.IdTipoPlanta);
        }

        [Test]
        public void TestGetTipoPlantas()
        {
            IList<TipoPlanta> tipos = null;
            tipos = repoTipo.GetTipoPlantas();
            //Validaciones
            Assert.IsNotNull(tipos);
        }

        [Test]
        public void RemoveTipo()
        {
            TipoPlanta tipo = new TipoPlanta();
            tipo.IdTipoPlanta = 1;
            tipo = repoTipo.GetByID(tipo.IdTipoPlanta);
            //Removemos el tipo
            bool exito = repoTipo.Remove(tipo);
            //Validaciones
            Assert.IsTrue(exito);

        }
    }
}