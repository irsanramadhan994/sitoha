using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_ef_oop.Models;
using test_ef_oop.Repositroyes;
using test_ef_oop.Forms;
using test_ef_oop.Database;

namespace test_ef_oop.Controllers
{
    public class CustomerController
    {
        private frmCustomer frm;
        private ICustomerRepository repo;
        public CustomerController(frmCustomer frm) {
            this.frm = frm;
            repo = new CustomerRepository();
        }

        public bool SaveCustomer(){
            try {
                customer data = new customer();
                data.kode = frm.txtKode.Text;
                data.nama = frm.txtNama.Text;
                repo.Insert(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
