using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using DataLINQ_RobsanNET;
using RobsanNET.Parametros;
using RobsanNET.Genericos;
using RobsanNET.Genericos.Ventanas;
using System.Globalization;

namespace RobsanNET.Operaciones
{
    public partial class ArticuloConsulta : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Propiedades
        ArticuloConsultaController controller = new ArticuloConsultaController();
        List<USPGETARTICULOSDETALLEResult> lstArticulosDet;
        #endregion
        public ArticuloConsulta()
        {
            InitializeComponent();
            CargarDatos();
            VerificacionPermisos();
        }

        private void VerificacionPermisos()
        {
            foreach (var permiso in DatosUsuario.Permisos)
            {
                   int nPemiso = Convert.ToInt32(permiso);
                if(nPemiso==2 || nPemiso==3)
                {
                    bbiEdit.Enabled = false;
                    bbiRefresh.Enabled = false;
                }
            }
        }

        private void CargarDatos()
        {
            #region CargarDatos
            CultureInfo mexico = new CultureInfo("es-MX");
            lstArticulosDet = controller.ObtenerArticulosDetalle();
            gridControl.DataSource = lstArticulosDet;
            bsiRecordsCount.Caption = "ARTICULOS : " + lstArticulosDet.Count;
            int sumaTotal = 0;
            foreach (USPGETARTICULOSDETALLEResult articulo in lstArticulosDet)
            {
                sumaTotal = sumaTotal + Convert.ToInt32(articulo.Acumulado);
            }
            lblTotal2.Caption = "TOTAL GENERAL:" + sumaTotal.ToString("C",mexico);
           
            #endregion
        }
        
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        
        
        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region bbiNew_ItemClick
            Acciones.MODO_CONSULTA = false;
            ArticuloRegistro ventanaRegistro = new ArticuloRegistro();
            ventanaRegistro.Show();
            this.Close();
            CargarDatos();
            #endregion

        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region bbiNew_ItemClick
            String claveID = String.Empty;
            Acciones.MODO_CONSULTA = true;
            claveID = gridView.GetFocusedRowCellValue("Clave").ToString();
            ArticuloRegistro ventanaRegistro = new ArticuloRegistro(claveID);
            ventanaRegistro.ShowDialog();
            CargarDatos();
            #endregion
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region bbiDelete_ItemClick
            bool encontroPermiso = false;
            foreach (var permiso in DatosUsuario.Permisos)
            {
                int nPermiso = Convert.ToInt32(permiso);
                if (nPermiso == 1)
                {
                    encontroPermiso = true;
                    break;
                }
            }
            if(!encontroPermiso)
            {
                ActivacionPermiso ventana = new ActivacionPermiso();
                ventana.ShowDialog();
                if (Acciones.MODO_ELIMINACION)
                    encontroPermiso = true;
               
            }
            if(encontroPermiso)
            {
                String claveID = String.Empty;
                if (gridView.RowCount > 0)
                {
                    claveID = gridView.GetFocusedRowCellValue("Clave").ToString();
                    controller.EliminarArticulo(claveID);
                }
                else
                    MessageBox.Show("No existen articulos registrados", "Aviso", MessageBoxButtons.OK);
                
            }
            CargarDatos();
           
            #endregion
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ArticuloAnexo ventanAnexo = new ArticuloAnexo();
            ventanAnexo.ShowDialog();
            CargarDatos();
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }
    }
}