using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste02
{
    public partial class tabelaDeVendedores : Form
    {
        public tabelaDeVendedores()
        {
            InitializeComponent();
        }

        private void botao32_Click(object sender, EventArgs e) //botao que fecha
        {
          this.Close();
        }

        private void menu15_Click(object sender, EventArgs e) //botao que vai pro menu
        {
            menu17.BorderStyle = BorderStyle.Fixed3D;
            menu17.BorderStyle = BorderStyle.None;
     
            tela10 novatela = new tela10();
            
            novatela.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void menu17_Click(object sender, EventArgs e)
        {

        }
    }
}
