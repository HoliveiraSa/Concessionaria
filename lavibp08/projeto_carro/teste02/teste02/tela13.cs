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
    public partial class tela13 : Form
    {
        public tela13()
        {
            InitializeComponent();
        }

        private void botao26_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao26.BorderStyle = BorderStyle.Fixed3D;
            botao26.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela14 novatela = new tela14();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu11_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu11.BorderStyle = BorderStyle.Fixed3D;
            menu11.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
