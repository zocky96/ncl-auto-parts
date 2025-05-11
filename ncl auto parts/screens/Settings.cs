using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts.screens
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            main.closeConn();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
