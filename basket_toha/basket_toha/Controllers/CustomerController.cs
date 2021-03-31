using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basket_toha.Models;
using basket_toha.Repositoryes;
using basket_toha.Forms;
using basket_toha.Database;

namespace basket_toha.Controllers
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
