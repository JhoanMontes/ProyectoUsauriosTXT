using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rpta = new DialogResult();
            rpta = MessageBox.Show("Desea Salir de la Aplicacion ?", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rpta == DialogResult.OK) 
            { 
                Application.Exit();
            }
        }
    }
}
