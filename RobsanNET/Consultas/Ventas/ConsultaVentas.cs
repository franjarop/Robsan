using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class ConsultaVentas : Form
    {
        #region propiedades
        ConsultaVentaController controller;
        #endregion
        public ConsultaVentas()
        {
            InitializeComponent();
            controller = new ConsultaVentaController();
            CargarDatos();
        }

        private void CargarDatos()
        {
            #region CargarDatos
            try
            {
                gridVentas.DataSource = controller.ObtenerListadoVentas();
            }
            catch (Exception)
            {
                
                throw;
            }
            #endregion
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String DetalleID = gridView1.GetFocusedRowCellValue("DetalleID").ToString();
                ConsultaDetalleVentas ventanaDetalle = new ConsultaDetalleVentas(DetalleID);
                ventanaDetalle.ShowDialog();
            }
            catch (Exception)
            {
                
            }  
           

        }
    }
}
