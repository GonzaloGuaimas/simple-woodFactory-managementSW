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
    public partial class FormConfiguracion : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<FormaPago> formasPagos = new List<FormaPago>();
        List<Usuario> usuarios = new List<Usuario>();
        List<Contraseña> contraseñas = new List<Contraseña>();
        private FormaPago formaPagoSeleccionada;
        Usuario usuari;
        public FormConfiguracion(Usuario user)
        {
            InitializeComponent();
            usuari = user;
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }





















        private void dataGridFormasPagos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridFormasPagos.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    formaPagoSeleccionada.key = dataGridFormasPagos.Rows[e.RowIndex].Cells[0].Value.ToString();
                    formaPagoSeleccionada.id = dataGridFormasPagos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    formaPagoSeleccionada.nombre = dataGridFormasPagos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    formaPagoSeleccionada.tipo = dataGridFormasPagos.Rows[e.RowIndex].Cells[3].Value.ToString();
                    formaPagoSeleccionada.comision = dataGridFormasPagos.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
                buttonAgregarFormaPago.Text = "Actualizar";
            }
            catch (Exception)
            {
            }
        }

        private async void buttonAgregarFormaPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (!comboTipoPago.Text.Equals("") && !textNombrePago.Text.Equals("") && !textComision.Text.Equals(""))
                {
                    
                    FormaPago formaPago = new FormaPago();
                    if (buttonAgregarFormaPago.Text.Equals("Agregar"))
                    {
                        formaPago.id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    }
                    else
                    {
                        formaPago.id = formaPagoSeleccionada.id;
                    }
                    buttonAgregarFormaPago.Text = "Espere...";
                    buttonAgregarFormaPago.Enabled = false;
                    formaPago.nombre = textNombrePago.Text;
                    formaPago.comision = textComision.Text;
                    formaPago.tipo = comboTipoPago.Text;
                    await firebaseHelper.addFormaPago(formaPago);
                    if (buttonAgregarFormaPago.Text.Equals("Agregar"))
                        MessageBox.Show("Forma de Pago Agregada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Forma de Pago Actualizada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cargarDatos();
                    buttonAgregarFormaPago.Enabled = true;
                    buttonAgregarFormaPago.Text = "Agregar";
                }
                else
                {
                    MessageBox.Show("Rellene Campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
            }
        }
        private async void buttonAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textDNI.Text.Equals("") && !textNombre.Text.Equals("") && !textApellido.Text.Equals("") && !comboRol.Text.Equals("") && !comboSucursal.Text.Equals("") && !textContraseña.Text.Equals("") && !textMail.Text.Equals(""))
                {
                    buttonAgregarUsuario.Enabled = false;
                    buttonAgregarUsuario.Text = "Espere...";
                    Usuario usuario = new Usuario();
                    usuario.dni = textDNI.Text;
                    usuario.nombre = textNombre.Text;
                    usuario.apellido = textApellido.Text;
                    usuario.rol = comboRol.Text;
                    usuario.sucursal = comboSucursal.Text;
                    usuario.contraseña = textComision.Text;
                    usuario.mail = textMail.Text;
                    await firebaseHelper.addUsuario(usuario);
                    MessageBox.Show("Usuario Generado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    buttonAgregarUsuario.Enabled = true;
                    buttonAgregarUsuario.Text = "Agregar";
                }
                else
                {
                    MessageBox.Show("Inserte Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
            }
        }

        private async void buttonAgregarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textContraseñaG.Text.Equals(""))
                {
                    buttonAgregarContraseña.Enabled = false;
                    buttonAgregarContraseña.Text = "Espere...";
                    Contraseña contraseña = new Contraseña();
                    contraseña.id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    contraseña.fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    contraseña.contraseña = textContraseñaG.Text;
                    contraseña.usuario = usuari.apellido + " " + usuari.nombre;
                    await firebaseHelper.addContraseña(contraseña);

                    MessageBox.Show("Contraseña Generada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                    buttonAgregarContraseña.Enabled = true;
                    buttonAgregarContraseña.Text = "Agregar";
                }
                else
                {
                    MessageBox.Show("Inserte Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
            }
        }

        private void dataGridUsuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridContraseñas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

























        private async void cargarDatos()
        {
            try
            {
                dataGridContraseñas.Rows.Clear();
                dataGridUsuarios.Rows.Clear();
                dataGridFormasPagos.Rows.Clear();
                formasPagos = await firebaseHelper.getAllFormaPago();
                contraseñas = await firebaseHelper.getAllContraseña();
                usuarios = await firebaseHelper.getAllUsuario();
                foreach (var forma in formasPagos)
                {
                    dataGridFormasPagos.Rows.Add(forma.key,forma.id,forma.nombre,forma.tipo,forma.comision);
                }
                foreach (var contraseña in contraseñas)
                {
                    dataGridContraseñas.Rows.Add(contraseña.key, contraseña.id, contraseña.fecha, contraseña.contraseña, contraseña.usuario);
                }
                foreach (var usuario in usuarios)
                {
                    dataGridUsuarios.Rows.Add(usuario.key, usuario.dni, usuario.nombre, usuario.apellido, usuario.rol, usuario.sucursal, usuario.contraseña, usuario.mail);
                }
            }
            catch (Exception)
            {
            }
        }

       
    }
}
