namespace RotiseriaDesktop
{
    partial class FrmListaUsuarios
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerUsuarios = new Microsoft.Reporting.WinForms.ReportViewer();
            this.UsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewerUsuarios
            // 
            this.reportViewerUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Usuarios";
            reportDataSource1.Value = this.UsuarioBindingSource;
            this.reportViewerUsuarios.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerUsuarios.LocalReport.ReportEmbeddedResource = "RotiseriaDesktop.ListaUsuarios.rdlc";
            this.reportViewerUsuarios.Location = new System.Drawing.Point(0, 0);
            this.reportViewerUsuarios.Name = "reportViewerUsuarios";
            this.reportViewerUsuarios.Size = new System.Drawing.Size(800, 450);
            this.reportViewerUsuarios.TabIndex = 0;
            // 
            // UsuarioBindingSource
            // 
            this.UsuarioBindingSource.DataSource = typeof(Datos.Usuario);
            // 
            // FrmListaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerUsuarios);
            this.Name = "FrmListaUsuarios";
            this.Text = "FrmListaUsuarios";
            this.Load += new System.EventHandler(this.FrmListaUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerUsuarios;
        private System.Windows.Forms.BindingSource UsuarioBindingSource;
    }
}