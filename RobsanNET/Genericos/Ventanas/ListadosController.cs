using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLINQ_RobsanNET;
using RobsanNET.BLLRobsanNET;

namespace RobsanNET.Genericos.Ventanas
{
    class ListadosController
    {
        #region Propiedades
        BLLOperacion operacion;
        #endregion

        public ListadosController()
        {
            operacion = new BLLOperacion();
        }

        internal List<USPGETCATEGORIASResult> ObtenerListaCategoriaBLL()
        {
            #region ObtenerListaCategoriaBLL
            try
            {
                return operacion.ObtenerCategoriasBLL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion 
        }

        internal List<USPGETDEPARTAMENTOSResult> ObtenerListadoDepartamentosBLL()
        {
            #region ObtenerListadoDepartamentosBLL
            try
            {
                return operacion.ObtenerDepartamentosBLL();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            #endregion
        }

        internal List<USPGETCATEGORIASResult> ObtenerListaCategoriaFiltradaBLL(String valor = "")
        {
            #region ObtenerListaCategoriaFiltradaBLL
            try
            {
                return   operacion.ObtenerCategoriasBLL(valor);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion 
        }

        internal List<USPGETMARCASResult> ObtenerListaMarcaBLL()
        {
            #region ObtenerListaMarcaBLL
            try
            {
                return operacion.ObtenerMarcasBLL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            #endregion
        }

        internal List<USPGETPASILLOSResult> ObtenerlistadoPasillos()
        {
            #region ObtenerlistadoPasillos
            try
            {
                return operacion.ObtenerPasillosBLL();
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        internal List<USPGETMUEBLESResult> ObtenerListadoMuebles()
        {
            #region ObtenerListadoMuebles
            try
            {
                return operacion.ObtenerMueblesBLL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion 
        }

        internal List<USPGETPROVEEDORESResult> ObtenerListaProveedores()
        {
            #region ObtenerListaProveedores
            try
            {
                return operacion.ObtenerProveedoresBLL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
    }
}
