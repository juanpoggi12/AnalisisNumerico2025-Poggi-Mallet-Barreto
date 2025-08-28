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
            lblIngresarFuncion.Location = new Point(38, 83);
            lblIngresarFuncion.Name = "lblIngresarFuncion";
            lblIngresarFuncion.Size = new Size(117, 20);
            lblIngresarFuncion.TabIndex = 0;
            lblIngresarFuncion.Text = "Ingresar Función";
            // 
            // txtFuncion
            // 
            txtFuncion.Location = new Point(38, 106);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(276, 27);
            txtFuncion.TabIndex = 1;
            // 
            // cmbMetodo
            // 
            cmbMetodo.FormattingEnabled = true;
            cmbMetodo.Items.AddRange(new object[] { "Método Cerrado: Bisección", "Método Cerrado: Regla Falsa", "Método Abierto: Newton-Raphson", "Método Abierto: Secante" });
            cmbMetodo.Location = new Point(40, 179);
            cmbMetodo.Name = "cmbMetodo";
            cmbMetodo.Size = new Size(274, 28);
            cmbMetodo.TabIndex = 2;
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.BackColor = SystemColors.Control;
            lblMetodo.Location = new Point(40, 156);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(142, 20);
            lblMetodo.TabIndex = 3;
            lblMetodo.Text = "Seleccionar Método";
            // 
            // lblIteraciones
            // 
            lblIteraciones.AutoSize = true;
            lblIteraciones.BackColor = SystemColors.GradientActiveCaption;
            lblIteraciones.Location = new Point(40, 236);
            lblIteraciones.Name = "lblIteraciones";
            lblIteraciones.Size = new Size(81, 20);
            lblIteraciones.TabIndex = 4;
            lblIteraciones.Text = "Iteraciones";
            // 
            // txtIteraciones
            // 
            txtIteraciones.Location = new Point(38, 259);
            txtIteraciones.Name = "txtIteraciones";
            txtIteraciones.Size = new Size(274, 27);
            txtIteraciones.TabIndex = 5;
            // 
            // lblTolerancia
            // 
            lblTolerancia.AutoSize = true;
            lblTolerancia.BackColor = SystemColors.GradientActiveCaption;
            lblTolerancia.Location = new Point(40, 315);
            lblTolerancia.Name = "lblTolerancia";
            lblTolerancia.Size = new Size(77, 20);
            lblTolerancia.TabIndex = 6;
            lblTolerancia.Text = "Tolerancia";
            // 
            // txtTolerancia
            // 
            txtTolerancia.Location = new Point(38, 341);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(274, 27);
            txtTolerancia.TabIndex = 7;
            // 
            // lblIntervalo
            // 
            lblIntervalo.AutoSize = true;
            lblIntervalo.BackColor = SystemColors.GradientActiveCaption;
            lblIntervalo.Location = new Point(540, 83);
            lblIntervalo.Name = "lblIntervalo";
            lblIntervalo.Size = new Size(148, 20);
            lblIntervalo.TabIndex = 8;
            lblIntervalo.Text = "Ingrese los intervalos";
            // 
            // lblXi
            // 
            lblXi.AutoSize = true;
            lblXi.BackColor = SystemColors.InactiveCaption;
            lblXi.Location = new Point(474, 109);
            lblXi.Name = "lblXi";
            lblXi.Size = new Size(22, 20);
            lblXi.TabIndex = 9;
            lblXi.Text = "Xi";
            // 
            // lblXd
            // 
            lblXd.AutoSize = true;
            lblXd.BackColor = SystemColors.ActiveCaption;
            lblXd.Location = new Point(727, 109);
            lblXd.Name = "lblXd";
            lblXd.Size = new Size(27, 20);
            lblXd.TabIndex = 10;
            lblXd.Text = "Xd";
            // 
            // txtXi
            // 
            txtXi.Location = new Point(421, 132);
            txtXi.Name = "txtXi";
            txtXi.Size = new Size(141, 27);
            txtXi.TabIndex = 11;
            // 
            // txtXd
            // 
            txtXd.Location = new Point(666, 132);
            txtXd.Name = "txtXd";
            txtXd.Size = new Size(147, 27);
            txtXd.TabIndex = 12;
            // 
            // buttonCalcular
            // 
            buttonCalcular.AutoSize = true;
            buttonCalcular.BackColor = SystemColors.AppWorkspace;
            buttonCalcular.Location = new Point(511, 170);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new Size(222, 45);
            buttonCalcular.TabIndex = 13;
            buttonCalcular.Text = "Calcular!!";
            buttonCalcular.UseVisualStyleBackColor = false;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // lblRaiz
            // 
            lblRaiz.AutoSize = true;
            lblRaiz.Location = new Point(361, 248);
            lblRaiz.Name = "lblRaiz";
            lblRaiz.Size = new Size(37, 20);
            lblRaiz.TabIndex = 14;
            lblRaiz.Text = "Raíz";
            // 
            // txtRaiz
            // 
            txtRaiz.Location = new Point(562, 236);
            txtRaiz.Name = "txtRaiz";
            txtRaiz.ReadOnly = true;
            txtRaiz.Size = new Size(300, 27);
            txtRaiz.TabIndex = 15;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(361, 357);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(64, 20);
            lblMensaje.TabIndex = 16;
            lblMensaje.Text = "Mensaje";
            lblMensaje.Click += lblMensaje_Click;
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(562, 357);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.ReadOnly = true;
            txtMensaje.Size = new Size(300, 27);
            txtMensaje.TabIndex = 17;
            // 
            // lblIteracionesRes
            // 
            lblIteracionesRes.AutoSize = true;
            lblIteracionesRes.Location = new Point(361, 282);
            lblIteracionesRes.Name = "lblIteracionesRes";
            lblIteracionesRes.Size = new Size(152, 20);
            lblIteracionesRes.TabIndex = 18;
            lblIteracionesRes.Text = "Iteraciones realizadas";
            lblIteracionesRes.Click += lblIteracionesRes_Click;
            // 
            // txtIteracionesRes
            // 
            txtIteracionesRes.Location = new Point(562, 275);
            txtIteracionesRes.Name = "txtIteracionesRes";
            txtIteracionesRes.ReadOnly = true;
            txtIteracionesRes.Size = new Size(300, 27);
            txtIteracionesRes.TabIndex = 19;
            // 
            // lblErrorRes
            // 
            lblErrorRes.AutoSize = true;
            lblErrorRes.Location = new Point(361, 322);
            lblErrorRes.Name = "lblErrorRes";
            lblErrorRes.Size = new Size(41, 20);
            lblErrorRes.TabIndex = 20;
            lblErrorRes.Text = "Error";
            // 
            // txtErrorRes
            // 
            txtErrorRes.Location = new Point(562, 315);
            txtErrorRes.Name = "txtErrorRes";
            txtErrorRes.ReadOnly = true;
            txtErrorRes.Size = new Size(300, 27);
            txtErrorRes.TabIndex = 21;
            // 
            // webViewGeoGebra
            // 
            webViewGeoGebra.AllowExternalDrop = true;
            webViewGeoGebra.CreationProperties = null;
            webViewGeoGebra.DefaultBackgroundColor = Color.White;
            webViewGeoGebra.Location = new Point(21, 417);
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
            ClientSize = new Size(914, 867);
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