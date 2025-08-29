using System;
using System.Globalization;
using System.Windows.Forms;
using AnalisisNumerico2025Poggi;
using System.Drawing.Drawing2D; // necesario para LinearGradientBrush

namespace InterfazDeUsuario
{
    public partial class RaicesForm : Form
    {
        private readonly MetodosCerrados solver = new MetodosCerrados();
        private GradientPanel _bg;

        public RaicesForm()
        {
            InitializeComponent();
            this.Size = new Size(1300, 900);
            // arrancar centrado
            this.StartPosition = FormStartPosition.CenterScreen;
            ApplyTheme();
            InstallGradientBackground();
            AddHeader();
            cmbMetodo.SelectedIndexChanged += cmbMetodo_SelectedIndexChanged;
            cmbMetodo.SelectedIndex = 0;
            ActualizarCampos();

            /*btnGraficar.Click += btnGraficar_Click;*/

        }


        private void ApplyTheme()
        {
            // Fuente y fondo general
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.BackColor = Color.FromArgb(246, 248, 255); // gris suave

            // Botón calcular estilo "moderno"
            buttonCalcular.FlatStyle = FlatStyle.Flat;
            buttonCalcular.FlatAppearance.BorderSize = 0;
            buttonCalcular.BackColor = Color.FromArgb(33, 150, 243); // azul
            buttonCalcular.ForeColor = Color.White;
            buttonCalcular.Height = 40;
            buttonCalcular.Width = 200;
            buttonCalcular.Text = "Calcular";
            buttonCalcular.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            StyleBadge(lblIngresarFuncion, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210)); // “INGRESAR FUNCIÓN”
            StyleBadge(lblMetodo, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210));
            StyleBadge(lblIteraciones, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210));
            StyleBadge(lblTolerancia, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210));
            StyleBadge(lblIntervalo, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210));

            // Xi / Xd (chips grises)
            StyleBadge(lblXi, Color.FromArgb(236, 239, 241), Color.FromArgb(55, 71, 79), 8, new Padding(6, 3, 6, 3));
            StyleBadge(lblXd, Color.FromArgb(236, 239, 241), Color.FromArgb(55, 71, 79), 8, new Padding(6, 3, 6, 3));

            // Resultados con código de color
            StyleBadge(lblRaiz, Color.FromArgb(232, 245, 233), Color.FromArgb(27, 94, 32));   // verde suave
            StyleBadge(lblIteracionesRes, Color.FromArgb(232, 245, 233), Color.FromArgb(27, 94, 32));
            StyleBadge(lblErrorRes, Color.FromArgb(255, 235, 238), Color.FromArgb(183, 28, 28));  // rojo suave
            StyleBadge(lblMensaje, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210)); // azul suave

            lblRaiz.ForeColor = Color.FromArgb(25, 118, 210);          // azul medio
            lblIteracionesRes.ForeColor = Color.FromArgb(25, 118, 210);
            lblErrorRes.ForeColor = Color.FromArgb(198, 40, 40);       // rojo para “Error”
            lblMensaje.ForeColor = Color.FromArgb(46, 125, 50);

            // TextBox de resultados → fondo blanco y solo lectura
            foreach (var tb in new[] { txtRaiz, txtIteracionesRes, txtErrorRes, txtMensaje })
            {
                tb.ReadOnly = true;
                tb.BackColor = Color.White;
                tb.BorderStyle = BorderStyle.FixedSingle;
            }

            // Labels con color uniforme
            foreach (var lbl in new[] { lblIngresarFuncion, lblMetodo, lblIteraciones, lblTolerancia,
                                lblIntervalo, lblXi, lblXd, lblRaiz, lblIteracionesRes,
                                lblErrorRes, lblMensaje })
            {
                lbl.ForeColor = Color.FromArgb(55, 71, 79);
                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                lbl.BackColor = Color.Transparent;
            }

            foreach (var lbl in new[] { lblRaiz, lblIteracionesRes, lblErrorRes, lblMensaje,
                            lblIngresarFuncion, lblMetodo, lblIteraciones,
                            lblTolerancia, lblIntervalo, lblXi, lblXd })
            {
                lbl.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(33, 33, 33); // gris muy oscuro casi negro
            }
        }
        //
        //private void RaicesForm_Load(object sender, EventArgs e)
        //{
        //    // Entrada
        //    StyleAsBadge(lblIngresarFuncion, Color.FromArgb(25, 118, 210), Color.White);
        //    StyleAsBadge(lblMetodo, Color.FromArgb(25, 118, 210), Color.White);
        //    StyleAsBadge(lblIteraciones, Color.FromArgb(25, 118, 210), Color.White);
        //    StyleAsBadge(lblTolerancia, Color.FromArgb(25, 118, 210), Color.White);
        //    StyleAsBadge(lblIntervalo, Color.FromArgb(25, 118, 210), Color.White);

        //    // Xi/Xd (gris oscuro con texto blanco)
        //    StyleAsBadge(lblXi, Color.FromArgb(97, 97, 97), Color.White);
        //    StyleAsBadge(lblXd, Color.FromArgb(97, 97, 97), Color.White);

        //    // Resultados
        //    StyleAsBadge(lblRaiz, Color.FromArgb(56, 142, 60), Color.White);  // Verde fuerte
        //    StyleAsBadge(lblIteracionesRes, Color.FromArgb(2, 119, 189), Color.White);  // Azul fuerte
        //    StyleAsBadge(lblErrorRes, Color.FromArgb(211, 47, 47), Color.White);  // Rojo fuerte
        //    StyleAsBadge(lblMensaje, Color.FromArgb(251, 192, 45), Color.Black); // Amarillo → texto negro
        //}

        //private void StyleAsBadge(Label lbl, Color back, Color fore)
        //{
        //    lbl.AutoSize = true;
        //    lbl.BackColor = back;
        //    lbl.ForeColor = fore;

        //    // Punto 3: texto en mayúsculas + fuente más grande
        //    lbl.Text = lbl.Text.ToUpperInvariant();
        //    lbl.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);

        //    lbl.Padding = new Padding(10, 6, 10, 6);
        //    lbl.TextAlign = ContentAlignment.MiddleCenter;

        //    // Punto 2: borde visible para que resalte
        //    //lbl.BorderStyle = BorderStyle.FixedSingle;

        //    // Bordes redondeados
        //    lbl.Resize += (s, e) =>
        //    {
        //        using var gp = new System.Drawing.Drawing2D.GraphicsPath();
        //        int r = 10; // radio de la esquina
        //        var rect = new Rectangle(0, 0, lbl.Width, lbl.Height);
        //        gp.AddArc(rect.X, rect.Y, r, r, 180, 90);
        //        gp.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
        //        gp.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
        //        gp.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
        //        gp.CloseFigure();
        //        lbl.Region = new Region(gp);
        //    };
        //}/// <summary>
        /// /
        /// </summary>

        private void InstallGradientBackground()
        {
            // menos parpadeo
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint, true);

            _bg = new GradientPanel
            {
                Dock = DockStyle.Fill,
                ColorTop = Color.FromArgb(245, 247, 250),   // arriba (gris muy claro)
                ColorBottom = Color.FromArgb(225, 235, 245) // abajo (celeste suave)
            };

            // lo agregamos y mandamos al fondo
            this.Controls.Add(_bg);
            _bg.SendToBack();
        }

        // OPCIONAL: una franja de color arriba con título
        private void AddHeader()
        {
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 52,
                BackColor = Color.FromArgb(33, 150, 243)
            };
            var title = new Label
            {
                Text = "Calculadora de Raíces",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(12, 16, 0, 0)
            };
            header.Controls.Add(title);
            this.Controls.Add(header);
            header.BringToFront();
        }

        // ---- Panel que pinta el degradado ----
        private sealed class GradientPanel : Panel
        {
            public Color ColorTop { get; set; } = Color.White;
            public Color ColorBottom { get; set; } = Color.Gainsboro;

            protected override void OnPaintBackground(PaintEventArgs e)
            {
                var rect = this.ClientRectangle;
                if (rect.Width == 0 || rect.Height == 0) return;

                using var brush = new LinearGradientBrush(
                    rect, ColorTop, ColorBottom, LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var rect = this.ClientRectangle;
            if (rect.Width == 0 || rect.Height == 0) return;

            using var brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(245, 247, 250),   // color superior (gris clarito)
                Color.FromArgb(225, 235, 245),   // color inferior (un celestito suave)
                LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(brush, rect);
        }
        private void cmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCampos();
        }

        private void ActualizarCampos()
        {
            string metodo = cmbMetodo.SelectedItem?.ToString() ?? string.Empty;

            // Newton: solo Xi
            if (metodo.IndexOf("Newton", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                txtXi.Enabled = true;
                txtXd.Enabled = false;
                txtXd.Text = string.Empty; // limpiar por claridad
            }
            // Secante y cerrados usan Xi y Xd
            else
            {
                txtXi.Enabled = true;
                txtXd.Enabled = true;
            }
        }

        // =========================
        // Helpers de parseo robusto
        // =========================

        private static double ParseDouble(string s, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException($"Ingrese un valor para {nombreCampo}.");

            // Acepta coma o punto
            s = s.Trim().Replace(',', '.');

            if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double v))
                return v;

            // Intento con cultura actual por si acaso
            if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out v))
                return v;

            throw new ArgumentException($"Ingrese un valor numérico válido para {nombreCampo}.");
        }

        private static int ParseInt(string s, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException($"Ingrese un valor para {nombreCampo}.");

            if (!int.TryParse(s.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out int v) || v <= 0)
                throw new ArgumentException($"{nombreCampo} debe ser un entero > 0.");

            return v;
        }

        private bool ValidarCampos(out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(txtFuncion.Text))
            {
                mensaje = "Debe ingresar una función (ej: x^5 + 0.25*x^2 - 1).";
                return false;
            }

            // Solo verificamos que exista Xi y (si aplica) Xd. La validación numérica exacta se hace al parsear.
            if (string.IsNullOrWhiteSpace(txtXi.Text))
            {
                mensaje = "Ingrese Xi.";
                return false;
            }

            string metodo = cmbMetodo.SelectedItem?.ToString() ?? string.Empty;
            if (metodo.IndexOf("Newton", StringComparison.OrdinalIgnoreCase) < 0)
            {
                if (string.IsNullOrWhiteSpace(txtXd.Text))
                {
                    mensaje = "Ingrese Xd.";
                    return false;
                }
            }

            return true;
        }

        private async void buttonCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica de presencia
                if (!ValidarCampos(out string mensajeValidacion))
                {
                    MessageBox.Show(mensajeValidacion, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string funcion = txtFuncion.Text.Trim();

                // Defaults si vienen vacíos
                double tol = string.IsNullOrWhiteSpace(txtTolerancia.Text)
                    ? 1e-6
                    : ParseDouble(txtTolerancia.Text, "Tolerancia");

                int maxIter = string.IsNullOrWhiteSpace(txtIteraciones.Text)
                    ? 100
                    : ParseInt(txtIteraciones.Text, "Máx. iteraciones");

                // Parse de Xi y Xd (si corresponde)
                double xi = ParseDouble(txtXi.Text, "Xi");
                double xd = 0.0;
                string metodoSel = cmbMetodo.SelectedItem?.ToString() ?? string.Empty;

                bool usaXd = metodoSel.IndexOf("Secante", StringComparison.OrdinalIgnoreCase) >= 0
                             || metodoSel.IndexOf("Bisección", StringComparison.OrdinalIgnoreCase) >= 0
                             || metodoSel.IndexOf("Regla Falsa", StringComparison.OrdinalIgnoreCase) >= 0;

                if (usaXd && txtXd.Enabled && !string.IsNullOrWhiteSpace(txtXd.Text))
                    xd = ParseDouble(txtXd.Text, "Xd");

                // Limpiar UI de salida
                txtRaiz.Text = "";
                txtMensaje.Text = "";
                txtIteracionesRes.Text = "";
                txtErrorRes.Text = "";

                double raiz = 0;
                string mensaje = "";
                int iteracionesRealizadas = 0;
                double error = 0;

                // Dispatch por método
                if (metodoSel.IndexOf("Bisección", StringComparison.OrdinalIgnoreCase) >= 0)
                {

                    var r = solver.Biseccion(funcion, 'x', xi, xd, tol, maxIter);
                    raiz = r.Raiz;
                    mensaje = r.Mensaje;
                    iteracionesRealizadas = r.Iteraciones;
                    error = r.Error;
                }
                else if (metodoSel.IndexOf("Regla Falsa", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var r = solver.ReglaFalsa(funcion, 'x', xi, xd, tol, maxIter);
                    raiz = r.Raiz;
                    mensaje = r.Mensaje;
                    iteracionesRealizadas = r.Iteraciones;
                    error = r.Error;
                }
                else if (metodoSel.IndexOf("Newton", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var abiertos = new MetodosAbiertos(funcion);
                    var r = abiertos.NewtonRaphson(xi, tol, maxIter);
                    raiz = r.Raiz;
                    mensaje = r.Message;
                    iteracionesRealizadas = r.Iteraciones.Count;
                    error = (r.Iteraciones.Count > 0) ? r.Iteraciones[^1].Error : 0.0;
                }
                else if (metodoSel.IndexOf("Secante", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var abiertos = new MetodosAbiertos(funcion);
                    var r = abiertos.Secante(xi, xd, tol, maxIter);
                    raiz = r.Raiz;
                    mensaje = r.Message;
                    iteracionesRealizadas = r.Iteraciones.Count;
                    error = (r.Iteraciones.Count > 0) ? r.Iteraciones[^1].Error : 0.0;
                }
                else
                {
                    throw new NotSupportedException("Seleccione un método válido.");
                }

                // Mostrar resultados
                txtRaiz.Text = raiz.ToString("G10", CultureInfo.InvariantCulture);
                txtMensaje.Text = mensaje;
                txtIteracionesRes.Text = iteracionesRealizadas.ToString(CultureInfo.InvariantCulture);
                txtErrorRes.Text = error.ToString("G10", CultureInfo.InvariantCulture);

                // ⬇️ graficar automáticamente (función + raíz/raíces)
                await GraficarGeoGebraAsync(funcion, txtRaiz.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /* private async void btnGraficar_Click(object sender, EventArgs e)
         {
             try
             {
                 string funcion = txtFuncion.Text.Trim();
                 string raiz = txtRaiz.Text.Trim().Replace(',', '.');

                 if (string.IsNullOrWhiteSpace(funcion))
                 {
                     MessageBox.Show("Primero ingrese una función.", "Validación",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
                 if (string.IsNullOrWhiteSpace(raiz))
                 {
                     MessageBox.Show("Primero calcule la raíz antes de graficar.", "Validación",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }

                 string funcionUrl = Uri.EscapeDataString(funcion);
                 string url = $"https://www.geogebra.org/calculator?" +
                              $"command=Function[{funcionUrl},-10,10]" +
                              $"&command=Point[({raiz},0)]";

                 await webViewGeoGebra.EnsureCoreWebView2Async(null);
                 webViewGeoGebra.CoreWebView2.Navigate(url);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error al graficar: " + ex.Message, "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }*/
        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = Math.Max(1, Math.Min(bounds.Width, bounds.Height) * 2);
            d = Math.Min(d, radius * 2);
            var gp = new GraphicsPath();
            var arc = new Rectangle(bounds.Location, new Size(d, d));
            gp.AddArc(arc, 180, 90);
            arc.X = bounds.Right - d; gp.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - d; gp.AddArc(arc, 0, 90);
            arc.X = bounds.Left; gp.AddArc(arc, 90, 90);
            gp.CloseFigure();
            return gp;
        }

        private async Task GraficarGeoGebraAsync(string funcion, string raicesCsv)
        {
            if (string.IsNullOrWhiteSpace(funcion)) return;

            // soporta "2", "-2, 2" o "-2;2" (separa por coma o punto y coma)
            var raices = raicesCsv?
                .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim().Replace(',', '.')) // por si viene decimal con coma
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList() ?? new List<string>();

            string funcionUrl = Uri.EscapeDataString(funcion);

            // comando de la función en [-10,10]
            var commands = new List<string> { $"command=Function[{funcionUrl},-10,10]" };

            // agrega un Point por cada raíz
            foreach (var r in raices)
                commands.Add($"command=Point[({r},0)]");

            string url = "https://www.geogebra.org/calculator?" + string.Join("&", commands);

            await webViewGeoGebra.EnsureCoreWebView2Async(null);
            webViewGeoGebra.CoreWebView2.Navigate(url);
        }

        // Aplica estilo "badge" (pastilla) a un Label
        private void StyleBadge(Label lbl, Color bg, Color fg, int radius = 10, Padding? pad = null)
        {
            lbl.AutoSize = true;
            lbl.BackColor = bg;
            lbl.ForeColor = fg;
            lbl.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lbl.Padding = pad ?? new Padding(8, 4, 8, 4);
            lbl.Margin = new Padding(0, 6, 0, 6);
            lbl.TextAlign = ContentAlignment.MiddleLeft;

            // redondeado
            lbl.Resize += (_, __) =>
            {
                using var gp = RoundedRect(new Rectangle(Point.Empty, lbl.Size), radius);
                var old = lbl.Region;
                lbl.Region = new Region(gp);
                old?.Dispose();
            };
            // forzar una primera vez
            lbl.PerformLayout();
        }

        private void lblMensaje_Click(object sender, EventArgs e)
        {

        }

        private void lblIteracionesRes_Click(object sender, EventArgs e)
        {

        }

        private void txtXi_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRaiz_Click(object sender, EventArgs e)
        {

        }

        private void txtErrorRes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIntervalo_Click(object sender, EventArgs e)
        {

        }

        private void lblMetodo_Click(object sender, EventArgs e)
        {

        }

        private void lblErrorRes_Click(object sender, EventArgs e)
        {

        }

        private void lblIngresarFuncion_Click(object sender, EventArgs e)
        {

        }

        private void txtRaiz_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
