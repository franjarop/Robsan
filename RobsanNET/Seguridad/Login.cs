using RobsanNET.Genericos;
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


namespace RobsanNET
{
    public partial class Login : Form
    {
        #region Propiedades
        LoginController controller;
        Validador validador;
        #endregion
        public Login()
        {
            controller = new LoginController();
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            validador = controller.ValidarControles(txtUsuario, txtContraseña);
            if (validador.Resultado)
            {
                if (controller.ValidadSesion(txtUsuario, txtContraseña))
                {
                    controller.AsignarPermisos(txtUsuario.Text.Trim().ToUpper(), txtContraseña.Text.Trim());
                    Menu ventana = new Menu();
                    ventana.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("Datos incorrectos", "Aviso", MessageBoxButtons.OK);
               
               
            }
            else if (controller.ValidarControlesConfiguracion(txtUsuario, txtContraseña))
            {
                ConfiguracionConexion ventanaConfiguracion = new ConfiguracionConexion();
                ventanaConfiguracion.ShowDialog();
            }
            else
                MessageBox.Show(validador.Mensaje, "Aviso", MessageBoxButtons.OK);
           
            
        }
    }
}
