using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLINQ_RobsanNET;

namespace RobsanNET.BLLRobsanNET
{
    class BLLOperacion
    {
        #region Propiedades
        DataTables dataTable;
        public TMarca _marca;
        public TDepartamento _departamento;
        public TCategoria _categoria;
        public TArticulo _articulo;
        public TCantidadesArticulo _cantidadesArt;
        public TPreciosArticulo _precioArticulo;
        public TPasillo _pasillo;
        public TMueble _mueble;
        public TCaracteristicasArticulo _caracteristicas;
        public TVentasEncabezado _ventaEncabezado;
        public TVentasDetalle _ventaDetalle;
        public TProveedore _proveedor;
        #endregion

        public BLLOperacion() {
            
            dataTable = new DataTables();
            _proveedor = new TProveedore();
            _marca = new TMarca();
            _departamento = new TDepartamento();
            _categoria = new TCategoria();
            _articulo = new TArticulo();
            _cantidadesArt = new TCantidadesArticulo();
            _precioArticulo = new TPreciosArticulo();
            _pasillo = new TPasillo();
            _mueble = new TMueble();
            _caracteristicas = new TCaracteristicasArticulo();
            _ventaEncabezado = new TVentasEncabezado();
            _ventaDetalle = new TVentasDetalle();
        }

        /// <summary>
        /// Metodo que permite obtener las unidades de compra/venta
        /// </summary>
        /// <returns></returns>
        internal List<USPGETUNIDADESResult> ObtenerUnidadesBLL()
        {
            #region ObtenerUnidades
            try
            {
               return dataTable.ObtenerUnidadesDAL();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            #endregion
        }

        internal void RegistrarCategoriaBLL()
        {
            #region RegistrarCategoria
            try
            {
                dataTable.RegistrarCategoriaDAL(_categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            #endregion
        }

        internal void RegistrarDepartamentoBLL()
        {
            #region RegistrarDepartamentoBLL
            try
            {
                dataTable.RegistrarDepartamentoDAL(_departamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal List<USPGETCATEGORIASResult> ObtenerCategoriasBLL(String valor = "")
        {
            #region ObtenerCategoriasBLL
            try
            {
                return dataTable.ObtenerCategoriasDAL(valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal List<USPGETDEPARTAMENTOSResult> ObtenerDepartamentosBLL()
        {
            #region ObtenerDepartamentosBLL
            try
            {
                return dataTable.ObtenerDepartamentosDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal List<USPGETMARCASResult> ObtenerMarcasBLL()
        {
            #region ObtenerMarcasBLL
            return dataTable.ObtenerMarcasDAL();
            #endregion
        }

        internal void RegistrarMarcaBLL()
        {
            #region RegistrarMarcaBLL
            try
            {
                dataTable.RegistrarMarcaDAL(_marca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            #endregion 
        }

        internal void GuardarInformacionBLL()
        {
            #region GuardarInformacion
            dataTable.GuardarArticuloCabeceraDAL(_articulo);
            dataTable.GuardarCantidadesArticuloDAL(_cantidadesArt);
            dataTable.GuardarPreciosArticulosDAL(_precioArticulo);
            dataTable.GuardarCaracteristicasDAL(_caracteristicas);
            #endregion
        }
        internal void ActualizarInformacionBLL()
        {
            #region ActualizarInformacionBLL
            try
            {
                dataTable.ActualizarArticuloCabeceraDAL(_articulo);
                dataTable.ActualizarCantidadesArticuloDAL(_cantidadesArt);
                dataTable.ActualizarPreciosArticulosDAL(_precioArticulo);
                dataTable.ActualizarCaracteristicasDAL(_caracteristicas);
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        internal List<USPGETARTICULOSDETALLEResult> ObtenerArticulosDetalleBLL()
        {
            #region ObtenerArticulosDetalleBLL
            try
            {
                return dataTable.ObtenerArticulosDetalleDAL();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion 
        }

        internal List<USPGETPASILLOSResult> ObtenerPasillosBLL()
        {
            #region ObtenerPasillosBLL
            try
            {
                return dataTable.ObtenerPasillosDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion 
        }

        internal List<USPGETMUEBLESResult> ObtenerMueblesBLL()
        {
            #region ObtenerMueblesBLL
            try
            {
                return dataTable.ObtenerMuebleDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal void RegistrarPasilloBLL()
        {
            #region RegistrarPasilloBLL
            try
            {
                dataTable.RegistrarPasilloDAL(_pasillo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal void RegistrarMuebleBLL()
        {
            #region RegistrarMuebleBLL
            try
            {
                dataTable.RegistrarMuebleDAL(_mueble);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal List<USPGETINFORMACIONARTICULOResult> ObtenerDetalleArticuloBLL(string claveID)
        {
            #region ObtenerDetalleArticuloBLL
            try
            {
                return dataTable.ObtenerDetalleArticuloDAL(claveID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            #endregion 
        }



        internal void EliminarArticuloBLL(String claveID)
        {
            #region EliminarArticulo
            try
            {
                dataTable.EliminarArticuloDAL(claveID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal void ActualizarCantidadesBLL()
        {
            #region ActualizarCantidadesBLL
            dataTable.ActualizarCantidadesArticuloIndividualDAL(_cantidadesArt);
            #endregion
        }

        internal string ObtenerFolioVentaBLL()
        {
            #region ObtenerFolioVentaBLL
            return dataTable.ObtenerFolioVentaDAL();
            #endregion
        }

        internal List<USPGETCLIENTESResult> ObtenerTiposDePagoBLL()
        {
            #region ObtenerTiposDePagoBLL
            try
            {
                return dataTable.ObtenerTiposDePagoDAL();
            }
            catch (Exception ex )
            {
                throw ex;
            }
            #endregion
        }

        internal void EliminarArticuloVendidoBLL(string claveID)
        {
            #region EliminarArticuloVendidoBLL
            try
            {
                dataTable.EliminarArticuloVendidoDAL(claveID);
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        internal void GuardarVentaEncabezadoBLL()
        {
            #region GuardarVentaEncabezadoBLL
            try
            {
                dataTable.GuardarEncabezadoDAL(_ventaEncabezado);
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        internal void GuardaVentaDetalleBLL()
        {
            #region GuardaVentaDetalleBLL
            try
            {
                dataTable.GuardarVentaDetalleDAL(_ventaDetalle);
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        internal bool NotificarCorreoBLL()
        {
            #region NotificarCorreoBLL
            try
            {
                return dataTable.NotificarCorreoDal();
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        internal List<USPGETPROVEEDORESResult> ObtenerProveedoresBLL()
        {
            #region ObtenerProveedoresBLL
            try
            {
                return dataTable.ObtenerProveedoresDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal void RegistrarProveedorBLL()
        {
            #region RegistrarProveedorBLL
            try
            {
                dataTable.RegistrarProveedorDAL(_proveedor);
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }
    }
}
