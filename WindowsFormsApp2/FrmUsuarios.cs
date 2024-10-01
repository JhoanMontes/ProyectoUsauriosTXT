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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            //cerrar el formulario
            this.Close();
            //quitar de la memoria
            this.Dispose();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //habilitar
            TxtID.Enabled=true;
            TxtPassword.Enabled=true;
            TxtUsuario.Enabled=true;
            BtnGuardar.Enabled=true;
            BtnCancelar.Enabled=true;
            //deshabilita
            BtnNuevo.Enabled = false;
            BtnEditar.Enabled=false;
            BtnEliminar.Enabled=false;
            BtnSalir.Enabled=false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //deshabilitar
            TxtID.Enabled = false;
            TxtPassword.Enabled = false;
            TxtUsuario.Enabled = false;
            BtnGuardar.Enabled = false;
            BtnCancelar.Enabled = false;
            //habilita
            BtnNuevo.Enabled = true;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnSalir.Enabled = true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            //deshabilitar
            TxtID.Enabled = false;
            TxtPassword.Enabled = false;
            TxtUsuario.Enabled = false;
            BtnGuardar.Enabled = false;
            BtnCancelar.Enabled = false;
            //habilita
            BtnNuevo.Enabled = true;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
            BtnSalir.Enabled = true;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            string[] arreglo = ClaseUsuarios.Func_LeerArchivo();
            for (int i = 0; i < arreglo.Length; i++)
            {
                string[] usuario = arreglo[i].Split(',');
                DgvUsuarios.Rows.Insert(i, usuario[0], usuario[1], usuario[2]);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult rpta = new DialogResult();
            long ideliminar = Convert.ToInt64(DgvUsuarios.Rows[DgvUsuarios.CurrentRow.Index].Cells["ID"].Value);
            string nombre = DgvUsuarios.Rows[DgvUsuarios.CurrentRow.Index].Cells["Usuario"].Value.ToString();
            rpta = MessageBox.Show("Desea Eliminar ID: "+ ideliminar.ToString() + "\n Usuario: "+ nombre + "  ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.Yes)
            {
                ClaseUsuarios. Func_EliminarUsuario(ideliminar.ToString());
            }
        }
    }
}
