namespace RobsanNET.Genericos.Ventanas
{
    partial class Listados
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
            this.paMenu = new System.Windows.Forms.Panel();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.gridLista = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.paMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // paMenu
            // 
            this.paMenu.BackColor = System.Drawing.Color.LightGray;
            this.paMenu.Controls.Add(this.btnSeleccionar);
            this.paMenu.Controls.Add(this.btnCancelar);
            this.paMenu.Controls.Add(this.btnAgregar);
            this.paMenu.Controls.Add(this.txtBusqueda);
            this.paMenu.Location = new System.Drawing.Point(0, 1);
            this.paMenu.Name = "paMenu";
            this.paMenu.Size = new System.Drawing.Size(388, 63);
            this.paMenu.TabIndex = 0;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::RobsanNET.Properties.Resources.seleccionar;
            this.btnSeleccionar.Location = new System.Drawing.Point(247, 17);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(35, 35);
            this.btnSeleccionar.TabIndex = 14;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::RobsanNET.Properties.Resources.cruz_eliminar;
            this.btnCancelar.Location = new System.Drawing.Point(337, 17);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(35, 35);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::RobsanNET.Properties.Resources.etiqueta_de_nuevo_producto;
            this.btnAgregar.Location = new System.Drawing.Point(292, 17);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(35, 35);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(3, 23);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(238, 21);
            this.txtBusqueda.TabIndex = 11;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // gridLista
            // 
            this.gridLista.Location = new System.Drawing.Point(0, 61);
            this.gridLista.MainView = this.gridView1;
            this.gridLista.Name = "gridLista";
            this.gridLista.Size = new System.Drawing.Size(385, 300);
            this.gridLista.TabIndex = 1;
            this.gridLista.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridLista;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // Listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.ControlBox = false;
            this.Controls.Add(this.gridLista);
            this.Controls.Add(this.paMenu);
            this.Name = "Listados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados";
            this.Load += new System.EventHandler(this.Listados_Load);
            this.paMenu.ResumeLayout(false);
            this.paMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paMenu;
        private DevExpress.XtraGrid.GridControl gridLista;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}