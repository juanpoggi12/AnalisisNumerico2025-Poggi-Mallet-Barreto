using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalisisNumerico2025Poggi.Regresion;

namespace InterfazDeUsuario
{
    public partial class RegresionForm : Form
    {
        private readonly List<double[]> _puntos = new();

        public RegresionForm()
        {
            InitializeComponent();
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            cmbMetodo.SelectedIndex = 0;   // Regresión Lineal por defecto
            txtTolerancia.Text = "0.8";    // 80%
            txtGrado.Text = "2";           // Grado por defecto si es polinomial
        }

        // ----------------------------
        // Eventos de interacción (UI)
        // ----------------------------

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                double x = ParseDouble(txtX.Text, "X");
                double y = ParseDouble(txtY.Text, "Y");
                _puntos.Add(new[] { x, y });
                RefrescarLista();
                txtX.Clear();
                txtY.Clear();
                txtX.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar punto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarUltimo_Click(object sender, EventArgs e)
        {
            if (_puntos.Count > 0)
            {
                _puntos.RemoveAt(_puntos.Count - 1);
                RefrescarLista();
            }
        }

        private void btnBorrarTodos_Click(object sender, EventArgs e)
        {
            _puntos.Clear();
            RefrescarLista();
            LimpiarSalida();
        }

        private void btnEditarSeleccionado_Click(object sender, EventArgs e)
        {
            int idx = lstPuntos.SelectedIndex;
            if (idx < 0)
            {
                MessageBox.Show("Seleccione un punto en la lista.", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var p = _puntos[idx];
            var dlg = new EditPointDialog(p[0], p[1]);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _puntos[idx] = new[] { dlg.X, dlg.Y };
                RefrescarLista();
            }
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (_puntos.Count < 2)
                {
                    MessageBox.Show("Agregue al menos 2 puntos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double tolerancia = ParseDouble(txtTolerancia.Text, "Tolerancia");
                int grado = SafeParseIntOrDefault(txtGrado.Text, 2);

                var puntosCargados = _puntos.ToList();

                // Selección de método
                var metodo = cmbMetodo.SelectedItem?.ToString() ?? string.Empty;
                ResultadoRegresion res;
                if (metodo.Contains("Polinomial", StringComparison.OrdinalIgnoreCase))
                {
                    res = RegresionPolinomial.Calcular(puntosCargados, grado, tolerancia);
                }
                else
                {
                    res = RegresionLineal.Calcular(puntosCargados, tolerancia);
                }

                // Mostrar salida
                txtFuncion.Text = res.Funcion;
                txtCorrelacion.Text = res.R.ToString("0.####", CultureInfo.InvariantCulture) + " %";
                txtECM.Text = res.ECM.ToString("0.###", CultureInfo.InvariantCulture);
                txtMensaje.Text = string.Join(Environment.NewLine, res.Advertencias);

                // Graficar en GeoGebra
                await GraficarGeoGebraAsync(res.Funcion, puntosCargados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------
        // Helpers
        // ----------------------------

        private void RefrescarLista()
        {
            lstPuntos.Items.Clear();
            int i = 1;
            foreach (var p in _puntos)
                lstPuntos.Items.Add($"Punto {i++}: ({p[0]}, {p[1]})");
        }

        private void LimpiarSalida()
        {
            txtFuncion.Text = "";
            txtCorrelacion.Text = "";
            txtECM.Text = "";
            txtMensaje.Text = "";
            webViewGeoGebra.CoreWebView2?.Navigate("about:blank");
        }

        private static double ParseDouble(string s, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new ArgumentException($"Ingrese un valor para {nombreCampo}.");
            s = s.Trim().Replace(',', '.');
            if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double v)) return v;
            if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out v)) return v;
            throw new ArgumentException($"Ingrese un valor numérico válido para {nombreCampo}.");
        }

        private static int SafeParseIntOrDefault(string s, int def)
        {
            if (int.TryParse((s ?? "").Trim(), out int v)) return v;
            return def;
        }

        private async Task GraficarGeoGebraAsync(string funcion, List<double[]> puntos)
        {
            if (string.IsNullOrWhiteSpace(funcion)) return;

            // Normalizar la función
            funcion = funcion.Trim();
            funcion = funcion.Replace(",", ".");        // usar punto decimal
            if (funcion.StartsWith("y=")) funcion = funcion.Substring(2);
            if (funcion.StartsWith("+")) funcion = funcion.Substring(1);
            funcion = "y=" + funcion;                   // volver a poner el prefijo correcto

            string funcionUrl = Uri.EscapeDataString(funcion);

            // Comando para la función en [-10,10]
            // Quitar el "y=" antes de mandarlo a GeoGebra
            string expresion = funcion.Replace("y=", "").Trim();
            string expresionUrl = Uri.EscapeDataString(expresion);

            // Ahora sí, solo la expresión
            var commands = new List<string> { $"command=Function[{expresionUrl},-10,10]" };

            // Agregar puntos
            foreach (var p in puntos)
            {
                string x = p[0].ToString(CultureInfo.InvariantCulture);
                string y = p[1].ToString(CultureInfo.InvariantCulture);
                commands.Add($"command=Point[({x},{y})]");
            }

            string url = "https://www.geogebra.org/calculator?" + string.Join("&", commands);

            await webViewGeoGebra.EnsureCoreWebView2Async(null);
            webViewGeoGebra.CoreWebView2.Navigate(url);
        }

        // ----------------------------
        // Diálogo simple para editar punto
        // ----------------------------

        private sealed class EditPointDialog : Form
        {
            private readonly TextBox _tx;
            private readonly TextBox _ty;
            private readonly Button _ok;
            private readonly Button _cancel;

            public double X { get; private set; }
            public double Y { get; private set; }

            public EditPointDialog(double x, double y)
            {
                this.Text = "Editar punto";
                this.Size = new Size(280, 180);
                this.StartPosition = FormStartPosition.CenterParent;

                var lblx = new Label { Text = "X", Location = new Point(20, 20) };
                _tx = new TextBox { Location = new Point(60, 18), Size = new Size(180, 27), Text = x.ToString(CultureInfo.InvariantCulture) };

                var lbly = new Label { Text = "Y", Location = new Point(20, 60) };
                _ty = new TextBox { Location = new Point(60, 58), Size = new Size(180, 27), Text = y.ToString(CultureInfo.InvariantCulture) };

                _ok = new Button { Text = "OK", Location = new Point(60, 100), Size = new Size(80, 30) };
                _cancel = new Button { Text = "Cancelar", Location = new Point(160, 100), Size = new Size(80, 30) };

                _ok.Click += (_, __) =>
                {
                    try
                    {
                        X = ParseDouble(_tx.Text, "X");
                        Y = ParseDouble(_ty.Text, "Y");
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                _cancel.Click += (_, __) => { this.DialogResult = DialogResult.Cancel; Close(); };

                Controls.Add(lblx);
                Controls.Add(_tx);
                Controls.Add(lbly);
                Controls.Add(_ty);
                Controls.Add(_ok);
                Controls.Add(_cancel);
            }
        }
    }
}