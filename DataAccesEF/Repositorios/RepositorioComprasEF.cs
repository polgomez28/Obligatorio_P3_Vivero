using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IList<Compras> Get()
        {
            throw new NotImplementedException();
        }

        public Compras GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Compras obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Compras obj)
        {
            throw new NotImplementedException();
        }
    }
}
