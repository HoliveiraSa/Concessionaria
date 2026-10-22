namespace Teste
{
    partial class tela09
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tela09));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.botao21 = new System.Windows.Forms.PictureBox();
            this.menu9 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.botao21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu9)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(393, 138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(559, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // botao21
            // 
            this.botao21.BackColor = System.Drawing.Color.Transparent;
            this.botao21.Image = ((System.Drawing.Image)(resources.GetObject("botao21.Image")));
            this.botao21.Location = new System.Drawing.Point(578, 397);
            this.botao21.Name = "botao21";
            this.botao21.Size = new System.Drawing.Size(190, 85);
            this.botao21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.botao21.TabIndex = 1;
            this.botao21.TabStop = false;
            this.botao21.Click += new System.EventHandler(this.botao21_Click);
            // 
            // menu9
            // 
            this.menu9.BackColor = System.Drawing.Color.Transparent;
            this.menu9.Image = ((System.Drawing.Image)(resources.GetObject("menu9.Image")));
            this.menu9.Location = new System.Drawing.Point(12, 38);
            this.menu9.Name = "menu9";
            this.menu9.Size = new System.Drawing.Size(43, 35);
            this.menu9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.menu9.TabIndex = 13;
            this.menu9.TabStop = false;
            // 
            // tela09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1384, 846);
            this.Controls.Add(this.menu9);
            this.Controls.Add(this.botao21);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1400, 885);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1400, 885);
            this.Name = "tela09";
            this.Text = "tela09";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.botao21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox botao21;
        private System.Windows.Forms.PictureBox menu9;
    }
}