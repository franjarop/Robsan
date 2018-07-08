using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RobsanNET.Operaciones;
using RobsanNET.Seguridad;
using RobsanNET.Genericos;
using RobsanNET.Operaciones.Ventas;
using RobsanNET.Consultas.Ventas;

namespace RobsanNET
{
    public partial class Menu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Propiedades
        MenuController controller;
        #endregion
        public Menu()
        {
            controller = new MenuController();
            InitializeComponent();
            

            #region Configuracion de Permisos
            foreach (var permiso in DatosUsuario.Permisos)
            {
                int nPemiso = Convert.ToInt32(permiso);
                if (nPemiso == 1)
                {
                    btnArticulos.Visible = true;
                    btnUsuarios.Visible = true;
                    btnVentas.Visible = true;
                    btnConsultaVentas.Visible = true;
                }
                else if (nPemiso ==2)
                {
                    btnArticulos.Visible = true;
                    btnVentas.Visible = true;
                }
                else if (nPemiso == 3)
                {
                    btnArticulos.Visible = true;
                }
                else if (nPemiso == 4)
                {
                    btnArticulos.Visible = true;
                }
            }
            #endregion

            #region Envio de Stock Bajo
            EnviarReporteDeArticulos();
            #endregion
        }

       
        void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            ArticuloConsulta ventana = new ArticuloConsulta();
            ventana.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuario ventana = new Usuario();
            ventana.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            PuntoVenta ventanaVentas = new PuntoVenta();
            ventanaVentas.Show();
        }

        private void btnConsultaVentas_Click(object sender, EventArgs e)
        {
            ConsultaVentas ventanaConsulta = new ConsultaVentas();
            ventanaConsulta.ShowDialog();
        }
        private void EnviarReporteDeArticulos()
        {
            try
            {
                if(controller.NotificarCorreo())
                if (!controller.EnviarReporteStock())
                    MessageBox.Show("Por el momento no podemos notificar el correo, revise su conexion de internet", "Aviso", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       
       
    }
}