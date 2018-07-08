using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLINQ_RobsanNET;
using RobsanNET.BLLRobsanNET;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RobsanNET.Genericos;
using RobsanNET.Parametros;

namespace RobsanNET.Operaciones
{
    class ArticuloRegistroController
    {
        
        #region propiedades
        List<USPGETPROVEEDORESResult> lstProveedores;
        List<USPGETMARCASResult> lstMarcas;
        List<USPGETUNIDADESResult> lstUnidadesCompra;
        List<USPGETUNIDADESResult> lstUnidadesVenta;
        List<USPGETCATEGORIASResult> lstCategorias;
        List<USPGETDEPARTAMENTOSResult> lstDepartamentos;
        List<USPGETPASILLOSResult> lstPasillos;
        List<USPGETMUEBLESResult> lstMuebles;
        List<USPGETINFORMACIONARTICULOResult> lstDetalleArticulo;
        BLLOperacion operacion;
        Validador validador;
        #endregion
        public ArticuloRegistroController()
        {
            operacion = new BLLOperacion();
        }
        /// <summary>
        /// Metodo que permitira cargar todos los datos necesarios para realizar la operacion
        /// del registro de un nuevo producto
        /// </summary>
        /// <param name="lblFecha"></param>
        internal void CargarDatosIniciales(Label lblFecha, System.Windows.Forms.ComboBox cmbMarca, System.Windows.Forms.ComboBox cmbProveedor, System.Windows.Forms.ComboBox cmbCategoria, System.Windows.Forms.ComboBox cmbDepartamento, System.Windows.Forms.ComboBox cmbUnidadCompra, System.Windows.Forms.ComboBox cmbUnidadVenta, System.Windows.Forms.ComboBox cmbPasillo, System.Windows.Forms.ComboBox cmbMueble)
        {
            #region CargarDatosIniciales
            try
            {
                lblFecha.Text = System.DateTime.Now.ToShortTimeString();
                //Obtencion de datos desde la base de datos;
                lstProveedores = operacion.ObtenerProveedoresBLL();
                lstMarcas = operacion.ObtenerMarcasBLL();
                lstUnidadesCompra = operacion.ObtenerUnidadesBLL();
                lstUnidadesVenta = operacion.ObtenerUnidadesBLL();
                lstCategorias = operacion.ObtenerCategoriasBLL();
                lstDepartamentos = operacion.ObtenerDepartamentosBLL();
                lstPasillos = operacion.ObtenerPasillosBLL();
                lstMuebles = operacion.ObtenerMueblesBLL();

                cmbProveedor.DataSource = lstProveedores;
                cmbProveedor.DisplayMember = "Descripcion";
                cmbProveedor.ValueMember = "ProveedorID";

                cmbMarca.DataSource = lstMarcas;
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "MarcaID";

                cmbUnidadCompra.DataSource = lstUnidadesCompra;
                cmbUnidadCompra.DisplayMember = "Descripcion";
                cmbUnidadCompra.ValueMember = "UnidadID";
                cmbUnidadCompra.SelectedIndex = 0;

                cmbUnidadVenta.DataSource = lstUnidadesVenta;
                cmbUnidadVenta.DisplayMember = "Descripcion";
                cmbUnidadVenta.ValueMember = "UnidadID";
                cmbUnidadVenta.SelectedIndex = 0;

                cmbCategoria.DataSource = lstCategorias;
                cmbCategoria.DisplayMember = "Descripcion";
                cmbCategoria.ValueMember = "CategoriaID";

                cmbDepartamento.DataSource = lstDepartamentos;
                cmbDepartamento.DisplayMember = "Descripcion";
                cmbDepartamento.ValueMember = "DepartamentoID";

                cmbPasillo.DataSource = lstPasillos;
                cmbPasillo.DisplayMember = "Descripcion";
                cmbPasillo.ValueMember = "PasilloID";

                cmbMueble.DataSource = lstMuebles;
                cmbMueble.DisplayMember = "Descripcion";
                cmbMueble.ValueMember = "MuebleID";
                


            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }



        internal string CalcularPrecioVenta(TextBox txtVenta, TextBox txtUnidad, TextBox txtMargen)
        {
            if (!string.IsNullOrEmpty(txtMargen.Text.Trim()) && !string.IsNullOrEmpty(txtUnidad.Text.Trim()))
            {
                txtVenta.Text= decimal.Round(((Convert.ToDecimal(txtUnidad.Text.Trim()) * (Convert.ToDecimal(txtMargen.Text.Trim()) / 100)) + Convert.ToDecimal(txtUnidad.Text.Trim())),2).ToString();
            }
            return null;
        }
        internal String CalcularPrecioVenta(TextBox txtVenta, TextBox txtUnidad, TextBox txtMargen, TextBox txtDescto, bool descuento = false)
        {
            if (!string.IsNullOrEmpty(txtMargen.Text.Trim()) && !string.IsNullOrEmpty(txtUnidad.Text.Trim()))
            {
                txtVenta.Text = decimal.Round(((Convert.ToDecimal(txtUnidad.Text.Trim()) * (Convert.ToDecimal(txtMargen.Text.Trim()) / 100)) + Convert.ToDecimal(txtUnidad.Text.Trim())),2).ToString();
            }
            if (descuento)
            {
                if(!String.IsNullOrEmpty(txtDescto.Text.Trim()))
                    txtVenta.Text = decimal.Round((Convert.ToDecimal(txtVenta.Text) - ((Convert.ToDecimal(txtVenta.Text) * Convert.ToDecimal(txtDescto.Text)) / 100)),2).ToString();
            }
            return null;
        }


        internal void CalcularMargenGanancia(TextBox txtVenta, TextBox txtUnidad, TextBox txtMargen)
        {
            if(!string.IsNullOrEmpty(txtVenta.Text.Trim()) && !string.IsNullOrEmpty(txtUnidad.Text.Trim()))
            {
                decimal diferencia =  (Convert.ToDecimal(txtVenta.Text.Trim()) - Convert.ToDecimal(txtUnidad.Text.Trim()));
                txtMargen.Text = ((diferencia / Convert.ToDecimal(txtUnidad.Text.Trim())) * 100).ToString("0.##");
            }
        }


        internal Validador ValidarControles(TextBox txtClave, TextBox txtDescripcion, TextBox txtFactor, NumericUpDown numericMin, NumericUpDown numericMax, TextBox txtCompraGeneral, TextBox txtUnidadUno, TextBox txtUnidadDos, GroupBox groupCantidades, GroupBox groupPrecios, RichTextBox richDescripcion)
        {
            #region ValidarControles
            validador = new Validador();
            validador.Resultado = true;

            #region Validacion de datos de cabecera
            if (String.IsNullOrEmpty(txtClave.Text.Trim()))
            {
                validador.Resultado = false;
                validador.Mensaje = "El campo CLAVE no puede quedar vacio";
            }
            else if (String.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                validador.Resultado = false;
                validador.Mensaje = "El campo DESCRIPCION no puede quedar vacio";
            }
            else if (String.IsNullOrEmpty(txtFactor.Text.Trim()))
            {
                validador.Resultado = false;
                validador.Mensaje = "El campo FACTOR no puede quedar vacio";
            }
            else if (numericMin.Value == 0)
            {
                validador.Resultado = false;
                validador.Mensaje = "Es necesario capturar un INVENTARIO MIN";
            }
            else if (numericMax.Value == 0)
            {
                validador.Resultado = false;
                validador.Mensaje = "Es necesario capturar un INVENTARIO MAX";
            }
            else if (String.IsNullOrEmpty(txtCompraGeneral.Text.Trim()))
            {
                validador.Resultado = false;
                validador.Mensaje = "El campo PRECIO COMPRA no puede quedar vacio";
            }
            else if (String.IsNullOrEmpty(txtCompraGeneral.Text.Trim()))
            {
                validador.Resultado = false;
                validador.Mensaje = "El campo PRECIO COMPRA no puede quedar vacio";
            }
            else if (String.IsNullOrEmpty(txtUnidadUno.Text.Trim()))
            {
                validador.Resultado = false;
                validador.Mensaje = "El campo PRECIO UNIDAD UNO no puede quedar vacio";
            }
            else if (String.IsNullOrEmpty(txtUnidadDos.Text.Trim()))
            {
                validador.Resultado = false;
                validador.Mensaje = "El campo PRECIO UNIDAD DOS no puede quedar vacio";
            }
            #endregion

            foreach (Control control in groupCantidades.Controls)
            {
                if (control is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox cmbControl = (System.Windows.Forms.ComboBox)control;
                    if(cmbControl.Name.Equals("cmbUnidadCompra") || cmbControl.Name.Equals("cmbUnidadVenta") ||  cmbControl.Name.Equals("cmbPasillo") || cmbControl.Name.Equals("cmbMueble"))
                    {
                        if(cmbControl.SelectedValue==null)
                        {
                            validador.Resultado = false;
                            validador.Mensaje = "El control de " + cmbControl.Tag + " no puede quedar vacio";
                        }
                    }
                }
            }
            if (validador.Resultado)
            {
                foreach (Control control in groupPrecios.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txtcontrol = (TextBox)control;
                        if (txtcontrol.Name.Equals("txtMargenUno"))
                        {
                            if (string.IsNullOrEmpty(txtcontrol.Text))
                            {
                                validador.Resultado = false;
                                validador.Mensaje = "Es necesario asignar un valor en el campo: " + txtcontrol.Text;
                                break;
                            }
                        }
                    }
                }

            }

            return validador;
            #endregion
        }

