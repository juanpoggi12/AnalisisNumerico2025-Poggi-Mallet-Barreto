using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalisisNumerico2025Poggi.Integracion;

namespace InterfazDeUsuario
{
    public partial class IntegracionForm : Form
    {
        public IntegracionForm()
        {
            InitializeComponent();
            ApplyTheme();
            InitializeDefaults();
            cmbMetodo.SelectedIndexChanged += CmbMetodo_SelectedIndexChanged;
        }

        private void InitializeDefaults()
        {
            cmbMetodo.SelectedIndex = 0;      // Trapecios Simple
            txtSubintervalos.Text = "100";    // valor útil por defecto para métodos múltiples
        }

        private void ApplyTheme()
        {
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.BackColor = Color.FromArgb(246, 248, 255);

            StyleBadge(lblTitulo, Color.FromArgb(33, 150, 243), Color.White, 10, new Padding(10, 6, 10, 6));
            StyleBadge(lblFuncion, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210));
            StyleBadge(lblMetodo, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210));
            StyleBadge(lblXi, Color.FromArgb(236, 239, 241), Color.FromArgb(55, 71, 79), 8, new Padding(6, 3, 6, 3));
            StyleBadge(lblXd, Color.FromArgb(236, 239, 241), Color.FromArgb(55, 71, 79), 8, new Padding(6, 3, 6, 3));
            StyleBadge(lblSubintervalos, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210));

            StyleBadge(lblResultado, Color.FromArgb(232, 245, 233), Color.FromArgb(27, 94, 32));
            StyleBadge(lblMensaje, Color.FromArgb(227, 242, 253), Color.FromArgb(25, 118, 210));

            foreach (var tb in new[] { txtResultado, txtMensaje })
            {
                tb.ReadOnly = true;
                tb.BackColor = Color.White;
                tb.BorderStyle = BorderStyle.FixedSingle;
            }

            foreach (var b in new[] { btnCalcular })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = Color.FromArgb(33, 150, 243);
                b.ForeColor = Color.White;
                b.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }

            // Anti parpadeo
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        private void StyleBadge(Label lbl, Color bg, Color fg, int radius = 8, Padding? pad = null)
        {
            lbl.AutoSize = true;
            lbl.BackColor = bg;
            lbl.ForeColor = fg;
            lbl.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            lbl.Padding = pad ?? new Padding(8, 4, 8, 4);
            lbl.Margin = new Padding(0, 6, 0, 6);
            lbl.TextAlign = ContentAlignment.MiddleLeft;

            lbl.Resize += (_, __) =>
            {
                using var gp = RoundedRect(new Rectangle(Point.Empty, lbl.Size), radius);
                var old = lbl.Region;
                lbl.Region = new Region(gp);
                old?.Dispose();
            };
            lbl.PerformLayout();
        }

        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = Math.Max(1, Math.Min(bounds.Width, bounds.Height) * 2);
            d = Math.Min(d, radius * 2);
            var gp = new System.Drawing.Drawing2D.GraphicsPath();
            var arc = new Rectangle(bounds.Location, new Size(d, d));
            gp.AddArc(arc, 180, 90);
            arc.X = bounds.Right - d; gp.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - d; gp.AddArc(arc, 0, 90);
            arc.X = bounds.Left; gp.AddArc(arc, 90, 90);
            gp.CloseFigure();
            return gp;
        }

        private void CmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool requiereN = cmbMetodo.SelectedItem?.ToString()?.IndexOf("Múltiple", StringComparison.OrdinalIgnoreCase) >= 0
                             || cmbMetodo.SelectedItem?.ToString()?.IndexOf("Combinado", StringComparison.OrdinalIgnoreCase) >= 0;
            txtSubintervalos.Enabled = requiereN;
            if (!requiereN) txtSubintervalos.Text = "";
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                if (string.IsNullOrWhiteSpace(txtFuncion.Text))
                {
                    MessageBox.Show("Debe ingresar una función (ej: 1/x, sin(x), x^2 + 3x).", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double xi = ParseDouble(txtXi.Text, "Xi");
                double xd = ParseDouble(txtXd.Text, "Xd");
                if (xd <= xi)
                {
                    MessageBox.Show("Xd debe ser mayor que Xi.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int n = 0;
                string metodo = cmbMetodo.SelectedItem?.ToString() ?? string.Empty;
                bool requiereN = metodo.IndexOf("Múltiple", StringComparison.OrdinalIgnoreCase) >= 0
                                 || metodo.IndexOf("Combinado", StringComparison.OrdinalIgnoreCase) >= 0;
                if (requiereN)
                {
                    n = ParseInt(txtSubintervalos.Text, "Subintervalos (n)");
                    if (n <= 0)
                    {
                        MessageBox.Show("n debe ser un entero > 0.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var solver = new IntegracionNumerica();
                ResultadoIntegracion res;

                // Dispatch por método
                if (metodo.Contains("Trapecios Simple", StringComparison.OrdinalIgnoreCase))
                    res = solver.TrapeciosSimple(txtFuncion.Text.Trim(), xi, xd);
                else if (metodo.Contains("Trapecios Múltiple", StringComparison.OrdinalIgnoreCase))
                    res = solver.TrapeciosMultiple(txtFuncion.Text.Trim(), xi, xd, n);
                else if (metodo.Contains("Simpson 1/3 Simple", StringComparison.OrdinalIgnoreCase))
                    res = solver.Simpson13Simple(txtFuncion.Text.Trim(), xi, xd);
                else if (metodo.Contains("Simpson 1/3 Múltiple", StringComparison.OrdinalIgnoreCase))
                    res = solver.Simpson13Multiple(txtFuncion.Text.Trim(), xi, xd, n);
                else if (metodo.Contains("Simpson 3/8 Simple", StringComparison.OrdinalIgnoreCase))
                    res = solver.Simpson38Simple(txtFuncion.Text.Trim(), xi, xd);
                else if (metodo.Contains("Combinado", StringComparison.OrdinalIgnoreCase))
                    res = solver.Simpson13_38Combinado(txtFuncion.Text.Trim(), xi, xd, n);
                else
                    throw new NotSupportedException("Seleccione un método válido.");

                // Mostrar salida
                txtResultado.Text = res.Resultado.ToString("G10", CultureInfo.InvariantCulture);
                txtMensaje.Text = BuildMensaje(res);

                // Graficar integral en GeoGebra (función + área sombreada aproximada con Polígono entre recta y curva)
                await GraficarGeoGebraAsync(txtFuncion.Text.Trim(), xi, xd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static double ParseDouble(string s, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException($"Ingrese un valor para {nombreCampo}.");
            s = s.Trim().Replace(',', '.');
            if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double v))
                return v;
            if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out v))
                return v;
            throw new ArgumentException($"Ingrese un valor numérico válido para {nombreCampo}.");
        }

        private static int ParseInt(string s, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException($"Ingrese un valor para {nombreCampo}.");
            if (!int.TryParse(s.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out int v))
                throw new ArgumentException($"{nombreCampo} debe ser un entero válido.");
            return v;
        }

        private static string BuildMensaje(ResultadoIntegracion r)
        {
            var advert = (r.Advertencias?.Any() == true) ? string.Join(Environment.NewLine, r.Advertencias) : "OK";
            return $"{r.Metodo}{Environment.NewLine}f(x) = {r.Funcion}{Environment.NewLine}[" +
                   $"{r.Xi.ToString("G", CultureInfo.InvariantCulture)}, " +
                   $"{r.Xd.ToString("G", CultureInfo.InvariantCulture)}]{Environment.NewLine}{advert}";
        }

        private async Task GraficarGeoGebraAsync(string funcion, double xi, double xd)
        {
            if (string.IsNullOrWhiteSpace(funcion)) return;

            // Normalizar expresión
            string expr = funcion.Trim().Replace(",", ".");
            string xiStr = xi.ToString(CultureInfo.InvariantCulture);
            string xdStr = xd.ToString(CultureInfo.InvariantCulture);

            // 1️⃣ Definir la función f(x)
            string fDef = $"f(x)={expr}";

            // 2️⃣ Dibujar la función en el intervalo
            string funcCmd = $"Function[f,{xiStr},{xdStr}]";

            // 3️⃣ Sombrear el área bajo la curva respecto al eje x
            string areaCmd = $"IntegralBetween[f,0,{xiStr},{xdStr}]";

            // 4️⃣ (Opcional) Marcar los límites Xi y Xd
            string aCmd = $"A=({xiStr},0)";
            string bCmd = $"B=({xdStr},0)";

            // ✅ Combinar todo en un único "command=" con punto y coma
            string allCmds = $"{fDef};{funcCmd};{areaCmd};{aCmd};{bCmd}";
            string url = "https://www.geogebra.org/calculator?command=" + Uri.EscapeDataString(allCmds);

            await webViewGeoGebra.EnsureCoreWebView2Async(null);
            webViewGeoGebra.CoreWebView2.Navigate(url);
        }

    }
}