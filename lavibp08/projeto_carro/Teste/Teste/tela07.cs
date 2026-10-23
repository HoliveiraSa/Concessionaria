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
    public partial class tela07 : Form
    {
        public tela07()
        {
            InitializeComponent();
        }

        private void check1_Click(object sender, EventArgs e)
        {

        }

        private void botao17_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao17.BorderStyle = BorderStyle.Fixed3D;
            botao17.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela02 novatela = new tela02();
            //abrimos a nova tela
            novatela.Show();
        }

        private void botao18_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao18.BorderStyle = BorderStyle.Fixed3D;
            botao18.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela08 novatela = new tela08();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu7_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu7.BorderStyle = BorderStyle.Fixed3D;
            menu7.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
