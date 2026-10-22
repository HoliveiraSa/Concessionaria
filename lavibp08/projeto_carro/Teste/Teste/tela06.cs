using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste
{
    public partial class tela06 : Form
    {
        public tela06()
        {
            InitializeComponent();
        }

        private void botao13_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao13.BorderStyle = BorderStyle.Fixed3D;
            botao13.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela07 novatela = new tela07();
            //abrimos a nova tela
            novatela.Show();
        }

        private void botao12_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao12.BorderStyle = BorderStyle.Fixed3D;
            botao12.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela05 novatela = new tela05();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
