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
    public partial class autenticacao : Form
    {
        public autenticacao()
        {
            InitializeComponent();
        }

        private void botao22_Click(object sender, EventArgs e) //botao de concluir, verifica se a senha digitada é igual a 0000 ou cpf do vendedor e abre a tela de destino
        {
      
            botao22.BorderStyle = BorderStyle.Fixed3D;
            botao22.BorderStyle = BorderStyle.None;
            
            tela01 novatela = new tela01();
            
            novatela.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//texto onde vai a senha 0000 ou o cpf de algum vendedor
        {

        }
    }
}
