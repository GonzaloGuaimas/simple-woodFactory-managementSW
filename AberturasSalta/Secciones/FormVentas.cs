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
    public partial class FormVentas : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Usuario usuario;
        List<Venta> ventas = new List<Venta>();
        List<Producto> detalleVentas = new List<Producto>();
        List<Pago> detallePago = new List<Pago>();
        Venta ventaSeleccionada;
        Venta ventaNula = new Venta();
        List<Cliente> clientes = new List<Cliente>();
        List<Usuario> usuarios = new List<Usuario>();
        Color redColor = Color.FromArgb(180, 63, 38);
        Color yellowColor = Color.FromArgb(251, 149, 21);
        Color greenColor = Color.FromArgb(27, 172, 0);
        public FormVentas(Usuario user)
        {
            InitializeComponent();
            usuario = user;
        }
        private void FormVentas_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
















        private void buttonNuevaVenta_Click(object sender, EventArgs e)
        {
            GenerarVenta generarVenta = new GenerarVenta(usuario, ventaNula);
            generarVenta.Show();
            this.Close();
        }
        private void buttonTodas_Click(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                DateTime fecha = new DateTime(Convert.ToInt32(venta.fecha.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(17, 2)));
                if (!venta.fecha_entrega.Equals(""))
                {
                    DateTime fechaEntr = new DateTime(Convert.ToInt32(venta.fecha_entrega.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(17, 2)));
                    dataGridVentas.Rows.Add(venta.key, venta.id, fecha, fechaEntr, venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                }
                else
                {
                    dataGridVentas.Rows.Add(venta.key, venta.id, fecha, "", venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                }
            }
            dataGridVentas.Sort(dataGridVentas.Columns[2], System.ComponentModel.ListSortDirection.Descending);
            recorrerListado();
        }
        private void dataGridVentas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridVentas.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    dataGridPagos.Rows.Clear();
                    dataGridProductos.Rows.Clear();
                    ventaSeleccionada = new Venta();
                    ventaSeleccionada.key = dataGridVentas.Rows[e.RowIndex].Cells[0].Value.ToString();
                    ventaSeleccionada.id = dataGridVentas.Rows[e.RowIndex].Cells[1].Value.ToString();
                    ventaSeleccionada.fecha = dataGridVentas.Rows[e.RowIndex].Cells[2].Value.ToString();
                    ventaSeleccionada.fecha_entrega = dataGridVentas.Rows[e.RowIndex].Cells[3].Value.ToString();
                    ventaSeleccionada.nombre_sucursal = dataGridVentas.Rows[e.RowIndex].Cells[4].Value.ToString();
                    ventaSeleccionada.tipo_pago = dataGridVentas.Rows[e.RowIndex].Cells[5].Value.ToString();
                    ventaSeleccionada.total = dataGridVentas.Rows[e.RowIndex].Cells[6].Value.ToString();
                    ventaSeleccionada.ganancia = dataGridVentas.Rows[e.RowIndex].Cells[7].Value.ToString();
                    ventaSeleccionada.estado = dataGridVentas.Rows[e.RowIndex].Cells[8].Value.ToString();
                    ventaSeleccionada.nombre_empleado = dataGridVentas.Rows[e.RowIndex].Cells[9].Value.ToString();
                    ventaSeleccionada.nombre_cliente = dataGridVentas.Rows[e.RowIndex].Cells[10].Value.ToString();
                    ventaSeleccionada.observacion = dataGridVentas.Rows[e.RowIndex].Cells[11].Value.ToString();

                    if (MouseButtons.Right.Equals(e.Button))
                    {
                        DialogResult result = MessageBox.Show("Desea Abrir Venta " + dataGridVentas.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            GenerarVenta generarVenta = new GenerarVenta(usuario, ventaSeleccionada);
                            generarVenta.Show();
                            this.Close();
                        }
                    }
                    foreach (var pago in detallePago)
                    {
                        if (pago.foranea.Equals(ventaSeleccionada.id))
                        {
                            dataGridPagos.Rows.Add(pago.nombre, pago.fecha, pago.monto, pago.sucursal, pago.comentario);
                        }
                    }
                    foreach (var producto in detalleVentas)
                    {
                        if (producto.foranea.Equals(ventaSeleccionada.id))
                        {
                            dataGridProductos.Rows.Add(producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.precio, producto.costo);
                        }
                    }
                }
            }
            catch (Exception ES)
            {

            }
        }















        private async void cargarDatos()
        {
            try
            {
                dataGridVentas.Rows.Clear();
                ventas = await firebaseHelper.getAllVentas();
                detalleVentas = await firebaseHelper.getAllDetalleVenta();
                detallePago = await firebaseHelper.getAllDetallePagos();
                usuarios = await firebaseHelper.getAllUsuario();
                clientes = await firebaseHelper.getAllClientes();
                foreach (var venta in ventas)
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(venta.fecha.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(17, 2)));
                    if (!venta.fecha_entrega.Equals(""))
                    {
                        DateTime fechaEntr = new DateTime(Convert.ToInt32(venta.fecha_entrega.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(17, 2)));
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, fechaEntr, venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                    else
                    {
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, "", venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                }
                dataGridVentas.Sort(dataGridVentas.Columns[2], System.ComponentModel.ListSortDirection.Descending);
                foreach (var user in usuarios)
                {
                    comboUsuarios.Items.Add(user.apellido + " " + user.nombre);
                }
                foreach (var cliente in clientes)
                {
                    comboClientes.Items.Add(cliente.nombre);
                }
                recorrerListado();
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private void recorrerListado()
        {
            foreach (DataGridViewRow row in dataGridVentas.Rows)
            {
                if (row.Cells[8].Value != null)
                {
                    if ((row.Cells[8].Value).ToString().Equals("A Fabricar"))
                    {
                        row.DefaultCellStyle.ForeColor = redColor;
                    }
                    else if ((row.Cells[8].Value).ToString().Equals("Pendiente Pago"))
                    {
                        row.DefaultCellStyle.ForeColor = yellowColor;
                    }
                    else if ((row.Cells[8].Value).ToString().Equals("Pagada Pendiente Retiro"))
                    {
                        row.DefaultCellStyle.ForeColor = yellowColor;
                    }
                    else if ((row.Cells[8].Value).ToString().Equals("Concretada"))
                    {
                        row.DefaultCellStyle.ForeColor = greenColor;
                    }
                }
            }
        }


























        private void comboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                if (comboClientes.Text.Equals(venta.nombre_cliente))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(venta.fecha.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(17, 2)));
                    if (!venta.fecha_entrega.Equals(""))
                    {
                        DateTime fechaEntr = new DateTime(Convert.ToInt32(venta.fecha_entrega.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(17, 2)));
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, fechaEntr, venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                    else
                    {
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, "", venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                }
            }
            dataGridVentas.Sort(dataGridVentas.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                if (dateFecha.Value.ToString("dd/MM/yyyy").Equals(venta.fecha.Substring(0,10)))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(venta.fecha.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(17, 2)));
                    if (!venta.fecha_entrega.Equals(""))
                    {
                        DateTime fechaEntr = new DateTime(Convert.ToInt32(venta.fecha_entrega.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(17, 2)));
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, fechaEntr, venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                    else
                    {
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, "", venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                }
            }
            dataGridVentas.Sort(dataGridVentas.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }

        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                if (comboEstado.Text.Equals(venta.estado))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(venta.fecha.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(17, 2)));
                    if (!venta.fecha_entrega.Equals(""))
                    {
                        DateTime fechaEntr = new DateTime(Convert.ToInt32(venta.fecha_entrega.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(17, 2)));
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, fechaEntr, venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                    else
                    {
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, "", venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                }
            }
            dataGridVentas.Sort(dataGridVentas.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }

        private void comboSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                if (comboSucursal.Text.Equals(venta.nombre_sucursal))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(venta.fecha.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(17, 2)));
                    if (!venta.fecha_entrega.Equals(""))
                    {
                        DateTime fechaEntr = new DateTime(Convert.ToInt32(venta.fecha_entrega.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(17, 2)));
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, fechaEntr, venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                    else
                    {
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, "", venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                }
            }
            dataGridVentas.Sort(dataGridVentas.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }

        private void comboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                if (comboUsuarios.Text.Equals(venta.nombre_empleado))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(venta.fecha.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(17, 2)));
                    if (!venta.fecha_entrega.Equals(""))
                    {
                        DateTime fechaEntr = new DateTime(Convert.ToInt32(venta.fecha_entrega.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(17, 2)));
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, fechaEntr, venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                    else
                    {
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, "", venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                }
            }
            dataGridVentas.Sort(dataGridVentas.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }

        private void dateFechaEntrega_ValueChanged(object sender, EventArgs e)
        {
            dataGridVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                if (dateFechaEntrega.Value.ToString("dd/MM/yyyy").Equals(venta.fecha_entrega.Substring(0, 10)))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(venta.fecha.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha.ToString().Substring(17, 2)));
                    if (!venta.fecha_entrega.Equals(""))
                    {
                        DateTime fechaEntr = new DateTime(Convert.ToInt32(venta.fecha_entrega.ToString().Substring(6, 4)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(3, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(0, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(11, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(14, 2)), Convert.ToInt32(venta.fecha_entrega.ToString().Substring(17, 2)));
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, fechaEntr, venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                    else
                    {
                        dataGridVentas.Rows.Add(venta.key, venta.id, fecha, "", venta.nombre_sucursal, venta.tipo_pago, venta.total, venta.ganancia, venta.estado, venta.nombre_empleado, venta.nombre_cliente, venta.observacion);
                    }
                }
            }
            dataGridVentas.Sort(dataGridVentas.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }
    }
}
