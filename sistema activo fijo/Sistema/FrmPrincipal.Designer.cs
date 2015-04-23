namespace Sistema
{
    partial class FrmPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tipobienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privilegiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarPrivilegioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDelFormularioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDeTextoDelFormularioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuenteDelFormularioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.IDUsuarioTxt = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.labelNombreEmpresa = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.labelCelular = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ingresoEgresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.privilegiosToolStripMenuItem,
            this.respaldoToolStripMenuItem,
            this.configuracionToolStripMenuItem,
            this.inicioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(942, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipobienToolStripMenuItem,
            this.categoriaToolStripMenuItem,
            this.cargoToolStripMenuItem,
            this.departamentoToolStripMenuItem,
            this.ingresoEgresoToolStripMenuItem,
            this.bToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem1.Text = "&Persona";
            // 
            // tipobienToolStripMenuItem
            // 
            this.tipobienToolStripMenuItem.Name = "tipobienToolStripMenuItem";
            this.tipobienToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tipobienToolStripMenuItem.Text = "Tipobien";
            this.tipobienToolStripMenuItem.Click += new System.EventHandler(this.tipobienToolStripMenuItem_Click);
            // 
            // categoriaToolStripMenuItem
            // 
            this.categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            this.categoriaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.categoriaToolStripMenuItem.Text = "Categoria";
            this.categoriaToolStripMenuItem.Click += new System.EventHandler(this.categoriaToolStripMenuItem_Click);
            // 
            // cargoToolStripMenuItem
            // 
            this.cargoToolStripMenuItem.Name = "cargoToolStripMenuItem";
            this.cargoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.cargoToolStripMenuItem.Text = "Cargo";
            this.cargoToolStripMenuItem.Click += new System.EventHandler(this.cargoToolStripMenuItem_Click);
            // 
            // departamentoToolStripMenuItem
            // 
            this.departamentoToolStripMenuItem.Name = "departamentoToolStripMenuItem";
            this.departamentoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.departamentoToolStripMenuItem.Text = "Departamento";
            this.departamentoToolStripMenuItem.Click += new System.EventHandler(this.departamentoToolStripMenuItem_Click);
            // 
            // privilegiosToolStripMenuItem
            // 
            this.privilegiosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gruposToolStripMenuItem,
            this.asignarPrivilegioToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.privilegiosToolStripMenuItem.Name = "privilegiosToolStripMenuItem";
            this.privilegiosToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.privilegiosToolStripMenuItem.Text = "&Administracion de Usuarios";
            this.privilegiosToolStripMenuItem.ToolTipText = "Contiene los formularios de grupo, privilegios y usuarios";
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gruposToolStripMenuItem.Text = "Grupos";
            this.gruposToolStripMenuItem.Click += new System.EventHandler(this.gruposToolStripMenuItem_Click);
            // 
            // asignarPrivilegioToolStripMenuItem
            // 
            this.asignarPrivilegioToolStripMenuItem.Name = "asignarPrivilegioToolStripMenuItem";
            this.asignarPrivilegioToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.asignarPrivilegioToolStripMenuItem.Text = "Asignar Privilegios";
            this.asignarPrivilegioToolStripMenuItem.Click += new System.EventHandler(this.asignarPrivilegioToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // respaldoToolStripMenuItem
            // 
            this.respaldoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.respaldoToolStripMenuItem.Name = "respaldoToolStripMenuItem";
            this.respaldoToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.respaldoToolStripMenuItem.Text = "&Seguridad";
            this.respaldoToolStripMenuItem.ToolTipText = "Contiene los formularios de backup, restore y bitacora";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorDelFormularioToolStripMenuItem,
            this.colorDeTextoDelFormularioToolStripMenuItem,
            this.fuenteDelFormularioToolStripMenuItem});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "&Configuracion";
            this.configuracionToolStripMenuItem.ToolTipText = "Contiene las funciones para la personalizacion de colores y fuentes de todos los " +
    "formularios";
            // 
            // colorDelFormularioToolStripMenuItem
            // 
            this.colorDelFormularioToolStripMenuItem.Name = "colorDelFormularioToolStripMenuItem";
            this.colorDelFormularioToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.colorDelFormularioToolStripMenuItem.Text = "Color del Formulario";
            this.colorDelFormularioToolStripMenuItem.Click += new System.EventHandler(this.colorDelFormularioToolStripMenuItem_Click);
            // 
            // colorDeTextoDelFormularioToolStripMenuItem
            // 
            this.colorDeTextoDelFormularioToolStripMenuItem.Name = "colorDeTextoDelFormularioToolStripMenuItem";
            this.colorDeTextoDelFormularioToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.colorDeTextoDelFormularioToolStripMenuItem.Text = "Color de Texto del Formulario";
            this.colorDeTextoDelFormularioToolStripMenuItem.Click += new System.EventHandler(this.colorDeTextoDelFormularioToolStripMenuItem_Click);
            // 
            // fuenteDelFormularioToolStripMenuItem
            // 
            this.fuenteDelFormularioToolStripMenuItem.Name = "fuenteDelFormularioToolStripMenuItem";
            this.fuenteDelFormularioToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.fuenteDelFormularioToolStripMenuItem.Text = "Fuente del Formulario";
            this.fuenteDelFormularioToolStripMenuItem.Click += new System.EventHandler(this.fuenteDelFormularioToolStripMenuItem_Click);
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesionToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // IDUsuarioTxt
            // 
            this.IDUsuarioTxt.Location = new System.Drawing.Point(757, 118);
            this.IDUsuarioTxt.Name = "IDUsuarioTxt";
            this.IDUsuarioTxt.Size = new System.Drawing.Size(100, 20);
            this.IDUsuarioTxt.TabIndex = 1;
            this.IDUsuarioTxt.Visible = false;
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.SystemColors.ControlText;
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(757, 166);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(100, 20);
            this.txtcodigo.TabIndex = 6;
            this.txtcodigo.Visible = false;
            // 
            // labelNombreEmpresa
            // 
            this.labelNombreEmpresa.AutoSize = true;
            this.labelNombreEmpresa.Location = new System.Drawing.Point(368, 45);
            this.labelNombreEmpresa.Name = "labelNombreEmpresa";
            this.labelNombreEmpresa.Size = new System.Drawing.Size(44, 13);
            this.labelNombreEmpresa.TabIndex = 7;
            this.labelNombreEmpresa.Text = "Sistema";
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(227, 92);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(52, 13);
            this.labelTelefono.TabIndex = 8;
            this.labelTelefono.Text = "Telefono:";
            // 
            // labelCelular
            // 
            this.labelCelular.AutoSize = true;
            this.labelCelular.Location = new System.Drawing.Point(463, 67);
            this.labelCelular.Name = "labelCelular";
            this.labelCelular.Size = new System.Drawing.Size(45, 13);
            this.labelCelular.TabIndex = 9;
            this.labelCelular.Text = "Celular: ";
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Location = new System.Drawing.Point(227, 67);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(55, 13);
            this.labelDireccion.TabIndex = 10;
            this.labelDireccion.Text = "Direccion:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(463, 92);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 11;
            this.labelEmail.Text = "Email:";
            // 
            // ingresoEgresoToolStripMenuItem
            // 
            this.ingresoEgresoToolStripMenuItem.Name = "ingresoEgresoToolStripMenuItem";
            this.ingresoEgresoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ingresoEgresoToolStripMenuItem.Text = "Ingreso-Egreso";
            this.ingresoEgresoToolStripMenuItem.Click += new System.EventHandler(this.ingresoEgresoToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(202, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(521, 349);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.bToolStripMenuItem.Text = "Bien";
            this.bToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 498);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelCelular);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelNombreEmpresa);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.IDUsuarioTxt);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorDelFormularioToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.TextBox IDUsuarioTxt;
        private System.Windows.Forms.ToolStripMenuItem colorDeTextoDelFormularioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuenteDelFormularioToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem respaldoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        public System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.ToolStripMenuItem privilegiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarPrivilegioToolStripMenuItem;
        private System.Windows.Forms.Label labelNombreEmpresa;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelCelular;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tipobienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresoEgresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
    }
}