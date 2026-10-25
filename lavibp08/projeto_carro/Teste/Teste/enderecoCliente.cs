using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using teste02;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Teste
{
    public partial class tela03 : Form
    {
        private DAO bd = new DAO();
        public tela03()
        {
            InitializeComponent();
        }
        private string nomeCliente;
        private string telefoneCliente;
        private string cpfCliente;
        private string emailCliente;

        public tela03(
            string nome,
            string telefone,
            string cpf,
            string email) : this()
        {
            nomeCliente = nome;
            telefoneCliente = telefone;
            cpfCliente = cpf;
            emailCliente = email;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//texto onde vai a cidade para cadastro do cliente
        {

        }

        private void botao6_Click(object sender, EventArgs e)
        {
            botao6.BorderStyle = BorderStyle.Fixed3D;
            botao6.BorderStyle = BorderStyle.None;

            // verificar se os campos foram preenchidos, lembrar de oclocar o erro
            if (string.IsNullOrWhiteSpace(nomeCliente) ||
                string.IsNullOrWhiteSpace(telefoneCliente) ||
                string.IsNullOrWhiteSpace(cpfCliente) ||
                string.IsNullOrWhiteSpace(emailCliente) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            
            string cpfNumeros = new string(
                cpfCliente.Where(char.IsDigit).ToArray()
            );

            if (cpfNumeros.Length != 11 ||
                !long.TryParse(cpfNumeros, out long cpfConvertido))
            {
                MessageBox.Show("Digite um CPF válido com 11 números.");
                return;
            }

            // enviar os dados para o banco
            try
            {
                bd.CadastrarCliente(
                    cpfConvertido,
                    nomeCliente.Trim(),
                    emailCliente.Trim(),
                    telefoneCliente.Trim(),
                    textBox6.Text.Trim(),       // Logradouro
                    textBox2.Text.Trim(),       // Número
                    textBox1.Text.Trim(),       // Bairro
                    textBox5.Text.Trim(),       // Cidade
                    textBox4.Text.Trim(),       // Estado
                    maskedTextBox1.Text.Trim()  // CEP
                );

                //abre a tela de sucesso somente após salvar
                clienteCadastroSucesso novatela =
                    new clienteCadastroSucesso();

                novatela.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar o cliente:\n" + ex.Message
                );
            }
        }

        private void botao7_Click(object sender, EventArgs e) //botao de voltar
        {

            this.Close();
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
