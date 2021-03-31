using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using basket_toha.Controllers;

namespace basket_toha.Forms
{
    public partial class frmCustomer : Form
    {

        CustomerController customerController;
        public frmCustomer()
        {
            InitializeComponent();
            customerController = new CustomerController(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (customerController.SaveCustomer())
            {
                MessageBox.Show("Succes save");
            }
            else
            {
                MessageBox.Show("Failed save");
            }
        }
    }
}
