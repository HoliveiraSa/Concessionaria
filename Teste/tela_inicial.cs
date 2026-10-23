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
    public partial class tela_inicial : Form
    {
        public tela_inicial()
        {
            InitializeComponent();
        }

        private void botao22_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao22.BorderStyle = BorderStyle.Fixed3D;
            botao22.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela01 novatela = new tela01();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
