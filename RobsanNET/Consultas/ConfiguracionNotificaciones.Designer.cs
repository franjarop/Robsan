namespace RobsanNET.Consultas
{
    partial class ConfiguracionNotificaciones
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
            this.groupCorreo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPara = new System.Windows.Forms.TextBox();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richMensaje = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupCorreo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupCorreo
            // 
            this.groupCorreo.BackColor = System.Drawing.Color.LightGray;
            this.groupCorreo.Controls.Add(this.label3);
            this.groupCorreo.Controls.Add(this.richMensaje);
            this.groupCorreo.Controls.Add(this.txtCC);
            this.groupCorreo.Controls.Add(this.label2);
            this.groupCorreo.Controls.Add(this.txtPara);
            this.groupCorreo.Controls.Add(this.label1);
            this.groupCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCorreo.Location = new System.Drawing.Point(12, 12);
            this.groupCorreo.Name = "groupCorreo";
            this.groupCorreo.Size = new System.Drawing.Size(394, 278);
            this.groupCorreo.TabIndex = 0;
            this.groupCorreo.TabStop = false;
            this.groupCorreo.Text = "Configuracion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para:";
            // 
            // txtPara
            // 
            this.txtPara.Location = new System.Drawing.Point(57, 28);
            this.txtPara.Name = "txtPara";
            this.txtPara.Size = new System.Drawing.Size(309, 22);
            this.txtPara.TabIndex = 1;
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(57, 72);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(309, 22);
            this.txtCC.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CC:";
            // 
            // richMensaje
            // 
            this.richMensaje.Location = new System.Drawing.Point(57, 138);
            this.richMensaje.Name = "richMensaje";
            this.richMensaje.Size = new System.Drawing.Size(309, 124);
            this.richMensaje.TabIndex = 4;
            this.richMensaje.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mensaje:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(12, 302);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(331, 302);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // ConfiguracionNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 337);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupCorreo);
            this.Name = "ConfiguracionNotificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfiguracionNotificaciones";
            this.groupCorreo.ResumeLayout(false);
            this.groupCorreo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupCorreo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richMensaje;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
    }
}