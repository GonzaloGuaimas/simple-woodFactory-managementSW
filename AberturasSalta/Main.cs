using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AberturasSalta.Secciones;
using AberturasSalta.Objetos;
using AberturasSalta.SubSecciones;

namespace AberturasSalta
{
    public partial class Main : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<Usuario> usuarios = new List<Usuario>();
        Usuario usuario;


        public Main()
        {
            InitializeComponent();
        }



        private void Main_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }


















        private void buttonStock_Click(object sender, EventArgs e)
        {
            FormStock formStock = new FormStock(usuario);
            formStock.Show();
        }
        private void buttonRemitos_Click(object sender, EventArgs e)
        {
            FormRemitos formRemitos = new FormRemitos(usuario);
            formRemitos.Show();
        }

        private void buttonVentas_Click(object sender, EventArgs e)
        {
            FormVentas formVentas = new FormVentas(usuario);
            formVentas.Show();
        }
        private void buttonConfiguracion_Click(object sender, EventArgs e)
        {
            FormConfiguracion formRRHH = new FormConfiguracion(usuario);
            formRRHH.Show();
        }
        private void buttonArqueoCaja_Click(object sender, EventArgs e)
        {
            FormArqueoCaja formRRHH = new FormArqueoCaja(usuario);
            formRRHH.Show();
        }
        private void buttonGastosDiarios_Click(object sender, EventArgs e)
        {
            GenerarGasto formRRHH = new GenerarGasto(usuario);
            formRRHH.Show();
        }
        private void buttonEstadisticas_Click(object sender, EventArgs e)
        {

        }















        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var user in usuarios)
                {
                    if (textDNI.Text.Equals(user.dni))
                    {
                        if (textContraseña.Text.Equals(user.contraseña))
                        {
                            panelNavegacion.Visible = true;
                            usuario = user;
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Errónea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
           
        }

        


















        private async void cargarDatos()
        {
            try
            {
                usuarios = await firebaseHelper.getAllUsuario();
                var contraseñas = await firebaseHelper.getAllContraseña();
                await firebaseHelper.deleteContraseña24HS(contraseñas);
            }catch(Exception es)
            {

            }
        }

       
    }
}
