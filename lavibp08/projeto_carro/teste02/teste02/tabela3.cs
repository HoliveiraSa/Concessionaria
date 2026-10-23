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
    public partial class tabela3 : Form
    {
        public tabela3()
        {
            InitializeComponent();
        }

        private void botao34_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao34.BorderStyle = BorderStyle.Fixed3D;
            botao34.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela01 novatela = new tela01();
            //abrimos a nova tela
            novatela.Show();
        }

        private void menu18_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu18.BorderStyle = BorderStyle.Fixed3D;
            menu18.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela10 novatela = new tela10();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
