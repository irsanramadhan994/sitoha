using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_ef_oop.Models;

namespace test_ef_oop.Repositroyes
{
    public interface IUserRepository
    {
        IEnumerable<user> GetAll();
        user GetById(int EmployeeID);
        bool GetByUserPass(user data);
        DataTable LoadUser();
        void Insert(user data);
        void Update(user data);
        void Delete(int userID);
        void Save();
    }
}
