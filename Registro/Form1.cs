using Registro.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadFrm frm = new CiudadFrm();
            frm.Show();
        }
    }
}
