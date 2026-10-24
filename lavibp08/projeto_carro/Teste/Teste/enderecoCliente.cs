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

        private void textBox5_TextChanged(object sender, EventArgs e)//texto onde vai a cidade para cadastro do cliente
        {

        }

        private void botao6_Click(object sender, EventArgs e) //botao de concluir
        {
          
            botao6.BorderStyle = BorderStyle.Fixed3D;
            botao6.BorderStyle = BorderStyle.None;
           
            clienteCadastroSucesso novatela = new clienteCadastroSucesso();
            
            novatela.Show();
        }

        private void botao7_Click(object sender, EventArgs e) //botao de voltar
        {

            this.Close();
        }

        private void menu3_Click(object sender, EventArgs e) //botao do menu
        {
          
            menu3.BorderStyle = BorderStyle.Fixed3D;
            menu3.BorderStyle = BorderStyle.None;
           
            menu novatela = new menu();
           
            novatela.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//texto onde vai o bairro para cadastro do cliente
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//texto onde vai o numero para cadastro do cliente
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//texto onde vai o estado para cadastro do cliente
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e) //texto onde vai o logradouro para cadastro do cliente
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//texto onde vai o cep para cadastro do cliente
        {

        }
    }
}
