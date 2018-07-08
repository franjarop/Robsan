using RobsanNET.BLLRobsanNET;
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

namespace RobsanNET.Genericos.Ventanas
{
    public partial class RegistroListado : Form
    {
        #region propiedades
        BLLOperacion operacion;
        #endregion
        public RegistroListado(String tituloVentana)
        {
            InitializeComponent();
            this.Text = tituloVentana;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtNombre.Text.Trim()))
            operacion = new BLLOperacion();
            switch (this.Text)
            {
                case TituloVentana.REG_PROVEEDOR:
                    operacion._proveedor.Descripcion = txtNombre.Text.ToUpper().Trim();
                    operacion.RegistrarProveedorBLL();
                    break;
                case TituloVentana.REG_MARCA:
                    operacion._marca.Descripcion = txtNombre.Text.ToUpper().Trim();
                    operacion._marca.FechaRegistro = System.DateTime.Now;
                    operacion.RegistrarMarcaBLL();
                    break;
                case TituloVentana.REG_CATEGORIA:
                    operacion._categoria.Descripcion = txtNombre.Text.ToUpper().Trim();
                    operacion.RegistrarCategoriaBLL();
                    break;
                case TituloVentana.REG_DEPARTAMENTO:
                    operacion._departamento.Descripcion = txtNombre.Text.ToUpper().Trim();
                    operacion.RegistrarDepartamentoBLL();
                    break;
                case TituloVentana.REG_PASILLO:
                    operacion._pasillo.Descripcion = txtNombre.Text.ToUpper().Trim();
                    operacion.RegistrarPasilloBLL();
                    break;
                case TituloVentana.REG_MUEBLE:
                    operacion._mueble.Descripcion = txtNombre.Text.ToUpper().Trim();
                    operacion.RegistrarMuebleBLL();
                    break;

            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            #region btnCancelar_Click
            this.Close();
            #endregion
        }
    }
}
