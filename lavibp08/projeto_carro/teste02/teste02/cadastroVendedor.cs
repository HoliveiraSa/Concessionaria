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
        private readonly Action abrirMenu;

        public tela11() : this(null)
        {
        }

        public tela11(Action abrirMenu)
        {
            InitializeComponent();
            this.abrirMenu = abrirMenu;
        }
        private void botao23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botao22_Click(object sender, EventArgs e)
        {
            botao22.BorderStyle = BorderStyle.Fixed3D;
            botao22.BorderStyle = BorderStyle.None;

            // Pegar somente os números do CPF
            string cpf = new string(
                maskedTextBox2.Text.Where(char.IsDigit).ToArray()
            );

            // Verificar se o CPF tem 11 números
            if (cpf.Length != 11)
            {
                MessageBox.Show(
                    "O CPF deve conter exatamente 11 números."
                );
                return;
            }

            // Passar os dados para a tela de endereço
            enderecoVendedor novatela = new enderecoVendedor(
                textBox1.Text,
                maskedTextBox2.Text,
                cpf,
                textBox4.Text
            );

            novatela.Show();
        }

     

        private void textBox1_TextChanged(object sender, EventArgs e) //campo de textyo de nome
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void textBox3_TextChanged(object sender, EventArgs e) //campo de texto de cpf
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//campo de texto de email
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //telefone
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //cpf
        {

        }
    }
}
