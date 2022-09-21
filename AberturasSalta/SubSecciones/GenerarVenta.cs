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
    public partial class GenerarVenta : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Usuario usuario;
        Venta venta;
        List<Producto> productos = new List<Producto>();
        List<Pago> detallePago = new List<Pago>();
        List<Producto> detalleVenta = new List<Producto>();
        List<Cliente> clientes = new List<Cliente>();
        List<Usuario> usuarios = new List<Usuario>();
        List<FormaPago> formasPagos = new List<FormaPago>();
        List<Contraseña> contraseñas = new List<Contraseña>();


        private int total = 0;
        private int cost = 0;
        private int pago = 0;
        private int saldo = 0;
        private int ganancia = 0;

        private Boolean band = false;

        public GenerarVenta(Usuario user,Venta ven)
        {
            InitializeComponent();
            usuario = user;
            venta = ven;
        }

        private void GenerarVenta_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }


















        private void dataGridStock_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridStock.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    foreach (var producto in productos)
                    {
                        if (producto.id.Equals(dataGridStock.Rows[e.RowIndex].Cells[0].Value.ToString()))
                        {
                            if (comboTipoPagoVenta.Text.Equals("Efectivo"))
                            {
                                dataGridPorductosAgregados.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.efectivo);
                            }
                            else if (comboTipoPagoVenta.Text.Equals("Lista"))
                            {
                                dataGridPorductosAgregados.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista);
                            }
                            calcular();
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void dataGridPorductosAgregados_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridPorductosAgregados.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Producto  " + dataGridPorductosAgregados.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridPorductosAgregados.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridPorductosAgregados.Rows.RemoveAt(e.RowIndex);
                        calcular();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void buttonAgregarFormaPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboFormaPago.Text.Equals("descuento"))
                {
                    Boolean band = false;
                    foreach (var contraseña in contraseñas)
                    {
                        if (textContraseña.Text.Equals(contraseña.contraseña))
                        {
                            band = true;
                            break;
                        }
                    }
                    if (band && !comboFormaPago.Text.Equals("") && !textMonto.Text.Equals("") && !comboSucursalFormaPago.Text.Equals(""))
                    {
                        dataGridPagos.Rows.Add(dateFechaPago.Value.ToString("dd/MM/yyyy"), comboFormaPago.Text, textMonto.Text, comboSucursalFormaPago.Text, textComentario.Text);
                        calcular();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Errónea / Complete Campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (!comboFormaPago.Text.Equals("") && !textMonto.Text.Equals("") && !comboSucursalFormaPago.Text.Equals(""))
                {
                    dataGridPagos.Rows.Add(dateFechaPago.Value.ToString("dd/MM/yyyy"),comboFormaPago.Text,textMonto.Text,comboSucursalFormaPago.Text,textComentario.Text);
                    calcular();
                }
                else
                {
                    MessageBox.Show("Rellene Campos de Pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception es)
            {

            }
        }

        private void dataGridPagos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridPagos.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Pago  " + dataGridPagos.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridPagos.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridPagos.Rows.RemoveAt(e.RowIndex);
                        calcular();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            foreach (var producto in productos)
            {
                dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
            }
        }

        private void textDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private async void buttonEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Se descontará el stock de sucursal: "+comboSucursalVenta.Text+ " Desea Continuar?", "Advertencia", MessageBoxButtons.YesNoCancel);
                if (resultado == DialogResult.Yes)
                {
                    buttonEntrega.Enabled = false;
                    buttonEntrega.Text = "Espere porfavor...";
                    comboEstadoVenta.Text = "Concretada";
                    band = true;
                    List<Producto> productosAgregados = new List<Producto>();
                    foreach (DataGridViewRow row in dataGridPorductosAgregados.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            Producto producto = new Producto();
                            producto.foranea = venta.id;
                            producto.fecha = venta.fecha;
                            producto.id = row.Cells[0].Value.ToString();
                            producto.tipo = row.Cells[1].Value.ToString();
                            producto.descripcion = row.Cells[2].Value.ToString();
                            producto.madera = row.Cells[3].Value.ToString();
                            producto.abiertoCerrado = row.Cells[4].Value.ToString();
                            producto.costo = row.Cells[5].Value.ToString();
                            producto.precio = row.Cells[6].Value.ToString();
                            producto.cantidad = "1";
                            productosAgregados.Add(producto);
                        }
                    }
                    //await firebaseHelper.stockProducto(productosAgregados, -1, comboSucursalVenta.Text);
                    //await firebaseHelper.stockProducto(productosAgregados, -1, "gral");
                    firebaseHelper.stockProducto(productosAgregados, -1, "gral"+comboSucursalVenta.Text);
                    
                    buttonEntrega.Enabled = false;
                    buttonEntrega.Text = "Espere porfavor...";
                    generarVenta();
                    MessageBox.Show("Entrega de Productos Generada. Stock Actualizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception es)
            {

            }
        }
        private void buttonGenerarVenta_Click(object sender, EventArgs e)
        {
            if (comboEstadoVenta.Text.Equals("A Fabricar"))
            {
                if (!textObservacion.Text.Equals("") && dataGridPagos.Rows.Count > 1)
                {
                    generarVenta();
                }
                else
                {
                    MessageBox.Show("Ingrese Descripcion de abertura en Observación / Pagos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                generarVenta();
            }
            
        }
        private void comboNombreCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var cliente in clientes)
            {
                if (cliente.nombre.Equals(comboNombreCliente.Text))
                {
                    textDNI.Text = cliente.dnicuit;
                    textNombreCliente.Text = cliente.nombre;
                    textEmailCliente.Text = cliente.email;
                    textTelefonoCliente.Text = cliente.telefono;
                }
            }
        }


















        private async void generarVenta()
        {
            try
            {
                if (!textNombreCliente.Text.Equals("") && !comboSucursalVenta.Text.Equals("") && !comboUsuario.Text.Equals(""))
                {
                    buttonGenerarVenta.Text = "Espere porfavor...";
                    buttonGenerarVenta.Enabled = false;
                    venta.fecha = dateFechaVenta.Value.ToString("dd/MM/yyyy HH:mm:ss");
                    
                    venta.nombre_empleado = comboUsuario.Text;
                    venta.nombre_sucursal = comboSucursalVenta.Text;
                    venta.nombre_cliente = textNombreCliente.Text;
                    venta.observacion = textObservacion.Text;
                    venta.tipo_pago = comboTipoPagoVenta.Text;

                    venta.estado = comboEstadoVenta.Text;
                    venta.total = total.ToString();
                    venta.ganancia = ganancia.ToString();
                    if (venta.id != null)
                    {
                        foreach (DataGridViewRow row in dataGridPagos.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                await firebaseHelper.deleteDetallePago(venta.id);
                            }
                        }
                        foreach (DataGridViewRow row in dataGridPorductosAgregados.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                await firebaseHelper.deleteDetalleVenta(venta.id);
                            }
                        }
                    }
                    else
                    {
                        venta.id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    }
                    if (band)
                    {
                        venta.fecha_entrega = dateFechaEntrega.Value.ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    else
                    {
                        venta.fecha_entrega = "";
                    }
                    List<Pago> pagos = new List<Pago>();
                    List<Producto> productosAgregados = new List<Producto>();
                    foreach (DataGridViewRow row in dataGridPagos.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            Pago pago = new Pago();
                            pago.id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                            pago.foranea = venta.id;
                            pago.fecha = row.Cells[0].Value.ToString();
                            pago.nombre = row.Cells[1].Value.ToString();
                            pago.monto = row.Cells[2].Value.ToString();
                            pago.sucursal = row.Cells[3].Value.ToString();
                            pago.comentario = row.Cells[4].Value.ToString();
                            pagos.Add(pago);
                        }
                    }
                    foreach (DataGridViewRow row in dataGridPorductosAgregados.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            Producto producto = new Producto();
                            producto.foranea = venta.id;
                            producto.fecha = venta.fecha;
                            producto.id = row.Cells[0].Value.ToString();
                            producto.tipo = row.Cells[1].Value.ToString();
                            producto.descripcion = row.Cells[2].Value.ToString();
                            producto.madera = row.Cells[3].Value.ToString();
                            producto.abiertoCerrado = row.Cells[4].Value.ToString();
                            producto.costo = row.Cells[5].Value.ToString();
                            producto.precio = row.Cells[6].Value.ToString();
                            producto.cantidad = "1";
                            productosAgregados.Add(producto);
                        }
                    }
                    Cliente cliente = new Cliente();
                    cliente.dnicuit = textDNI.Text;
                    cliente.nombre = textNombreCliente.Text;
                    cliente.telefono = textTelefonoCliente.Text;
                    cliente.email = textEmailCliente.Text;

                    firebaseHelper.addCliente(cliente);
                    firebaseHelper.addDetallePago(pagos);
                    firebaseHelper.addDetalleVenta(productosAgregados);
                    firebaseHelper.addVenta(venta);
                    buttonGenerarVenta.Text = "Generar Venta";
                    buttonGenerarVenta.Enabled = true;
                    MessageBox.Show("Venta Generada con Éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Inserte Datos del Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception es)
            {

            }
        }
        private async void cargarDatos()
        {
            try
            {
                productos = await firebaseHelper.getAllProductos();
                detallePago = await firebaseHelper.getAllDetallePagos();
                detalleVenta = await firebaseHelper.getAllDetalleVenta();
                usuarios = await firebaseHelper.getAllUsuario();
                clientes = await firebaseHelper.getAllClientes();
                formasPagos = await firebaseHelper.getAllFormaPago();
                contraseñas = await firebaseHelper.getAllContraseña();
                dataGridStock.Rows.Clear();
                foreach (var producto in productos)
                {
                    dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
                }
                foreach (var user in usuarios)
                {
                    comboUsuario.Items.Add(user.apellido+" "+user.nombre);
                }
                foreach (var cliente in clientes)
                {
                    comboNombreCliente.Items.Add(cliente.nombre);
                }
                foreach (var forma in formasPagos)
                {
                    comboFormaPago.Items.Add(forma.nombre);
                }
                cargarVenta();
               
            }
            catch (Exception es)
            {

            }
        }
        private void cargarVenta()
        {
            if (venta.id != null)
            {
                comboUsuario.Text = venta.nombre_empleado;
                comboSucursalVenta.Text = venta.nombre_sucursal;
                textObservacion.Text = venta.observacion;
                comboEstadoVenta.Text = venta.estado;
                dateFechaVenta.Value = Convert.ToDateTime(venta.fecha);
                if (!venta.fecha_entrega.Equals(""))
                {
                    dateFechaEntrega.Value = Convert.ToDateTime(venta.fecha_entrega);
                }
                comboTipoPagoVenta.Text = venta.tipo_pago;
                textNombreCliente.Text = venta.nombre_cliente;
                foreach (var pago in detallePago)
                {
                    if (pago.foranea.Equals(venta.id))
                    {
                        dataGridPagos.Rows.Add(pago.fecha, pago.nombre, pago.monto, pago.sucursal, pago.comentario);
                    }
                }
                foreach (var producto in detalleVenta)
                {
                    if (producto.foranea.Equals(venta.id))
                    {
                        dataGridPorductosAgregados.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.precio);
                    }
                }
                calcular();
            }
            else
            {
                comboUsuario.Text = usuario.apellido + " " + usuario.nombre;
                
                if (!usuario.sucursal.Equals("-"))
                {
                    comboSucursalVenta.Text = usuario.sucursal;
                    comboSucursalFormaPago.Text = usuario.sucursal;
                }
                comboEstadoVenta.Text = "Pendiente";
                comboTipoPagoVenta.Text = "Lista";
                buttonEntrega.Enabled = false;
                calcular();
            }
        }

        private void calcular()
        {
            try
            {
                total = 0;
                cost = 0;
                pago = 0;
                saldo = 0;
                ganancia = 0;
                foreach (DataGridViewRow row in dataGridPorductosAgregados.Rows)
                {
                    if (row.Cells[0].Value!=null)
                    {
                        total += Int32.Parse( row.Cells[5].Value.ToString());
                        cost += Int32.Parse( row.Cells[4].Value.ToString());
                    }
                }
                foreach (DataGridViewRow row in dataGridPagos.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        pago += Int32.Parse(row.Cells[2].Value.ToString());
                    }
                }
                textTotal.Text = "Total: $" + total.ToString();
                saldo = pago - total;
                textSaldo.Text = "Saldo: $" + saldo.ToString();
                ganancia = total - cost;
                if (saldo>=0)
                {
                    comboEstadoVenta.Text = "Pagada Pendiente Retiro";
                    buttonEntrega.Enabled = true;
                }
                else
                {
                    comboEstadoVenta.Text = "Pendiente Pago";
                    buttonEntrega.Enabled = false;
                }
                if (dataGridPorductosAgregados.Rows.Count <= 1)
                {
                    comboEstadoVenta.Text = "A Fabricar";
                    buttonEntrega.Enabled = false;
                }
            }
            catch(Exception es)
            {

            }
        }




















        private void comboFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                if (comboFiltroTipo.Text.Equals(producto.tipo))
                {
                    dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
                }
            }
        }

        private void comboFiltroTipoMadera_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                if (comboFiltroTipoMadera.Text.Equals(producto.madera))
                {
                    dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
                }
            }
        }

        private void comboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFormaPago.Text.Equals("descuento"))
            {
                textContraseña.Visible = true;
                textLabelContraseña.Visible = true;
            }
            else
            {
                textContraseña.Visible = false;
                textLabelContraseña.Visible = false;
            }
        }
        private void comboFiltroAbCerrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                if (comboFiltroAbCerrada.Text.Equals(producto.abiertoCerrado))
                {
                    dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
                }
            }
        }



































        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                dataGridStock.Rows.Clear();
                foreach (var producto in productos)
                {
                    if (textCodigo.Text.Equals(producto.id))
                    {
                        DateTime fecha = new DateTime(Convert.ToInt32(producto.fecha.ToString().Substring(6, 4)), Convert.ToInt32(producto.fecha.ToString().Substring(3, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(0, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(11, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(14, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(17, 2)));
                        dataGridStock.Rows.Add(producto.key, producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, fecha);
                    }
                }
                textCodigo.Text = "";
                this.ActiveControl = textCodigo;
            }
        }

        private void textFiltroDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    dataGridStock.Rows.Clear();
                    foreach (var producto in productos)
                    {
                        if (textFiltroDescripcion.Text.Equals(producto.descripcion))
                        {
                            DateTime fecha = new DateTime(Convert.ToInt32(producto.fecha.ToString().Substring(6, 4)), Convert.ToInt32(producto.fecha.ToString().Substring(3, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(0, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(11, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(14, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(17, 2)));
                            dataGridStock.Rows.Add(producto.key, producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, fecha);
                        }
                    }
                }
            }
            catch (Exception s)
            {

            }
        }


    }
}
