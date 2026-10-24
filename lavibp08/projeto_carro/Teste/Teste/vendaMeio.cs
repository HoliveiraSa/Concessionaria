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
    public partial class vendaMeio : Form
    {
        public vendaMeio()
        {
            InitializeComponent();
        }

        private void botao13_Click(object sender, EventArgs e) //botao pra avancar pro seguro da venda
        {
            
            botao13.BorderStyle = BorderStyle.Fixed3D;
            botao13.BorderStyle = BorderStyle.None;
           
            vendaSeguro novatela = new vendaSeguro();
            
            novatela.Show();
        }

        private void botao12_Click(object sender, EventArgs e) //botao pra voltar pra iniciar a venda
        {
          this.Close();
        }

        private void menu6_Click(object sender, EventArgs e) //botao pro menu
        {
           
            menu6.BorderStyle = BorderStyle.Fixed3D;
            menu6.BorderStyle = BorderStyle.None;
            
            menu novatela = new menu();
          
            novatela.Show();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//texto onde vai a data da venda
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//texto onde vai o cpf do cliente
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//texto onde vai o cpf do vendedor
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //texto onde vai o codigo do veiculo
        {

        }

        private void botao14_Click(object sender, EventArgs e) //imagem que é pra ser um botao que vai consulta o cpf do cliente no banco de dados
        {

        }

        private void botao15_Click(object sender, EventArgs e)//imagem que é pra ser um botao que vai consulta o cpf do vendedor no banco de dados
        {

        }

        private void botao16_Click(object sender, EventArgs e) //imagem que é pra ser um botao que vai consulta o codigo do veiculo no banco de dados
        {

        }
    }
}
