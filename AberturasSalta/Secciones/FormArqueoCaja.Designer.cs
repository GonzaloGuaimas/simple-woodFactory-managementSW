
namespace AberturasSalta.Secciones
{
    partial class FormArqueoCaja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArqueoCaja));
            this.dataGridArqueos = new System.Windows.Forms.DataGridView();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.efectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.comboFiltroUsuarios = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboFiltroSucursal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTodos = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelAgregarProd = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.textRestante = new System.Windows.Forms.Label();
            this.textExtraccion = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.Label();
            this.textTransferencia = new System.Windows.Forms.Label();
            this.textCredito = new System.Windows.Forms.Label();
            this.textDebito = new System.Windows.Forms.Label();
            this.textEfectivo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dateFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonAgregarActualizar = new System.Windows.Forms.Button();
            this.textGasto = new System.Windows.Forms.Label();
            this.textComentario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboUsuario = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboSucursalCierre = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArqueos)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelAgregarProd.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridArqueos
            // 
            this.dataGridArqueos.AllowUserToResizeColumns = false;
            this.dataGridArqueos.AllowUserToResizeRows = false;
            this.dataGridArqueos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridArqueos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridArqueos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridArqueos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridArqueos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridArqueos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridArqueos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.key,
            this.id,
            this.fecha,
            this.sucursal,
            this.empleado,
            this.extraccion,
            this.restante,
            this.gasto,
            this.efectivo,
            this.debito,
            this.credito,
            this.transferencia,
            this.descuento,
            this.total,
            this.comentario});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridArqueos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridArqueos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridArqueos.GridColor = System.Drawing.SystemColors.WindowText;
            this.dataGridArqueos.Location = new System.Drawing.Point(0, 151);
            this.dataGridArqueos.Name = "dataGridArqueos";
            this.dataGridArqueos.ReadOnly = true;
            this.dataGridArqueos.RowHeadersVisible = false;
            this.dataGridArqueos.RowHeadersWidth = 51;
            this.dataGridArqueos.RowTemplate.Height = 24;
            this.dataGridArqueos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridArqueos.Size = new System.Drawing.Size(1056, 207);
            this.dataGridArqueos.TabIndex = 54;
            // 
            // key
            // 
            this.key.HeaderText = "key";
            this.key.Name = "key";
            this.key.ReadOnly = true;
            this.key.Visible = false;
            this.key.Width = 30;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 21;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 62;
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "sucursal";
            this.sucursal.Name = "sucursal";
            this.sucursal.ReadOnly = true;
            this.sucursal.Width = 78;
            // 
            // empleado
            // 
            this.empleado.HeaderText = "empleado";
            this.empleado.Name = "empleado";
            this.empleado.ReadOnly = true;
            this.empleado.Width = 85;
            // 
            // extraccion
            // 
            this.extraccion.HeaderText = "extraccion";
            this.extraccion.Name = "extraccion";
            this.extraccion.ReadOnly = true;
            this.extraccion.Width = 90;
            // 
            // restante
            // 
            this.restante.HeaderText = "restante";
            this.restante.Name = "restante";
            this.restante.ReadOnly = true;
            this.restante.Width = 77;
            // 
            // gasto
            // 
            this.gasto.HeaderText = "gasto";
            this.gasto.Name = "gasto";
            this.gasto.ReadOnly = true;
            this.gasto.Width = 61;
            // 
            // efectivo
            // 
            this.efectivo.HeaderText = "efectivo";
            this.efectivo.Name = "efectivo";
            this.efectivo.ReadOnly = true;
            this.efectivo.Width = 75;
            // 
            // debito
            // 
            this.debito.HeaderText = "debito";
            this.debito.Name = "debito";
            this.debito.ReadOnly = true;
            this.debito.Width = 65;
            // 
            // credito
            // 
            this.credito.HeaderText = "credito";
            this.credito.Name = "credito";
            this.credito.ReadOnly = true;
            this.credito.Width = 70;
            // 
            // transferencia
            // 
            this.transferencia.HeaderText = "transferencia";
            this.transferencia.Name = "transferencia";
            this.transferencia.ReadOnly = true;
            this.transferencia.Width = 106;
            // 
            // descuento
            // 
            this.descuento.HeaderText = "descuento";
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            this.descuento.Width = 89;
            // 
            // total
            // 
            this.total.HeaderText = "total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 55;
            // 
            // comentario
            // 
            this.comentario.HeaderText = "comentario";
            this.comentario.Name = "comentario";
            this.comentario.ReadOnly = true;
            this.comentario.Width = 94;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dateFechaEntrega);
            this.panel3.Controls.Add(this.comboFiltroUsuarios);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.comboFiltroSucursal);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 78);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1056, 73);
            this.panel3.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(934, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Filtros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(312, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 58;
            this.label1.Text = "Filtrar Fecha";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateFechaEntrega
            // 
            this.dateFechaEntrega.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaEntrega.Location = new System.Drawing.Point(315, 39);
            this.dateFechaEntrega.Margin = new System.Windows.Forms.Padding(2);
            this.dateFechaEntrega.Name = "dateFechaEntrega";
            this.dateFechaEntrega.Size = new System.Drawing.Size(112, 20);
            this.dateFechaEntrega.TabIndex = 57;
            this.dateFechaEntrega.ValueChanged += new System.EventHandler(this.dateFecha_ValueChanged);
            // 
            // comboFiltroUsuarios
            // 
            this.comboFiltroUsuarios.BackColor = System.Drawing.SystemColors.Control;
            this.comboFiltroUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboFiltroUsuarios.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFiltroUsuarios.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboFiltroUsuarios.FormattingEnabled = true;
            this.comboFiltroUsuarios.ItemHeight = 12;
            this.comboFiltroUsuarios.Location = new System.Drawing.Point(178, 39);
            this.comboFiltroUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.comboFiltroUsuarios.Name = "comboFiltroUsuarios";
            this.comboFiltroUsuarios.Size = new System.Drawing.Size(108, 20);
            this.comboFiltroUsuarios.TabIndex = 56;
            this.comboFiltroUsuarios.SelectedIndexChanged += new System.EventHandler(this.comboFiltroUsuarios_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(176, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 12);
            this.label3.TabIndex = 55;
            this.label3.Text = "Usuario";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboFiltroSucursal
            // 
            this.comboFiltroSucursal.BackColor = System.Drawing.SystemColors.Control;
            this.comboFiltroSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboFiltroSucursal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFiltroSucursal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboFiltroSucursal.FormattingEnabled = true;
            this.comboFiltroSucursal.ItemHeight = 12;
            this.comboFiltroSucursal.Items.AddRange(new object[] {
            "Zuviria",
            "Independencia",
            "Santa Lucia",
            "Chile",
            "La Isla",
            "-"});
            this.comboFiltroSucursal.Location = new System.Drawing.Point(49, 39);
            this.comboFiltroSucursal.Margin = new System.Windows.Forms.Padding(2);
            this.comboFiltroSucursal.Name = "comboFiltroSucursal";
            this.comboFiltroSucursal.Size = new System.Drawing.Size(108, 20);
            this.comboFiltroSucursal.TabIndex = 54;
            this.comboFiltroSucursal.SelectedIndexChanged += new System.EventHandler(this.comboFiltroSucursal_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(47, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 12);
            this.label4.TabIndex = 53;
            this.label4.Text = "Sucursal";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonTodos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(934, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 73);
            this.panel1.TabIndex = 29;
            // 
            // buttonTodos
            // 
            this.buttonTodos.BackColor = System.Drawing.Color.Black;
            this.buttonTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTodos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTodos.Location = new System.Drawing.Point(15, 23);
            this.buttonTodos.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTodos.Name = "buttonTodos";
            this.buttonTodos.Size = new System.Drawing.Size(95, 36);
            this.buttonTodos.TabIndex = 28;
            this.buttonTodos.Text = "Todos";
            this.buttonTodos.UseVisualStyleBackColor = false;
            this.buttonTodos.Click += new System.EventHandler(this.buttonTodos_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Black;
            this.panelBottom.Controls.Add(this.panelAgregarProd);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 358);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1056, 116);
            this.panelBottom.TabIndex = 52;
            // 
            // panelAgregarProd
            // 
            this.panelAgregarProd.Controls.Add(this.label13);
            this.panelAgregarProd.Controls.Add(this.textRestante);
            this.panelAgregarProd.Controls.Add(this.textExtraccion);
            this.panelAgregarProd.Controls.Add(this.label15);
            this.panelAgregarProd.Controls.Add(this.textTotal);
            this.panelAgregarProd.Controls.Add(this.textTransferencia);
            this.panelAgregarProd.Controls.Add(this.textCredito);
            this.panelAgregarProd.Controls.Add(this.textDebito);
            this.panelAgregarProd.Controls.Add(this.textEfectivo);
            this.panelAgregarProd.Controls.Add(this.label12);
            this.panelAgregarProd.Controls.Add(this.dateFechaCierre);
            this.panelAgregarProd.Controls.Add(this.panel4);
            this.panelAgregarProd.Controls.Add(this.textGasto);
            this.panelAgregarProd.Controls.Add(this.textComentario);
            this.panelAgregarProd.Controls.Add(this.label8);
            this.panelAgregarProd.Controls.Add(this.comboUsuario);
            this.panelAgregarProd.Controls.Add(this.label7);
            this.panelAgregarProd.Controls.Add(this.comboSucursalCierre);
            this.panelAgregarProd.Controls.Add(this.label5);
            this.panelAgregarProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAgregarProd.Location = new System.Drawing.Point(0, 0);
            this.panelAgregarProd.Name = "panelAgregarProd";
            this.panelAgregarProd.Size = new System.Drawing.Size(1056, 116);
            this.panelAgregarProd.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(909, 13);
            this.label13.TabIndex = 63;
            this.label13.Text = "Cierre de Caja";
            // 
            // textRestante
            // 
            this.textRestante.AutoSize = true;
            this.textRestante.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRestante.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textRestante.Location = new System.Drawing.Point(767, 80);
            this.textRestante.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textRestante.Name = "textRestante";
            this.textRestante.Size = new System.Drawing.Size(88, 15);
            this.textRestante.TabIndex = 62;
            this.textRestante.Text = "Restante: $0";
            this.textRestante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textExtraccion
            // 
            this.textExtraccion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textExtraccion.Location = new System.Drawing.Point(770, 45);
            this.textExtraccion.Name = "textExtraccion";
            this.textExtraccion.Size = new System.Drawing.Size(114, 20);
            this.textExtraccion.TabIndex = 60;
            this.textExtraccion.TextChanged += new System.EventHandler(this.textExtraccion_TextChanged);
            this.textExtraccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textExtraccion_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label15.Location = new System.Drawing.Point(767, 26);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 12);
            this.label15.TabIndex = 61;
            this.label15.Text = "Extracción:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textTotal
            // 
            this.textTotal.AutoSize = true;
            this.textTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textTotal.Location = new System.Drawing.Point(577, 80);
            this.textTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textTotal.Name = "textTotal";
            this.textTotal.Size = new System.Drawing.Size(63, 15);
            this.textTotal.TabIndex = 59;
            this.textTotal.Text = "Total: $0";
            this.textTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textTransferencia
            // 
            this.textTransferencia.AutoSize = true;
            this.textTransferencia.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTransferencia.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textTransferencia.Location = new System.Drawing.Point(577, 36);
            this.textTransferencia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textTransferencia.Name = "textTransferencia";
            this.textTransferencia.Size = new System.Drawing.Size(121, 15);
            this.textTransferencia.TabIndex = 58;
            this.textTransferencia.Text = "Transferencia: $0";
            this.textTransferencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textCredito
            // 
            this.textCredito.AutoSize = true;
            this.textCredito.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCredito.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textCredito.Location = new System.Drawing.Point(449, 80);
            this.textCredito.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textCredito.Name = "textCredito";
            this.textCredito.Size = new System.Drawing.Size(79, 15);
            this.textCredito.TabIndex = 57;
            this.textCredito.Text = "Credito: $0";
            this.textCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textDebito
            // 
            this.textDebito.AutoSize = true;
            this.textDebito.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDebito.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textDebito.Location = new System.Drawing.Point(449, 36);
            this.textDebito.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textDebito.Name = "textDebito";
            this.textDebito.Size = new System.Drawing.Size(73, 15);
            this.textDebito.TabIndex = 56;
            this.textDebito.Text = "Debito: $0";
            this.textDebito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textEfectivo
            // 
            this.textEfectivo.AutoSize = true;
            this.textEfectivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEfectivo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textEfectivo.Location = new System.Drawing.Point(312, 80);
            this.textEfectivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textEfectivo.Name = "textEfectivo";
            this.textEfectivo.Size = new System.Drawing.Size(83, 15);
            this.textEfectivo.TabIndex = 55;
            this.textEfectivo.Text = "Efectivo: $0";
            this.textEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(12, 26);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 12);
            this.label12.TabIndex = 54;
            this.label12.Text = "Fecha Cierre";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateFechaCierre
            // 
            this.dateFechaCierre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaCierre.Location = new System.Drawing.Point(11, 45);
            this.dateFechaCierre.Margin = new System.Windows.Forms.Padding(2);
            this.dateFechaCierre.Name = "dateFechaCierre";
            this.dateFechaCierre.Size = new System.Drawing.Size(112, 20);
            this.dateFechaCierre.TabIndex = 53;
            this.dateFechaCierre.ValueChanged += new System.EventHandler(this.dateFechaCierre_ValueChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonAgregarActualizar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(909, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(147, 116);
            this.panel4.TabIndex = 39;
            // 
            // buttonAgregarActualizar
            // 
            this.buttonAgregarActualizar.BackColor = System.Drawing.Color.Black;
            this.buttonAgregarActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregarActualizar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgregarActualizar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAgregarActualizar.Location = new System.Drawing.Point(16, 25);
            this.buttonAgregarActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAgregarActualizar.Name = "buttonAgregarActualizar";
            this.buttonAgregarActualizar.Size = new System.Drawing.Size(119, 59);
            this.buttonAgregarActualizar.TabIndex = 38;
            this.buttonAgregarActualizar.Text = "Cerrar Caja";
            this.buttonAgregarActualizar.UseVisualStyleBackColor = false;
            this.buttonAgregarActualizar.Click += new System.EventHandler(this.buttonAgregarActualizar_Click);
            // 
            // textGasto
            // 
            this.textGasto.AutoSize = true;
            this.textGasto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGasto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textGasto.Location = new System.Drawing.Point(312, 36);
            this.textGasto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textGasto.Name = "textGasto";
            this.textGasto.Size = new System.Drawing.Size(68, 15);
            this.textGasto.TabIndex = 34;
            this.textGasto.Text = "Gasto: $0";
            this.textGasto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textComentario
            // 
            this.textComentario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textComentario.Location = new System.Drawing.Point(147, 89);
            this.textComentario.Name = "textComentario";
            this.textComentario.Size = new System.Drawing.Size(114, 20);
            this.textComentario.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(144, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "Comentario";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboUsuario
            // 
            this.comboUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboUsuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUsuario.FormattingEnabled = true;
            this.comboUsuario.Location = new System.Drawing.Point(147, 45);
            this.comboUsuario.Name = "comboUsuario";
            this.comboUsuario.Size = new System.Drawing.Size(114, 20);
            this.comboUsuario.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(144, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "Usuario";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboSucursalCierre
            // 
            this.comboSucursalCierre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboSucursalCierre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSucursalCierre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboSucursalCierre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSucursalCierre.FormattingEnabled = true;
            this.comboSucursalCierre.Items.AddRange(new object[] {
            "Zuviria",
            "Independencia",
            "Santa Lucia",
            "Chile",
            "La Isla",
            "-"});
            this.comboSucursalCierre.Location = new System.Drawing.Point(14, 89);
            this.comboSucursalCierre.Name = "comboSucursalCierre";
            this.comboSucursalCierre.Size = new System.Drawing.Size(109, 20);
            this.comboSucursalCierre.TabIndex = 0;
            this.comboSucursalCierre.SelectedIndexChanged += new System.EventHandler(this.comboSucursalCierre_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(11, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "Sucursal";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1056, 78);
            this.panel2.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1056, 78);
            this.label2.TabIndex = 20;
            this.label2.Text = "CIERRE DE CAJA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormArqueoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 474);
            this.Controls.Add(this.dataGridArqueos);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormArqueoCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormArqueoCaja";
            this.Load += new System.EventHandler(this.FormArqueoCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArqueos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelAgregarProd.ResumeLayout(false);
            this.panelAgregarProd.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridArqueos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonTodos;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelAgregarProd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonAgregarActualizar;
        private System.Windows.Forms.Label textGasto;
        private System.Windows.Forms.TextBox textComentario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboSucursalCierre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateFechaCierre;
        private System.Windows.Forms.Label textTotal;
        private System.Windows.Forms.Label textTransferencia;
        private System.Windows.Forms.Label textCredito;
        private System.Windows.Forms.Label textDebito;
        private System.Windows.Forms.Label textEfectivo;
        private System.Windows.Forms.Label textRestante;
        private System.Windows.Forms.TextBox textExtraccion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFechaEntrega;
        private System.Windows.Forms.ComboBox comboFiltroUsuarios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboFiltroSucursal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn key;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn restante;
        private System.Windows.Forms.DataGridViewTextBoxColumn gasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn efectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
    }
}