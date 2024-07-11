namespace products_magento_to_prestashop
{
    partial class FormpPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormpPrincipal));
            this.textBox_Key_APIWEB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_URL_APIWEB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Cargar_FileCSV_Products = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_Select_Directory = new System.Windows.Forms.Button();
            this.button_Add_Products_Prestashop = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayudaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxVersionMagento = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Key_APIWEB
            // 
            this.textBox_Key_APIWEB.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Key_APIWEB.Location = new System.Drawing.Point(73, 51);
            this.textBox_Key_APIWEB.Name = "textBox_Key_APIWEB";
            this.textBox_Key_APIWEB.Size = new System.Drawing.Size(490, 23);
            this.textBox_Key_APIWEB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Key";
            // 
            // textBox_URL_APIWEB
            // 
            this.textBox_URL_APIWEB.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_URL_APIWEB.Location = new System.Drawing.Point(73, 22);
            this.textBox_URL_APIWEB.Name = "textBox_URL_APIWEB";
            this.textBox_URL_APIWEB.Size = new System.Drawing.Size(490, 23);
            this.textBox_URL_APIWEB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "URL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Key_APIWEB);
            this.groupBox1.Controls.Add(this.textBox_URL_APIWEB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 85);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "API WEB";
            // 
            // button_Cargar_FileCSV_Products
            // 
            this.button_Cargar_FileCSV_Products.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cargar_FileCSV_Products.Location = new System.Drawing.Point(9, 22);
            this.button_Cargar_FileCSV_Products.Name = "button_Cargar_FileCSV_Products";
            this.button_Cargar_FileCSV_Products.Size = new System.Drawing.Size(169, 57);
            this.button_Cargar_FileCSV_Products.TabIndex = 12;
            this.button_Cargar_FileCSV_Products.Text = "Cargar Tabla de Productos de Magento";
            this.button_Cargar_FileCSV_Products.UseVisualStyleBackColor = true;
            this.button_Cargar_FileCSV_Products.Click += new System.EventHandler(this.button_Cargar_FileCSV_Products_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 22);
            this.progressBar1.MarqueeAnimationSpeed = 25;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(504, 25);
            this.progressBar1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 460);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 55);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "En espera";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(514, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "0%";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_Select_Directory);
            this.groupBox3.Controls.Add(this.button_Add_Products_Prestashop);
            this.groupBox3.Controls.Add(this.button_Cargar_FileCSV_Products);
            this.groupBox3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(570, 85);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acciones";
            // 
            // button_Select_Directory
            // 
            this.button_Select_Directory.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Select_Directory.Location = new System.Drawing.Point(203, 22);
            this.button_Select_Directory.Name = "button_Select_Directory";
            this.button_Select_Directory.Size = new System.Drawing.Size(169, 57);
            this.button_Select_Directory.TabIndex = 16;
            this.button_Select_Directory.Text = "Seleccionar Directorio www/pub/media de Magento 2.1.1";
            this.button_Select_Directory.UseVisualStyleBackColor = true;
            this.button_Select_Directory.Click += new System.EventHandler(this.button_Select_Imagenes_Click);
            // 
            // button_Add_Products_Prestashop
            // 
            this.button_Add_Products_Prestashop.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add_Products_Prestashop.Location = new System.Drawing.Point(392, 22);
            this.button_Add_Products_Prestashop.Name = "button_Add_Products_Prestashop";
            this.button_Add_Products_Prestashop.Size = new System.Drawing.Size(169, 57);
            this.button_Add_Products_Prestashop.TabIndex = 15;
            this.button_Add_Products_Prestashop.Text = "Insertar Productos a Prestashop";
            this.button_Add_Products_Prestashop.UseVisualStyleBackColor = true;
            this.button_Add_Products_Prestashop.Click += new System.EventHandler(this.button_Add_Products_Prestashop_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(10, 258);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(570, 196);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Registro";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.CausesValidation = false;
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(9, 21);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(552, 169);
            this.listBox1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayudaToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(589, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayudaToolStripMenuItem1
            // 
            this.ayudaToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ayudaToolStripMenuItem1.Name = "ayudaToolStripMenuItem1";
            this.ayudaToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.ayudaToolStripMenuItem1.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // comboBoxVersionMagento
            // 
            this.comboBoxVersionMagento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVersionMagento.FormattingEnabled = true;
            this.comboBoxVersionMagento.Items.AddRange(new object[] {
            "Magento 2.1.1"});
            this.comboBoxVersionMagento.Location = new System.Drawing.Point(301, 14);
            this.comboBoxVersionMagento.Name = "comboBoxVersionMagento";
            this.comboBoxVersionMagento.Size = new System.Drawing.Size(261, 23);
            this.comboBoxVersionMagento.TabIndex = 26;
            this.comboBoxVersionMagento.SelectedIndexChanged += new System.EventHandler(this.comboBoxVersionMagento_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.comboBoxVersionMagento);
            this.groupBox5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(9, 209);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(570, 43);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Versión de Magento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Versión de la tienda online en Magento";
            // 
            // FormpPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(589, 519);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(605, 700);
            this.MinimumSize = new System.Drawing.Size(605, 380);
            this.Name = "FormpPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magento 2.1.1 To Prestashop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Key_APIWEB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_URL_APIWEB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Cargar_FileCSV_Products;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_Add_Products_Prestashop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Select_Directory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxVersionMagento;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
    }
}

