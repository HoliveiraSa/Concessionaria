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
    public partial class tabela2 : Form
    {
        public tabela2()
        {
            InitializeComponent();
        }

        private void botao32_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao33.BorderStyle = BorderStyle.Fixed3D;
            botao33.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela01 novatela = new tela01();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu15_Click(object sender, EventArgs e)
        {//botao17
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu17.BorderStyle = BorderStyle.Fixed3D;
            menu17.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
