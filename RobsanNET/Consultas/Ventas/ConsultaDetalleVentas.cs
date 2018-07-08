using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobsanNET.Consultas.Ventas
{
    public partial class ConsultaDetalleVentas : Form
    {
        #region Propiedades
        String detalleID;
        ConsultaDetalleVentasController controller;
        #endregion
        public ConsultaDetalleVentas(String detalleID)
        {
            InitializeComponent();
            this.detalleID = detalleID;
            controller = new ConsultaDetalleVentasController();
            CargarDatos();
        }

        private void CargarDatos()
        {
            #region CargarDatos
            gridVentasDetalle.DataSource = controller.ObtenerDetalleVenta(this.detalleID);
            #endregion
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