        internal void GuardarInformacion(TextBox txtClave, TextBox txtClaveProveedor, TextBox txtDescripcion, System.Windows.Forms.ComboBox cmbMarca, GroupBox groupClasificacion, GroupBox groupCantidades, GroupBox groupCompra, GroupBox groupPrecios, RichTextBox richDescripcion)
        {
            #region GuardarInformacion
            try
            {
                #region Registro de datos del articulo
                operacion._articulo.ArticuloID = txtClave.Text.Trim().ToUpper();
                operacion._articulo.ClaveProveedor = txtClaveProveedor.Text.Trim().ToUpper();
                operacion._articulo.Usuario = DatosUsuario.Usuario;
                operacion._articulo.Actualizado = System.DateTime.Now;
                operacion._articulo.Descripcion = txtDescripcion.Text.Trim().ToUpper();
                operacion._articulo.MarcaID = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
                foreach (Control control in groupClasificacion.Controls)
                {
                    if (control is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cmbControl = (System.Windows.Forms.ComboBox)control;
                        if (cmbControl.Name.Equals("cmbProveedor") && cmbControl.SelectedValue != null)
                            operacion._articulo.ProveedorID = Convert.ToInt32(cmbControl.SelectedValue.ToString());
                        if (cmbControl.Name.Equals("cmbCategoria"))
                            operacion._articulo.CategoriaID = Convert.ToInt32(cmbControl.SelectedValue.ToString());
                        if (cmbControl.Name.Equals("cmbDepartamento"))
                            operacion._articulo.DepartamentoID = Convert.ToInt32(cmbControl.SelectedValue.ToString());
                    }
                }
                foreach (Control control in groupCompra.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txtControl = (TextBox)control;
                        if (txtControl.Name.Equals("txtCompraGeneral"))
                            operacion._articulo.PrecioCompra = Convert.ToDecimal(txtControl.Text.Trim());
                    }
                    if (control is Panel)
                    {
                        foreach (Control subcontrol in control.Controls)
                        {
                            if (subcontrol is TextBox)
                            {
                                TextBox txtControl = (TextBox)subcontrol;
                                if (txtControl.Name.Equals("txtUnidadUno"))
                                    operacion._articulo.PrecioVentaUno = Convert.ToDecimal(txtControl.Text.Trim());
                                if (txtControl.Name.Equals("txtUnidadDos"))
                                    operacion._articulo.PrecioVentaDos = Convert.ToDecimal(txtControl.Text.Trim());
                            }

                        }
                    }
                }
                #endregion

                #region Registro de datos de canntidades de articulos
                operacion._cantidadesArt.ArticuloID = txtClave.Text.Trim().ToUpper();
                foreach (Control control in groupCantidades.Controls)
                {
                    if (control is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cmbControl = (System.Windows.Forms.ComboBox)control;
                        if (cmbControl.Name.Equals("cmbPasillo"))
                            operacion._articulo.PasilloID = Convert.ToInt32(cmbControl.SelectedValue.ToString());
                        if (cmbControl.Name.Equals("cmbMueble"))
                            operacion._articulo.MuebleID = Convert.ToInt32(cmbControl.SelectedValue.ToString());
                        if (cmbControl.Name.Equals("cmbUnidadCompra"))
                            operacion._cantidadesArt.UnidadCompra = Convert.ToInt32(cmbControl.SelectedValue.ToString());
                        if (cmbControl.Name.Equals("cmbUnidadVenta"))
                            operacion._cantidadesArt.UnidadVenta = Convert.ToInt32(cmbControl.SelectedValue.ToString());
                    }
                    if (control is NumericUpDown)
                    {
                        NumericUpDown numControl = (NumericUpDown)control;
                        if (numControl.Name.Equals("numericMin"))
                            operacion._cantidadesArt.InventarioMin = numControl.Value;
                        if (numControl.Name.Equals("numericMax"))
                            operacion._cantidadesArt.InventarioMax = numControl.Value;
                    }
                    if (control is TextBox)
                    {
                        TextBox txtControl = (TextBox)control;
                        if (txtControl.Name.Equals("txtFactor"))
                            operacion._cantidadesArt.Factor = Convert.ToDecimal(txtControl.Text.Trim());
                    }
                }
                #endregion
                
                
                //Registro de precios del articulo
                operacion._precioArticulo.ArticuloID = txtClave.Text.Trim().ToUpper();
                #region Seccion de precions
                foreach (Control control in groupPrecios.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txtControl = (TextBox)control;
                        //Precios de tipo Uno
                        if (txtControl.Name.Equals("txtMargenUno") && !string.IsNullOrEmpty(txtControl.Text))
                            operacion._precioArticulo.MargenUtilidadUno = Convert.ToDecimal(txtControl.Text.Trim());
                        if (txtControl.Name.Equals("txtDesctoUno") && !string.IsNullOrEmpty(txtControl.Text))
                            operacion._precioArticulo.PorcentajeDescuentoUno = 0;
                        if (txtControl.Name.Equals("txtVentaUno") && !string.IsNullOrEmpty(txtControl.Text))
                            operacion._precioArticulo.PrecioUno = Convert.ToDouble(txtControl.Text.Trim());
                        //Precios de tipo Dos
                        if (txtControl.Name.Equals("txtMargenDos") && !string.IsNullOrEmpty(txtControl.Text))
                            operacion._precioArticulo.MargenUtilidadDos = Convert.ToDecimal(txtControl.Text.Trim());
                        if (txtControl.Name.Equals("txtDesctoDos") && !string.IsNullOrEmpty(txtControl.Text))
                            operacion._precioArticulo.PorcentajeDescuentoDos = (txtControl.Text==String.Empty)?0:Convert.ToDecimal(txtControl.Text);
                        if (txtControl.Name.Equals("txtVentaDos") && !string.IsNullOrEmpty(txtControl.Text))
                            operacion._precioArticulo.PrecioDos = Convert.ToDouble(txtControl.Text.Trim());
                    }
                    if (control is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cmbControl = (System.Windows.Forms.ComboBox)control;
                        if (cmbControl.Name.Equals("cmbDesctoUno"))
                            operacion._precioArticulo.TipoDescuentoUno = cmbControl.Text;
                        if (cmbControl.Name.Equals("cmbDesctoDos"))
                            operacion._precioArticulo.TipoDescuentoDos = cmbControl.Text;
                    }

                }
                #endregion

