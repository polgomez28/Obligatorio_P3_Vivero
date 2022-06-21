using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccesEF;

namespace DataAccesEF
{
    public class RepositorioComprasEF : IRepositorioCompras
    {
        ViveroContext _dbContext;

        public RepositorioComprasEF(ViveroContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Compra> Get()
        {
            throw new NotImplementedException();
        }

        public Compra GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Compra obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Compra obj)
        {
            throw new NotImplementedException();
        }
    }
}
