using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobsanNET.Operaciones.Ventas
{
    public partial class PuntoVenta : Form
    {
        #region Propiedades
        PuntoVentaController controller;
        int detalleID;

        #endregion
        public PuntoVenta()
        {
            InitializeComponent();
            controller = new PuntoVentaController();
            CargarDatos();
        }

        private void CargarDatos()
        {
            #region CargarDatos
            controller.CargarDatos(lblFolio, lblFecha, cmbTipoPago, lblUsuario);
            #endregion
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            //controller.CargarArticulo(txtClave, gridControl1, cmbTipoPago, lblTotal);
            

        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            #region btnEfectivo_Click
            PagoCliente ventana = new PagoCliente(lblTotal.Text);
            ventana.ShowDialog();
            Random rnd = new Random();
            bool permiso =  ventana.ObtenerPermiso();
            if(permiso)
            {
                detalleID =Convert.ToInt32(Convert.ToInt32(lblFolio.Text.Trim()) +rnd.Next(1,9000));
                controller.GuardarVentaEncabezado(lblFolio, lblFecha, cmbTipoPago.SelectedValue.ToString(), lblUsuario, detalleID, lblTotal.Text);
                controller.GuardarVentaDetalle(detalleID);
                controller.EliminarArticulosVendidos();
                ventana.Close();
                this.Close();
                PuntoVenta nuevaVenta = new PuntoVenta();
                nuevaVenta.Show();
            }
           
           
            #endregion
        }

        

        private void PuntoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
                btnEfectivo.PerformClick();
            if(e.KeyCode == Keys.Enter)
            {
                controller.CargarArticulo(txtClave, gridControl1, cmbTipoPago, lblTotal);
            }
        }

       

     

    }
}
