using RobsanNET.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobsanNET.BLLRobsanNET;
using DataLINQ_RobsanNET;

namespace RobsanNET.Seguridad
{
   
    class LoginController
    {
        #region Propiedades
        Validador validador;
        BLLSeguridad seguridad;
        #endregion
        public LoginController()
        {
            validador = new Validador();
            seguridad = new BLLSeguridad();
        }
        internal Validador ValidarControles(System.Windows.Forms.TextBox txtUsuario, System.Windows.Forms.TextBox txtContraseña)
        {
            #region ValidarControles
            try
            {
                validador.Resultado = true;
                if(String.IsNullOrEmpty(txtUsuario.Text.Trim()))
                {
                    validador.Resultado = false;
                    validador.Mensaje = "El campo de Usuario no puede quedar vacio";
                    return validador;
                }
                else
                {
                    if (txtUsuario.Text.ToUpper().Equals("CONFIGURACION"))
                        validador.Resultado = false;
                }
                if(String.IsNullOrEmpty(txtContraseña.Text.Trim()))
                {
                    validador.Resultado = false;
                    validador.Mensaje = "El campo de contraseña no puede quedar vacio";
                    return validador;
                }
                return validador;
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        internal bool ValidadSesion(System.Windows.Forms.TextBox txtUsuario, System.Windows.Forms.TextBox txtContraseña)
        {
            #region ValidadSesion
            try
            {
                bool resultado = false;
                resultado =  seguridad.ValidarSesionBLL(txtUsuario.Text.Trim().ToUpper(), txtContraseña.Text.Trim());
                return resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal void AsignarPermisos(string usuario, string contraseña)
        {
            DatosUsuario.Usuario = usuario;
            DatosUsuario.Contraseña = contraseña;
            List<USPGETPERMISOUSUARIOResult> lstPermisoUsuario = seguridad.ObtenerPermisosUsuarioBLL(usuario);
            foreach (USPGETPERMISOUSUARIOResult permiso in lstPermisoUsuario)
            {
                DatosUsuario.Permisos.Add(permiso.PermisoID.ToString());                
            }
            
            
        }

        internal bool ValidarControlesConfiguracion(System.Windows.Forms.TextBox txtUsuario, System.Windows.Forms.TextBox txtContraseña)
        {
            #region 
            if (!string.IsNullOrEmpty(txtUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtContraseña.Text.Trim()))
            {
                if (txtUsuario.Text.Trim().Equals("Configuracion") && txtContraseña.Text.Trim().Equals("Visual2018"))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            #endregion
        }
    }
}
