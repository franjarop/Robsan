using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLINQ_RobsanNET;
using RobsanNET.BLLRobsanNET;

namespace RobsanNET.Operaciones
{
    class ArticuloConsultaController
    {
        #region propiedades
        BLLOperacion operacion;
        #endregion

        public ArticuloConsultaController()
        {
            operacion = new BLLOperacion();
        }

        internal List<USPGETARTICULOSDETALLEResult> ObtenerArticulosDetalle()
        {
            #region ObtenerArticulosDetalle
            try
            {
                return operacion.ObtenerArticulosDetalleBLL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            #endregion
        }

        internal void EliminarArticulo(string claveID)
        {
            #region EliminarArticulo
            try
            {
                operacion.EliminarArticuloBLL(claveID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
    }
}
