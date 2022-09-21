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

namespace AberturasSalta.Secciones
{
    public partial class FormArqueoCaja : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<Pago> pagos = new List<Pago>();
        List<FormaPago> formaPagos = new List<FormaPago>();
        List<ArqueoCaja> arqueos = new List<ArqueoCaja>();
        List<Usuario> usuarios = new List<Usuario>();
        Usuario usuario;

        private int gast = 0;
        private int efectiv = 0;
        private int debit = 0;
        private int credit = 0;
        private int transferenci = 0;
        private int tota = 0;
        private int restant = 0;
        private int descuent = 0;

        public FormArqueoCaja(Usuario user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void FormArqueoCaja_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }



















        private void dateFechaCierre_ValueChanged(object sender, EventArgs e)
        {
            calcular();
        }
        private async void buttonAgregarActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!comboSucursalCierre.Text.Equals("-") && !comboSucursalCierre.Text.Equals("") && !textExtraccion.Text.Equals(""))
                {
                    buttonAgregarActualizar.Enabled = false;
                    buttonAgregarActualizar.Text = "Espere...";
                    ArqueoCaja arqueoCaja = new ArqueoCaja();
                    arqueoCaja.id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    arqueoCaja.fecha = dateFechaCierre.Value.ToString("dd/MM/yyyy HH:mm:ss");
                    arqueoCaja.sucursal = comboSucursalCierre.Text;
                    arqueoCaja.empleado = comboUsuario.Text;
                    arqueoCaja.efectivo_Extraccion = textExtraccion.Text;
                    arqueoCaja.efectivo_Restante = restant.ToString();
                    arqueoCaja.gasto_diario = gast.ToString();
                    arqueoCaja.efectivo = efectiv.ToString();
                    arqueoCaja.debito = debit.ToString();
                    arqueoCaja.credito = credit.ToString();
                    arqueoCaja.transferencia = transferenci.ToString();
                    arqueoCaja.total = tota.ToString();
                    arqueoCaja.descuento = descuent.ToString();
                    arqueoCaja.comentario = textComentario.Text;
                    await firebaseHelper.addArqueo(arqueoCaja);
                    MessageBox.Show("Caja Cerrada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    buttonAgregarActualizar.Enabled = true;
                    buttonAgregarActualizar.Text = "Cerrar Caja";
                }
                else
                {
                    MessageBox.Show("Complete Campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception es)
            {

            }
        }
        private void buttonTodos_Click(object sender, EventArgs e)
        {
            dataGridArqueos.Rows.Clear();
            foreach (var arqueo in arqueos)
            {
                DateTime fecha = new DateTime(Convert.ToInt32(arqueo.fecha.ToString().Substring(6, 4)), Convert.ToInt32(arqueo.fecha.ToString().Substring(3, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(0, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(11, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(14, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(17, 2)));
                dataGridArqueos.Rows.Add(arqueo.key, arqueo.id, fecha, arqueo.sucursal, arqueo.empleado, arqueo.efectivo_Extraccion, arqueo.efectivo_Restante, arqueo.gasto_diario, arqueo.efectivo, arqueo.debito, arqueo.credito, arqueo.transferencia, arqueo.descuento, arqueo.total, arqueo.comentario);
            }
            dataGridArqueos.Sort(dataGridArqueos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
        }























        private async void cargarDatos()
        {
            try
            {
                comboUsuario.Text = usuario.apellido + " " + usuario.nombre;
                if (!usuario.sucursal.Equals("-"))
                {
                    comboSucursalCierre.Text = usuario.sucursal;
                }
                pagos = await firebaseHelper.getAllDetallePagos();
                formaPagos = await firebaseHelper.getAllFormaPago();
                arqueos = await firebaseHelper.getAllArqueo();
                usuarios = await firebaseHelper.getAllUsuario();
                dataGridArqueos.Rows.Clear();
                foreach (var arqueo in arqueos)
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(arqueo.fecha.ToString().Substring(6, 4)), Convert.ToInt32(arqueo.fecha.ToString().Substring(3, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(0, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(11, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(14, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(17, 2)));
                    dataGridArqueos.Rows.Add(arqueo.key,arqueo.id, fecha, arqueo.sucursal, arqueo.empleado,arqueo.efectivo_Extraccion,arqueo.efectivo_Restante,arqueo.gasto_diario,arqueo.efectivo,arqueo.debito,arqueo.credito,arqueo.transferencia,arqueo.descuento, arqueo.total, arqueo.comentario);
                }
                foreach (var user in usuarios)
                {
                    comboUsuario.Items.Add(user.apellido + " " + user.nombre);
                    comboFiltroUsuarios.Items.Add(user.apellido + " " + user.nombre);
                }
                dataGridArqueos.Sort(dataGridArqueos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
                calcular();
                
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void calcular()
        {
            gast = 0;
            efectiv = 0;
            debit = 0;
            credit = 0;
            transferenci = 0;
            tota = 0;
            foreach (var pago in pagos)
            {
                foreach (var forma in formaPagos)
                {
                    if (pago.sucursal.Equals(comboSucursalCierre.Text) && pago.nombre.Equals(forma.nombre) && pago.fecha.Substring(0,10).Equals(dateFechaCierre.Value.ToString("dd/MM/yyyy")))
                    {
                        switch (forma.tipo)
                        {
                            case "gasto":
                                gast += Int32.Parse(pago.monto);
                                break;
                            case "efectivo":
                                efectiv += Int32.Parse(pago.monto);
                                break;
                            case "debito":
                                debit += Int32.Parse(pago.monto);
                                break;
                            case "credito":
                                credit += Int32.Parse(pago.monto);
                                break;
                            case "transferencia":
                                transferenci += Int32.Parse(pago.monto);
                                break;
                            case "descuento":
                                descuent += Int32.Parse(pago.monto);
                                break;
                        }
                        if (forma.tipo.Equals("descuento"))
                        {
                           
                        }
                        else if (forma.tipo.Equals("gasto"))
                        {

                        }
                        else
                        {
                            tota += Int32.Parse(pago.monto);
                        }
                        break;
                    }
                }
            }
            tota = tota - descuent - gast;
            textGasto.Text = "Gasto: $" + gast.ToString();
            textEfectivo.Text = "Efectivo: $" + efectiv.ToString();
            textDebito.Text = "Debito: $" + debit.ToString();
            textCredito.Text = "Credito: $" + credit.ToString();
            textTransferencia.Text = "Transferencia: $" + transferenci.ToString();
            textTotal.Text = "Total: $" + tota.ToString();
        }
        private void textExtraccion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                restant = efectiv-gast- Int32.Parse(textExtraccion.Text);
                textRestante.Text = "Restante: " + restant;
            }
            catch (Exception)
            {
            }
            
        }
        private void textExtraccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


































        private void comboFiltroUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridArqueos.Rows.Clear();
            foreach (var arqueo in arqueos)
            {
                if (arqueo.empleado.Equals(comboFiltroUsuarios.Text))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(arqueo.fecha.ToString().Substring(6, 4)), Convert.ToInt32(arqueo.fecha.ToString().Substring(3, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(0, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(11, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(14, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(17, 2)));
                    dataGridArqueos.Rows.Add(arqueo.key, arqueo.id, fecha, arqueo.sucursal, arqueo.empleado, arqueo.efectivo_Extraccion, arqueo.efectivo_Restante, arqueo.gasto_diario, arqueo.efectivo, arqueo.debito, arqueo.credito, arqueo.transferencia, arqueo.descuento, arqueo.total, arqueo.comentario);
                }
                dataGridArqueos.Sort(dataGridArqueos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void comboFiltroSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridArqueos.Rows.Clear();
            foreach (var arqueo in arqueos)
            {
                if (arqueo.sucursal.Equals(comboFiltroSucursal.Text))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(arqueo.fecha.ToString().Substring(6, 4)), Convert.ToInt32(arqueo.fecha.ToString().Substring(3, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(0, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(11, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(14, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(17, 2)));
                    dataGridArqueos.Rows.Add(arqueo.key, arqueo.id, fecha, arqueo.sucursal, arqueo.empleado, arqueo.efectivo_Extraccion, arqueo.efectivo_Restante, arqueo.gasto_diario, arqueo.efectivo, arqueo.debito, arqueo.credito, arqueo.transferencia, arqueo.descuento, arqueo.total, arqueo.comentario);
                }
                dataGridArqueos.Sort(dataGridArqueos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            dataGridArqueos.Rows.Clear();
            foreach (var arqueo in arqueos)
            {
                if (arqueo.fecha.Substring(0,10).Equals(dateFechaEntrega.Value.ToString("dd/MM/yyyy")))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(arqueo.fecha.ToString().Substring(6, 4)), Convert.ToInt32(arqueo.fecha.ToString().Substring(3, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(0, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(11, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(14, 2)), Convert.ToInt32(arqueo.fecha.ToString().Substring(17, 2)));
                    dataGridArqueos.Rows.Add(arqueo.key, arqueo.id, fecha, arqueo.sucursal,arqueo.empleado, arqueo.efectivo_Extraccion, arqueo.efectivo_Restante, arqueo.gasto_diario, arqueo.efectivo, arqueo.debito, arqueo.credito, arqueo.transferencia, arqueo.descuento, arqueo.total, arqueo.comentario);
                }
                dataGridArqueos.Sort(dataGridArqueos.Columns[2], System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void comboSucursalCierre_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcular();
        }
    }
}
