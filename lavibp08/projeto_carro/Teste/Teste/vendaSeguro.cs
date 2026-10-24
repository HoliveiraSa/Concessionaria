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
    public partial class vendaSeguro : Form
    {
        public vendaSeguro()
        {
            InitializeComponent();
        }

        private void check1_Click(object sender, EventArgs e)
        {

        }

        private void botao17_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            botao17.BorderStyle = BorderStyle.Fixed3D;
            botao17.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela02 novatela = new tela02();
            //abrimos a nova tela
            novatela.Show();
        }

        
       

        private void menu7_Click(object sender, EventArgs e) //checkbox de seguro, caso
        {
           
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) // valor total do seguro de acordo com a opção escolhida
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//checkbox de segur, caso esteja desativada significa que o cliente não quer seguro, ou seja, os campos de textos nao podem estar possibilitados de escrever
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) //checkbox de seguro parcial, ele vai ficar 5% o valor do carro
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) //checkbox de seguro integral, ele vai ficar 10% o valor do carro
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //campo de texto que vai ficar o valor que a venda ta sendo realizada de acordo com o que foi colocado, ele nao pode ser alterado e tem que ja ter a data
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //campo de texto que vai ficar a data final do seguro
        {

        }
    }
}
