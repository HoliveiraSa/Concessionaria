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

namespace Teste
{
    public partial class tela02 : Form
    {
        public tela02()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void botao5_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao5.BorderStyle = BorderStyle.Fixed3D;
            botao5.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela03 novatela = new tela03();
            //abrimos a nova tela
            novatela.Show();
        }

        private void botao4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu2_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu2.BorderStyle = BorderStyle.Fixed3D;
            menu2.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
