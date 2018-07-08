using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLINQ_RobsanNET
{
    public class DataTables
    {
        #region Propiedades
        public DataRobsanNETDataContext dataContext;
        #endregion
       
        public DataTables() {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["conexionProduccion"].ConnectionString;
            dataContext = new DataRobsanNETDataContext();
        }

        #region SEGURIDAD
        public List<USPGETPERMISOSResult> obtenerPermisoSistemaDAL()
        {
            #region obtenerPermisoSistemaDAL
            try
            {
                return dataContext.USPGETPERMISOS().ToList<USPGETPERMISOSResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        public void guardarUsuarioDAL(TAutUsuario _autUsuario)
        {
            #region guardarUsuarioDAL
            try
            {
                if(dataContext.TAutUsuarios.Count(user => user.Usuario == _autUsuario.Usuario && user.Nombre== _autUsuario.Nombre)>0)
                {
                    var usuarioData = dataContext.TAutUsuarios.Where(user => user.Usuario == _autUsuario.Usuario && user.Nombre == _autUsuario.Nombre).FirstOrDefault<TAutUsuario>();
                    usuarioData.Nombre = _autUsuario.Nombre;
                    usuarioData.Apellido = _autUsuario.Apellido;
                    usuarioData.Usuario = _autUsuario.Usuario;
                    usuarioData.Password = _autUsuario.Password;
                    usuarioData.Borrado = _autUsuario.Borrado;
                    usuarioData.Actualizacion = System.DateTime.Now;
                    dataContext.SubmitChanges();
                }
                else
                {
                    dataContext.TAutUsuarios.InsertOnSubmit(_autUsuario);
                    dataContext.SubmitChanges();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        #endregion

        #region OPERACIONES
        public List<USPGETUNIDADESResult> ObtenerUnidadesDAL()
        {
            #region ObtenerUnidadesDAL
            try
            {
                return dataContext.USPGETUNIDADES().ToList<USPGETUNIDADESResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        public void RegistrarCategoriaDAL(TCategoria _categoria)
        {
            #region RegistrarCategoriaDAL
            try
            {
                dataContext.TCategorias.InsertOnSubmit(_categoria);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        public void RegistrarDepartamentoDAL(TDepartamento _departamento)
        {
            #region RegistrarDepartamentoDAL
            try
            {
                dataContext.TDepartamentos.InsertOnSubmit(_departamento);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        #endregion




        public List<USPGETCATEGORIASResult> ObtenerCategoriasDAL(string valor ="")
        {
            #region ObtenerCategoriasDAL
            try
            {
                return dataContext.USPGETCATEGORIAS(valor).ToList<USPGETCATEGORIASResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public List<USPGETDEPARTAMENTOSResult> ObtenerDepartamentosDAL()
        {
            #region ObtenerDepartamentosDAL
            try
            {
                return dataContext.USPGETDEPARTAMENTOS().ToList<USPGETDEPARTAMENTOSResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public List<USPGETMARCASResult> ObtenerMarcasDAL()
        {
            #region ObtenerMarcasDAL
            try
            {
                return dataContext.USPGETMARCAS().ToList<USPGETMARCASResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            #endregion
        }

        public void RegistrarMarcaDAL(TMarca _marca)
        {
            #region RegistrarMarcaDAL
            try
            {
                dataContext.TMarcas.InsertOnSubmit(_marca);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public void GuardarArticuloCabeceraDAL(TArticulo _articulo)
        {
            #region GuardarArticuloCabeceraDAL
            try
            {
                dataContext.TArticulos.InsertOnSubmit(_articulo);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {    
                throw ex;
            }
            #endregion
        }
        public void ActualizarArticuloCabeceraDAL(TArticulo _articulo)
        {
            #region ActualizarArticuloCabeceraDAL
            try
            {
                if(dataContext.TArticulos.Count(art => art.ArticuloID == _articulo.ArticuloID)>0)
                {
                    var articulo = dataContext.TArticulos.Where(art => art.ArticuloID == _articulo.ArticuloID).FirstOrDefault<TArticulo>();
                    articulo.Descripcion = _articulo.Descripcion;
                    articulo.ProveedorID = _articulo.ProveedorID;
                    articulo.ClaveProveedor = _articulo.ClaveProveedor;
                    articulo.MarcaID = _articulo.MarcaID;
                    articulo.CategoriaID = _articulo.CategoriaID;
                    articulo.DepartamentoID = _articulo.DepartamentoID;
                    articulo.PrecioCompra = _articulo.PrecioCompra;
                    articulo.PrecioVentaUno = _articulo.PrecioVentaUno;
                    articulo.PrecioVentaDos = _articulo.PrecioVentaDos;
                    articulo.PasilloID = _articulo.PasilloID;
                    articulo.MuebleID = _articulo.MuebleID;
                    articulo.Actualizado = _articulo.Actualizado;
                    articulo.Usuario = _articulo.Usuario;
                    dataContext.SubmitChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        public void GuardarCantidadesArticuloDAL(TCantidadesArticulo _cantidadesArt)
        {
            #region GuardarCantidadesArticuloDAL
            try
            {
                dataContext.TCantidadesArticulos.InsertOnSubmit(_cantidadesArt);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            #endregion
        }
        public void ActualizarCantidadesArticuloDAL(TCantidadesArticulo _cantidadesArt)
        {
            #region ActualizarCantidadesArticuloDAL
            try
            {
                if (dataContext.TCantidadesArticulos.Count(can => can.ArticuloID == _cantidadesArt.ArticuloID) > 0)
                {
                    var cantidades = dataContext.TCantidadesArticulos.Where(can => can.ArticuloID == _cantidadesArt.ArticuloID).FirstOrDefault<TCantidadesArticulo>();
                    cantidades.UnidadCompra = _cantidadesArt.UnidadCompra;
                    cantidades.UnidadVenta = _cantidadesArt.UnidadVenta;
                    cantidades.InventarioMin = _cantidadesArt.InventarioMin;
                    cantidades.InventarioMax = _cantidadesArt.InventarioMax;
                    cantidades.Factor = _cantidadesArt.Factor;
                    dataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public void GuardarPreciosArticulosDAL(TPreciosArticulo _precioArticulo)
        {
            #region GuardarPreciosArticulosDAL
            try
            {
                dataContext.TPreciosArticulos.InsertOnSubmit(_precioArticulo);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public List<USPGETARTICULOSDETALLEResult> ObtenerArticulosDetalleDAL()
        {
            #region ObtenerArticulosDetalleDAL
            try
            {
                return dataContext.USPGETARTICULOSDETALLE().ToList<USPGETARTICULOSDETALLEResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion 
        }

        public List<USPGETPASILLOSResult> ObtenerPasillosDAL()
        {
            #region ObtenerPasillosDAL
            try
            {
                return dataContext.USPGETPASILLOS().ToList<USPGETPASILLOSResult>();
            }
            catch (Exception ex )
            {
                throw ex;
            }
            #endregion
        }

        public List<USPGETMUEBLESResult> ObtenerMuebleDAL()
        {
            #region ObtenerMuebleDAL
            try
            {
                return dataContext.USPGETMUEBLES().ToList<USPGETMUEBLESResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public void RegistrarPasilloDAL(TPasillo _pasillo)
        {
            #region RegistrarPasilloDAL
            try
            {
                dataContext.TPasillos.InsertOnSubmit(_pasillo);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion 
        }

        public void RegistrarMuebleDAL(TMueble _mueble)
        {
            #region RegistrarMuebleDAL
            try
            {
                dataContext.TMuebles.InsertOnSubmit(_mueble);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            #endregion
        }

        public void GuardarCaracteristicasDAL(TCaracteristicasArticulo _caracteristicas)
        {
            #region GuardarCaracteristicasDAL
            try
            {
                if(!String.IsNullOrEmpty(_caracteristicas.Descripcion))
                {
                    dataContext.TCaracteristicasArticulos.InsertOnSubmit(_caracteristicas);
                    dataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public List<USPGETINFORMACIONARTICULOResult> ObtenerDetalleArticuloDAL(string claveID)
        {
            #region ObtenerDetalleArticuloDAL
            try
            {
                return dataContext.USPGETINFORMACIONARTICULO(claveID).ToList<USPGETINFORMACIONARTICULOResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }





        public void ActualizarPreciosArticulosDAL(TPreciosArticulo _precioArticulo)
        {
            #region ActualizarPreciosArticulosDAL
            try
            {
                if (dataContext.TPreciosArticulos.Count(pre => pre.ArticuloID == _precioArticulo.ArticuloID) > 0)
                {
                    var precioArt = dataContext.TPreciosArticulos.Where(pre => pre.ArticuloID == _precioArticulo.ArticuloID).FirstOrDefault<TPreciosArticulo>();
                    precioArt.MargenUtilidadUno = _precioArticulo.MargenUtilidadUno;
                    precioArt.PrecioUno = _precioArticulo.PrecioUno;
                    precioArt.MargenUtilidadDos = _precioArticulo.MargenUtilidadDos;
                    precioArt.TipoDescuentoDos = _precioArticulo.TipoDescuentoDos;
                    precioArt.PrecioDos = _precioArticulo.PrecioDos;
                    dataContext.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            #endregion
        }

        public void ActualizarCaracteristicasDAL(TCaracteristicasArticulo _caracteristicas)
        {
            #region ActualizarCaracteristicasDAL
            try
            {
                if (dataContext.TCaracteristicasArticulos.Count(cara => cara.ArticuloID == _caracteristicas.ArticuloID) > 0)
                {
                    var caracteristicas = dataContext.TCaracteristicasArticulos.Where(cara => cara.ArticuloID == _caracteristicas.ArticuloID).FirstOrDefault<TCaracteristicasArticulo>();
                    caracteristicas.Descripcion = _caracteristicas.Descripcion;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        public void GuardarPermisosUsuarioDAL(TPermisoUsuario _permisoUsuario)
        {
            #region GuardarPermisosUsuarioDAL
            try
            {
                
                dataContext.TPermisoUsuarios.InsertOnSubmit(_permisoUsuario);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
           
        }

        public TAutUsuario ValidarSesionDAL(string usuario, string contraseña)
        {
            #region ValidarSesionDAL
            if (dataContext.TAutUsuarios.Count(aut => aut.Usuario == usuario) > 0)
            {
                var autUsuario = dataContext.TAutUsuarios.Where(aut=> aut.Usuario == usuario).FirstOrDefault<TAutUsuario>();
                return autUsuario;
            }
            return null;
            #endregion
        }

        public List<USPGETPERMISOUSUARIOResult> ObtenerPermisoUsuarioDAL(string usuario)
        {
            #region ObtenerPermisoUsuarioDAL
            try
            {
                return dataContext.USPGETPERMISOUSUARIO(usuario).ToList<USPGETPERMISOUSUARIOResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        /// <summary>
        /// Funcion que permitira eliminar todos los registros relacionados al producto
        /// seleccionado.
        /// </summary>
        /// <param name="claveID"></param>
        public void EliminarArticuloDAL(String claveID)
        {
            #region EliminarArticuloDAL
            try
            {
                if (dataContext.TArticulos.Count(art => art.ArticuloID == claveID) > 0)
                {
                    TArticulo articulo = dataContext.TArticulos.Where(art => art.ArticuloID == claveID).FirstOrDefault<TArticulo>();
                    dataContext.TArticulos.DeleteOnSubmit(articulo);
                    dataContext.SubmitChanges();
                }
                if(dataContext.TCantidadesArticulos.Count(art=>art.ArticuloID == claveID)>0)
                {
                    TCantidadesArticulo cantidadArticulo = dataContext.TCantidadesArticulos.Where(art => art.ArticuloID == claveID).FirstOrDefault<TCantidadesArticulo>();
                    dataContext.TCantidadesArticulos.DeleteOnSubmit(cantidadArticulo);
                }
                if(dataContext.TCaracteristicasArticulos.Count(art=>art.ArticuloID == claveID)>0)
                {
                    TCaracteristicasArticulo caracteristica = dataContext.TCaracteristicasArticulos.Where(art => art.ArticuloID == claveID).FirstOrDefault<TCaracteristicasArticulo>();
                    dataContext.TCaracteristicasArticulos.DeleteOnSubmit(caracteristica);
                }
                if(dataContext.TPreciosArticulos.Count(art => art.ArticuloID == claveID)>0)
                {
                    TPreciosArticulo precioArticulo = dataContext.TPreciosArticulos.Where(art => art.ArticuloID == claveID).First<TPreciosArticulo>();
                    dataContext.TPreciosArticulos.DeleteOnSubmit(precioArticulo);
                }
                dataContext.SubmitChanges();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public void ActualizarCantidadesArticuloIndividualDAL(TCantidadesArticulo _cantidadesArt)
        {
            try
            {
               var cantidadArt = dataContext.TCantidadesArticulos.Where(art => art.ArticuloID == _cantidadesArt.ArticuloID).FirstOrDefault<TCantidadesArticulo>();
               cantidadArt.Existencia = _cantidadesArt.Existencia;
               dataContext.SubmitChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public string ObtenerFolioVentaDAL()
        {
            #region ObtenerFolioVentaDAL
            try
            {
                return  (dataContext.TVentasEncabezados.Count()+1).ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        public List<USPGETCLIENTESResult> ObtenerTiposDePagoDAL()
        {
            #region ObtenerTiposDePagoDAL
            try
            {
                return dataContext.USPGETCLIENTES().ToList<USPGETCLIENTESResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public void EliminarArticuloVendidoDAL(string claveID)
        {
            #region EliminarArticuloVendidoDAL
            try
            {
                var articulo = dataContext.TCantidadesArticulos.Where(art => art.ArticuloID == claveID).FirstOrDefault<TCantidadesArticulo>();
                articulo.Existencia = articulo.Existencia - 1;
                dataContext.SubmitChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        public void GuardarEncabezadoDAL(TVentasEncabezado _ventaEncabezado)
        {
            #region GuardarEncabezadoDAL
            try
            {
                dataContext.TVentasEncabezados.InsertOnSubmit(_ventaEncabezado);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public void GuardarVentaDetalleDAL(TVentasDetalle _ventaDetalle)
        {
            #region GuardarVentaDetalleDAL
            try
            {
                dataContext.TVentasDetalles.InsertOnSubmit(_ventaDetalle);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public List<USPGETVENTASResult> ObtenerListadoVentasDAL()
        {
            #region ObtenerListadoVentasDAL
            try
            {
                return dataContext.USPGETVENTAS().ToList<USPGETVENTASResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public List<USPGETDETALLE_VENTASResult> ObtenerDetalleVentaDAL(string detalleID)
        {
            #region ObtenerDetalleVentaDAL
            try
            {
                return dataContext.USPGETDETALLE_VENTAS(detalleID).ToList<USPGETDETALLE_VENTASResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public USPGETINFOUSUARIOResult ObtenerInformacionUsuarioDAL(string usuario)
        {
            #region ObtenerInformacionUsuarioDAL
            try
            {
                return dataContext.USPGETINFOUSUARIO(usuario).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public void BorrarPermisosUsuarioDAL(string usuario)
        {
            try
            {
                dataContext.ExecuteCommand("DELETE TPermisoUsuario WHERE USUARIO='" + usuario + "'");
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool NotificarCorreoDal()
        {
            #region NotificarCorreoDal
            try
            {
                var correo = dataContext.TCorreoNotificacions.Where(co => co.CorreoID == 1).FirstOrDefault<TCorreoNotificacion>();
                if (correo.fechaEnvio.ToShortDateString() == System.DateTime.Now.ToShortDateString() )
                    return false;
                else
                {
                    correo.fechaEnvio = System.DateTime.Now;
                    dataContext.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        public List<USPGETPROVEEDORESResult> ObtenerProveedoresDAL()
        {
            #region ObtenerProveedoresDAL
            try
            {
                return dataContext.USPGETPROVEEDORES().ToList<USPGETPROVEEDORESResult>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        public void RegistrarProveedorDAL(TProveedore _proveedor)
        {
            #region RegistrarProveedorDAL
            try
            {
                dataContext.TProveedores.InsertOnSubmit(_proveedor);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
    }
}
