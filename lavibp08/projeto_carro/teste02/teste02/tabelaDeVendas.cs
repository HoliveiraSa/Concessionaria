using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace teste02
{
    public partial class tabelaDeVendas : Form
    {
        public tabelaDeVendas()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e) //botao que fecha a tela
        {
            this.Close();
        }
     
        private void menu15_Click(object sender, EventArgs e) //botao de menu
        {
            
            menu15.BorderStyle = BorderStyle.Fixed3D;
            menu15.BorderStyle = BorderStyle.None;
          
            tela10 novatela = new tela10();
        
            novatela.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
