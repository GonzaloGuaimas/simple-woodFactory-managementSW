using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AberturasSalta.SubSecciones;
using AberturasSalta.Objetos;

namespace AberturasSalta.Secciones
{
    public partial class FormRemitos : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Usuario usuario;
        Remito remitoNulo = new Remito();
        Remito remitoSeleccionado;
        List<Remito> remitos = new List<Remito>();
        List<Producto> detalleRemito = new List<Producto>();
        List<Usuario> usuarios = new List<Usuario>();
        Color redColor = Color.FromArgb(180, 63, 38);
        Color yellowColor = Color.FromArgb(251, 149, 21);
        Color greenColor = Color.FromArgb(27, 172, 0);
        public FormRemitos(Usuario user)
        {
            InitializeComponent();
            usuario = user;
        }
        private void FormRemitos_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }







        private void buttonNuevoRemito_Click(object sender, EventArgs e)
        {
            this.Close();
            GenerarRemito generar = new GenerarRemito(usuario, remitoNulo);
            generar.Show();
        }















        private async void cargarDatos()
        {
            try
            {
                remitos = await firebaseHelper.getAllRemitos();
                detalleRemito = await firebaseHelper.getAllDetalleRemitos();
                usuarios = await firebaseHelper.getAllUsuario();
                dataGridRemitos.Rows.Clear();
                foreach (var remito in remitos)
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(remito.fecha.ToString().Substring(6, 4)), Convert.ToInt32(remito.fecha.ToString().Substring(3, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(0, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(11, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(14, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(17, 2)));
                    dataGridRemitos.Rows.Add(remito.key,remito.id,fecha,remito.tipo,remito.observacion,remito.desde,remito.destino,remito.usuario);
                }
                dataGridRemitos.Sort(dataGridRemitos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
                foreach (var user in usuarios)
                {
                    comboUsuario.Items.Add(user.apellido + " " + user.nombre);
                }
                recorrerListado();
            }
            catch(Exception es)
            {

            }
        }






















        private void buttonTodos_Click(object sender, EventArgs e)
        {
            dataGridRemitos.Rows.Clear();
            foreach (var remito in remitos)
            {
                DateTime fecha = new DateTime(Convert.ToInt32(remito.fecha.ToString().Substring(6, 4)), Convert.ToInt32(remito.fecha.ToString().Substring(3, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(0, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(11, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(14, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(17, 2)));
                dataGridRemitos.Rows.Add(remito.key, remito.id, fecha, remito.tipo, remito.observacion, remito.desde, remito.destino, remito.usuario);
            }
            dataGridRemitos.Sort(dataGridRemitos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
            recorrerListado();
        }

        private void dataGridRemitos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridRemitos.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    dataGridProductos.Rows.Clear();
                    remitoSeleccionado = new Remito();
                    remitoSeleccionado.key = dataGridRemitos.Rows[e.RowIndex].Cells[0].Value.ToString();
                    remitoSeleccionado.id = dataGridRemitos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    remitoSeleccionado.fecha = dataGridRemitos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    remitoSeleccionado.tipo = dataGridRemitos.Rows[e.RowIndex].Cells[3].Value.ToString();
                    remitoSeleccionado.observacion = dataGridRemitos.Rows[e.RowIndex].Cells[4].Value.ToString();
                    remitoSeleccionado.estado = dataGridRemitos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    remitoSeleccionado.desde = dataGridRemitos.Rows[e.RowIndex].Cells[6].Value.ToString();
                    remitoSeleccionado.destino = dataGridRemitos.Rows[e.RowIndex].Cells[7].Value.ToString();

                    if (MouseButtons.Right.Equals(e.Button))
                    {
                        DialogResult result = MessageBox.Show("Desea Abrir Remito " + dataGridRemitos.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            GenerarRemito generar = new GenerarRemito(usuario, remitoSeleccionado);
                            generar.Show();
                            this.Close();
                        }
                    }
                    int cant = 0;
                    foreach (var producto in detalleRemito)
                    {
                        if (producto.foranea.Equals(remitoSeleccionado.id))
                        {
                            dataGridProductos.Rows.Add(producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.cantidad);
                            cant = cant + Int32.Parse(producto.cantidad);
                        }
                    }
                    textCantidad.Text = "Cantidad: " + cant.ToString();
                }
            }
            catch(Exception es)
            {

            }
        }
        private void recorrerListado()
        {
            foreach (DataGridViewRow row in dataGridRemitos.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    if ((row.Cells[3].Value).ToString().Equals("Traspaso"))
                    {
                        row.DefaultCellStyle.ForeColor = yellowColor;
                    }
                    else if ((row.Cells[3].Value).ToString().Equals("Salida"))
                    {
                        row.DefaultCellStyle.ForeColor = redColor;
                    }
                    else if ((row.Cells[3].Value).ToString().Equals("Entrada"))
                    {
                        row.DefaultCellStyle.ForeColor = greenColor;
                    }
                }
            }
        }



















        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridRemitos.Rows.Clear();
            foreach (var remito in remitos)
            {
                if (comboTipo.Text.Equals(remito.tipo))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(remito.fecha.ToString().Substring(6, 4)), Convert.ToInt32(remito.fecha.ToString().Substring(3, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(0, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(11, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(14, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(17, 2)));
                    dataGridRemitos.Rows.Add(remito.key, remito.id, fecha, remito.tipo, remito.observacion, remito.desde, remito.destino, remito.usuario);
                }
            }
            dataGridRemitos.Sort(dataGridRemitos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }

        private void comboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridRemitos.Rows.Clear();
            foreach (var remito in remitos)
            {
                if (comboUsuario.Text.Equals(remito.usuario))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(remito.fecha.ToString().Substring(6, 4)), Convert.ToInt32(remito.fecha.ToString().Substring(3, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(0, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(11, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(14, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(17, 2)));
                    dataGridRemitos.Rows.Add(remito.key, remito.id, fecha, remito.tipo, remito.observacion, remito.desde, remito.destino, remito.usuario);
                }
            }
            dataGridRemitos.Sort(dataGridRemitos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }

        private void comboDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridRemitos.Rows.Clear();
            foreach (var remito in remitos)
            {
                if (comboDestino.Text.Equals(remito.destino))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(remito.fecha.ToString().Substring(6, 4)), Convert.ToInt32(remito.fecha.ToString().Substring(3, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(0, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(11, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(14, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(17, 2)));
                    dataGridRemitos.Rows.Add(remito.key, remito.id, fecha, remito.tipo, remito.observacion, remito.desde, remito.destino, remito.usuario);
                }
            }
            dataGridRemitos.Sort(dataGridRemitos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }

        private void comboDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridRemitos.Rows.Clear();
            foreach (var remito in remitos)
            {
                if (comboDesde.Text.Equals(remito.desde))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(remito.fecha.ToString().Substring(6, 4)), Convert.ToInt32(remito.fecha.ToString().Substring(3, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(0, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(11, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(14, 2)), Convert.ToInt32(remito.fecha.ToString().Substring(17, 2)));
                    dataGridRemitos.Rows.Add(remito.key, remito.id, fecha, remito.tipo, remito.observacion, remito.desde, remito.destino, remito.usuario);
                }
            }
            dataGridRemitos.Sort(dataGridRemitos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }
    }
}
