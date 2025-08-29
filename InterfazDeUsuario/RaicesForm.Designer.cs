namespace InterfazDeUsuario
{
    partial class RaicesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewGeoGebra;

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
            lblIngresarFuncion = new Label();
            txtFuncion = new TextBox();
            cmbMetodo = new ComboBox();
            lblMetodo = new Label();
            lblIteraciones = new Label();
            txtIteraciones = new TextBox();
            lblTolerancia = new Label();
            txtTolerancia = new TextBox();
            lblIntervalo = new Label();
            lblXi = new Label();
            lblXd = new Label();
            txtXi = new TextBox();
            txtXd = new TextBox();
            buttonCalcular = new Button();
            lblRaiz = new Label();
            txtRaiz = new TextBox();
            lblMensaje = new Label();
            txtMensaje = new TextBox();
            lblIteracionesRes = new Label();
            txtIteracionesRes = new TextBox();
            lblErrorRes = new Label();
            txtErrorRes = new TextBox();
            webViewGeoGebra = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webViewGeoGebra).BeginInit();
            SuspendLayout();
            // 
            // lblIngresarFuncion
            // 
            lblIngresarFuncion.AutoSize = true;
            lblIngresarFuncion.BackColor = SystemColors.MenuHighlight;
            lblIngresarFuncion.Location = new Point(30, 64);
            lblIngresarFuncion.Name = "lblIngresarFuncion";
            lblIngresarFuncion.Size = new Size(145, 20);
            lblIngresarFuncion.TabIndex = 0;
            lblIngresarFuncion.Text = "INGRESAR FUNCIÓN";
            lblIngresarFuncion.Click += lblIngresarFuncion_Click;
            // 
            // txtFuncion
            // 
            txtFuncion.Location = new Point(38, 98);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(276, 27);
            txtFuncion.TabIndex = 1;
            // 
            // cmbMetodo
            // 
            cmbMetodo.FormattingEnabled = true;
            cmbMetodo.Items.AddRange(new object[] { "Método Cerrado: Bisección", "Método Cerrado: Regla Falsa", "Método Abierto: Newton-Raphson", "Método Abierto: Secante" });
            cmbMetodo.Location = new Point(38, 194);
            cmbMetodo.Name = "cmbMetodo";
            cmbMetodo.Size = new Size(274, 28);
            cmbMetodo.TabIndex = 2;
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.BackColor = SystemColors.Control;
            lblMetodo.Location = new Point(30, 160);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(168, 20);
            lblMetodo.TabIndex = 3;
            lblMetodo.Text = "SELECCIONAR MÉTODO";
            lblMetodo.Click += lblMetodo_Click;
            // 
            // lblIteraciones
            // 
            lblIteraciones.AutoSize = true;
            lblIteraciones.BackColor = SystemColors.GradientActiveCaption;
            lblIteraciones.Location = new Point(30, 241);
            lblIteraciones.Name = "lblIteraciones";
            lblIteraciones.Size = new Size(99, 20);
            lblIteraciones.TabIndex = 4;
            lblIteraciones.Text = "ITERACIONES";
            // 
            // txtIteraciones
            // 
            txtIteraciones.Location = new Point(38, 274);
            txtIteraciones.Name = "txtIteraciones";
            txtIteraciones.Size = new Size(274, 27);
            txtIteraciones.TabIndex = 5;
            // 
            // lblTolerancia
            // 
            lblTolerancia.AutoSize = true;
            lblTolerancia.BackColor = SystemColors.GradientActiveCaption;
            lblTolerancia.Location = new Point(34, 349);
            lblTolerancia.Name = "lblTolerancia";
            lblTolerancia.Size = new Size(95, 20);
            lblTolerancia.TabIndex = 6;
            lblTolerancia.Text = "TOLERANCIA";
            // 
            // txtTolerancia
            // 
            txtTolerancia.Location = new Point(38, 385);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(274, 27);
            txtTolerancia.TabIndex = 7;
            // 
            // lblIntervalo
            // 
            lblIntervalo.AutoSize = true;
            lblIntervalo.BackColor = SystemColors.GradientActiveCaption;
            lblIntervalo.Location = new Point(110, 456);
            lblIntervalo.Name = "lblIntervalo";
            lblIntervalo.Size = new Size(92, 20);
            lblIntervalo.TabIndex = 8;
            lblIntervalo.Text = "INTERVALOS";
            lblIntervalo.Click += lblIntervalo_Click;
            // 
            // lblXi
            // 
            lblXi.AutoSize = true;
            lblXi.BackColor = SystemColors.InactiveCaption;
            lblXi.Location = new Point(51, 475);
            lblXi.Name = "lblXi";
            lblXi.Size = new Size(22, 20);
            lblXi.TabIndex = 9;
            lblXi.Text = "Xi";
            // 
            // lblXd
            // 
            lblXd.AutoSize = true;
            lblXd.BackColor = SystemColors.ActiveCaption;
            lblXd.Location = new Point(236, 475);
            lblXd.Name = "lblXd";
            lblXd.Size = new Size(27, 20);
            lblXd.TabIndex = 10;
            lblXd.Text = "Xd";
            // 
            // txtXi
            // 
            txtXi.Location = new Point(38, 498);
            txtXi.Name = "txtXi";
            txtXi.Size = new Size(67, 27);
            txtXi.TabIndex = 11;
            txtXi.TextChanged += txtXi_TextChanged;
            // 
            // txtXd
            // 
            txtXd.Location = new Point(224, 498);
            txtXd.Name = "txtXd";
            txtXd.Size = new Size(69, 27);
            txtXd.TabIndex = 12;
            // 
            // buttonCalcular
            // 
            buttonCalcular.AutoSize = true;
            buttonCalcular.BackColor = SystemColors.AppWorkspace;
            buttonCalcular.Location = new Point(71, 598);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new Size(222, 45);
            buttonCalcular.TabIndex = 13;
            buttonCalcular.Text = "CALCULAR";
            buttonCalcular.UseVisualStyleBackColor = false;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // lblRaiz
            // 
            lblRaiz.AutoSize = true;
            lblRaiz.BackColor = SystemColors.ActiveCaption;
            lblRaiz.Location = new Point(469, 562);
            lblRaiz.Name = "lblRaiz";
            lblRaiz.Size = new Size(41, 20);
            lblRaiz.TabIndex = 14;
            lblRaiz.Text = "RAÍZ";
            lblRaiz.Click += lblRaiz_Click;
            // 
            // txtRaiz
            // 
            txtRaiz.Location = new Point(707, 555);
            txtRaiz.Name = "txtRaiz";
            txtRaiz.ReadOnly = true;
            txtRaiz.Size = new Size(300, 27);
            txtRaiz.TabIndex = 15;
            txtRaiz.TextChanged += txtRaiz_TextChanged;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.BackColor = SystemColors.ActiveCaption;
            lblMensaje.Location = new Point(469, 682);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(73, 20);
            lblMensaje.TabIndex = 16;
            lblMensaje.Text = "MENSAJE";
            lblMensaje.Click += lblMensaje_Click;
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(707, 675);
            txtMensaje.Multiline = true;
            txtMensaje.Name = "txtMensaje";
            txtMensaje.ReadOnly = true;
            txtMensaje.Size = new Size(300, 144);
            txtMensaje.TabIndex = 17;
            txtMensaje.TextChanged += txtMensaje_TextChanged;
            // 
            // lblIteracionesRes
            // 
            lblIteracionesRes.AutoSize = true;
            lblIteracionesRes.BackColor = SystemColors.ActiveCaption;
            lblIteracionesRes.Location = new Point(469, 605);
            lblIteracionesRes.Name = "lblIteracionesRes";
            lblIteracionesRes.Size = new Size(189, 20);
            lblIteracionesRes.TabIndex = 18;
            lblIteracionesRes.Text = "ITERACIONES REALIZADAS";
            lblIteracionesRes.Click += lblIteracionesRes_Click;
            // 
            // txtIteracionesRes
            // 
            txtIteracionesRes.Location = new Point(707, 598);
            txtIteracionesRes.Name = "txtIteracionesRes";
            txtIteracionesRes.ReadOnly = true;
            txtIteracionesRes.Size = new Size(300, 27);
            txtIteracionesRes.TabIndex = 19;
            // 
            // lblErrorRes
            // 
            lblErrorRes.AutoSize = true;
            lblErrorRes.BackColor = SystemColors.ActiveCaption;
            lblErrorRes.Location = new Point(469, 643);
            lblErrorRes.Name = "lblErrorRes";
            lblErrorRes.Size = new Size(55, 20);
            lblErrorRes.TabIndex = 20;
            lblErrorRes.Text = "ERROR";
            lblErrorRes.Click += lblErrorRes_Click;
            // 
            // txtErrorRes
            // 
            txtErrorRes.Location = new Point(707, 636);
            txtErrorRes.Name = "txtErrorRes";
            txtErrorRes.ReadOnly = true;
            txtErrorRes.Size = new Size(300, 27);
            txtErrorRes.TabIndex = 21;
            txtErrorRes.TextChanged += txtErrorRes_TextChanged;
            // 
            // webViewGeoGebra
            // 
            webViewGeoGebra.AllowExternalDrop = true;
            webViewGeoGebra.CreationProperties = null;
            webViewGeoGebra.DefaultBackgroundColor = Color.White;
            webViewGeoGebra.Location = new Point(384, 98);
            webViewGeoGebra.Margin = new Padding(3, 4, 3, 4);
            webViewGeoGebra.Name = "webViewGeoGebra";
            webViewGeoGebra.Size = new Size(869, 437);
            webViewGeoGebra.TabIndex = 50;
            webViewGeoGebra.ZoomFactor = 1D;
            // 
            // RaicesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1457, 867);
            Controls.Add(lblRaiz);
            Controls.Add(txtRaiz);
            Controls.Add(lblMensaje);
            Controls.Add(txtMensaje);
            Controls.Add(lblIteracionesRes);
            Controls.Add(txtIteracionesRes);
            Controls.Add(lblErrorRes);
            Controls.Add(txtErrorRes);
            Controls.Add(buttonCalcular);
            Controls.Add(txtXd);
            Controls.Add(txtXi);
            Controls.Add(lblXd);
            Controls.Add(lblXi);
            Controls.Add(lblIntervalo);
            Controls.Add(txtTolerancia);
            Controls.Add(lblTolerancia);
            Controls.Add(txtIteraciones);
            Controls.Add(lblIteraciones);
            Controls.Add(lblMetodo);
            Controls.Add(cmbMetodo);
            Controls.Add(txtFuncion);
            Controls.Add(lblIngresarFuncion);
            Controls.Add(webViewGeoGebra);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RaicesForm";
            Text = "RaicesForm";
            ((System.ComponentModel.ISupportInitialize)webViewGeoGebra).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIngresarFuncion;
        private TextBox txtFuncion;
        private ComboBox cmbMetodo;
        private Label lblMetodo;
        private Label lblIteraciones;
        private TextBox txtIteraciones;
        private Label lblTolerancia;
        private TextBox txtTolerancia;
        private Label lblIntervalo;
        private Label lblXi;
        private Label lblXd;
        private TextBox txtXi;
        private TextBox txtXd;
        private Button buttonCalcular;

        // Resultados
        private Label lblRaiz;
        private TextBox txtRaiz;
        private Label lblMensaje;
        private TextBox txtMensaje;
        private Label lblIteracionesRes;
        private TextBox txtIteracionesRes;
        private Label lblErrorRes;
        private TextBox txtErrorRes;
    }
}