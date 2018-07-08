using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobsanNET.BLLRobsanNET;
using DataLINQ_RobsanNET;

namespace RobsanNET.Consultas.Ventas
{
    class ConsultaVentaController
    {
        #region Propiedades
        BLLConsulta consulta;
        #endregion

        public ConsultaVentaController()
        {
            consulta = new BLLConsulta();
        }
        internal List<USPGETVENTASResult> ObtenerListadoVentas()
        {
            #region ObtenerListadoVentas
            try
            {
               return consulta.ObtenerListadoVentasBLL();
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }
    }
}
