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
using System.Globalization;

namespace teste02
{
    public partial class cadastroVeiculo : Form
    {
        private readonly Action abrirMenu;

        public cadastroVeiculo() : this(null)
        {
        }

        public cadastroVeiculo(Action abrirMenu)
        {
            InitializeComponent();
            this.abrirMenu = abrirMenu;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void botao27_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botao28_Click(object sender, EventArgs e)
        {
            string modelo = textBox1.Text.Trim();
            string anoTexto = textBox3.Text.Trim();
            string chassi = textBox4.Text.Trim();
            string cor = textBox5.Text.Trim();
            string valorTexto = maskedTextBox2.Text.Trim();

            // Verificar se todos os campos foram preenchidos
            if (string.IsNullOrWhiteSpace(modelo) ||
                string.IsNullOrWhiteSpace(anoTexto) ||
                string.IsNullOrWhiteSpace(chassi) ||
                string.IsNullOrWhiteSpace(cor) ||
                string.IsNullOrWhiteSpace(valorTexto))
            {
                MessageBox.Show("Preencha todos os campos do veículo.");
                return;
            }

            // Validar o ano
            if (!int.TryParse(anoTexto, out int ano))
            {
                MessageBox.Show("Digite um ano válido.");
                return;
            }

            // Validar o valor do veículo
            if (!decimal.TryParse(
                valorTexto,
                NumberStyles.Currency,
                CultureInfo.GetCultureInfo("pt-BR"),
                out decimal valor) || valor < 0)
            {
                MessageBox.Show("Digite um valor válido para o veículo.");
                return;
            }

            try
            {
                DAO bd = new DAO();

                // Salvar o veículo e receber o código gerado pelo MySQL
                int codigoVeiculo = bd.CadastrarVeiculo(
                    chassi,
                    modelo,
                    ano,
                    cor,
                    valor
                );

                // Abrir a tela de especificações com o código do veículo
                cadastroVeiculoEspecificacoes novatela =
                    new cadastroVeiculoEspecificacoes(codigoVeiculo);

                novatela.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar veículo:\n" + ex.Message
                );
            }
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //campo de texto do modelo
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //campo de texto do ano
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //campo de texto do chassi
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) //campo de texto da cor
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //campo de texto do valor
        {

        }
    }
}
