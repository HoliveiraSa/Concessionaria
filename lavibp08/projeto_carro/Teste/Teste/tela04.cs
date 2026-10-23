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
    public partial class tela04 : Form
    {
        public tela04()
        {
            InitializeComponent();
        }

        private void botao8_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao8.BorderStyle = BorderStyle.Fixed3D;
            botao8.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela05 novatela = new tela05();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu4_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu4.BorderStyle = BorderStyle.Fixed3D;
            menu4.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
