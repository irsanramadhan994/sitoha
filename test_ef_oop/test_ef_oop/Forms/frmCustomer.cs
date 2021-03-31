using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_ef_oop.Controllers;

namespace test_ef_oop.Forms
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
            else {
                MessageBox.Show("Failed save");
            }
        }
    }
}
