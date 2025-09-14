using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AnalisisNumerico2025Poggi.SistemasEcuaciones;

namespace InterfazDeUsuario
{
    public partial class SistemasForm : Form
    {
        public SistemasForm()
        {
            InitializeComponent();
        }

        // ————————————————————
        // Eventos UI
        // ————————————————————

        private void SistemasForm_Load(object sender, EventArgs e)
        {
            // Inicializar combo métodos y estado de campos
            cmbMetodoSis.Items.Clear();
            cmbMetodoSis.Items.AddRange(new object[] { "Gauss-Jordan", "Gauss-Seidel" });
            cmbMetodoSis.SelectedIndex = 0;
            ToggleSeidelParams();

            // DataGrids
            dgvEntrada.AllowUserToAddRows = false;
            dgvEntrada.AllowUserToDeleteRows = false;
            dgvEntrada.RowHeadersVisible = false;
            dgvEntrada.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvReducida.AllowUserToAddRows = false;
            dgvReducida.AllowUserToDeleteRows = false;
            dgvReducida.RowHeadersVisible = false;
            dgvReducida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void cmbMetodoSis_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleSeidelParams();
        }

        private void btnArmar_Click(object sender, EventArgs e)
        {
            try
            {
                ArmarMatriz();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Armar matriz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResolverSis_Click(object sender, EventArgs e)
        {
            ResolverSistema();
        }

        private void lstPasosSis_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarPasoSeleccionado();
        }

        // ————————————————————
        // Lógica de UI
        // ————————————————————

        private void ToggleSeidelParams()
        {
            bool esSeidel = (cmbMetodoSis.SelectedItem?.ToString() ?? "")
                .IndexOf("Seidel", StringComparison.OrdinalIgnoreCase) >= 0;

            txtToleranciaSis.Enabled = esSeidel;
            txtMaxIterSis.Enabled = esSeidel;
            if (!esSeidel)
            {
                // mantener visibles pero deshabilitados para consistencia
            }
        }

        private void ArmarMatriz()
        {
            int n = (int)numericUpDownN.Value;

            dgvEntrada.Columns.Clear();
            dgvEntrada.Rows.Clear();

            for (int j = 0; j < n; j++)
                dgvEntrada.Columns.Add($"c{j}", $"a{j + 1}");

            dgvEntrada.Columns.Add("b", "b");

            dgvEntrada.Rows.Add(n);

            // limpiar celdas
            for (int i = 0; i < n; i++)
                for (int j = 0; j <= n; j++)
                    dgvEntrada[j, i].Value = "";
        }

        private void ResolverSistema()
        {
            ResultadoSistema res = null; // Declarada fuera para usarla en catch

            try
            {
                lstAdvertenciasSis.Items.Clear();
                lstErroresSis.Items.Clear();
                lstPasosSis.Items.Clear();
                txtSolucionSis.Clear();
                dgvReducida.DataSource = null;
                _ultimoResultado = null;

                double[,] A = LeerMatrizDesdeGrid();

                string metodo = cmbMetodoSis.SelectedItem?.ToString() ?? "";

                if (metodo.IndexOf("Jordan", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    res = Ecuaciones.ResolverGaussJordan(A);
                    GuardarYMostrar(res, esSeidel: false);
                }
                else if (metodo.IndexOf("Seidel", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // parse de parámetros
                    double tol = ParseDoubleUi(txtToleranciaSis.Text, "Tolerancia", 1e-3);
                    int maxIt = ParseIntUi(txtMaxIterSis.Text, "Máx. iteraciones", 1000);

                    // Advertir (no bloquear) si no es DD
                    if (!EsDiagonalmenteDominante(A))
                        lstAdvertenciasSis.Items.Add("La matriz no es diagonalmente dominante. Gauss-Seidel podría no converger.");

                    res = Ecuaciones.ResolverGaussSeidel(A, tol, maxIt);
                    GuardarYMostrar(res, esSeidel: true);
                }
                else
                {
                    throw new NotSupportedException("Seleccione un método válido.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje en la lista y en un MessageBox
                lstErroresSis.Items.Add(ex.Message);
                MessageBox.Show(ex.Message, "Resolver", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Si hay resultado parcial, mostrarlo igual
                if (res != null)
                    GuardarYMostrar(res, esSeidel: true);
            }
        }

        private double[,] LeerMatrizDesdeGrid()
        {
            if (dgvEntrada.Rows.Count == 0 || dgvEntrada.Columns.Count == 0)
                throw new ArgumentException("Primero armá la matriz con 'Armar matriz'.");

            int n = dgvEntrada.Rows.Count;
            int m = dgvEntrada.Columns.Count;

            if (m != n + 1)
                throw new ArgumentException($"La matriz aumentada debe ser de tamaño {n}×(n+1). Actualmente es {n}×{m}.");

            var A = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    object val = dgvEntrada[j, i].Value;
                    if (val == null || string.IsNullOrWhiteSpace(val.ToString()))
                        throw new ArgumentException($"Celda vacía en fila {i + 1}, columna {j + 1}.");

                    string s = val.ToString()!.Trim().Replace(',', '.');

                    if (!double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double d))
                        throw new ArgumentException($"Valor inválido en fila {i + 1}, columna {j + 1}: '{val}'.");

                    A[i, j] = d;
                }
            }

            return A;
        }

        private void GuardarYMostrar(ResultadoSistema res, bool esSeidel)
        {
            _ultimoResultado = res;
            MostrarResultado(res, esSeidel);
        }

        private void MostrarResultado(ResultadoSistema res, bool esSeidel)
        {
            // Solución
            if (res?.Solucion != null && res.Solucion.Length > 0)
            {
                var lineas = res.Solucion.Select((x, i) => $"x{i + 1} = {x.ToString("G10", CultureInfo.InvariantCulture)}");
                txtSolucionSis.Text = string.Join(Environment.NewLine, lineas);
            }
            else
            {
                txtSolucionSis.Text = "(sin solución calculada)";
            }

            // Matriz reducida (solo para Jordan; Seidel no aplica)
            if (!esSeidel && res?.MatrizReducida != null)
            {
                dgvReducida.DataSource = ToDataTable(res.MatrizReducida);
            }
            else
            {
                dgvReducida.DataSource = null;
            }

            // Advertencias / Errores (si el backend los llena)
            if (res?.Advertencias != null)
                foreach (var w in res.Advertencias) lstAdvertenciasSis.Items.Add(w);

            // Pasos
            if (res?.Pasos != null && res.Pasos.Count > 0)
            {
                for (int k = 0; k < res.Pasos.Count; k++)
                    lstPasosSis.Items.Add($"Paso {k + 1}");
            }
        }

        private void MostrarPasoSeleccionado()
        {
            int idx = lstPasosSis.SelectedIndex;
            if (idx < 0 || _ultimoResultado == null || _ultimoResultado.Pasos == null) return;
            if (idx >= _ultimoResultado.Pasos.Count) return;

            var paso = _ultimoResultado.Pasos[idx];
            dgvReducida.DataSource = ToDataTable(paso);
        }

        // ————————————————————
        // Helpers
        // ————————————————————

        private ResultadoSistema _ultimoResultado;

        private static DataTable ToDataTable(double[,] M)
        {
            int rows = M.GetLength(0);
            int cols = M.GetLength(1);

            var dt = new DataTable();
            for (int j = 0; j < cols; j++)
                dt.Columns.Add(j == cols - 1 ? "b" : $"a{j + 1}", typeof(string));

            for (int i = 0; i < rows; i++)
            {
                var arr = new object[cols];
                for (int j = 0; j < cols; j++)
                    arr[j] = M[i, j].ToString("G10", CultureInfo.InvariantCulture);
                dt.Rows.Add(arr);
            }
            return dt;
        }

        private static bool EsDiagonalmenteDominante(double[,] A)
        {
            int n = A.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                double suma = 0;
                for (int j = 0; j < n; j++)
                    if (j != i) suma += Math.Abs(A[i, j]);

                if (Math.Abs(A[i, i]) < suma)
                    return false;
            }
            return true;
        }

        private static double ParseDoubleUi(string s, string nombre, double defaultValue)
        {
            if (string.IsNullOrWhiteSpace(s)) return defaultValue;
            s = s.Trim().Replace(',', '.');
            if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double v))
                return v;
            throw new ArgumentException($"{nombre} inválido.");
        }

        private static int ParseIntUi(string s, string nombre, int defaultValue)
        {
            if (string.IsNullOrWhiteSpace(s)) return defaultValue;
            if (int.TryParse(s.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out int v) && v > 0)
                return v;
            throw new ArgumentException($"{nombre} debe ser un entero > 0.");
        }
    }
}