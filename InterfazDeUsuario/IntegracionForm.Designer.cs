using System.Drawing;
using System.Windows.Forms;

namespace InterfazDeUsuario
{
    partial class IntegracionForm
    {
        private System.ComponentModel.IContainer components = null;

        // Entrada
        private Label lblTitulo;
        private Label lblFuncion;
        private TextBox txtFuncion;

        private Label lblMetodo;
        private ComboBox cmbMetodo;

        private Label lblXi;
        private TextBox txtXi;

        private Label lblXd;
        private TextBox txtXd;

        private Label lblSubintervalos;
        private TextBox txtSubintervalos;

        private Button btnCalcular;

        // Salida
        private Label lblResultado;
        private TextBox txtResultado;
        private Label lblMensaje;
        private TextBox txtMensaje;

        // GeoGebra
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewGeoGebra;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitulo = new Label();
            lblFuncion = new Label();
            txtFuncion = new TextBox();

            lblMetodo = new Label();
            cmbMetodo = new ComboBox();

            lblXi = new Label();
            txtXi = new TextBox();

            lblXd = new Label();
            txtXd = new TextBox();

            lblSubintervalos = new Label();
            txtSubintervalos = new TextBox();

            btnCalcular = new Button();

            lblResultado = new Label();
            txtResultado = new TextBox();
            lblMensaje = new Label();
            txtMensaje = new TextBox();

            webViewGeoGebra = new Microsoft.Web.WebView2.WinForms.WebView2();

            SuspendLayout();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 860);
            this.Text = "Integración Numérica";

            // Título
            lblTitulo.AutoSize = true;
            lblTitulo.Text = "Integración Numérica";
            lblTitulo.Location = new Point(24, 20);
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            // Función
            lblFuncion.AutoSize = true;
            lblFuncion.Text = "Función f(x)";
            lblFuncion.Location = new Point(24, 70);
            txtFuncion.Location = new Point(24, 95);
            txtFuncion.Size = new Size(320, 27);
            txtFuncion.PlaceholderText = "Ej: 1/x, sin(x), x^2 + 3x";

            // Método
            lblMetodo.AutoSize = true;
            lblMetodo.Text = "Método";
            lblMetodo.Location = new Point(24, 135);
            cmbMetodo.Location = new Point(24, 160);
            cmbMetodo.Size = new Size(320, 27);
            cmbMetodo.Items.AddRange(new object[]
            {
                "Trapecios Simple",
                "Trapecios Múltiple",
                "Simpson 1/3 Simple",
                "Simpson 1/3 Múltiple",
                "Simpson 3/8 Simple",
                "Combinado (1/3 + 3/8)"
            });

            // Xi
            lblXi.AutoSize = true;
            lblXi.Text = "Xi (a)";
            lblXi.Location = new Point(24, 205);
            txtXi.Location = new Point(24, 230);
            txtXi.Size = new Size(150, 27);

            // Xd
            lblXd.AutoSize = true;
            lblXd.Text = "Xd (b)";
            lblXd.Location = new Point(194, 205);
            txtXd.Location = new Point(194, 230);
            txtXd.Size = new Size(150, 27);

            // Subintervalos
            lblSubintervalos.AutoSize = true;
            lblSubintervalos.Text = "Subintervalos (n)";
            lblSubintervalos.Location = new Point(24, 270);
            txtSubintervalos.Location = new Point(24, 295);
            txtSubintervalos.Size = new Size(150, 27);

            // Calcular
            btnCalcular.Text = "Calcular";
            btnCalcular.Location = new Point(24, 340);
            btnCalcular.Size = new Size(320, 40);
            btnCalcular.Click += btnCalcular_Click;

            // Salida
            lblResultado.AutoSize = true;
            lblResultado.Text = "Área (resultado)";
            lblResultado.Location = new Point(380, 70);
            txtResultado.Location = new Point(380, 95);
            txtResultado.Size = new Size(300, 27);
            txtResultado.ReadOnly = true;

            lblMensaje.AutoSize = true;
            lblMensaje.Text = "Mensaje / Advertencias";
            lblMensaje.Location = new Point(380, 135);
            txtMensaje.Location = new Point(380, 160);
            txtMensaje.Size = new Size(500, 100);
            txtMensaje.Multiline = true;
            txtMensaje.ReadOnly = true;

            // WebView2
            webViewGeoGebra.Location = new Point(380, 290);
            webViewGeoGebra.Size = new Size(980, 500);
            webViewGeoGebra.ZoomFactor = 1D;

            // Add controls
            Controls.Add(lblTitulo);
            Controls.Add(lblFuncion);
            Controls.Add(txtFuncion);
            Controls.Add(lblMetodo);
            Controls.Add(cmbMetodo);
            Controls.Add(lblXi);
            Controls.Add(txtXi);
            Controls.Add(lblXd);
            Controls.Add(txtXd);
            Controls.Add(lblSubintervalos);
            Controls.Add(txtSubintervalos);
            Controls.Add(btnCalcular);

            Controls.Add(lblResultado);
            Controls.Add(txtResultado);
            Controls.Add(lblMensaje);
            Controls.Add(txtMensaje);
            Controls.Add(webViewGeoGebra);

            ResumeLayout(false);
        }
    }
}