                #region Registro de caracteristicas del articulos
                operacion._caracteristicas.ArticuloID = txtClave.Text.Trim().ToUpper();
                operacion._caracteristicas.Descripcion = (!string.IsNullOrEmpty(richDescripcion.Text.Trim())) ? richDescripcion.Text.ToUpper().Trim() : String.Empty;
                #endregion
                //Envio de objetos para guardar en la base de datos
                if (!Acciones.MODO_CONSULTA)
                    operacion.GuardarInformacionBLL();
                else
                    operacion.ActualizarInformacionBLL();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion 
        }

        /// <summary>
        /// Metodo que se conecta a la base de datos y mediante una consulta especial
        /// obtiene todos los valores relacionados con el articulo
        /// </summary>
        /// <param name="txtClave"></param>
        /// <param name="txtDescripcion"></param>
        /// <param name="cmbMarca"></param>
        /// <param name="groupClasificacion"></param>
        /// <param name="groupCantidades"></param>
        /// <param name="groupCompra"></param>
        /// <param name="groupPrecios"></param>
        /// <param name="richDescripcion"></param>
        internal void MostrarInformacionArticulo(String claveID, TextBox txtClave, TextBox txtDescripcion, TextBox txtClaveProveedor, System.Windows.Forms.ComboBox cmbMarca, GroupBox groupClasificacion, GroupBox groupCantidades, GroupBox groupCompra, GroupBox groupPrecios, RichTextBox richDescripcion)
        {
            #region MostrarInformacionArticulo
            lstDetalleArticulo = operacion.ObtenerDetalleArticuloBLL(claveID);
            foreach (USPGETINFORMACIONARTICULOResult articulo in lstDetalleArticulo)
            {
                txtClave.Text = articulo.ArticuloID;
                txtClave.Enabled = false;
                txtDescripcion.Text = articulo.DescripcionArticulo;
                txtClaveProveedor.Text = articulo.ClaveProveedor;
                cmbMarca.Text = articulo.DescripcionMarca;
                foreach (Control control in groupClasificacion.Controls)
                {
                    if(control is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cmbControl = (System.Windows.Forms.ComboBox)control;
                        if (cmbControl.Name.Equals("cmbProveedor"))
                            cmbControl.Text = articulo.NombreProveedor;
                        if (cmbControl.Name.Equals("cmbCategoria"))
                            cmbControl.Text = articulo.DescripcionCategoria;
                        else if (cmbControl.Name.Equals("cmbDepartamento"))
                            cmbControl.Text = articulo.DescripcionDepartamento;
                    }
                }
                #region Seccion de cantidades
                foreach (Control control in groupCantidades.Controls)
                {
                    if (control is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cmbControl = (System.Windows.Forms.ComboBox)control;
                        if (cmbControl.Name.Equals("cmbUnidadCompra"))
                            cmbControl.Text = articulo.UnidadCompra.ToString();
                        else if (cmbControl.Name.Equals("cmbUnidadVenta"))
                            cmbControl.Text = articulo.UnidadVenta.ToString();
                        else if (cmbControl.Name.Equals("cmbPasillo"))
                            cmbControl.Text = articulo.NombrePasillo;
                        else if (cmbControl.Name.Equals("cmbMueble"))
                            cmbControl.Text = articulo.NombreMueble;
                    }
                    if (control is NumericUpDown)
                    {
                        NumericUpDown numeriControl = (NumericUpDown)control;
                        if (numeriControl.Name.Equals("numericMin"))
                            numeriControl.Value = Convert.ToDecimal( articulo.InventarioMin);
                        else if (numeriControl.Name.Equals("numericMax"))
                            numeriControl.Value = Convert.ToDecimal( articulo.InventarioMax);
                    }
                    if (control is TextBox)
                    {
                        TextBox txtControl = (TextBox)control;
                        if (txtControl.Name.Equals("txtFactor"))
                            txtControl.Text = articulo.Factor.ToString();
                    }
                }
                #endregion

                #region Seccion de compras
                foreach (Control control in groupCompra.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txtControl = (TextBox)control;
                        txtControl.Text = articulo.PrecioCompra.ToString();
                    }
                    if (control is Label)
                    {
                        Label lblControl = (Label)control;
                        if (lblControl.Name.Equals("lblUnidad"))
                            lblControl.Text = articulo.UnidadCompra;
                    }
                    if (control is Panel)
                    {
                        foreach (Control controlPanel in control.Controls)
                        {
                            if (controlPanel is TextBox)
                            {
                                TextBox txtControl = (TextBox)controlPanel;
                                if (txtControl.Name.Equals("txtUnidadUno"))
                                    txtControl.Text = articulo.PrecioVentaUno.ToString();
                                else if (txtControl.Name.Equals("txtUnidadDos"))
                                    txtControl.Text = articulo.PrecioVentaDos.ToString();
                            }
                            if (controlPanel is Label)
                            {
                                Label lblControl = (Label)controlPanel;
                                if (lblControl.Name.Equals("lblUnidadUno"))
                                    lblControl.Text = articulo.UnidadCompra;
                                else if (lblControl.Name.Equals("lblUnidadDos"))
                                    lblControl.Text = articulo.UnidadVenta;
                            }
                        }
                    }
                }
                #endregion

                foreach (Control control in groupPrecios.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox txtControl = (TextBox)control;
                        if (txtControl.Name.Equals("txtMargenUno"))
                            txtControl.Text = articulo.MargenUtilidadUno.ToString();
                        else if (txtControl.Name.Equals("txtMargenDos"))
                            txtControl.Text = articulo.MargenUtilidadDos.ToString();
                        else if (txtControl.Name.Equals("txtDesctoUno"))
                            txtControl.Text = "";
                        else if (txtControl.Name.Equals("txtDesctoDos"))
                            txtControl.Text = "";
                        else if (txtControl.Name.Equals("txtVentaUno"))
                            txtControl.Text = articulo.PrecioUno.ToString();
                        else if (txtControl.Name.Equals("txtVentaDos"))
                            txtControl.Text = articulo.PrecioDos.ToString();
                    }
                    if (control is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cmbControl = (System.Windows.Forms.ComboBox)control;
                        if (cmbControl.Name.Equals("cmbDesctoUno"))
                            cmbControl.Text = "N/A";
                        else if (cmbControl.Name.Equals("cmbDesctoDos"))
                            cmbControl.Text = articulo.TipoDescuentoDos;
                       
                    }
                    
                }
                richDescripcion.Text = articulo.DescripcionGral;

               

            }
            #endregion 
        }


        internal void RecargarCargarDatos(System.Windows.Forms.ComboBox cmbControl, string titulo)
        {
            #region RecargarCargarDatos
            switch (titulo)
            {
                case "ProveedorID":
                    cmbControl.DataSource = operacion.ObtenerProveedoresBLL();
                    break;
                case "MarcaID":
                    cmbControl.DataSource = operacion.ObtenerMarcasBLL();
                    break;
                case "CategoriaID":
                    cmbControl.DataSource = operacion.ObtenerCategoriasBLL();
                    break;
                case "DepartamentoID":
                    cmbControl.DataSource = operacion.ObtenerDepartamentosBLL();
                    break;
                case "PasilloID":
                    cmbControl.DataSource = operacion.ObtenerPasillosBLL();
                    break;
                case "MuebleID":
                    cmbControl.DataSource = operacion.ObtenerMueblesBLL();
                    break;
                default:
                    break;
            }
            cmbControl.DisplayMember = "Descripcion";
            cmbControl.ValueMember = titulo;
            #endregion
        }
    }
}
