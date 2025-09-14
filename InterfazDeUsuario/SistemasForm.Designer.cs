namespace InterfazDeUsuario
{
    partial class SistemasForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Entrada
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.Button btnArmar;
        private System.Windows.Forms.DataGridView dgvEntrada;

        private System.Windows.Forms.Label lblMetodoSis;
        private System.Windows.Forms.ComboBox cmbMetodoSis;

        private System.Windows.Forms.Label lblToleranciaSis;
        private System.Windows.Forms.TextBox txtToleranciaSis;
        private System.Windows.Forms.Label lblMaxIterSis;
        private System.Windows.Forms.TextBox txtMaxIterSis;

        private System.Windows.Forms.CheckBox chkCapturarPasos;
        private System.Windows.Forms.Button btnResolverSis;

        // Salida
        private System.Windows.Forms.GroupBox grpResultado;
        private System.Windows.Forms.Label lblSolucionSis;
        private System.Windows.Forms.TextBox txtSolucionSis;

        private System.Windows.Forms.Label lblReducida;
        private System.Windows.Forms.DataGridView dgvReducida;

        private System.Windows.Forms.Label lblAdvertenciasSis;
        private System.Windows.Forms.ListBox lstAdvertenciasSis;

        private System.Windows.Forms.Label lblErroresSis;
        private System.Windows.Forms.ListBox lstErroresSis;

        private System.Windows.Forms.Label lblPasosSis;
        private System.Windows.Forms.ListBox lstPasosSis;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblN = new System.Windows.Forms.Label();
            this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
            this.btnArmar = new System.Windows.Forms.Button();
            this.dgvEntrada = new System.Windows.Forms.DataGridView();

            this.lblMetodoSis = new System.Windows.Forms.Label();
            this.cmbMetodoSis = new System.Windows.Forms.ComboBox();
            this.lblToleranciaSis = new System.Windows.Forms.Label();
            this.txtToleranciaSis = new System.Windows.Forms.TextBox();
            this.lblMaxIterSis = new System.Windows.Forms.Label();
            this.txtMaxIterSis = new System.Windows.Forms.TextBox();
            this.chkCapturarPasos = new System.Windows.Forms.CheckBox();
            this.btnResolverSis = new System.Windows.Forms.Button();

            this.grpResultado = new System.Windows.Forms.GroupBox();
            this.lblSolucionSis = new System.Windows.Forms.Label();
            this.txtSolucionSis = new System.Windows.Forms.TextBox();
            this.lblReducida = new System.Windows.Forms.Label();
            this.dgvReducida = new System.Windows.Forms.DataGridView();
            this.lblAdvertenciasSis = new System.Windows.Forms.Label();
            this.lstAdvertenciasSis = new System.Windows.Forms.ListBox();
            this.lblErroresSis = new System.Windows.Forms.Label();
            this.lstErroresSis = new System.Windows.Forms.ListBox();
            this.lblPasosSis = new System.Windows.Forms.Label();
            this.lstPasosSis = new System.Windows.Forms.ListBox();

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReducida)).BeginInit();

            this.SuspendLayout();

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Sistemas de ecuaciones";
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SistemasForm_Load);

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Text = "Sistemas de ecuaciones (Gauss-Jordan / Gauss-Seidel)";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);

            // lblN
            this.lblN.AutoSize = true;
            this.lblN.Text = "Dimensión n:";
            this.lblN.Location = new System.Drawing.Point(20, 60);

            // numericUpDownN
            this.numericUpDownN.Location = new System.Drawing.Point(120, 58);
            this.numericUpDownN.Minimum = 2;
            this.numericUpDownN.Maximum = 10;
            this.numericUpDownN.Value = 3;
            this.numericUpDownN.Width = 60;

            // btnArmar
            this.btnArmar.Text = "Armar matriz";
            this.btnArmar.Location = new System.Drawing.Point(200, 55);
            this.btnArmar.Size = new System.Drawing.Size(120, 30);
            this.btnArmar.Click += new System.EventHandler(this.btnArmar_Click);

            // dgvEntrada
            this.dgvEntrada.Location = new System.Drawing.Point(20, 100);
            this.dgvEntrada.Size = new System.Drawing.Size(620, 380);
            this.dgvEntrada.AllowUserToAddRows = false;
            this.dgvEntrada.AllowUserToDeleteRows = false;
            this.dgvEntrada.RowHeadersVisible = false;
            this.dgvEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // lblMetodoSis
            this.lblMetodoSis.AutoSize = true;
            this.lblMetodoSis.Text = "Método";
            this.lblMetodoSis.Location = new System.Drawing.Point(20, 500);

            // cmbMetodoSis
            this.cmbMetodoSis.Location = new System.Drawing.Point(20, 525);
            this.cmbMetodoSis.Size = new System.Drawing.Size(300, 28);
            this.cmbMetodoSis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoSis.SelectedIndexChanged += new System.EventHandler(this.cmbMetodoSis_SelectedIndexChanged);

            // lblToleranciaSis
            this.lblToleranciaSis.AutoSize = true;
            this.lblToleranciaSis.Text = "Tolerancia (Seidel)";
            this.lblToleranciaSis.Location = new System.Drawing.Point(20, 565);

            // txtToleranciaSis
            this.txtToleranciaSis.Location = new System.Drawing.Point(20, 588);
            this.txtToleranciaSis.Size = new System.Drawing.Size(140, 27);
            this.txtToleranciaSis.Text = "0.001";

            // lblMaxIterSis
            this.lblMaxIterSis.AutoSize = true;
            this.lblMaxIterSis.Text = "Máx. iteraciones (Seidel)";
            this.lblMaxIterSis.Location = new System.Drawing.Point(180, 565);

            // txtMaxIterSis
            this.txtMaxIterSis.Location = new System.Drawing.Point(180, 588);
            this.txtMaxIterSis.Size = new System.Drawing.Size(140, 27);
            this.txtMaxIterSis.Text = "1000";

            // chkCapturarPasos
            this.chkCapturarPasos.AutoSize = true;
            this.chkCapturarPasos.Text = "Capturar pasos";
            this.chkCapturarPasos.Location = new System.Drawing.Point(20, 630);
            this.chkCapturarPasos.Checked = true;

            // btnResolverSis
            this.btnResolverSis.Text = "Resolver";
            this.btnResolverSis.Location = new System.Drawing.Point(20, 670);
            this.btnResolverSis.Size = new System.Drawing.Size(300, 40);
            this.btnResolverSis.Click += new System.EventHandler(this.btnResolverSis_Click);

            // grpResultado
            this.grpResultado.Text = "Resultado";
            this.grpResultado.Location = new System.Drawing.Point(660, 60);
            this.grpResultado.Size = new System.Drawing.Size(710, 740);

            // lblSolucionSis
            this.lblSolucionSis.AutoSize = true;
            this.lblSolucionSis.Text = "Solución";
            this.lblSolucionSis.Location = new System.Drawing.Point(680, 20); // relativo al form
            // Lo agregaremos dentro del GroupBox con coordenadas internas más abajo.

            // txtSolucionSis
            this.txtSolucionSis.Location = new System.Drawing.Point(680, 45);
            this.txtSolucionSis.Multiline = true;
            this.txtSolucionSis.ReadOnly = true;
            this.txtSolucionSis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSolucionSis.Size = new System.Drawing.Size(670, 80);

            // lblReducida
            this.lblReducida.AutoSize = true;
            this.lblReducida.Text = "Matriz final / paso seleccionado";
            this.lblReducida.Location = new System.Drawing.Point(680, 140);

            // dgvReducida
            this.dgvReducida.Location = new System.Drawing.Point(680, 165);
            this.dgvReducida.Size = new System.Drawing.Size(670, 240);
            this.dgvReducida.AllowUserToAddRows = false;
            this.dgvReducida.AllowUserToDeleteRows = false;
            this.dgvReducida.RowHeadersVisible = false;
            this.dgvReducida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // lblAdvertenciasSis
            this.lblAdvertenciasSis.AutoSize = true;
            this.lblAdvertenciasSis.Text = "Advertencias";
            this.lblAdvertenciasSis.Location = new System.Drawing.Point(680, 415);

            // lstAdvertenciasSis
            this.lstAdvertenciasSis.Location = new System.Drawing.Point(680, 440);
            this.lstAdvertenciasSis.Size = new System.Drawing.Size(320, 160);

            // lblErroresSis
            this.lblErroresSis.AutoSize = true;
            this.lblErroresSis.Text = "Errores";
            this.lblErroresSis.Location = new System.Drawing.Point(1030, 415);

            // lstErroresSis
            this.lstErroresSis.Location = new System.Drawing.Point(1030, 440);
            this.lstErroresSis.Size = new System.Drawing.Size(320, 160);

            // lblPasosSis
            this.lblPasosSis.AutoSize = true;
            this.lblPasosSis.Text = "Pasos";
            this.lblPasosSis.Location = new System.Drawing.Point(680, 610);

            // lstPasosSis
            this.lstPasosSis.Location = new System.Drawing.Point(680, 635);
            this.lstPasosSis.Size = new System.Drawing.Size(670, 160);
            this.lstPasosSis.SelectedIndexChanged += new System.EventHandler(this.lstPasosSis_SelectedIndexChanged);

            // Agregar controles al form
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.numericUpDownN);
            this.Controls.Add(this.btnArmar);
            this.Controls.Add(this.dgvEntrada);

            this.Controls.Add(this.lblMetodoSis);
            this.Controls.Add(this.cmbMetodoSis);
            this.Controls.Add(this.lblToleranciaSis);
            this.Controls.Add(this.txtToleranciaSis);
            this.Controls.Add(this.lblMaxIterSis);
            this.Controls.Add(this.txtMaxIterSis);
            this.Controls.Add(this.chkCapturarPasos);
            this.Controls.Add(this.btnResolverSis);

            this.Controls.Add(this.lblSolucionSis);
            this.Controls.Add(this.txtSolucionSis);
            this.Controls.Add(this.lblReducida);
            this.Controls.Add(this.dgvReducida);
            this.Controls.Add(this.lblAdvertenciasSis);
            this.Controls.Add(this.lstAdvertenciasSis);
            this.Controls.Add(this.lblErroresSis);
            this.Controls.Add(this.lstErroresSis);
            this.Controls.Add(this.lblPasosSis);
            this.Controls.Add(this.lstPasosSis);

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReducida)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}