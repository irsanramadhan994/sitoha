using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_ef_oop.Repositroyes;
using test_ef_oop.Models;

namespace test_ef_oop.Controllers
{
    class UserController
    {
        private UserRepository _repo;
        private IUserRepository _irepo;
        private frmLogin frm;
        public UserController(frmLogin frm) {
            _repo = new UserRepository(new Models.DBContext());
            _irepo = new UserRepository(new Models.DBContext());
            this.frm = frm;
        }

        public void TestLoad() {
            frm.dgvUser.DataSource = _repo.LoadUser();
            List<user> test = (List<user>)_irepo.GetAll();

            frm.dgvUser.DataSource = test; 
        }
    }
}
