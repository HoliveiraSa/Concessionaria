using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace teste02
{
    public partial class Atualizar_veiculo : Form
    {
        private int codigoVeiculo;
        private int codigoEspecificacao;
        public Atualizar_veiculo()
        {
            InitializeComponent();
        }
        public Atualizar_veiculo(DataRow veiculo) : this()
        {
            codigoVeiculo = Convert.ToInt32(veiculo["codigo"]);

            codigoEspecificacao =
                veiculo["especificacaoCodigo"] == DBNull.Value
                ? 0
                : Convert.ToInt32(veiculo["especificacaoCodigo"]);

            // Dados do veículo
            textBox1.Text = Convert.ToString(veiculo["modelo"]);
            textBox2.Text = Convert.ToString(veiculo["ano"]);
            textBox3.Text = Convert.ToString(veiculo["chassi"]);
            textBox4.Text = Convert.ToString(veiculo["cor"]);
            maskedTextBox1.Text = Convert.ToString(veiculo["valor"]);

            // Especificações
            textBox5.Text = Convert.ToString(veiculo["combustivel"]);
            textBox6.Text = Convert.ToString(veiculo["direcao"]);
            textBox7.Text = Convert.ToString(veiculo["arCondicionado"]);
            textBox8.Text = Convert.ToString(veiculo["centralMultimidia"]);
            textBox9.Text = Convert.ToString(veiculo["portas"]);
            textBox10.Text = Convert.ToString(veiculo["quilometragem"]);
            textBox11.Text = Convert.ToString(veiculo["bancos"]);
        }

        private void Atualizar_veiculo_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //modelo
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//valor
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //ano
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //chassi
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //cor
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) //combustivel
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e) //direcao
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e) //ar condicionado
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)//central multimidia
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)//portas
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)//quilometragem
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string modelo = textBox1.Text.Trim();
            string anoTexto = textBox2.Text.Trim();
            string chassi = textBox3.Text.Trim();
            string cor = textBox4.Text.Trim();

            string combustivel = textBox5.Text.Trim();
            string direcao = textBox6.Text.Trim();
            string arCondicionado = textBox7.Text.Trim();
            string centralMultimidia = textBox8.Text.Trim();
            string portas = textBox9.Text.Trim();
            string quilometragemTexto = textBox10.Text.Trim();
            string bancos = textBox11.Text.Trim();
            string valorTexto = maskedTextBox1.Text.Trim();

            // Verificar se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(modelo) ||
                string.IsNullOrWhiteSpace(anoTexto) ||
                string.IsNullOrWhiteSpace(chassi) ||
                string.IsNullOrWhiteSpace(cor) ||
                string.IsNullOrWhiteSpace(valorTexto) ||
                string.IsNullOrWhiteSpace(combustivel) ||
                string.IsNullOrWhiteSpace(direcao) ||
                string.IsNullOrWhiteSpace(arCondicionado) ||
                string.IsNullOrWhiteSpace(centralMultimidia) ||
                string.IsNullOrWhiteSpace(portas) ||
                string.IsNullOrWhiteSpace(quilometragemTexto) ||
                string.IsNullOrWhiteSpace(bancos))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            // Validar o ano
            if (!int.TryParse(anoTexto, out int ano))
            {
                MessageBox.Show("Digite um ano válido.");
                return;
            }

            // Validar o valor em reais
            if (!decimal.TryParse(
                valorTexto,
                NumberStyles.Currency,
                CultureInfo.GetCultureInfo("pt-BR"),
                out decimal valor) || valor < 0)
            {
                MessageBox.Show("Digite um valor válido para o veículo.");
                return;
            }

            // Validar a quilometragem
            string numerosKm = new string(
                quilometragemTexto.Where(char.IsDigit).ToArray()
            );

            if (!long.TryParse(numerosKm, out long quilometragem))
            {
                MessageBox.Show("Digite uma quilometragem válida.");
                return;
            }

            // Confirmar a atualização
            DialogResult resposta = MessageBox.Show(
                "Deseja salvar as alterações deste veículo?",
                "Confirmar atualização",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                DAO bd = new DAO();

                bd.AtualizarVeiculo(
                    codigoVeiculo,
                    codigoEspecificacao,
                    modelo,
                    ano,
                    chassi,
                    cor,
                    valor,
                    combustivel,
                    direcao,
                    arCondicionado,
                    centralMultimidia,
                    portas,
                    quilometragem,
                    bancos
                );

                MessageBox.Show("Veículo atualizado com sucesso!");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao atualizar veículo:\n" + ex.Message
                );
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)//bancos
        {

        }
    }
}
