namespace Sistema.PERFILUSUARIO.PRESENTACION
{
    partial class PGRUPO
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTNELIMINAR = new System.Windows.Forms.Button();
            this.BTNACTUALIZAR = new System.Windows.Forms.Button();
            this.BTNREGISTRAR = new System.Windows.Forms.Button();
            this.BTNNUEVO = new System.Windows.Forms.Button();
            this.TXTDESCRIPCION = new System.Windows.Forms.TextBox();
            this.TXTCOD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.IdUsuario = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(68, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(321, 106);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // BTNELIMINAR
            // 
            this.BTNELIMINAR.Location = new System.Drawing.Point(384, 99);
            this.BTNELIMINAR.Name = "BTNELIMINAR";
            this.BTNELIMINAR.Size = new System.Drawing.Size(75, 23);
            this.BTNELIMINAR.TabIndex = 16;
            this.BTNELIMINAR.Text = "ELIMINAR";
            this.BTNELIMINAR.UseVisualStyleBackColor = true;
            this.BTNELIMINAR.Click += new System.EventHandler(this.BTNELIMINAR_Click);
            // 
            // BTNACTUALIZAR
            // 
            this.BTNACTUALIZAR.Location = new System.Drawing.Point(277, 99);
            this.BTNACTUALIZAR.Name = "BTNACTUALIZAR";
            this.BTNACTUALIZAR.Size = new System.Drawing.Size(87, 23);
            this.BTNACTUALIZAR.TabIndex = 15;
            this.BTNACTUALIZAR.Text = "ACTUALIZAR";
            this.BTNACTUALIZAR.UseVisualStyleBackColor = true;
            this.BTNACTUALIZAR.Click += new System.EventHandler(this.BTNACTUALIZAR_Click);
            // 
            // BTNREGISTRAR
            // 
            this.BTNREGISTRAR.Location = new System.Drawing.Point(166, 99);
            this.BTNREGISTRAR.Name = "BTNREGISTRAR";
            this.BTNREGISTRAR.Size = new System.Drawing.Size(90, 23);
            this.BTNREGISTRAR.TabIndex = 14;
            this.BTNREGISTRAR.Text = "REGISTRAR";
            this.BTNREGISTRAR.UseVisualStyleBackColor = true;
            this.BTNREGISTRAR.Click += new System.EventHandler(this.BTNREGISTRAR_Click);
            // 
            // BTNNUEVO
            // 
            this.BTNNUEVO.Location = new System.Drawing.Point(68, 99);
            this.BTNNUEVO.Name = "BTNNUEVO";
            this.BTNNUEVO.Size = new System.Drawing.Size(75, 23);
            this.BTNNUEVO.TabIndex = 13;
            this.BTNNUEVO.Text = "NUEVO";
            this.BTNNUEVO.UseVisualStyleBackColor = true;
            this.BTNNUEVO.Click += new System.EventHandler(this.BTNNUEVO_Click);
            // 
            // TXTDESCRIPCION
            // 
            this.TXTDESCRIPCION.Location = new System.Drawing.Point(187, 40);
            this.TXTDESCRIPCION.Name = "TXTDESCRIPCION";
            this.TXTDESCRIPCION.Size = new System.Drawing.Size(100, 20);
            this.TXTDESCRIPCION.TabIndex = 12;
            // 
            // TXTCOD
            // 
            this.TXTCOD.Location = new System.Drawing.Point(187, 2);
            this.TXTCOD.Name = "TXTCOD";
            this.TXTCOD.Size = new System.Drawing.Size(100, 20);
            this.TXTCOD.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "DESCRIPCION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "CODIGO";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "prueba";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IdUsuario
            // 
            this.IdUsuario.Location = new System.Drawing.Point(355, 47);
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.Size = new System.Drawing.Size(100, 20);
            this.IdUsuario.TabIndex = 19;
            this.IdUsuario.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(415, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Registar Privilegio";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PGRUPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 294);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.IdUsuario);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BTNELIMINAR);
            this.Controls.Add(this.BTNACTUALIZAR);
            this.Controls.Add(this.BTNREGISTRAR);
            this.Controls.Add(this.BTNNUEVO);
            this.Controls.Add(this.TXTDESCRIPCION);
            this.Controls.Add(this.TXTCOD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PGRUPO";
            this.Text = "PGRUPO";
            this.Load += new System.EventHandler(this.PGRUPO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTNELIMINAR;
        private System.Windows.Forms.Button BTNACTUALIZAR;
        private System.Windows.Forms.Button BTNREGISTRAR;
        private System.Windows.Forms.Button BTNNUEVO;
        private System.Windows.Forms.TextBox TXTDESCRIPCION;
        private System.Windows.Forms.TextBox TXTCOD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox IdUsuario;
        private System.Windows.Forms.Button button2;
    }
}