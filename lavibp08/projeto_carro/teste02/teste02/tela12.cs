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
    public partial class tela12 : Form
    {
        public tela12()
        {
            InitializeComponent();
        }

        private void botao25_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao25.BorderStyle = BorderStyle.Fixed3D;
            botao25.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela11 novatela = new tela11();
            //abrimos a nova tela
            novatela.Show();
        }

        private void botao24_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao24.BorderStyle = BorderStyle.Fixed3D;
            botao24.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela13 novatela = new tela13();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu10_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu10.BorderStyle = BorderStyle.Fixed3D;
            menu10.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
