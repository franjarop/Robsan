using RobsanNET.Operaciones;
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
    public partial class Listados : Form
    {
        #region propiedades
        ListadosController controller;
        RegistroListado ventanaRegistro;
        public string  Seleccionado { get; set; }
    
        #endregion
        public Listados(string tituloVentana)
        {
            InitializeComponent();
            this.Text = tituloVentana;
            controller = new ListadosController();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            #region btnAgregar_Click
            String nombreVentana = string.Empty;
            switch(this.Text)
            {
                case TituloVentana.CONS_PROVEEDOR:
                    nombreVentana = TituloVentana.REG_PROVEEDOR;
                    break;
                case TituloVentana.CONS_MARCA:
                    nombreVentana = TituloVentana.REG_MARCA;
                    break;
                case TituloVentana.CONS_CATEGORIA:
                    nombreVentana = TituloVentana.REG_CATEGORIA;
                    break;
                case TituloVentana.CONS_DEPARTAMENTO:
                    nombreVentana = TituloVentana.REG_DEPARTAMENTO;
                    break;
                case TituloVentana.CONS_PASILLO:
                    nombreVentana = TituloVentana.REG_PASILLO;
                    break;
                case TituloVentana.CONS_MUEBLE:
                    nombreVentana = TituloVentana.REG_MUEBLE;
                    break;
            }
            ventanaRegistro = new RegistroListado(nombreVentana);
            ventanaRegistro.ShowDialog();
            MostrarInformacion();
            #endregion
        }

        private void MostrarInformacion()
        {
            switch (this.Text)
            {
                case TituloVentana.CONS_PROVEEDOR:
                    gridLista.DataSource = controller.ObtenerListaProveedores();
                    break;
                case TituloVentana.CONS_MARCA:
                    gridLista.DataSource = controller.ObtenerListaMarcaBLL();
                    break;
                case TituloVentana.CONS_CATEGORIA:
                    gridLista.DataSource = controller.ObtenerListaCategoriaBLL();
                    break;
                case TituloVentana.CONS_DEPARTAMENTO:
                    gridLista.DataSource = controller.ObtenerListadoDepartamentosBLL();
                    break;
                case TituloVentana.CONS_PASILLO:
                    gridLista.DataSource = controller.ObtenerlistadoPasillos();
                    break;
                case TituloVentana.CONS_MUEBLE:
                    gridLista.DataSource = controller.ObtenerListadoMuebles();
                    break;
            }
        }

        private void Listados_Load(object sender, EventArgs e)
        {
            MostrarInformacion();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            #region txtBusqueda_TextChanged
            switch (this.Text)
            {
                case TituloVentana.CONS_CATEGORIA:
                    gridLista.DataSource = controller.ObtenerListaCategoriaFiltradaBLL(txtBusqueda.Text.Trim());
                    break;
                case TituloVentana.CONS_DEPARTAMENTO:
                    gridLista.DataSource = controller.ObtenerListadoDepartamentosBLL();
                    break;
            }
            #endregion
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            #region btnSeleccionar_Click
            Seleccionado = gridView1.GetFocusedRowCellValue("Descripcion").ToString();
            this.Hide();
            #endregion
        }

        
    }
}
