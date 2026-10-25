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
    public partial class enderecoVendedor : Form
    {
        private DAO bd = new DAO();
        public enderecoVendedor()
        {
            InitializeComponent();
        }
        private string nomeVendedor;
        private string telefoneVendedor;
        private string cpfVendedor;
        private string emailVendedor;

        public enderecoVendedor(
            string nome,
            string telefone,
            string cpf,
            string email) : this()
        {
            nomeVendedor = nome;
            telefoneVendedor = telefone;
            cpfVendedor = cpf;
            emailVendedor = email;
        }

        private void botao25_Click(object sender, EventArgs e) //botao que fecha
        {
           this.Close();
        }

        private void botao24_Click(object sender, EventArgs e)
        {
            botao24.BorderStyle = BorderStyle.Fixed3D;
            botao24.BorderStyle = BorderStyle.None;

            // Verificar se os dados pessoais foram recebidos
            if (string.IsNullOrWhiteSpace(nomeVendedor) ||
                string.IsNullOrWhiteSpace(cpfVendedor) ||
                string.IsNullOrWhiteSpace(emailVendedor) ||
                string.IsNullOrWhiteSpace(telefoneVendedor))
            {
                MessageBox.Show(
                    "Os dados pessoais do vendedor não foram preenchidos."
                );
                return;
            }

            // Verificar os campos do endereço
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Preencha todos os campos do endereço.");
                return;
            }

            try
            {
                // Enviar todos os dados para o banco
                bd.CadastrarVendedor(
                    cpfVendedor.Trim(),
                    nomeVendedor.Trim(),
                    emailVendedor.Trim(),
                    telefoneVendedor.Trim(),
                    textBox6.Text.Trim(), // Logradouro
                    textBox2.Text.Trim(), // Número
                    textBox1.Text.Trim(), // Bairro
                    textBox5.Text.Trim(), // Cidade
                    textBox4.Text.Trim().ToUpper(), // Estado
                    maskedTextBox1.Text.Trim()  // CEP
                );

                MessageBox.Show("Vendedor cadastrado com sucesso!");

                // Abrir a tela de sucesso somente depois de salvar
                vendedorCadastroSucesso novatela =
                    new vendedorCadastroSucesso();

                novatela.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar vendedor:\n" + ex.Message
                );
            }
        }

        

        private void textBox3_TextChanged(object sender, EventArgs e) //cep
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //bairro
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//numero
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //estado
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) //cidade
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e) //logradouro
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
