namespace Proyecto1_201700328
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokensHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokensXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresLexicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresLeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lexemasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expresionesRegularesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.analizarArchivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1231, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripMenuItem.Image")));
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripMenuItem.Image")));
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarComoToolStripMenuItem.Image")));
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tokensHTMLToolStripMenuItem,
            this.tokensXMLToolStripMenuItem,
            this.erroresLexicosToolStripMenuItem,
            this.erroresLeToolStripMenuItem,
            this.lexemasToolStripMenuItem,
            this.macrosToolStripMenuItem,
            this.expresionesRegularesToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // tokensHTMLToolStripMenuItem
            // 
            this.tokensHTMLToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tokensHTMLToolStripMenuItem.Image")));
            this.tokensHTMLToolStripMenuItem.Name = "tokensHTMLToolStripMenuItem";
            this.tokensHTMLToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.tokensHTMLToolStripMenuItem.Text = "Tokens HTML";
            this.tokensHTMLToolStripMenuItem.Click += new System.EventHandler(this.tokensHTMLToolStripMenuItem_Click);
            // 
            // tokensXMLToolStripMenuItem
            // 
            this.tokensXMLToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tokensXMLToolStripMenuItem.Image")));
            this.tokensXMLToolStripMenuItem.Name = "tokensXMLToolStripMenuItem";
            this.tokensXMLToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.tokensXMLToolStripMenuItem.Text = "Tokens XML";
            // 
            // erroresLexicosToolStripMenuItem
            // 
            this.erroresLexicosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("erroresLexicosToolStripMenuItem.Image")));
            this.erroresLexicosToolStripMenuItem.Name = "erroresLexicosToolStripMenuItem";
            this.erroresLexicosToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.erroresLexicosToolStripMenuItem.Text = "Errores Lexicos HTML";
            this.erroresLexicosToolStripMenuItem.Click += new System.EventHandler(this.erroresLexicosToolStripMenuItem_Click);
            // 
            // erroresLeToolStripMenuItem
            // 
            this.erroresLeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("erroresLeToolStripMenuItem.Image")));
            this.erroresLeToolStripMenuItem.Name = "erroresLeToolStripMenuItem";
            this.erroresLeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.erroresLeToolStripMenuItem.Text = "Errores Lexicos XML";
            this.erroresLeToolStripMenuItem.Click += new System.EventHandler(this.erroresLeToolStripMenuItem_Click);
            // 
            // lexemasToolStripMenuItem
            // 
            this.lexemasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lexemasToolStripMenuItem.Image")));
            this.lexemasToolStripMenuItem.Name = "lexemasToolStripMenuItem";
            this.lexemasToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.lexemasToolStripMenuItem.Text = "Lexemas";
            this.lexemasToolStripMenuItem.Click += new System.EventHandler(this.lexemasToolStripMenuItem_Click);
            // 
            // macrosToolStripMenuItem
            // 
            this.macrosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("macrosToolStripMenuItem.Image")));
            this.macrosToolStripMenuItem.Name = "macrosToolStripMenuItem";
            this.macrosToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.macrosToolStripMenuItem.Text = "Macros";
            this.macrosToolStripMenuItem.Click += new System.EventHandler(this.macrosToolStripMenuItem_Click);
            // 
            // expresionesRegularesToolStripMenuItem
            // 
            this.expresionesRegularesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("expresionesRegularesToolStripMenuItem.Image")));
            this.expresionesRegularesToolStripMenuItem.Name = "expresionesRegularesToolStripMenuItem";
            this.expresionesRegularesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.expresionesRegularesToolStripMenuItem.Text = "Expresiones Regulares";
            this.expresionesRegularesToolStripMenuItem.Click += new System.EventHandler(this.expresionesRegularesToolStripMenuItem_Click);
            // 
            // analizarArchivoToolStripMenuItem
            // 
            this.analizarArchivoToolStripMenuItem.Name = "analizarArchivoToolStripMenuItem";
            this.analizarArchivoToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.analizarArchivoToolStripMenuItem.Text = "Analizar Archivo";
            this.analizarArchivoToolStripMenuItem.Click += new System.EventHandler(this.analizarArchivoToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(22, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 363);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivo de Analisis";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(7, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(563, 337);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1151, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 68);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AccessibleDescription = "";
            this.button2.AccessibleName = "AFND";
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(1151, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 74);
            this.button2.TabIndex = 4;
            this.button2.Tag = "AFND";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(1151, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 65);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(599, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 363);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imagenes Generadas";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(1151, 320);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 41);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(1151, 367);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 38);
            this.button5.TabIndex = 8;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox2);
            this.groupBox3.Location = new System.Drawing.Point(22, 418);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1204, 240);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(7, 20);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(1190, 214);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(559, 28);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(32, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "X";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(29, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(31, 32);
            this.button7.TabIndex = 11;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 670);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tokensHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tokensXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresLexicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresLeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lexemasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expresionesRegularesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        public System.Windows.Forms.RichTextBox richTextBox2;
    }
}

