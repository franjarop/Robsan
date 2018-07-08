using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobsanNET.BLLRobsanNET;
using DataLINQ_RobsanNET;

namespace RobsanNET.Consultas.Ventas
{
    class ConsultaDetalleVentasController
    {
        #region Propiedades
        BLLConsulta consulta;
        #endregion
        public ConsultaDetalleVentasController()
        {
            consulta = new BLLConsulta();
        }
        internal List<USPGETDETALLE_VENTASResult> ObtenerDetalleVenta(string detalleID)
        {
            #region ObtenerDetalleVenta
            try
            {
                return consulta.ObtenerDetalleVentaBLL(detalleID);
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }
    }
}
