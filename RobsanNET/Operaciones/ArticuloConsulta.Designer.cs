namespace RobsanNET.Operaciones
{
    partial class ArticuloConsulta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columClave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columMarca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnDepartamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columExistencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columAcumulado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columCaracteristicas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.lblTotal = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemHypertextLabel1 = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
            this.lblTotal2 = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.columnProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 143);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(790, 456);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columClave,
            this.columnProveedor,
            this.columDescripcion,
            this.columMarca,
            this.columCategoria,
            this.ColumnDepartamento,
            this.columPrecio,
            this.columExistencia,
            this.columAcumulado,
            this.columCaracteristicas});
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 1;
            this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Acumulado", this.columAcumulado, "(Total: $ {0:0.##})")});
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColumnDepartamento, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // columClave
            // 
            this.columClave.Caption = "Clave";
            this.columClave.FieldName = "Clave";
            this.columClave.Name = "columClave";
            // 
            // columDescripcion
            // 
            this.columDescripcion.Caption = "Descripcion";
            this.columDescripcion.FieldName = "Descripcion";
            this.columDescripcion.Name = "columDescripcion";
            this.columDescripcion.Visible = true;
            this.columDescripcion.VisibleIndex = 2;
            // 
            // columMarca
            // 
            this.columMarca.Caption = "Marca";
            this.columMarca.FieldName = "Marca";
            this.columMarca.Name = "columMarca";
            this.columMarca.Visible = true;
            this.columMarca.VisibleIndex = 3;
            // 
            // columCategoria
            // 
            this.columCategoria.Caption = "Categoria";
            this.columCategoria.FieldName = "Categoria";
            this.columCategoria.Name = "columCategoria";
            this.columCategoria.Visible = true;
            this.columCategoria.VisibleIndex = 4;
            // 
            // ColumnDepartamento
            // 
            this.ColumnDepartamento.Caption = "Departamento";
            this.ColumnDepartamento.FieldName = "Departamento";
            this.ColumnDepartamento.Name = "ColumnDepartamento";
            this.ColumnDepartamento.Visible = true;
            this.ColumnDepartamento.VisibleIndex = 4;
            // 
            // columPrecio
            // 
            this.columPrecio.Caption = "Precio";
            this.columPrecio.FieldName = "Precio";
            this.columPrecio.Name = "columPrecio";
            this.columPrecio.Visible = true;
            this.columPrecio.VisibleIndex = 5;
            // 
            // columExistencia
            // 
            this.columExistencia.Caption = "Existencia";
            this.columExistencia.FieldName = "Existencia";
            this.columExistencia.Name = "columExistencia";
            this.columExistencia.Visible = true;
            this.columExistencia.VisibleIndex = 6;
            // 
            // columAcumulado
            // 
            this.columAcumulado.Caption = "Acumulado";
            this.columAcumulado.FieldName = "Acumulado";
            this.columAcumulado.Name = "columAcumulado";
            this.columAcumulado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Acumulado", "SUM={0:0.##}")});
            this.columAcumulado.Visible = true;
            this.columAcumulado.VisibleIndex = 7;
            // 
            // columCaracteristicas
            // 
            this.columCaracteristicas.Caption = "Caracteristicas";
            this.columCaracteristicas.FieldName = "Caracteristicas";
            this.columCaracteristicas.Name = "columCaracteristicas";
            this.columCaracteristicas.Visible = true;
            this.columCaracteristicas.VisibleIndex = 8;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.bbiNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiRefresh,
            this.barButtonItem1,
            this.lblTotal,
            this.lblTotal2});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 23;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHypertextLabel1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(790, 143);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Vista Previa";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintPreview_ItemClick);
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "Nuevo";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.ImageUri.Uri = "New";
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Editar";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Eliminar";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Actualizar";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Clonar";
            this.barButtonItem1.Id = 20;
            this.barButtonItem1.ImageOptions.ImageUri.Uri = "Copy";
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // lblTotal
            // 
            this.lblTotal.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblTotal.Caption = "barEditItem1";
            this.lblTotal.Edit = this.repositoryItemHypertextLabel1;
            this.lblTotal.Id = 21;
            this.lblTotal.Name = "lblTotal";
            // 
            // repositoryItemHypertextLabel1
            // 
            this.repositoryItemHypertextLabel1.Name = "repositoryItemHypertextLabel1";
            // 
            // lblTotal2
            // 
            this.lblTotal2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblTotal2.Caption = "barStaticItem2";
            this.lblTotal2.Id = 22;
            this.lblTotal2.Name = "lblTotal2";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Tasks";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Print and Export";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.ItemLinks.Add(this.lblTotal2);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 568);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(790, 31);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "RECORDS : 0";
            this.barStaticItem1.Id = 15;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // columnProveedor
            // 
            this.columnProveedor.Caption = "NPC";
            this.columnProveedor.FieldName = "ClaveProveedor";
            this.columnProveedor.Name = "columnProveedor";
            this.columnProveedor.Visible = true;
            this.columnProveedor.VisibleIndex = 1;
            // 
            // ArticuloConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 599);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "ArticuloConsulta";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Articulos";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarEditItem lblTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel repositoryItemHypertextLabel1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem lblTotal2;
        private DevExpress.XtraGrid.Columns.GridColumn columClave;
        private DevExpress.XtraGrid.Columns.GridColumn columDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn columMarca;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnDepartamento;
        private DevExpress.XtraGrid.Columns.GridColumn columPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn columExistencia;
        private DevExpress.XtraGrid.Columns.GridColumn columAcumulado;
        private DevExpress.XtraGrid.Columns.GridColumn columCaracteristicas;
        private DevExpress.XtraGrid.Columns.GridColumn columCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn columnProveedor;
    }
}