using Microsoft.Reporting.WinForms;
using Registro.Dao;
using Registro.DataSet;
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

       
        private void UltimosRegistros()
        {
            CiudadDao dao = new CiudadDao();
            List<Ciudad> ciudades = new List<Ciudad>();
            ciudades = dao.Listar("");
            LstUltReg.Items.Clear();
            foreach (Ciudad c in ciudades)
            {
                LstUltReg.Items.Add(c.Nombre + " - " + c.Poblacion.ToString());
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            LblFecha.Text = DateTime.Now.ToLongDateString();
            
        }

        private void mostrarPoblaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimirReporte();
        }

        private void ImprimirReporte()
        {
            CiudadDao ciudades = new CiudadDao();
            
            ReportDataSource dataSource = new ReportDataSource("DsDatos", ciudades.OrdenarPoblacion());

            FrmReportes frmReportes = new FrmReportes();
            frmReportes.reportViewer1.LocalReport.DataSources.Clear();
            frmReportes.reportViewer1.LocalReport.DataSources.Add(dataSource);
            //Configurar el archivo de reporte
            frmReportes.reportViewer1.LocalReport.ReportEmbeddedResource = "Registro.Reportes.RptPoblacion.rdlc";
            //Refrescar el reporte
            frmReportes.reportViewer1.RefreshReport();

            //Visualizar el formulario
            frmReportes.ShowDialog();
        }
    }
}
