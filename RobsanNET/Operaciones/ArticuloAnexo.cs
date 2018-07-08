using DataLINQ_RobsanNET;
using RobsanNET.BLLRobsanNET;
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
    
    public partial class ArticuloAnexo : Form
    {
        #region Propiedades
        List<USPGETINFORMACIONARTICULOResult> lstDetalleArticulo;
        BLLOperacion operacion;
        int totalArticulos;
        #endregion

        public ArticuloAnexo()
        {
            InitializeComponent();
            operacion = new BLLOperacion();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar==(int)Keys.Enter)
            {
                lstDetalleArticulo = operacion.ObtenerDetalleArticuloBLL(txtCodigo.Text.Trim());
                foreach (USPGETINFORMACIONARTICULOResult articulo in lstDetalleArticulo)
                {
                    lblDescripcion.Text = articulo.DescripcionArticulo;
                    lblMarca.Text = articulo.DescripcionMarca;
                    lblExistencias.Text = articulo.Existencia +" " + articulo.UnidadVenta;
                    totalArticulos = Convert.ToInt32(articulo.Existencia);
                    
                }
            }
        }

        private void numericUnidades_ValueChanged(object sender, EventArgs e)
        {
            lblTotal.Text = (totalArticulos + numericUnidades.Value).ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtCodigo.Text.Trim()))
            {
                operacion._cantidadesArt.ArticuloID = txtCodigo.Text;
                operacion._cantidadesArt.Existencia = Convert.ToInt32(lblTotal.Text);
                operacion.ActualizarCantidadesBLL();
                MessageBox.Show("Articulo actualizado", "Aviso", MessageBoxButtons.OK);
                txtCodigo.Text = String.Empty;
                txtCodigo.Focus();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
