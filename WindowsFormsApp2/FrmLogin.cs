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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            //valido si el archivo txt existe
            if (ClaseUsuarios.Func_ExisteTxt() == true)
            {
                //valido si la persona ingresa los datos
                if (TxtUsuario.Text.Trim().Length > 0 && TxtPassword.Text.Trim().Length > 0)
                {
                    string[] arre = ClaseUsuarios.Func_DatosUsuario(TxtUsuario.Text);
                    //pregunto el usuario es igual
                    if (TxtUsuario.Text == arre[0])
                    {
                        //pregunto si el password es el mismo
                        if (TxtPassword.Text == arre[1])
                        {
                            //oculto el formulario actual
                            this.Hide();
                            //creo una instanacia del formulario que voy a llamar
                            FrmMenu frm = new FrmMenu();
                            //muestro el formulario
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Contrasena Errada", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Usuario NO Existe", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Ingrese los Datos", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Archivo TXT NO Existe", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
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
