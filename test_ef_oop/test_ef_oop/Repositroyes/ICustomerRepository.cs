using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_ef_oop.Models;

namespace test_ef_oop.Repositroyes
{
    public interface ICustomerRepository
    {
        bool Insert(customer entity);

        bool Update(customer entity);

        bool Delete(int id);

        DataTable Load();

    }
}
