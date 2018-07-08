using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobsanNET.BLLRobsanNET;
using RobsanNET.Genericos;
using DataLINQ_RobsanNET;
using System.Data;
using System.Windows.Forms;

namespace RobsanNET.Operaciones.Ventas
{
    class PuntoVentaController
    {
        #region Propiedades
        BLLOperacion operacion;
        List<USPGETINFORMACIONARTICULOResult> lstDetalleArticulo;
        DataTable dtVentas;
        double total = 0;
        #endregion
        public PuntoVentaController()
        {

            operacion = new BLLOperacion();
            dtVentas = new DataTable();
            dtVentas.Columns.Add("Clave", typeof(string));
            dtVentas.Columns.Add("Descripcion", typeof(string));
            dtVentas.Columns.Add("Marca", typeof(string));
            dtVentas.Columns.Add("Precio", typeof(double));
        }
        internal void CargarDatos(System.Windows.Forms.Label lblFolio, System.Windows.Forms.Label lblFecha, System.Windows.Forms.ComboBox cmbTipoPago, System.Windows.Forms.Label lblUsuario)
        {
            #region CargarDatos
            lblFolio.Text = operacion.ObtenerFolioVentaBLL();
            lblFecha.Text = System.DateTime.Now.ToString();
            cmbTipoPago.DataSource = operacion.ObtenerTiposDePagoBLL();
            cmbTipoPago.ValueMember = "TipoClienteID";
            cmbTipoPago.DisplayMember = "Descripcion";
            lblUsuario.Text = DatosUsuario.Usuario;

            #endregion
        }

        internal void CargarArticulo(TextBox txtClave, DevExpress.XtraGrid.GridControl gridControl, ComboBox cmbTipoPago, Label lblTotal)
        {

            lstDetalleArticulo = operacion.ObtenerDetalleArticuloBLL(txtClave.Text.Trim());
            if(lstDetalleArticulo.Count>0)
            {
                cmbTipoPago.Enabled = false;
                foreach (USPGETINFORMACIONARTICULOResult articulo in lstDetalleArticulo)
                {
                    DataRow[] articulos = dtVentas.Select("Clave='"+txtClave.Text.Trim()+"'");
                    int artRegistrados = articulos.Count();
                    if (articulos.Count() < articulo.Existencia)
                    {
                        if (Convert.ToInt32(cmbTipoPago.SelectedValue) == 1)
                        {
                            dtVentas.Rows.Add(articulo.ArticuloID, articulo.DescripcionArticulo, articulo.DescripcionMarca, articulo.PrecioUno);
                            total += Convert.ToDouble(articulo.PrecioUno);
                        }

                        else
                        {
                            dtVentas.Rows.Add(articulo.ArticuloID, articulo.DescripcionArticulo, articulo.DescripcionMarca, articulo.PrecioDos);
                            total += Convert.ToDouble(articulo.PrecioDos);
                        }
                        gridControl.DataSource = dtVentas;
                        lblTotal.Text = total.ToString();
                        txtClave.Text = String.Empty;
                        txtClave.Focus();

                    }
                    else
                        MessageBox.Show("No puede registrar este articulo, debido a que tiene stock bajo", "Aviso", MessageBoxButtons.OK);
                    
                }
            }
            
           
        }

        internal void EliminarArticulosVendidos()
        {
            #region EliminarArticulosVendidos
            foreach (DataRow fila in dtVentas.Rows)
            {
                operacion.EliminarArticuloVendidoBLL(fila["Clave"].ToString());
            }
            #endregion
        }

        internal void GuardarVentaEncabezado(Label lblFolio, Label lblFecha, string tipoCliente, Label lblUsuario, Int32 detalleID, string total)
        {
            #region GuardarVentaEncabezado
            operacion._ventaEncabezado.FechaRegistro =Convert.ToDateTime(lblFecha.Text);
            operacion._ventaEncabezado.TipoCliente =Convert.ToDecimal(tipoCliente);
            operacion._ventaEncabezado.Usuario = lblUsuario.Text;
            operacion._ventaEncabezado.DetalleID =detalleID;
            operacion._ventaEncabezado.Total = Convert.ToDouble(total);
            operacion.GuardarVentaEncabezadoBLL();
            #endregion
        }

        internal void GuardarVentaDetalle(int detalleID)
        {
            #region GuardarVentaDetalle
            try
            {
                foreach (DataRow fila in dtVentas.Rows)
                {
                    operacion = new BLLOperacion();
                    operacion._ventaDetalle.DetalleID = detalleID;
                    operacion._ventaDetalle.ArticuloID = fila["Clave"].ToString();
                    operacion._ventaDetalle.Descripcion = fila["Descripcion"].ToString();
                    operacion._ventaDetalle.MarcaID = fila["Marca"].ToString();
                    operacion._ventaDetalle.PrecioUnitario = Convert.ToDouble(fila["Precio"]);
                    operacion.GuardaVentaDetalleBLL();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }
    }
}
