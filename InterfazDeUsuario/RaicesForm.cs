using System;
using System.Windows.Forms;
using AnalisisNumerico2025Poggi;

namespace InterfazDeUsuario
{
    public partial class RaicesForm : Form
    {
        private Solver solver = new Solver();

        public RaicesForm()
        {
            InitializeComponent();
            cmbMetodo.SelectedIndexChanged += cmbMetodo_SelectedIndexChanged;
            cmbMetodo.SelectedIndex = 0;
            ActualizarCampos();
        }

        private void cmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCampos();
        }

        private void ActualizarCampos()
        {
            string metodo = cmbMetodo.SelectedItem?.ToString() ?? "";
            if (metodo.Contains("Newton-Raphson"))
            {
                txtXi.Enabled = true;
                txtXd.Enabled = false;
                txtXd.Text = "";
            }
            else if (metodo.Contains("Secante"))
            {
                txtXi.Enabled = true;
                txtXd.Enabled = true;
            }
            else 
            {
                txtXi.Enabled = true;
                txtXd.Enabled = true;
            }
        }

        private bool ValidarCampos(out string mensaje)
        {
            mensaje = "";
            if (string.IsNullOrWhiteSpace(txtFuncion.Text))
            {
                mensaje = "Debe ingresar una función.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtIteraciones.Text) || !int.TryParse(txtIteraciones.Text, out int iter) || iter <= 0)
            {
                mensaje = "Ingrese un número válido de iteraciones (>0).";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTolerancia.Text) || !double.TryParse(txtTolerancia.Text.Replace(',', '.'), out double tol) || tol <= 0)
            {
                mensaje = "Ingrese una tolerancia válida (>0).";
                return false;
            }
            string metodo = cmbMetodo.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(txtXi.Text) || !double.TryParse(txtXi.Text.Replace(',', '.'), out _))
            {
                mensaje = "Ingrese un valor numérico válido para Xi.";
                return false;
            }
            if (!metodo.Contains("Newton-Raphson"))
            {
                if (string.IsNullOrWhiteSpace(txtXd.Text) || !double.TryParse(txtXd.Text.Replace(',', '.'), out _))
                {
                    mensaje = "Ingrese un valor numérico válido para Xd.";
                    return false;
                }
            }
            return true;
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos(out string mensajeValidacion))
                {
                    MessageBox.Show(mensajeValidacion, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string funcion = txtFuncion.Text;
                double xi = double.Parse(txtXi.Text.Replace(',', '.'));
                double xd = txtXd.Enabled && !string.IsNullOrWhiteSpace(txtXd.Text) ? double.Parse(txtXd.Text.Replace(',', '.')) : 0;
                double tol = double.Parse(txtTolerancia.Text.Replace(',', '.'));
                int iter = int.Parse(txtIteraciones.Text);

                string metodo = cmbMetodo.SelectedItem.ToString();
                double raiz = 0;
                string mensaje = "";
                int iteracionesRealizadas = 0;
                double error = 0;

                if (metodo.Contains("Bisección"))
                {
                    raiz = solver.Biseccion(funcion, 'x', xi, xd, tol, iter);
                    mensaje = "Bisección finalizada";
                }
                else if (metodo.Contains("Regla Falsa"))
                {
                    raiz = solver.ReglaFalsa(funcion, 'x', xi, xd, tol, iter);
                    mensaje = "Regla Falsa finalizada";
                }
                else if (metodo.Contains("Newton-Raphson"))
                {
                    var abiertos = new MetodosAbiertos(funcion);
                    var resultado = abiertos.NewtonRaphson(xi, tol, iter);
                    raiz = resultado.Raiz;
                    mensaje = resultado.Message;
                    iteracionesRealizadas = resultado.Iteraciones.Count;
                    if (resultado.Iteraciones.Count > 0)
                        error = resultado.Iteraciones[^1].Error;
                }
                else if (metodo.Contains("Secante"))
                {
                    var abiertos = new MetodosAbiertos(funcion);
                    var resultado = abiertos.Secante(xi, xd, tol, iter);
                    raiz = resultado.Raiz;
                    mensaje = resultado.Message;
                    iteracionesRealizadas = resultado.Iteraciones.Count;
                    if (resultado.Iteraciones.Count > 0)
                        error = resultado.Iteraciones[^1].Error;
                }

                txtRaiz.Text = raiz.ToString("G10");
                txtMensaje.Text = mensaje;
                txtIteracionesRes.Text = iteracionesRealizadas.ToString();
                txtErrorRes.Text = error.ToString("G10");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
