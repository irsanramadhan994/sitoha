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
using test_ef_oop.Database;

namespace test_ef_oop
{
    public partial class frmLogin : Form
    {
        UserController _userController;
        public frmLogin()
        {
            InitializeComponent();
            DBConecction.OpenConnection();
            _userController = new UserController(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _userController.TestLoad();
        }
    }
}
