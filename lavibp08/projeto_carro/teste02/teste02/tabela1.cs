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
    public partial class tabela1 : Form
    {
        public tabela1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {//botao31
         //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao31.BorderStyle = BorderStyle.Fixed3D;
            botao31.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela01 novatela = new tela01();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu15_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu15.BorderStyle = BorderStyle.Fixed3D;
            menu15.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
