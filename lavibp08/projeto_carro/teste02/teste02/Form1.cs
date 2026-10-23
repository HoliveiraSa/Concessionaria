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
    public partial class tela11 : Form
    {
        public tela11() => InitializeComponent();

        private void botao23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botao22_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao22.BorderStyle = BorderStyle.Fixed3D;
            botao22.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela12 novatela = new tela12();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu9_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu9.BorderStyle = BorderStyle.Fixed3D;
            menu9.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
