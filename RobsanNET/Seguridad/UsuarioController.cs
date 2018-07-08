using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobsanNET.BLLRobsanNET;
using DataLINQ_RobsanNET;
using System.Windows.Forms;
using RobsanNET.Genericos;

namespace RobsanNET.Seguridad
{
    class UsuarioController:BLLSeguridad
    {
        BLLSeguridad seguridad;
        Validador validador;
        List<USPGETPERMISOSResult> lstPermisos;
        public UsuarioController() 
        {
            seguridad = new BLLSeguridad();
            validador = new Validador();
        }

        internal void obtenerPermisoSistema(DevExpress.XtraEditors.ListBoxControl lstPermisosSinAsignar)
        {
            lstPermisos = seguridad.obtenerPermisoSistemaBLL();
            try
            {
                foreach (USPGETPERMISOSResult permiso in lstPermisos)
                {
                    lstPermisosSinAsignar.Items.Add(permiso.PermisoID + " - " + permiso.Descripcion);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion que me permite validar que se hayen llenado los datos obligatorios
        /// </summary>
        /// <param name="groupUsuario"></param>
        /// <returns></returns>
        internal Validador validarInformacion(System.Windows.Forms.GroupBox groupUsuario)
        {
            #region validarInformacion
            try
            {
                validador.Mensaje = String.Empty;
                validador.Resultado = true;
                foreach (Control  control in groupUsuario.Controls)
                {
                    if(control is TextBox)
                    {
                        if (string.IsNullOrEmpty(control.Text))
                        {
                            validador.Resultado = false;
                            validador.Mensaje = "El campo de: " + control.Tag + " no puede quedar vacio";
                            break;
                        }
                    }
                    
                }
                return validador;
            }
            catch (Exception ex) 
            {                
                throw ex;
            }
            #endregion
        }

        internal void guardarInformacion(TextBox txtNombre, TextBox txtApellido, TextBox txtUsuario, TextBox txtContraseña)
        {
            try
            {
                seguridad._autUsuario.Nombre = txtNombre.Text.ToUpper().Trim();
                seguridad._autUsuario.Apellido = txtApellido.Text.ToUpper().Trim();
                seguridad._autUsuario.Usuario = txtUsuario.Text.ToUpper().Trim();
                seguridad._autUsuario.Password = encryptarClave(txtContraseña.Text.Trim());
                seguridad._autUsuario.Actualizacion = DateTime.Now;
                seguridad._autUsuario.Borrado = false;
                seguridad.guardarUsuarioBLL();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public string encryptarClave(string contraseña)
        {
            String resultado = string.Empty;
            byte[] encryptar = System.Text.Encoding.Unicode.GetBytes(contraseña);
            resultado = Convert.ToBase64String(encryptar);
            return resultado;
        }

        public string descrencryptarClave(string contraseña)
        {
            String resultado = string.Empty;
            byte[] desencryptar = Convert.FromBase64String(contraseña);
            resultado = System.Text.Encoding.Unicode.GetString(desencryptar);
            return resultado;
        }

        internal void AsignarPermiso(DevExpress.XtraEditors.ListBoxControl lstPermisosAsignados, DevExpress.XtraEditors.ListBoxControl lstPermisosSinAsignar)
        {
            lstPermisosAsignados.Items.Add(lstPermisosSinAsignar.SelectedItem);
            lstPermisosSinAsignar.Items.Remove(lstPermisosSinAsignar.SelectedItem);
        }

        internal void EliminarPermisos(DevExpress.XtraEditors.ListBoxControl lstPermisosAsignados, DevExpress.XtraEditors.ListBoxControl lstPermisosSinAsignar)
        {
            lstPermisosSinAsignar.Items.Add(lstPermisosAsignados.SelectedItem);
            lstPermisosAsignados.Items.Remove(lstPermisosAsignados.SelectedItem);
        }


        internal void GuardarPermisosUsuario(TextBox txtUsuario, DevExpress.XtraEditors.ListBoxControl lstPermisosAsignados)
        {
            #region GuardarPermisosUsuario
            seguridad.BorrarPermisosUsuarioBLL(txtUsuario.Text.ToUpper().Trim());
            foreach (var permiso in lstPermisosAsignados.Items)
            {
                seguridad = new BLLSeguridad();
                seguridad._permisoUsuario.PermisoID = Convert.ToDecimal(permiso.ToString().Split('-')[0]);
                seguridad._permisoUsuario.Usuario = txtUsuario.Text.Trim().ToUpper();
                seguridad.GuardarPermisosUsuarioBLL();
            }
            #endregion
        }

        internal USPGETINFOUSUARIOResult ObtenerInformacionUsuario(string usuario)
        {
            #region ObtenerInformacionUsuario
            try
            {
                return seguridad.ObtenerInformacionUsuarioBLL(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal void MostrarPermisosAsignados(DevExpress.XtraEditors.ListBoxControl lstPermisosAsignados, DevExpress.XtraEditors.ListBoxControl lstPermisosSinAsignar, string usuario)
        {
            List<USPGETPERMISOUSUARIOResult> lstPermisoUsuario = seguridad.ObtenerPermisosUsuarioBLL(usuario);
            foreach (USPGETPERMISOUSUARIOResult permiso in lstPermisoUsuario)
            {
                foreach (USPGETPERMISOSResult permisoGral in lstPermisos)
                {
                    if (permisoGral.PermisoID == permiso.PermisoID)
                    {
                        lstPermisosAsignados.Items.Add(permisoGral.PermisoID + " - " + permisoGral.Descripcion);
                        lstPermisosSinAsignar.Items.Remove(permisoGral.PermisoID + " - " + permisoGral.Descripcion);
                    }
                        
                }
            }
        }
    }
}
