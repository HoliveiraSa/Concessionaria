namespace teste02
{
    partial class tabelaDeVeiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tabelaDeVeiculos));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.botao35 = new System.Windows.Forms.PictureBox();
            this.menu19 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.botao35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu19)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(369, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(185, 219);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1017, 402);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // botao35
            // 
            this.botao35.BackColor = System.Drawing.Color.Transparent;
            this.botao35.Image = ((System.Drawing.Image)(resources.GetObject("botao35.Image")));
            this.botao35.Location = new System.Drawing.Point(586, 627);
            this.botao35.Name = "botao35";
            this.botao35.Size = new System.Drawing.Size(186, 80);
            this.botao35.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.botao35.TabIndex = 2;
            this.botao35.TabStop = false;
            this.botao35.Click += new System.EventHandler(this.botao35_Click);
            // 
            // menu19
            // 
            this.menu19.BackColor = System.Drawing.Color.Transparent;
            this.menu19.Image = ((System.Drawing.Image)(resources.GetObject("menu19.Image")));
            this.menu19.Location = new System.Drawing.Point(12, 40);
            this.menu19.Name = "menu19";
            this.menu19.Size = new System.Drawing.Size(43, 35);
            this.menu19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.menu19.TabIndex = 17;
            this.menu19.TabStop = false;
            this.menu19.Click += new System.EventHandler(this.menu19_Click);
            // 
            // tabelaDeVeiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1384, 846);
            this.Controls.Add(this.menu19);
            this.Controls.Add(this.botao35);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1400, 885);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1400, 885);
            this.Name = "tabelaDeVeiculos";
            this.Text = "tabela4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.botao35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu19)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox botao35;
        private System.Windows.Forms.PictureBox menu19;
    }
}