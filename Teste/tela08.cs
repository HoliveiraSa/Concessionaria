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
    public partial class tela08 : Form
    {
        public tela08()
        {
            InitializeComponent();
        }

        private void botao19_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao19.BorderStyle = BorderStyle.Fixed3D;
            botao19.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela07 novatela = new tela07();
            //abrimos a nova tela
            novatela.Show();
        }

        private void botao20_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao20.BorderStyle = BorderStyle.Fixed3D;
            botao20.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela09 novatela = new tela09();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
