using RobsanNET.Genericos;
using RobsanNET.Genericos.Ventanas;
using RobsanNET.Parametros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobsanNET.Operaciones
{
    public partial class ArticuloRegistro : Form
    {
        #region Propiedades
        Listados ventanaListado;
        ArticuloRegistroController controller;
        #endregion
        public ArticuloRegistro(string claveID = "")
        {
            InitializeComponent();
            CargarDatosIniciales();
            if (!string.IsNullOrEmpty(claveID))
                controller.MostrarInformacionArticulo(claveID, txtClave, txtDescripcion, txtProveedor, cmbMarca, groupClasificacion, groupCantidades, groupCompra, groupPrecios, richDescripcion);   
        }

       
        private void CargarDatosIniciales()
        {
            controller = new ArticuloRegistroController();
            controller.CargarDatosIniciales(lblFecha,cmbMarca, cmbProveedor, cmbCategoria, cmbDepartamento, cmbUnidadCompra, cmbUnidadVenta, cmbPasillo, cmbMueble);
            cmbDesctoUno.SelectedIndex = 0;
            cmbDesctoDos.SelectedIndex = 0;
            cmbDesctoTres.SelectedIndex = 0;
            cmbDesctoCuatro.SelectedIndex = 0;
            cmbProveedor.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            #region btnCategoria_Click
            ventanaListado = new Listados(TituloVentana.CONS_CATEGORIA);
            ventanaListado.ShowDialog();
            controller.RecargarCargarDatos(cmbCategoria, "CategoriaID");
            cmbCategoria.Text = ventanaListado.Seleccionado;
            ventanaListado.Close();
            #endregion

        }

        private void cmbUnidadCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region cmbUnidadCompra_SelectedIndexChanged
            lblUnidad.Text = "X " + cmbUnidadCompra.Text;
            lblUnidadUno.Text = "X " + cmbUnidadCompra.Text;
            #endregion
        }

        private void cmbUnidadVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region cmbUnidadVenta_SelectedIndexChanged
            lblUnidadDos.Text = "X " + cmbUnidadVenta.Text;
            #endregion
        }

        private void txtCompraGeneral_TextChanged(object sender, EventArgs e)
        {
            #region txtCompraGeneral_TextChanged
            if (!string.IsNullOrEmpty(txtFactor.Text.Trim()) && !string.IsNullOrEmpty(txtCompraGeneral.Text.Trim()))
            {

                txtUnidadUno.Text = decimal.Round((Convert.ToDecimal(txtCompraGeneral.Text.Trim()) + ((Convert.ToDecimal(txtCompraGeneral.Text.Trim()) * 16) / 100)), 2).ToString();
                Decimal precioNeto = decimal.Round(Convert.ToDecimal(txtCompraGeneral.Text.Trim()) / Convert.ToDecimal(txtFactor.Text.Trim()), 2);
                txtUnidadDos.Text = decimal.Round((precioNeto + ((precioNeto * 16) / 100)), 2).ToString();
            }
            #endregion
        }

        private void txtMargenUno_TextChanged(object sender, EventArgs e)
        {
            #region txtMargenUno_TextChanged
            //controller.CalcularPrecioVenta(txtVentaUno, txtUnidadDos, txtMargenUno);
            #endregion
        }
        private void txtMargenDos_TextChanged(object sender, EventArgs e)
        {
            #region txtMargenUno_TextChanged
            //controller.CalcularPrecioVenta(txtVentaDos, txtUnidadDos, txtMargenDos);
            #endregion

        }

        private void txtVentaUno_TextChanged(object sender, EventArgs e)
        {
            #region txtVentaUno_TextChanged
            controller.CalcularMargenGanancia(txtVentaUno, txtUnidadDos, txtMargenUno);
            #endregion
        }
        private void txtVentaDos_TextChanged(object sender, EventArgs e)
        {
            #region txtVentaDos_TextChanged
            controller.CalcularMargenGanancia(txtVentaDos, txtUnidadDos, txtMargenDos);
            #endregion 

        }

        private void btnDepartamento_Click(object sender, EventArgs e)
        {
            #region btnDepartamento_Click
            ventanaListado = new Listados(TituloVentana.CONS_DEPARTAMENTO);
            ventanaListado.ShowDialog();
            controller.RecargarCargarDatos(cmbDepartamento, "DepartamentoID");
            cmbDepartamento.Text = ventanaListado.Seleccionado;
            ventanaListado.Close();
            #endregion
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            #region btnMarca_Click
            ventanaListado = new Listados(TituloVentana.CONS_MARCA);
            ventanaListado.ShowDialog();
            controller.RecargarCargarDatos(cmbMarca, "MarcaID");
            cmbMarca.Text = ventanaListado.Seleccionado;
            ventanaListado.Close();
            
            #endregion
        }

        private void cmbDesctoUno_SelectedValueChanged(object sender, EventArgs e)
        {
            #region cmbDesctoUno_SelectedValueChanged
            if (!cmbDesctoUno.Text.Equals("N/A"))
                txtDesctoUno.Enabled = true;
            else
                txtDesctoUno.Enabled = false;
            #endregion
        }

        private void cmbDesctoDos_SelectedValueChanged(object sender, EventArgs e)
        {
            #region cmbDesctoDos_SelectedValueChanged
            #endregion
        }

        private void txtDesctoDos_TextChanged(object sender, EventArgs e)
        {
            #region txtDesctoDos_TextChanged
            controller.CalcularPrecioVenta(txtVentaDos, txtUnidadDos, txtMargenDos, txtDesctoDos, true);
            #endregion
        }

       

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            #region btnGrabar_Click
            Validador validador = controller.ValidarControles(txtClave, txtDescripcion, txtFactor, numericMin, numericMax, txtCompraGeneral, txtUnidadUno, txtUnidadDos, groupCantidades, groupPrecios, richDescripcion);
            if (validador.Resultado)
            {
                controller.GuardarInformacion(txtClave, txtProveedor, txtDescripcion, cmbMarca, groupClasificacion, groupCantidades, groupCompra, groupPrecios, richDescripcion);
                MessageBox.Show("El articulo se registro correctamente!...","Aviso",MessageBoxButtons.OK);
                ArticuloConsulta ventana = new ArticuloConsulta();
                ventana.Show();
                this.Close();

            }
            else
                MessageBox.Show(validador.Mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

           
            #endregion
        }

        private void btnPasillo_Click(object sender, EventArgs e)
        {
            #region btnPasillo_Click
            ventanaListado = new Listados(TituloVentana.CONS_PASILLO);
            ventanaListado.ShowDialog();
            controller.RecargarCargarDatos(cmbPasillo, "PasilloID");
            cmbPasillo.Text = ventanaListado.Seleccionado;
            ventanaListado.Close();
            #endregion
        }

        private void btnMueble_Click(object sender, EventArgs e)
        {
            #region btnMueble_Click
            ventanaListado = new Listados(TituloVentana.CONS_MUEBLE);
            ventanaListado.ShowDialog();
            controller.RecargarCargarDatos(cmbMueble, "MuebleID");
            cmbMueble.Text = ventanaListado.Seleccionado;
            ventanaListado.Close();
            #endregion
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            ventanaListado = new Listados(TituloVentana.CONS_PROVEEDOR);
            ventanaListado.ShowDialog();
            controller.RecargarCargarDatos(cmbProveedor, "ProveedorID");
            cmbProveedor.Text = ventanaListado.Seleccionado;
            ventanaListado.Close();
        }

       
    }
}
