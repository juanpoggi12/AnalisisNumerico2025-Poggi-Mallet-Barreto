using System.Drawing;
using System.Windows.Forms;

namespace InterfazDeUsuario
{
    partial class RegresionForm
    {
        private System.ComponentModel.IContainer components = null;

        // Entrada
        private Label lblTitulo;
        private Label lblMetodo;
        private ComboBox cmbMetodo;
        private Label lblGrado;
        private TextBox txtGrado;
        private Label lblTolerancia;
        private TextBox txtTolerancia;
        private Label lblIngresarPunto;
        private TextBox txtX;
        private TextBox txtY;
        private Button btnAgregar;
        private Button btnBorrarUltimo;
        private Button btnBorrarTodos;
        private Button btnEditarSeleccionado;
        private ListBox lstPuntos;

        // Salida
        private Label lblFuncion;
        private TextBox txtFuncion;
        private Label lblCorrelacion;
        private TextBox txtCorrelacion;
        private Label lblECM;
        private TextBox txtECM;
        private Label lblMensaje;
        private TextBox txtMensaje;

        // Acciones
        private Button btnCalcular;

        // WebView2 para GeoGebra
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
            lblMetodo = new Label();
            cmbMetodo = new ComboBox();
            lblGrado = new Label();
            txtGrado = new TextBox();
            lblTolerancia = new Label();
            txtTolerancia = new TextBox();
            lblIngresarPunto = new Label();
            txtX = new TextBox();
            txtY = new TextBox();
            btnAgregar = new Button();
            btnBorrarUltimo = new Button();
            btnBorrarTodos = new Button();
            btnEditarSeleccionado = new Button();
            lstPuntos = new ListBox();

            lblFuncion = new Label();
            txtFuncion = new TextBox();
            lblCorrelacion = new Label();
            txtCorrelacion = new TextBox();
            lblECM = new Label();
            txtECM = new TextBox();
            lblMensaje = new Label();
            txtMensaje = new TextBox();

            btnCalcular = new Button();

            webViewGeoGebra = new Microsoft.Web.WebView2.WinForms.WebView2();

            // Form
            SuspendLayout();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 860);
            this.Text = "Regresión (Mínimos Cuadrados)";

            // Título
            lblTitulo.AutoSize = true;
            lblTitulo.Text = "Ajuste por Regresión";
            lblTitulo.Location = new Point(24, 20);
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            // Método
            lblMetodo.AutoSize = true;
            lblMetodo.Text = "Método";
            lblMetodo.Location = new Point(24, 70);

            cmbMetodo.Items.AddRange(new object[]
            {
                "Regresión Lineal",
                "Regresión Polinomial"
            });
            cmbMetodo.Location = new Point(24, 95);
            cmbMetodo.Size = new Size(280, 27);

            // Grado
            lblGrado.AutoSize = true;
            lblGrado.Text = "Grado (2..10)";
            lblGrado.Location = new Point(24, 135);
            txtGrado.Location = new Point(24, 160);
            txtGrado.Size = new Size(120, 27);

            // Tolerancia
            lblTolerancia.AutoSize = true;
            lblTolerancia.Text = "Tolerancia (0..1)";
            lblTolerancia.Location = new Point(184, 135);
            txtTolerancia.Location = new Point(184, 160);
            txtTolerancia.Size = new Size(120, 27);

            // Ingresar punto
            lblIngresarPunto.AutoSize = true;
            lblIngresarPunto.Text = "Ingresar punto (X, Y)";
            lblIngresarPunto.Location = new Point(24, 205);
            txtX.Location = new Point(24, 230);
            txtX.Size = new Size(100, 27);
            txtX.PlaceholderText = "X";

            txtY.Location = new Point(130, 230);
            txtY.Size = new Size(100, 27);
            txtY.PlaceholderText = "Y";

            btnAgregar.Text = "Agregar";
            btnAgregar.Location = new Point(240, 230);
            btnAgregar.Size = new Size(100, 27);
            btnAgregar.Click += btnAgregar_Click;

            // Lista de puntos y acciones
            lstPuntos.Location = new Point(24, 270);
            lstPuntos.Size = new Size(320, 250);

            btnBorrarUltimo.Text = "Borrar último";
            btnBorrarUltimo.Location = new Point(24, 530);
            btnBorrarUltimo.Size = new Size(100, 30);
            btnBorrarUltimo.Click += btnBorrarUltimo_Click;

            btnBorrarTodos.Text = "Borrar todos";
            btnBorrarTodos.Location = new Point(130, 530);
            btnBorrarTodos.Size = new Size(100, 30);
            btnBorrarTodos.Click += btnBorrarTodos_Click;

            btnEditarSeleccionado.Text = "Editar";
            btnEditarSeleccionado.Location = new Point(236, 530);
            btnEditarSeleccionado.Size = new Size(100, 30);
            btnEditarSeleccionado.Click += btnEditarSeleccionado_Click;

            // Botón calcular
            btnCalcular.Text = "Calcular";
            btnCalcular.Location = new Point(24, 580);
            btnCalcular.Size = new Size(312, 40);
            btnCalcular.Click += btnCalcular_Click;

            // Salida
            lblFuncion.AutoSize = true;
            lblFuncion.Text = "Función obtenida";
            lblFuncion.Location = new Point(380, 70);
            txtFuncion.Location = new Point(380, 95);
            txtFuncion.Size = new Size(400, 27);
            txtFuncion.ReadOnly = true;

            lblCorrelacion.AutoSize = true;
            lblCorrelacion.Text = "Correlación (R %)";
            lblCorrelacion.Location = new Point(380, 135);
            txtCorrelacion.Location = new Point(380, 160);
            txtCorrelacion.Size = new Size(180, 27);
            txtCorrelacion.ReadOnly = true;

            lblECM.AutoSize = true;
            lblECM.Text = "Error cuadrático medio";
            lblECM.Location = new Point(580, 135);
            txtECM.Location = new Point(580, 160);
            txtECM.Size = new Size(200, 27);
            txtECM.ReadOnly = true;

            lblMensaje.AutoSize = true;
            lblMensaje.Text = "Mensaje";
            lblMensaje.Location = new Point(380, 205);
            txtMensaje.Location = new Point(380, 230);
            txtMensaje.Size = new Size(400, 100);
            txtMensaje.Multiline = true;
            txtMensaje.ReadOnly = true;

            // WebView2
            webViewGeoGebra.Location = new Point(380, 350);
            webViewGeoGebra.Size = new Size(980, 440);
            webViewGeoGebra.ZoomFactor = 1D;

            // Add controls
            Controls.Add(lblTitulo);
            Controls.Add(lblMetodo);
            Controls.Add(cmbMetodo);
            Controls.Add(lblGrado);
            Controls.Add(txtGrado);
            Controls.Add(lblTolerancia);
            Controls.Add(txtTolerancia);
            Controls.Add(lblIngresarPunto);
            Controls.Add(txtX);
            Controls.Add(txtY);
            Controls.Add(btnAgregar);
            Controls.Add(lstPuntos);
            Controls.Add(btnBorrarUltimo);
            Controls.Add(btnBorrarTodos);
            Controls.Add(btnEditarSeleccionado);
            Controls.Add(btnCalcular);

            Controls.Add(lblFuncion);
            Controls.Add(txtFuncion);
            Controls.Add(lblCorrelacion);
            Controls.Add(txtCorrelacion);
            Controls.Add(lblECM);
            Controls.Add(txtECM);
            Controls.Add(lblMensaje);
            Controls.Add(txtMensaje);
            Controls.Add(webViewGeoGebra);

            ResumeLayout(false);
        }
    }
}