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
    public partial class tela15 : Form
    {
        public tela15()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tela15_Load(object sender, EventArgs e)
        {

        }

        private void botao28_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao28.BorderStyle = BorderStyle.Fixed3D;
            botao28.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela14 novatela = new tela14();
            //abrimos a nova tela
            novatela.Show();
        }

        private void botao29_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao29.BorderStyle = BorderStyle.Fixed3D;
            botao29.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela16 novatela = new tela16();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu13_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu13.BorderStyle = BorderStyle.Fixed3D;
            menu13.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
