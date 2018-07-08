using RobsanNET.Parametros;
using RobsanNET.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobsanNET.Genericos.Ventanas
{
    public partial class ActivacionPermiso : Form
    {
        #region propiedades
        LoginController controller;
        #endregion
        public ActivacionPermiso()
        {
            InitializeComponent();
            controller = new LoginController();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (controller.ValidadSesion(txtUsuario, txtContraseña))
            {
                Acciones.MODO_ELIMINACION = true;
                this.Close();
            }
            else
                MessageBox.Show("Datos incorrectos...", "Aviso", MessageBoxButtons.OK);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
