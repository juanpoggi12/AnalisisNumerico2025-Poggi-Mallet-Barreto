namespace InterfazDeUsuario
{
    partial class RaicesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewGeoGebra;
        private System.Windows.Forms.Button btnGraficar;

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
            SuspendLayout();
            // 
            // lblIngresarFuncion
            // 
            lblIngresarFuncion.AutoSize = true;
            lblIngresarFuncion.BackColor = SystemColors.MenuHighlight;
            lblIngresarFuncion.Location = new Point(35, 32);
            lblIngresarFuncion.Name = "lblIngresarFuncion";
            lblIngresarFuncion.Size = new Size(95, 15);
            lblIngresarFuncion.TabIndex = 0;
            lblIngresarFuncion.Text = "Ingresar Función";
            // 
            // txtFuncion
            // 
            txtFuncion.Location = new Point(33, 57);
            txtFuncion.Margin = new Padding(3, 2, 3, 2);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(242, 23);
            txtFuncion.TabIndex = 1;
            // 
            // cmbMetodo
            // 
            cmbMetodo.FormattingEnabled = true;
            cmbMetodo.Items.AddRange(new object[] { "Método Cerrado: Bisección", "Método Cerrado: Regla Falsa", "Método Abierto: Newton-Raphson", "Método Abierto: Secante" });
            cmbMetodo.Location = new Point(35, 121);
            cmbMetodo.Margin = new Padding(3, 2, 3, 2);
            cmbMetodo.Name = "cmbMetodo";
            cmbMetodo.Size = new Size(240, 23);
            cmbMetodo.TabIndex = 2;
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.BackColor = SystemColors.Control;
            lblMetodo.Location = new Point(35, 92);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(112, 15);
            lblMetodo.TabIndex = 3;
            lblMetodo.Text = "Seleccionar Método";
            // 
            // lblIteraciones
            // 
            lblIteraciones.AutoSize = true;
            lblIteraciones.BackColor = SystemColors.GradientActiveCaption;
            lblIteraciones.Location = new Point(35, 159);
            lblIteraciones.Name = "lblIteraciones";
            lblIteraciones.Size = new Size(64, 15);
            lblIteraciones.TabIndex = 4;
            lblIteraciones.Text = "Iteraciones";
            // 
            // txtIteraciones
            // 
            txtIteraciones.Location = new Point(35, 187);
            txtIteraciones.Margin = new Padding(3, 2, 3, 2);
            txtIteraciones.Name = "txtIteraciones";
            txtIteraciones.Size = new Size(240, 23);
            txtIteraciones.TabIndex = 5;
            // 
            // lblTolerancia
            // 
            lblTolerancia.AutoSize = true;
            lblTolerancia.BackColor = SystemColors.GradientActiveCaption;
            lblTolerancia.Location = new Point(35, 224);
            lblTolerancia.Name = "lblTolerancia";
            lblTolerancia.Size = new Size(61, 15);
            lblTolerancia.TabIndex = 6;
            lblTolerancia.Text = "Tolerancia";
            // 
            // txtTolerancia
            // 
            txtTolerancia.Location = new Point(35, 254);
            txtTolerancia.Margin = new Padding(3, 2, 3, 2);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(240, 23);
            txtTolerancia.TabIndex = 7;
            // 
            // lblIntervalo
            // 
            lblIntervalo.AutoSize = true;
            lblIntervalo.BackColor = SystemColors.GradientActiveCaption;
            lblIntervalo.Location = new Point(91, 298);
            lblIntervalo.Name = "lblIntervalo";
            lblIntervalo.Size = new Size(117, 15);
            lblIntervalo.TabIndex = 8;
            lblIntervalo.Text = "Ingrese los intervalos";
            // 
            // lblXi
            // 
            lblXi.AutoSize = true;
            lblXi.BackColor = SystemColors.InactiveCaption;
            lblXi.Location = new Point(61, 337);
            lblXi.Name = "lblXi";
            lblXi.Size = new Size(17, 15);
            lblXi.TabIndex = 9;
            lblXi.Text = "Xi";
            // 
            // lblXd
            // 
            lblXd.AutoSize = true;
            lblXd.BackColor = SystemColors.ActiveCaption;
            lblXd.Location = new Point(239, 337);
            lblXd.Name = "lblXd";
            lblXd.Size = new Size(21, 15);
            lblXd.TabIndex = 10;
            lblXd.Text = "Xd";
            // 
            // txtXi
            // 
            txtXi.Location = new Point(14, 365);
            txtXi.Margin = new Padding(3, 2, 3, 2);
            txtXi.Name = "txtXi";
            txtXi.Size = new Size(124, 23);
            txtXi.TabIndex = 11;
            // 
            // txtXd
            // 
            txtXd.Location = new Point(181, 365);
            txtXd.Margin = new Padding(3, 2, 3, 2);
            txtXd.Name = "txtXd";
            txtXd.Size = new Size(129, 23);
            txtXd.TabIndex = 12;
            // 
            // buttonCalcular
            // 
            buttonCalcular.AutoSize = true;
            buttonCalcular.BackColor = SystemColors.AppWorkspace;
            buttonCalcular.Location = new Point(68, 423);
            buttonCalcular.Margin = new Padding(3, 2, 3, 2);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new Size(194, 34);
            buttonCalcular.TabIndex = 13;
            buttonCalcular.Text = "Calcular!!";
            buttonCalcular.UseVisualStyleBackColor = false;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // lblRaiz
            // 
            lblRaiz.AutoSize = true;
            lblRaiz.Location = new Point(350, 29);
            lblRaiz.Name = "lblRaiz";
            lblRaiz.Size = new Size(28, 15);
            lblRaiz.TabIndex = 14;
            lblRaiz.Text = "Raíz";
            // 
            // txtRaiz
            // 
            txtRaiz.Location = new Point(490, 29);
            txtRaiz.Margin = new Padding(3, 2, 3, 2);
            txtRaiz.Name = "txtRaiz";
            txtRaiz.ReadOnly = true;
            txtRaiz.Size = new Size(176, 23);
            txtRaiz.TabIndex = 15;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(350, 121);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(51, 15);
            lblMensaje.TabIndex = 16;
            lblMensaje.Text = "Mensaje";
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(427, 118);
            txtMensaje.Margin = new Padding(3, 2, 3, 2);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.ReadOnly = true;
            txtMensaje.Size = new Size(263, 23);
            txtMensaje.TabIndex = 17;
            // 
            // lblIteracionesRes
            // 
            lblIteracionesRes.AutoSize = true;
            lblIteracionesRes.Location = new Point(350, 62);
            lblIteracionesRes.Name = "lblIteracionesRes";
            lblIteracionesRes.Size = new Size(118, 15);
            lblIteracionesRes.TabIndex = 18;
            lblIteracionesRes.Text = "Iteraciones realizadas";
            // 
            // txtIteracionesRes
            // 
            txtIteracionesRes.Location = new Point(490, 62);
            txtIteracionesRes.Margin = new Padding(3, 2, 3, 2);
            txtIteracionesRes.Name = "txtIteracionesRes";
            txtIteracionesRes.ReadOnly = true;
            txtIteracionesRes.Size = new Size(176, 23);
            txtIteracionesRes.TabIndex = 19;
            // 
            // lblErrorRes
            // 
            lblErrorRes.AutoSize = true;
            lblErrorRes.Location = new Point(350, 92);
            lblErrorRes.Name = "lblErrorRes";
            lblErrorRes.Size = new Size(32, 15);
            lblErrorRes.TabIndex = 20;
            lblErrorRes.Text = "Error";
            // 
            // txtErrorRes
            // 
            txtErrorRes.Location = new Point(490, 92);
            txtErrorRes.Margin = new Padding(3, 2, 3, 2);
            txtErrorRes.Name = "txtErrorRes";
            txtErrorRes.ReadOnly = true;
            txtErrorRes.Size = new Size(176, 23);
            txtErrorRes.TabIndex = 21;
            // 
            // RaicesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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

            this.webViewGeoGebra = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webViewGeoGebra)).BeginInit();

            // 
            // RaicesForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Name = "RaicesForm";
            this.Text = "RaicesForm";
            this.btnGraficar = new System.Windows.Forms.Button();

            // 
            // btnGraficar
            // 
            this.btnGraficar.AutoSize = true;
            this.btnGraficar.Location = new System.Drawing.Point(320, 160); // ajustá posición si querés
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(120, 46);
            this.btnGraficar.TabIndex = 51;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);

            // 
            // webViewGeoGebra
            // 
            this.webViewGeoGebra.AllowExternalDrop = true;
            this.webViewGeoGebra.CreationProperties = null;
            this.webViewGeoGebra.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewGeoGebra.Location = new System.Drawing.Point(20, 320); // ponelo grande abajo/derecha
            this.webViewGeoGebra.Name = "webViewGeoGebra";
            this.webViewGeoGebra.Size = new System.Drawing.Size(760, 300);
            this.webViewGeoGebra.TabIndex = 50;
            this.webViewGeoGebra.ZoomFactor = 1D;

            // Agregar a Controls
            this.Controls.Add(this.webViewGeoGebra);
            this.webViewGeoGebra.SendToBack();
            this.Controls.Add(this.btnGraficar);

            ((System.ComponentModel.ISupportInitialize)(this.webViewGeoGebra)).EndInit();

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