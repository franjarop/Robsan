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
    public partial class PagoCliente : Form
    {
        #region Propiedades
        double cantidad;
        bool pagocuenta = false;
        double saldo;
        #endregion
        public PagoCliente(String cantidad)
        {
           
            InitializeComponent();
            lblTotal.Text = ""+cantidad;
            lblTotalCambio.Text = "$0.00";
            if (!cantidad.Equals("$0.00"))
                this.cantidad = Convert.ToDouble(cantidad);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            pagocuenta = false;
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEfectivo.Text.Trim()))
            {
                Double efectivo = Convert.ToDouble(txtEfectivo.Text.Trim());
                if (efectivo > cantidad)
                {
                    lblTotalCambio.Text = "$ "+(efectivo - cantidad).ToString();
                    lblTotal.Text = "$0.00";
                }
                else
                {
                    lblTotal.Text ="$ "+ (cantidad - efectivo).ToString();
                    pagocuenta = true;
                }
                

            }
            else
            {
                lblTotal.Text = cantidad.ToString();
                lblTotalCambio.Text = "0.00";
            }
            
             if (saldo == 0)
                 pagocuenta = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saldo = Convert.ToDouble(lblTotal.Text.Substring(1));
            if (saldo != 0)
                MessageBox.Show("No puede liquidar la cuenta, debido a que tiene un faltante", "Aviso", MessageBoxButtons.OK);
            else
                this.Hide();
        }

        internal bool ObtenerPermiso()
        {
            return pagocuenta;
        }
    }
}
