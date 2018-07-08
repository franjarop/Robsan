using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLINQ_RobsanNET;
using RobsanNET.Genericos;

namespace RobsanNET.Seguridad
{
    public partial class Usuario : Form
    {
        #region Propiedades
        UsuarioController usuarioController = new UsuarioController();
        USPGETINFOUSUARIOResult dataUsuario;
        #endregion
        public Usuario()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            usuarioController.obtenerPermisoSistema(lstPermisosSinAsignar);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            #region btnGrabar_Click
            Validador validador =  usuarioController.validarInformacion(groupUsuario);
            if (validador.Resultado)
            {
                usuarioController.guardarInformacion(txtNombre, txtApellido, txtUsuario, txtContraseña);
                usuarioController.GuardarPermisosUsuario(txtUsuario, lstPermisosAsignados);
                MessageBox.Show("El usuario fue modificado o dado de alta","Aviso",MessageBoxButtons.OK);
                this.Close();
            }
            else
                MessageBox.Show(validador.Mensaje,"Aviso",MessageBoxButtons.OKCancel);
            #endregion
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            usuarioController.AsignarPermiso(lstPermisosAsignados, lstPermisosSinAsignar);
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            usuarioController.EliminarPermisos(lstPermisosAsignados, lstPermisosSinAsignar);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            #region btnBuscar_Click
            string usuario = txtBuscar.Text.ToUpper().Trim();
            dataUsuario = usuarioController.ObtenerInformacionUsuario(usuario);
            txtUsuario.Text = dataUsuario.Usuario;
            txtNombre.Text = dataUsuario.Nombre;
            txtApellido.Text = dataUsuario.Apellido;

            usuarioController.MostrarPermisosAsignados(lstPermisosAsignados, lstPermisosSinAsignar, usuario);
           
           
            
            #endregion
        }
    }
}
