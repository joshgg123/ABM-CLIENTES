namespace ABM_CLIENTES
{
    partial class Clientes
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
            this.gridClientes = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nomCliente = new MetroFramework.Controls.MetroTextBox();
            this.apeCliente = new MetroFramework.Controls.MetroTextBox();
            this.telCliente = new MetroFramework.Controls.MetroTextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridClientes
            // 
            this.gridClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.gridClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridClientes.ColumnHeadersHeight = 30;
            this.gridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridClientes.EnableHeadersVisualStyles = false;
            this.gridClientes.GridColor = System.Drawing.Color.SteelBlue;
            this.gridClientes.Location = new System.Drawing.Point(12, 12);
            this.gridClientes.Name = "gridClientes";
            this.gridClientes.ReadOnly = true;
            this.gridClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridClientes.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.gridClientes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridClientes.Size = new System.Drawing.Size(402, 368);
            this.gridClientes.TabIndex = 0;
            this.gridClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(12, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Alta";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button2.Location = new System.Drawing.Point(444, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Modificacion";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nomCliente
            // 
            // 
            // 
            // 
            this.nomCliente.CustomButton.Image = null;
            this.nomCliente.CustomButton.Location = new System.Drawing.Point(178, 1);
            this.nomCliente.CustomButton.Name = "";
            this.nomCliente.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.nomCliente.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nomCliente.CustomButton.TabIndex = 1;
            this.nomCliente.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nomCliente.CustomButton.UseSelectable = true;
            this.nomCliente.CustomButton.Visible = false;
            this.nomCliente.Lines = new string[] {
        "Nombre"};
            this.nomCliente.Location = new System.Drawing.Point(12, 407);
            this.nomCliente.MaxLength = 32767;
            this.nomCliente.Name = "nomCliente";
            this.nomCliente.PasswordChar = '\0';
            this.nomCliente.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nomCliente.SelectedText = "";
            this.nomCliente.SelectionLength = 0;
            this.nomCliente.SelectionStart = 0;
            this.nomCliente.ShortcutsEnabled = true;
            this.nomCliente.Size = new System.Drawing.Size(200, 23);
            this.nomCliente.TabIndex = 3;
            this.nomCliente.Text = "Nombre";
            this.nomCliente.UseSelectable = true;
            this.nomCliente.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nomCliente.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.nomCliente.Click += new System.EventHandler(this.nomCliente_Click);
            this.nomCliente.Enter += new System.EventHandler(this.nomCliente_Enter);
            this.nomCliente.Leave += new System.EventHandler(this.nomCliente_Leave);
            // 
            // apeCliente
            // 
            // 
            // 
            // 
            this.apeCliente.CustomButton.Image = null;
            this.apeCliente.CustomButton.Location = new System.Drawing.Point(178, 1);
            this.apeCliente.CustomButton.Name = "";
            this.apeCliente.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.apeCliente.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.apeCliente.CustomButton.TabIndex = 1;
            this.apeCliente.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.apeCliente.CustomButton.UseSelectable = true;
            this.apeCliente.CustomButton.Visible = false;
            this.apeCliente.Lines = new string[] {
        "Apellido"};
            this.apeCliente.Location = new System.Drawing.Point(12, 449);
            this.apeCliente.MaxLength = 32767;
            this.apeCliente.Name = "apeCliente";
            this.apeCliente.PasswordChar = '\0';
            this.apeCliente.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.apeCliente.SelectedText = "";
            this.apeCliente.SelectionLength = 0;
            this.apeCliente.SelectionStart = 0;
            this.apeCliente.ShortcutsEnabled = true;
            this.apeCliente.Size = new System.Drawing.Size(200, 23);
            this.apeCliente.TabIndex = 4;
            this.apeCliente.Text = "Apellido";
            this.apeCliente.UseSelectable = true;
            this.apeCliente.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.apeCliente.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.apeCliente.Enter += new System.EventHandler(this.apeCliente_Enter);
            this.apeCliente.Leave += new System.EventHandler(this.apeCliente_Leave);
            // 
            // telCliente
            // 
            // 
            // 
            // 
            this.telCliente.CustomButton.Image = null;
            this.telCliente.CustomButton.Location = new System.Drawing.Point(178, 1);
            this.telCliente.CustomButton.Name = "";
            this.telCliente.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.telCliente.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.telCliente.CustomButton.TabIndex = 1;
            this.telCliente.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.telCliente.CustomButton.UseSelectable = true;
            this.telCliente.CustomButton.Visible = false;
            this.telCliente.Lines = new string[] {
        "Telefono"};
            this.telCliente.Location = new System.Drawing.Point(12, 490);
            this.telCliente.MaxLength = 32767;
            this.telCliente.Name = "telCliente";
            this.telCliente.PasswordChar = '\0';
            this.telCliente.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.telCliente.SelectedText = "";
            this.telCliente.SelectionLength = 0;
            this.telCliente.SelectionStart = 0;
            this.telCliente.ShortcutsEnabled = true;
            this.telCliente.Size = new System.Drawing.Size(200, 23);
            this.telCliente.TabIndex = 5;
            this.telCliente.Text = "Telefono";
            this.telCliente.UseSelectable = true;
            this.telCliente.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.telCliente.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.telCliente.Enter += new System.EventHandler(this.telCliente_Enter);
            this.telCliente.Leave += new System.EventHandler(this.telCliente_Leave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button3.Location = new System.Drawing.Point(614, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 37);
            this.button3.TabIndex = 6;
            this.button3.Text = "Baja";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(11)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(764, 617);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.telCliente);
            this.Controls.Add(this.apeCliente);
            this.Controls.Add(this.nomCliente);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridClientes);
            this.Name = "Clientes";
            this.Text = "Clientes";



            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridClientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private MetroFramework.Controls.MetroTextBox nomCliente;
        private MetroFramework.Controls.MetroTextBox apeCliente;
        private MetroFramework.Controls.MetroTextBox telCliente;
        private System.Windows.Forms.Button button3;
    }
}