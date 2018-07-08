using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLINQ_RobsanNET;
using System.Data;
using RobsanNET.Seguridad;

namespace RobsanNET.BLLRobsanNET
{
    class BLLSeguridad
    {
        DataTables dataTable;
        public TAutUsuario _autUsuario;
        public TPermisoUsuario _permisoUsuario;
        
        public BLLSeguridad() {
            dataTable = new DataTables();
            _autUsuario = new TAutUsuario();
            _permisoUsuario = new TPermisoUsuario();
        }
        
        public List<USPGETPERMISOSResult> obtenerPermisoSistemaBLL()
        {
            #region obtenerPermisoSistema
            try
            {
                return dataTable.obtenerPermisoSistemaDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal void guardarUsuarioBLL()
        {
            try
            {
                dataTable.guardarUsuarioDAL(_autUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void GuardarPermisosUsuarioBLL()
        {
            #region GuardarPermisosUsuarioBLL
            try
            {
                dataTable.GuardarPermisosUsuarioDAL(_permisoUsuario);
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        internal bool ValidarSesionBLL(string usuario, string contraseña)
        {
            try
            {
                UsuarioController usuarioController = new UsuarioController();
                TAutUsuario autUsuario =  dataTable.ValidarSesionDAL(usuario, contraseña);
                if (autUsuario != null)
                {
                    String contraseñaDesencryptada = usuarioController.descrencryptarClave(autUsuario.Password);
                    if (contraseña == contraseñaDesencryptada)
                        return true;
                    else
                        return false;
                }
                return false;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<USPGETPERMISOUSUARIOResult> ObtenerPermisosUsuarioBLL(string usuario)
        {
            #region ObtenerPermisosUsuarioBLL
            try
            {
                return dataTable.ObtenerPermisoUsuarioDAL(usuario);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            #endregion
        }

        internal USPGETINFOUSUARIOResult ObtenerInformacionUsuarioBLL(string usuario)
        {
            #region ObtenerInformacionUsuarioBLL
            try
            {
                return dataTable.ObtenerInformacionUsuarioDAL(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal void BorrarPermisosUsuarioBLL(string usuario)
        {
            try
            {
                dataTable.BorrarPermisosUsuarioDAL(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
