using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobsanNET.BLLRobsanNET;
using DataLINQ_RobsanNET;
using System.Net.Mail;
using System.Net;
namespace RobsanNET
{
    class MenuController
    {
        #region propiedades
        BLLOperacion operacion;
        List<USPGETARTICULOSDETALLEResult> lstArticulos;
        List<USPGETARTICULOSDETALLEResult> lstArticulosStockBajo;
        List<USPGETARTICULOSDETALLEResult> lstArticulosStockAlto;
        #endregion

        public MenuController()
        {
            operacion = new BLLOperacion();
            lstArticulosStockBajo = new List<USPGETARTICULOSDETALLEResult>();
            lstArticulosStockAlto = new List<USPGETARTICULOSDETALLEResult>();
        }
        /// <summary>
        /// Funcion que mandara un reporte de stock que se encuentra debajo del
        /// minimo y encima del superior para controlar las compras que se realizan
        /// </summary>
        internal bool EnviarReporteStock()
        {
            #region EnviarReporteStock
            try
            {
                lstArticulos = operacion.ObtenerArticulosDetalleBLL();
                foreach (USPGETARTICULOSDETALLEResult articulo in lstArticulos)
                {
                    if (articulo.Existencia > articulo.UnidadMax)
                        lstArticulosStockAlto.Add(articulo);
                    else if (articulo.Existencia < articulo.UnidadMin)
                        lstArticulosStockBajo.Add(articulo);
                }
                if (!EnviarCorreo())
                    return false;
                else
                    return true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        private bool EnviarCorreo()
        {
            #region EnviarCorreo
            SmtpClient ClienteSMTP = new SmtpClient("smtp.gmail.com", 587);
            ClienteSMTP.EnableSsl = true;

            NetworkCredential credentials = new NetworkCredential("franjarop.sistemas", "crysains.9017", "");
            ClienteSMTP.Credentials = credentials;

            MailMessage Mensaje = new MailMessage();
            Mensaje.IsBodyHtml = true;
            Mensaje.To.Add(new MailAddress("franjarop.sistemas@gmail.com"));
            Mensaje.To.Add(new MailAddress("transportes.robless@gmail.com"));
            Mensaje.From = new MailAddress("franjarop.sistemas@correo.com");
            Mensaje.Subject = "Reporte de stock del dia " + System.DateTime.Now.ToShortDateString();
            Mensaje.Body = ConstruirCuerpoCorreo();
            try
            {
                ClienteSMTP.Send(Mensaje);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                ClienteSMTP.Dispose();
            }  
            #endregion
        }

        private string ConstruirCuerpoCorreo()
        {
            String tituloStockBajo = "LISTADO DE ARTICULOS CON STOCK BAJO";
            String tituloStockAlto = "LISTADO DE ARTICULOS CON STOCK ALTO";
            String mensaje = "<B>" + tituloStockBajo + "</B>";
            mensaje += "<BR>";
            mensaje += "<TABLE cellspacing=10>";
            mensaje += "<TR>";
            mensaje += "<TD>Descripcion</TD><TD>Marca</TD><TD>Cantidad minima</TD><TD>Existencia<TD>";
            mensaje += "</TR>";
            foreach (USPGETARTICULOSDETALLEResult articuloBajo in lstArticulosStockBajo)
            {
                mensaje += "<TR>";
                mensaje += "<TD>" + articuloBajo.Descripcion + "</TD><TD>" + articuloBajo.Marca + "</TD><TD>" + articuloBajo.UnidadMin + "</TD><TD>" + articuloBajo.Existencia + "</TD>";
                mensaje += "</TR>";
            }
            mensaje += "</TABLE>";
            mensaje += "<BR><BR>";
            mensaje += "<B>" + tituloStockAlto + "</B>";
            mensaje += "<BR>";
            mensaje += "<TABLE cellspacing=10>";
            mensaje += "<TR>";
            mensaje += "<TD>NPC</TD><TD>Descripcion</TD><TD>Marca</TD><TD>Cantidad maxima</TD><TD>Existencia<TD>";
            mensaje += "</TR>";
            foreach (USPGETARTICULOSDETALLEResult articuloAlto in lstArticulosStockAlto)
            {
                mensaje += "<TR>";
                mensaje += "<TD>" + articuloAlto.ClaveProveedor + "</TD><TD>"+"<TD>" + articuloAlto.Descripcion + "</TD><TD>" + articuloAlto.Marca + "</TD><TD>" + articuloAlto.UnidadMax + "</TD><TD>" + articuloAlto.Existencia + "</TD>";
                mensaje += "</TR>";
            }
            mensaje += "</TABLE>";
            mensaje += "<BR><BR><BR>";
            mensaje += "Este mensaje ha sido programado para que usted lo reciba diario atte. JavierDev ®";
            return mensaje;
        }

        internal bool NotificarCorreo()
        {
            #region NotificarCorreo
            try
            {
                return operacion.NotificarCorreoBLL();
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion 
        }
    }
}
