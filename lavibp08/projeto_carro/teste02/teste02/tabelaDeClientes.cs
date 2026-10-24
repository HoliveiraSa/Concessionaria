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
    public partial class tabelaDeClientes : Form
    {
        public tabelaDeClientes()
        {
            InitializeComponent();
        }

        private void botao34_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu18_Click(object sender, EventArgs e) //botao de menu
        {
           
            menu18.BorderStyle = BorderStyle.Fixed3D;
            menu18.BorderStyle = BorderStyle.None;
   
            tela10 novatela = new tela10();
        
            novatela.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
