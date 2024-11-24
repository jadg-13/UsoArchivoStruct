using Registro.Dao;
using Registro.Estructuras;
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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadFrm frm = new CiudadFrm();
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var opcion = MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.timer_Tick);
            timer.Start();
            UltimosRegistros();
        }

        //Ver ultimos 5 registros
        private void UltimosRegistros()
        {
            CiudadDao dao = new CiudadDao();
            List<Ciudad> ciudades = new List<Ciudad>();
            ciudades = dao.Listar("");

            foreach(Ciudad c in ciudades)
            {
                LstUltReg.Items.Add(c.Nombre);
            }
            
        

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            LblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
