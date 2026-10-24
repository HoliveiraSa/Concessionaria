namespace teste02
{
    partial class tabelaDeVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tabelaDeVendas));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.botao31 = new System.Windows.Forms.PictureBox();
            this.menu15 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.botao31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu15)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(373, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(162, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1076, 536);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // botao31
            // 
            this.botao31.BackColor = System.Drawing.Color.Transparent;
            this.botao31.Image = ((System.Drawing.Image)(resources.GetObject("botao31.Image")));
            this.botao31.Location = new System.Drawing.Point(606, 594);
            this.botao31.Name = "botao31";
            this.botao31.Size = new System.Drawing.Size(175, 84);
            this.botao31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.botao31.TabIndex = 2;
            this.botao31.TabStop = false;
            this.botao31.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // menu15
            // 
            this.menu15.BackColor = System.Drawing.Color.Transparent;
            this.menu15.Image = ((System.Drawing.Image)(resources.GetObject("menu15.Image")));
            this.menu15.Location = new System.Drawing.Point(12, 36);
            this.menu15.Name = "menu15";
            this.menu15.Size = new System.Drawing.Size(43, 35);
            this.menu15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.menu15.TabIndex = 15;
            this.menu15.TabStop = false;
            this.menu15.Click += new System.EventHandler(this.menu15_Click);
            // 
            // tabelaDeVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1384, 846);
            this.Controls.Add(this.menu15);
            this.Controls.Add(this.botao31);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1400, 885);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1400, 885);
            this.Name = "tabelaDeVendas";
            this.Text = "tabela1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.botao31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu15)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox botao31;
        private System.Windows.Forms.PictureBox menu15;
    }
}