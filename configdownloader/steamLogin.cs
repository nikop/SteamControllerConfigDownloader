using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace configdownloader
{
    public partial class steamLogin : Form
    {
        public steamLogin()
        {
            InitializeComponent();
        }

        private void steamLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        void updateInputs()
        {
            button2.Enabled = usernameInput.Text == "" && passwordInput.Text == "";
        }

        private void usernameInput_TextChanged(object sender, EventArgs e)
        {
            updateInputs();
        }

        private void passwordInput_TextChanged(object sender, EventArgs e)
        {
            updateInputs();
        }
    }
}
