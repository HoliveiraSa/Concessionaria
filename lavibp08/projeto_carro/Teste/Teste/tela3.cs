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
    public partial class tela03 : Form
    {
        public tela03()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void botao6_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao6.BorderStyle = BorderStyle.Fixed3D;
            botao6.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela04 novatela = new tela04();
            //abrimos a nova tela
            novatela.Show();
        }

        private void botao7_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao7.BorderStyle = BorderStyle.Fixed3D;
            botao7.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela02 novatela = new tela02();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu3_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu3.BorderStyle = BorderStyle.Fixed3D;
            menu3.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
