namespace InterfazDeUsuario
{
    partial class RaicesForm
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

            // Resultados
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
            lblIngresarFuncion.Location = new Point(40, 42);
            lblIngresarFuncion.Name = "lblIngresarFuncion";
            lblIngresarFuncion.Size = new Size(117, 20);
            lblIngresarFuncion.TabIndex = 0;
            lblIngresarFuncion.Text = "Ingresar Función";
            // 
            // txtFuncion
            // 
            txtFuncion.Location = new Point(38, 76);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(276, 27);
            txtFuncion.TabIndex = 1;
            // 
            // cmbMetodo
            // 
            cmbMetodo.FormattingEnabled = true;
            cmbMetodo.Items.AddRange(new object[] {
                "Método Cerrado: Bisección",
                "Método Cerrado: Regla Falsa",
                "Método Abierto: Newton-Raphson",
                "Método Abierto: Secante"
            });
            cmbMetodo.Location = new Point(40, 161);
            cmbMetodo.Name = "cmbMetodo";
            cmbMetodo.Size = new Size(274, 28);
            cmbMetodo.TabIndex = 2;
            cmbMetodo.SelectedIndex = 0;
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.BackColor = SystemColors.ActiveCaption;
            lblMetodo.Location = new Point(40, 122);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(142, 20);
            lblMetodo.TabIndex = 3;
            lblMetodo.Text = "Seleccionar Método";
            // 
            // lblIteraciones
            // 
            lblIteraciones.AutoSize = true;
            lblIteraciones.BackColor = SystemColors.MenuHighlight;
            lblIteraciones.Location = new Point(40, 212);
            lblIteraciones.Name = "lblIteraciones";
            lblIteraciones.Size = new Size(81, 20);
            lblIteraciones.TabIndex = 4;
            lblIteraciones.Text = "Iteraciones";
            // 
            // txtIteraciones
            // 
            txtIteraciones.Location = new Point(40, 249);
            txtIteraciones.Name = "txtIteraciones";
            txtIteraciones.Size = new Size(274, 27);
            txtIteraciones.TabIndex = 5;
            // 
            // lblTolerancia
            // 
            lblTolerancia.AutoSize = true;
            lblTolerancia.BackColor = SystemColors.HotTrack;
            lblTolerancia.Location = new Point(40, 298);
            lblTolerancia.Name = "lblTolerancia";
            lblTolerancia.Size = new Size(77, 20);
            lblTolerancia.TabIndex = 6;
            lblTolerancia.Text = "Tolerancia";
            // 
            // txtTolerancia
            // 
            txtTolerancia.Location = new Point(40, 338);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(274, 27);
            txtTolerancia.TabIndex = 7;
            // 
            // lblIntervalo
            // 
            lblIntervalo.AutoSize = true;
            lblIntervalo.BackColor = SystemColors.MenuHighlight;
            lblIntervalo.Location = new Point(104, 398);
            lblIntervalo.Name = "lblIntervalo";
            lblIntervalo.Size = new Size(148, 20);
            lblIntervalo.TabIndex = 8;
            lblIntervalo.Text = "Ingrese los intervalos";
            // 
            // lblXi
            // 
            lblXi.AutoSize = true;
            lblXi.BackColor = SystemColors.InactiveCaption;
            lblXi.Location = new Point(70, 449);
            lblXi.Name = "lblXi";
            lblXi.Size = new Size(22, 20);
            lblXi.TabIndex = 9;
            lblXi.Text = "Xi";
            // 
            // lblXd
            // 
            lblXd.AutoSize = true;
            lblXd.BackColor = SystemColors.ActiveCaption;
            lblXd.Location = new Point(273, 449);
            lblXd.Name = "lblXd";
            lblXd.Size = new Size(27, 20);
            lblXd.TabIndex = 10;
            lblXd.Text = "Xd";
            // 
            // txtXi
            // 
            txtXi.Location = new Point(16, 487);
            txtXi.Name = "txtXi";
            txtXi.Size = new Size(141, 27);
            txtXi.TabIndex = 11;
            // 
            // txtXd
            // 
            txtXd.Location = new Point(207, 487);
            txtXd.Name = "txtXd";
            txtXd.Size = new Size(147, 27);
            txtXd.TabIndex = 12;
            // 
            // buttonCalcular
            // 
            buttonCalcular.AutoSize = true;
            buttonCalcular.BackColor = SystemColors.AppWorkspace;
            buttonCalcular.Location = new Point(78, 564);
            buttonCalcular.Name = "buttonCalcular";
            buttonCalcular.Size = new Size(222, 46);
            buttonCalcular.TabIndex = 13;
            buttonCalcular.Text = "Calcular!!";
            buttonCalcular.UseVisualStyleBackColor = false;
            buttonCalcular.Click += buttonCalcular_Click;
            // 
            // lblRaiz
            // 
            lblRaiz.AutoSize = true;
            lblRaiz.Location = new Point(400, 42);
            lblRaiz.Name = "lblRaiz";
            lblRaiz.Size = new Size(38, 20);
            lblRaiz.TabIndex = 14;
            lblRaiz.Text = "Raíz";
            // 
            // txtRaiz
            // 
            txtRaiz.Location = new Point(450, 39);
            txtRaiz.Name = "txtRaiz";
            txtRaiz.Size = new Size(200, 27);
            txtRaiz.TabIndex = 15;
            txtRaiz.ReadOnly = true;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(400, 82);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(65, 20);
            lblMensaje.TabIndex = 16;
            lblMensaje.Text = "Mensaje";
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(480, 79);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(300, 27);
            txtMensaje.TabIndex = 17;
            txtMensaje.ReadOnly = true;
            // 
            // lblIteracionesRes
            // 
            lblIteracionesRes.AutoSize = true;
            lblIteracionesRes.Location = new Point(400, 122);
            lblIteracionesRes.Name = "lblIteracionesRes";
            lblIteracionesRes.Size = new Size(146, 20);
            lblIteracionesRes.TabIndex = 18;
            lblIteracionesRes.Text = "Iteraciones realizadas";
            // 
            // txtIteracionesRes
            // 
            txtIteracionesRes.Location = new Point(560, 119);
            txtIteracionesRes.Name = "txtIteracionesRes";
            txtIteracionesRes.Size = new Size(100, 27);
            txtIteracionesRes.TabIndex = 19;
            txtIteracionesRes.ReadOnly = true;
            // 
            // lblErrorRes
            // 
            lblErrorRes.AutoSize = true;
            lblErrorRes.Location = new Point(400, 162);
            lblErrorRes.Name = "lblErrorRes";
            lblErrorRes.Size = new Size(43, 20);
            lblErrorRes.TabIndex = 20;
            lblErrorRes.Text = "Error";
            // 
            // txtErrorRes
            // 
            txtErrorRes.Location = new Point(460, 159);
            txtErrorRes.Name = "txtErrorRes";
            txtErrorRes.Size = new Size(200, 27);
            txtErrorRes.TabIndex = 21;
            txtErrorRes.ReadOnly = true;
            // 
            // RaicesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 650);
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
            Name = "RaicesForm";
            Text = "RaicesForm";
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