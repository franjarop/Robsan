using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLINQ_RobsanNET;

namespace RobsanNET.BLLRobsanNET
{
    class BLLConsulta
    {
        #region propiedades
        DataTables datatable;
        #endregion
        public BLLConsulta()
        {
            datatable = new DataTables();
        }
        internal List<USPGETVENTASResult> ObtenerListadoVentasBLL()
        {
            #region ObtenerListadoVentasBLL
            try
            {
                return datatable.ObtenerListadoVentasDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        internal List<USPGETDETALLE_VENTASResult> ObtenerDetalleVentaBLL(string detalleID)
        {
            #region ObtenerDetalleVentaBLL
            try
            {
                return datatable.ObtenerDetalleVentaDAL(detalleID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
    }
}
