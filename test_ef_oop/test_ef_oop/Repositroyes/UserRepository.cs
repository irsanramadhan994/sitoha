using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using test_ef_oop.Models;
using System.Data;

namespace test_ef_oop.Repositroyes
{
    class UserRepository : IUserRepository
    {
        private readonly DBContext _context;

        public UserRepository()
        {
            _context = new DBContext();
        }

        public UserRepository(DBContext context)
        {
            _context = context;
        }

        IEnumerable<user> IUserRepository.GetAll()
        {
            return _context.user.ToList();
        }

        user IUserRepository.GetById(int IdUser)
        {
            return _context.user.Find(IdUser);
        }

        bool IUserRepository.GetByUserPass(user data)
        {
            return _context.user.Where(u => u.user_name.Contains(data.user_name)).ToList().Count() > 0;
        }

        void IUserRepository.Insert(user data)
        {
            _context.user.Add(data);
        }

        void IUserRepository.Update(user data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }

        void IUserRepository.Delete(int IdUser)
        {
            user data = _context.user.Find(IdUser);
            _context.user.Remove(data);
        }

        void IUserRepository.Save()
        {
            _context.SaveChanges();
        }

        public DataTable LoadUser() {
            DataTable dtResult = new DataTable();
            //dtResult = _context.Database.SqlQuery<DataTable>("SELECT kode, nama FROM dbo.customer").FirstOrDefault();
            //var data = _context.Database.SqlQuery<string>("SELECT kode FROM dbo.customer").ToArray()
            return dtResult;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
