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
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;


namespace AberturasSalta.Secciones
{
    public partial class FormStock : Form
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        List<Producto> productos = new List<Producto>();
        Usuario usuario;
        Producto productoSeleccionado;
        private string rutaEntrada = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/ABERTURAS software/software/catalogo.docx";
        private string rutaSalida = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/ABERTURAS software/salida/";
        private string rutaGenerada = "";
        private string rutaEtiqueta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/ABERTURAS software/etiquetas/";



        public FormStock(Usuario user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
           
            cargarDatos();
        }











        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textDescripcion.Text.Equals("") && !textCosto.Text.Equals("") && !textLista.Text.Equals("") && !textEfectivo.Text.Equals("") && !comboTipoAbertura.Text.Equals("") && !comboTipoMadera.Text.Equals(""))
                {
                    buttonActualizar.Enabled = false;
                    buttonActualizar.Text = "Espere...";
                    productoSeleccionado.fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    productoSeleccionado.tipo = comboTipoAbertura.Text;
                    productoSeleccionado.descripcion = textDescripcion.Text;
                    productoSeleccionado.madera = comboTipoMadera.Text;
                    productoSeleccionado.costo = textCosto.Text;
                    productoSeleccionado.lista = textLista.Text;
                    productoSeleccionado.abiertoCerrado = comboAbiertaCerrada.Text;
                    productoSeleccionado.efectivo = textEfectivo.Text;
                    MessageBox.Show("Producto Actualizado, actualize listado para mostrar cambios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    firebaseHelper.addProducto(productoSeleccionado);
                    //cargarDatos();
                    textDescripcion.Text = "";
                    textCosto.Text = "0";
                    buttonActualizar.Enabled = false;
                    buttonActualizar.Text = "Actualizar";
                    buttonAgregarActualizar.Enabled = true;
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

        private void buttonAgregarActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textDescripcion.Text.Equals("") && !textCosto.Text.Equals("") && !textLista.Text.Equals("") && !textEfectivo.Text.Equals("") && !comboTipoAbertura.Text.Equals("") && !comboTipoMadera.Text.Equals(""))
                {
                    buttonAgregarActualizar.Enabled = false;
                    buttonAgregarActualizar.Text = "Espere...";
                    Producto producto = new Producto();
                    producto.fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    producto.tipo = comboTipoAbertura.Text;
                    producto.descripcion = textDescripcion.Text;
                    producto.madera = comboTipoMadera.Text;
                    producto.costo = textCosto.Text;
                    producto.lista = textLista.Text;
                    producto.efectivo = textEfectivo.Text;
                    producto.abiertoCerrado = comboAbiertaCerrada.Text;
                    producto.id = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    MessageBox.Show("Producto Agregado, actualize listado para mostrar cambios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    firebaseHelper.addProducto(producto);
                    
                    //cargarDatos();
                    textDescripcion.Text = "";
                    textCosto.Text = "0";
                    this.ActiveControl = textDescripcion;
                    buttonAgregarActualizar.Enabled = true;
                    buttonAgregarActualizar.Text = "Agregar";
                }
                else
                {
                    MessageBox.Show("Rellene Campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private void buttonTodos_Click(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                DateTime fecha = new DateTime(Convert.ToInt32(producto.fecha.ToString().Substring(6, 4)), Convert.ToInt32(producto.fecha.ToString().Substring(3, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(0, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(11, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(14, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(17, 2)));
                dataGridStock.Rows.Add(producto.key, producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, fecha);
            }
            dataGridStock.Sort(dataGridStock.Columns[15], System.ComponentModel.ListSortDirection.Descending);
        }
        private async void dataGridStock_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridStock.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (e.Button.Equals(MouseButtons.Right))
                    {
                        DialogResult result = MessageBox.Show("Desea Eliminar Producto " + dataGridStock.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dataGridStock.Rows[e.RowIndex].Cells[3].Value.ToString(), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            await firebaseHelper.deleteProducto(dataGridStock.Rows[e.RowIndex].Cells[1].Value.ToString());
                            MessageBox.Show("Producto Eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cargarDatos();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Desea Actualizar Producto " + dataGridStock.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dataGridStock.Rows[e.RowIndex].Cells[3].Value.ToString(), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            productoSeleccionado = new Producto();
                            productoSeleccionado.key = dataGridStock.Rows[e.RowIndex].Cells[0].Value.ToString();
                            productoSeleccionado.id = dataGridStock.Rows[e.RowIndex].Cells[1].Value.ToString();
                            productoSeleccionado.tipo = dataGridStock.Rows[e.RowIndex].Cells[2].Value.ToString();
                            productoSeleccionado.descripcion = dataGridStock.Rows[e.RowIndex].Cells[3].Value.ToString();
                            productoSeleccionado.madera = dataGridStock.Rows[e.RowIndex].Cells[4].Value.ToString();
                            productoSeleccionado.abiertoCerrado = dataGridStock.Rows[e.RowIndex].Cells[5].Value.ToString();
                            productoSeleccionado.costo = dataGridStock.Rows[e.RowIndex].Cells[6].Value.ToString();
                            productoSeleccionado.lista = dataGridStock.Rows[e.RowIndex].Cells[7].Value.ToString();
                            productoSeleccionado.efectivo = dataGridStock.Rows[e.RowIndex].Cells[8].Value.ToString();
                            if (dataGridStock.Rows[e.RowIndex].Cells[8].Value != null)
                                productoSeleccionado.gral = dataGridStock.Rows[e.RowIndex].Cells[9].Value.ToString();
                            else
                                productoSeleccionado.gral = "0";
                            if (dataGridStock.Rows[e.RowIndex].Cells[9].Value != null)
                                productoSeleccionado.dep = dataGridStock.Rows[e.RowIndex].Cells[10].Value.ToString();
                            else
                                productoSeleccionado.dep = "0";
                            if (dataGridStock.Rows[e.RowIndex].Cells[10].Value != null)
                                productoSeleccionado.A = dataGridStock.Rows[e.RowIndex].Cells[11].Value.ToString();
                            else
                                productoSeleccionado.A = "0";
                            if (dataGridStock.Rows[e.RowIndex].Cells[11].Value != null)
                                productoSeleccionado.B = dataGridStock.Rows[e.RowIndex].Cells[12].Value.ToString();
                            else
                                productoSeleccionado.B = "0";
                            if (dataGridStock.Rows[e.RowIndex].Cells[12].Value != null)
                                productoSeleccionado.C = dataGridStock.Rows[e.RowIndex].Cells[13].Value.ToString();
                            else
                                productoSeleccionado.C = "0";
                            if (dataGridStock.Rows[e.RowIndex].Cells[13].Value != null)
                                productoSeleccionado.D = dataGridStock.Rows[e.RowIndex].Cells[14].Value.ToString();
                            else
                                productoSeleccionado.D = "0";
                            if (dataGridStock.Rows[e.RowIndex].Cells[14].Value != null)
                                productoSeleccionado.E = dataGridStock.Rows[e.RowIndex].Cells[15].Value.ToString();
                            else
                                productoSeleccionado.E = "0";
                            if (dataGridStock.Rows[e.RowIndex].Cells[15].Value != null)
                                productoSeleccionado.F = dataGridStock.Rows[e.RowIndex].Cells[16].Value.ToString();
                            else
                                productoSeleccionado.F = "0";
                            productoSeleccionado.fecha = dataGridStock.Rows[e.RowIndex].Cells[17].Value.ToString();

                            comboTipoAbertura.Text = productoSeleccionado.tipo;
                            comboAbiertaCerrada.Text = productoSeleccionado.abiertoCerrado;
                            textDescripcion.Text = productoSeleccionado.descripcion;
                            comboTipoMadera.Text = productoSeleccionado.madera;
                            textCosto.Text = productoSeleccionado.costo;
                            textLista.Text = productoSeleccionado.lista;
                            textEfectivo.Text = productoSeleccionado.efectivo;
                            buttonActualizar.Enabled = true;
                            buttonAgregarActualizar.Enabled = false;
                        }
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
                dataGridStock.Rows.Clear();
                productos = await firebaseHelper.getAllProductos();
                foreach (var producto in productos)
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(producto.fecha.ToString().Substring(6, 4)), Convert.ToInt32(producto.fecha.ToString().Substring(3, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(0, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(11, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(14, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(17, 2)));
                    dataGridStock.Rows.Add(producto.key, producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, fecha);
                }
                dataGridStock.Sort(dataGridStock.Columns[15], System.ComponentModel.ListSortDirection.Descending);
            }
            catch(Exception es)
            {

            }
        }

        private void textCosto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textLista.Text = (Math.Round(Int32.Parse(textCosto.Text) * 1.40) + Int32.Parse(textCosto.Text)).ToString();
                textEfectivo.Text = (Math.Round(Int32.Parse(textCosto.Text) * 1.1) + Int32.Parse(textCosto.Text)).ToString();
            }
            catch (Exception es)
            {

            }
        }

        private void textCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

















        private void comboFiltroTipoMadera_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                if (comboFiltroTipoMadera.Text.Equals(producto.madera))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(producto.fecha.ToString().Substring(6, 4)), Convert.ToInt32(producto.fecha.ToString().Substring(3, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(0, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(11, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(14, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(17, 2)));
                    dataGridStock.Rows.Add(producto.key, producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, fecha);
                }
            }
            dataGridStock.Sort(dataGridStock.Columns[15], System.ComponentModel.ListSortDirection.Descending);
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                if (comboTipo.Text.Equals(producto.tipo))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(producto.fecha.ToString().Substring(6, 4)), Convert.ToInt32(producto.fecha.ToString().Substring(3, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(0, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(11, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(14, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(17, 2)));
                    dataGridStock.Rows.Add(producto.key, producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, fecha);
                }
            }
            dataGridStock.Sort(dataGridStock.Columns[15], System.ComponentModel.ListSortDirection.Descending);
        }
        private void comboBoxFiltroAbCerrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridStock.Rows.Clear();
            foreach (var producto in productos)
            {
                if (comboBoxFiltroAbCerrada.Text.Equals(producto.abiertoCerrado))
                {
                    DateTime fecha = new DateTime(Convert.ToInt32(producto.fecha.ToString().Substring(6, 4)), Convert.ToInt32(producto.fecha.ToString().Substring(3, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(0, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(11, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(14, 2)), Convert.ToInt32(producto.fecha.ToString().Substring(17, 2)));
                    dataGridStock.Rows.Add(producto.key, producto.id, producto.tipo, producto.descripcion, producto.madera, producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, fecha);
                }
            }
            dataGridStock.Sort(dataGridStock.Columns[15], System.ComponentModel.ListSortDirection.Descending);
        }
        private void buttonExportar_Click(object sender, EventArgs e)
        {
            CreateWordDocument(rutaEntrada, rutaSalida + "Catalogo " + comboTipo.Text + ".pdf");
        }
        private void buttonActualiz_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }














































        private void CreateWordDocument(object filename, object SaveAs)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;
            try
            {
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;
                    myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing,ref missing, ref missing, ref missing,ref missing, ref missing, ref missing,ref missing, ref missing, ref missing,ref missing, ref missing, ref missing);
                    myWordDoc.Activate();
                    int i = 1;
                    this.FindAndReplace(wordApp, "<nombre>", comboTipo.Text);
                    foreach (DataGridViewRow item in dataGridStock.Rows)
                    {
                        if (item.Cells[0].Value!=null)
                        {
                            generarEtiqueta(item.Cells[1].Value.ToString());
                            this.FindAndReplace(wordApp, "<desc" + i.ToString() + ">", item.Cells[3].Value.ToString() + " " + item.Cells[4].Value.ToString() + " " + item.Cells[5].Value.ToString());
                            this.FindAndReplace(wordApp, "<PrecioEfectivo" + i.ToString() + ">", item.Cells[8].Value.ToString());
                            this.FindAndReplace(wordApp, "<PrecioLista" + i.ToString() + ">", item.Cells[7].Value.ToString());
                            var shape = myWordDoc.Bookmarks["codigo" + i.ToString()].Range.InlineShapes.AddPicture(rutaGenerada, false, true);
                            i++;
                        }                   
                    }
                    myWordDoc.SaveAs2(ref SaveAs, WdSaveFormat.wdFormatPDF, ref missing, ref missing, ref missing,ref missing, ref missing, ref missing,ref missing, ref missing, ref missing,ref missing, ref missing, ref missing,ref missing, ref missing, ref missing);
                    object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
                    object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
                    object routeDocument = false;
                    myWordDoc.Close(ref saveOption, ref originalFormat, ref routeDocument);
                    wordApp.Quit();
                    MessageBox.Show("Catalogo Generado");
                }
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
                myWordDoc.SaveAs2(ref SaveAs, WdSaveFormat.wdFormatPDF, ref missing, ref missing, ref missing,ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
                object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
                object routeDocument = false;
                myWordDoc.Close(ref saveOption, ref originalFormat, ref routeDocument);
                wordApp.Quit();
                MessageBox.Show("Ocurrio un error");
               
            }
        }

        private void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref ToFindText,ref matchCase, ref matchWholeWord, ref matchWildCards, ref matchSoundLike, ref nmatchAllforms, ref forward, ref wrap, ref format, ref replaceWithText,ref replace, ref matchKashida, ref matchDiactitics, ref matchAlefHamza, ref matchControl);
        }
        private void generarEtiqueta(string idProducto)
        {
            try
            {
                BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
                Codigo.IncludeLabel = true;
                panelResultado.BackgroundImage = Codigo.Encode(BarcodeLib.TYPE.CODE128, idProducto, Color.Black, Color.White, 188, 56);
                Image imgFinal = (Image)panelResultado.BackgroundImage.Clone();
                rutaGenerada = rutaEtiqueta + idProducto + ".png";
                imgFinal.Save(rutaGenerada, ImageFormat.Png);
            }
            catch (Exception es)
            {

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
                dataGridStock.Sort(dataGridStock.Columns[15], System.ComponentModel.ListSortDirection.Descending);
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
                            dataGridStock.Rows.Add(producto.key, producto.id, producto.tipo, producto.descripcion, producto.madera,producto.abiertoCerrado, producto.costo, producto.lista, producto.efectivo, producto.gral, producto.dep, producto.A, producto.B, producto.C, producto.D, producto.E, producto.F, fecha);
                        }
                    }
                    dataGridStock.Sort(dataGridStock.Columns[15], System.ComponentModel.ListSortDirection.Descending);
                }
            }
            catch(Exception s)
            {

            }
        }

        private void calcular()
        {
           
        }

       
    }
}
