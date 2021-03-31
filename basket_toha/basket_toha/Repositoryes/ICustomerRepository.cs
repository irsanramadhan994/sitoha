using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basket_toha.Models;

namespace basket_toha.Repositoryes
{
    public interface ICustomerRepository
    {
        bool Insert(customer entity);

        bool Update(customer entity);

        bool Delete(int id);

        DataTable Load();

    }
}
