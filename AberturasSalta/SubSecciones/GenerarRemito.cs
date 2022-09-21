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
    public partial class GenerarRemito : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Usuario usuario;
        Remito remito;
        List<Producto> productos = new List<Producto>();
        List<Producto> detalleRemito = new List<Producto>();
        List<Usuario> usuarios = new List<Usuario>();

        string idSeleccionado = "0";
        public GenerarRemito(Usuario user,Remito rem)
        {
            InitializeComponent();
            usuario = user;
            remito = rem;
        }

        private void GenerarRemito_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }














        private async void buttonGenerarRemito_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridProductoRemito.Rows.Count > 1)
                {
                    buttonGenerarRemito.Text = "Espere porfavor...";
                    buttonGenerarRemito.Enabled = false;
                    remito = new Remito();
                    remito.id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    remito.fecha = dateFechaRemito.Value.ToString("dd/MM/yyyy HH:mm:ss");
                    remito.usuario = comboUsuario.Text;
                    remito.observacion = textObservacion.Text;
                    remito.tipo = comboTipoRemito.Text;
                    remito.desde = comboDesde.Text;
                    remito.destino = comboDestino.Text;
                    List<Producto> productosAgregados = new List<Producto>();
                    foreach (DataGridViewRow row in dataGridProductoRemito.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            Producto producto = new Producto();
                            producto.foranea = remito.id;
                            producto.fecha = remito.fecha;
                            producto.id = row.Cells[0].Value.ToString();
                            producto.tipo = row.Cells[1].Value.ToString();
                            producto.descripcion = row.Cells[2].Value.ToString();
                            producto.madera = row.Cells[3].Value.ToString();
                            producto.abiertoCerrado = row.Cells[4].Value.ToString();
                            producto.costo = row.Cells[5].Value.ToString();
                            producto.lista = row.Cells[6].Value.ToString();
                            producto.efectivo = row.Cells[7].Value.ToString();
                            producto.cantidad = row.Cells[8].Value.ToString();
                            productosAgregados.Add(producto);
                        }
                    }
                    if (!comboTipoRemito.Text.Equals("Salida") && !comboTipoRemito.Text.Equals("Traspaso"))
                    {
                        
                        firebaseHelper.stockProducto(productosAgregados, 1, "graldep");
                        //await firebaseHelper.stockProducto(productosAgregados, 1, "gral"); cambio
                        firebaseHelper.addDetalleRemito(productosAgregados);
                        firebaseHelper.addRemito(remito);
                        buttonGenerarRemito.Text = "Generar Remito";
                        buttonGenerarRemito.Enabled = true;
                        MessageBox.Show("Remito Generado con Éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (comboTipoRemito.Text.Equals("Salida"))
                    {
                        if (!comboDestino.Text.Equals(""))
                        {
                            //await firebaseHelper.stockProducto(productosAgregados, -1, "dep"); cambio
                            firebaseHelper.stockProducto(productosAgregados, 1, "dep"+comboDestino.Text);
                            firebaseHelper.addDetalleRemito(productosAgregados);
                            firebaseHelper.addRemito(remito);
                            buttonGenerarRemito.Text = "Generar Remito";
                            buttonGenerarRemito.Enabled = true;
                            MessageBox.Show("Remito Generado con Éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            buttonGenerarRemito.Text = "Generar Remito";
                            buttonGenerarRemito.Enabled = true;
                            MessageBox.Show("Seleccione Destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (comboTipoRemito.Text.Equals("Traspaso"))
                    {
                        if (!comboDestino.Text.Equals("") && !comboDesde.Text.Equals(""))
                        {
                            await firebaseHelper.stockProducto(productosAgregados, -1, comboDesde.Text);
                            await firebaseHelper.stockProducto(productosAgregados, 1, comboDestino.Text);
                            firebaseHelper.addDetalleRemito(productosAgregados);
                            firebaseHelper.addRemito(remito);
                            buttonGenerarRemito.Text = "Generar Remito";
                            buttonGenerarRemito.Enabled = true;
                            MessageBox.Show("Remito Generado con Éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            buttonGenerarRemito.Text = "Generar Remito";
                            buttonGenerarRemito.Enabled = true;
                            MessageBox.Show("Seleccione Desde y Destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Inserte Productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception es)
            {

            }
        }

        private void dataGridStock_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridStock.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    idSeleccionado = dataGridStock.Rows[e.RowIndex].Cells[0].Value.ToString();
                    this.ActiveControl = textCant;
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
            }
        }

        private void dataGridProductoRemito_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridProductoRemito.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    DialogResult resultado = MessageBox.Show("Desea Eliminar Producto  " + dataGridProductoRemito.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridProductoRemito.Rows[e.RowIndex].Cells[2].Value.ToString(), "Advertencia", MessageBoxButtons.YesNoCancel);
                    if (resultado == DialogResult.Yes)
                    {
                        dataGridProductoRemito.Rows.RemoveAt(e.RowIndex);
                        calcular();
                    }
                }
            }
            catch(Exception es)
            {

            }
        }













        private async void cargarDatos()
        {
            try
            {
                productos = await firebaseHelper.getAllProductos();
                detalleRemito = await firebaseHelper.getAllDetalleRemitos();
                usuarios = await firebaseHelper.getAllUsuario();
                dataGridStock.Rows.Clear();
                foreach (var producto in productos)
                {
                    dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
                }
                foreach (var user in usuarios)
                {
                    comboUsuario.Items.Add(user.apellido + " " + user.nombre);
                }
                cargarRemito();
            }
            catch (Exception es)
            {

            }
        }

        private void cargarRemito()
        {
            if (remito.id != null)
            {
                comboUsuario.Text = remito.usuario;
                textObservacion.Text = remito.observacion;
                comboTipoRemito.Text = remito.tipo;
                //dateFechaRemito.Value = Convert.ToDateTime(remito.fecha);
                comboDesde.Text = remito.desde;
                comboDestino.Text = remito.destino;

                foreach (var producto in detalleRemito)
                {
                    if (producto.foranea.Equals(remito.id))
                    {
                        dataGridProductoRemito.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista,producto.efectivo,producto.cantidad);
                    }
                }
                calcular();
            }
            else
            {
                comboUsuario.Text = usuario.apellido + " " + usuario.nombre;
                comboTipoRemito.Text = "Entrada";
            }
        }

        private void calcular()
        {
            try
            {
                int cant = 0;
                foreach (DataGridViewRow row in dataGridProductoRemito.Rows)
                {
                    if (row.Cells[8].Value !=null)
                    {
                        cant = cant + Int32.Parse(row.Cells[8].Value.ToString());
                    }
                }
                textCantidad.Text = "Cantidad: " + cant.ToString();
            }
            catch (Exception es)
            {

            }
        }

        private void comboTipoRemito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoRemito.Text.Equals("Entrada"))
            {
                comboDesde.Enabled = false;
                comboDestino.Enabled = false;
            }
            else if (comboTipoRemito.Text.Equals("Salida"))
            {
                comboDesde.Enabled = false;
                comboDestino.Enabled = true;
            }
            else if (comboTipoRemito.Text.Equals("Traspaso"))
            {
                comboDesde.Enabled = true;
                comboDestino.Enabled = true;
            }
        }















        private void comboFiltroTipoMadera_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                if (comboFiltroTipoMadera.Text.Equals(producto.madera))
                {
                    dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
                }
            }
        }

        private void comboFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                if (comboFiltroTipo.Text.Equals(producto.tipo))
                {
                    dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
                }
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
                            dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
                        }
                    }
                }
            }
            catch (Exception s)
            {

            }
        }
        private void comboFiltroAbCerrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                if (comboFiltroAbCerrada.Text.Equals(producto.abiertoCerrado))
                {
                    dataGridStock.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, producto.fecha);
                }
            }
        }
        private void textCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!textCant.Text.Equals("0") || !textCant.Text.Equals(""))
                {
                    this.ActiveControl = dataGridStock;
                    foreach (var producto in productos)
                    {
                        if (producto.id.Equals(idSeleccionado))
                        {
                            dataGridProductoRemito.Rows.Add(producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, textCant.Text);
                            calcular();
                            break;
                        }
                    }
                    textCant.Text = "";
                }
                else
                {
                    MessageBox.Show("Inserte un valor Diferente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textCant_MouseDown(object sender, MouseEventArgs e)
        {
            textCant.Text = "";
        }

       
    }
}
