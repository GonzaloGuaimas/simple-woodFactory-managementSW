using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AberturasSalta.Objetos;

namespace AberturasSalta.SubSecciones
{
    public partial class GenerarGasto : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Usuario usuario;
        List<Pago> pagos = new List<Pago>();
        List<Pago> pagosAdd = new List<Pago>();
        List<Usuario> usuarios = new List<Usuario>();
        

        public GenerarGasto(Usuario user)
        {
            InitializeComponent();
            usuario = user;
        }
        private void GenerarGasto_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
























        private async void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!comboSucursal.Text.Equals("") && !comboEmpleado.Text.Equals("") && !textMotivo.Text.Equals("") && !textMonto.Text.Equals(""))
                {
                    buttonAgregar.Enabled = false;
                    buttonAgregar.Text = "Espere...";
                    Pago pago = new Pago();
                    pago.id = dateFecha.Value.ToString("ddMMyyyyHHmmss");
                    pago.fecha = dateFecha.Value.ToString("dd/MM/yyyy HH:mm:ss");
                    pago.sucursal = comboSucursal.Text;
                    pago.foranea = comboEmpleado.Text;
                    pago.nombre = "gasto";
                    pago.comentario = textMotivo.Text;
                    pago.monto = textMonto.Text;
                    pagosAdd.Add(pago);
                    await firebaseHelper.addDetallePago(pagosAdd);
                    MessageBox.Show("Gasto Agregado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    buttonAgregar.Enabled = true;
                    buttonAgregar.Text = "Agregar";
                }
                else
                {
                    MessageBox.Show("Complete Campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
            }
        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            dataGridGastos.Rows.Clear();
            foreach (var pago in pagos)
            {
                if (pago.nombre.Equals("gasto"))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(pago.fecha.ToString().Substring(6, 4)), Convert.ToInt32(pago.fecha.ToString().Substring(3, 2)), Convert.ToInt32(pago.fecha.ToString().Substring(0, 2)), 12, 12, 12);
                    dataGridGastos.Rows.Add(pago.id, fecha, pago.monto, pago.sucursal, pago.comentario, pago.foranea);
                }
            }
            dataGridGastos.Sort(dataGridGastos.Columns[1], System.ComponentModel.ListSortDirection.Descending);

        }

        private void comboFiltroSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridGastos.Rows.Clear();
            foreach (var pago in pagos)
            {
                if (pago.sucursal.Equals(comboFiltroSucursal.Text))
                {
                    if (pago.nombre.Equals("gasto"))
                    {
                        DateTime fecha = new DateTime(Convert.ToInt32(pago.fecha.ToString().Substring(6, 4)), Convert.ToInt32(pago.fecha.ToString().Substring(3, 2)), Convert.ToInt32(pago.fecha.ToString().Substring(0, 2)), 12, 12, 12);
                        dataGridGastos.Rows.Add(pago.id, fecha, pago.monto, pago.sucursal, pago.comentario, pago.foranea);
                    }
                }
            }
            dataGridGastos.Sort(dataGridGastos.Columns[1], System.ComponentModel.ListSortDirection.Descending);
        }

        private void dateFiltroFecha_ValueChanged(object sender, EventArgs e)
        {
            dataGridGastos.Rows.Clear();
            foreach (var pago in pagos)
            {
                if (pago.fecha.Substring(0, 10).Equals(dateFecha.Value.ToString("dd/MM/yyyy")))
                {
                    if (pago.nombre.Equals("gasto"))
                    {
                        DateTime fecha = new DateTime(Convert.ToInt32(pago.fecha.ToString().Substring(6, 4)), Convert.ToInt32(pago.fecha.ToString().Substring(3, 2)), Convert.ToInt32(pago.fecha.ToString().Substring(0, 2)), 12, 12, 12);
                        dataGridGastos.Rows.Add(pago.id, fecha, pago.monto, pago.sucursal, pago.comentario, pago.foranea);
                    }
                }
            }
            dataGridGastos.Sort(dataGridGastos.Columns[1], System.ComponentModel.ListSortDirection.Descending);
        }




















        private async void cargarDatos()
        {
            try
            {
                pagos = await firebaseHelper.getAllDetallePagos();
                usuarios = await firebaseHelper.getAllUsuario();
                comboEmpleado.Text = usuario.apellido + " " + usuario.nombre;
                comboSucursal.Text = usuario.sucursal;
                dataGridGastos.Rows.Clear();
                foreach (var pago in pagos)
                {
                    if (pago.nombre.Equals("gasto"))
                    {
                        DateTime fecha = new DateTime(Convert.ToInt32(pago.fecha.ToString().Substring(6, 4)), Convert.ToInt32(pago.fecha.ToString().Substring(3, 2)), Convert.ToInt32(pago.fecha.ToString().Substring(0, 2)), 12, 12, 12);
                        dataGridGastos.Rows.Add(pago.id, fecha, pago.monto, pago.sucursal, pago.comentario, pago.foranea);
                    }
                }
                dataGridGastos.Sort(dataGridGastos.Columns[1], System.ComponentModel.ListSortDirection.Descending);
                foreach (var user in usuarios)
                {
                    comboEmpleado.Items.Add(user.apellido + " " + user.nombre);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

    }
}
