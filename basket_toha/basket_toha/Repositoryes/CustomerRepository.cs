using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basket_toha.Models;
using basket_toha.Database;

namespace basket_toha.Repositoryes
{
    public class CustomerRepository : ICustomerRepository
    {
        bool ICustomerRepository.Insert(customer entity)
        {
            try{
                DBConecction.BeginTransaction();

                Dictionary<string, object> Fields = new Dictionary<string, object>();
                Fields.Add("kode", entity.kode);
                Fields.Add("nama", entity.nama);
                DBConecction.Insert(Fields, "customerss");

                DBConecction.CommitTransaction();
                return true;
            }
            catch
            {
                DBConecction.RollBackTransaction();
                return false;
            }

        }

        bool ICustomerRepository.Update(customer entity)
        {
            throw new NotImplementedException();
        }

        bool ICustomerRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        DataTable ICustomerRepository.Load()
        {
            throw new NotImplementedException();
        }

        
    }
}
