using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dominio;
namespace DataAccesEF
{
    public class RepositorioDePlazaEF : IRepositorioDePlaza
    {
        ViveroContext _dbContext;

        public RepositorioDePlazaEF(ViveroContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DePlaza> Get()
        {
            throw new NotImplementedException();
        }

        public DePlaza GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DePlaza obj)
        {

            try
            {

                _dbContext.Add<DePlaza>(obj);
                _dbContext.SaveChanges();
            }
            catch (SqlException ex)
            {

                throw;
            }
            
        }

        public void Update(DePlaza obj)
        {
            throw new NotImplementedException();
        }
    }
}
