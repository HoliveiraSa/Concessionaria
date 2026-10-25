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
    public partial class cadastroVeiculoEspecificacoes : Form
    {
        public cadastroVeiculoEspecificacoes()
        {
            InitializeComponent();
        }
        public int CodigoVeiculo { get; private set; }

        public cadastroVeiculoEspecificacoes(int codigoVeiculo)
            : this()
        {
            CodigoVeiculo = codigoVeiculo;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tela15_Load(object sender, EventArgs e)
        {

        }

        private void botao28_Click(object sender, EventArgs e) //botao que fecha
        {
            this.Close();
        }

        private void botao29_Click(object sender, EventArgs e) //botao de conclusao
        {
            string combustivel = textBox1.Text.Trim();
            string direcao = textBox2.Text.Trim();
            string arCondicionado = textBox3.Text.Trim();
            string centralMultimidia = textBox4.Text.Trim();
            string portas = textBox5.Text.Trim();
            string quilometragemTexto = textBox6.Text.Trim();
            string bancos = textBox7.Text.Trim();

            if (string.IsNullOrWhiteSpace(combustivel) ||
                string.IsNullOrWhiteSpace(direcao) ||
                string.IsNullOrWhiteSpace(arCondicionado) ||
                string.IsNullOrWhiteSpace(centralMultimidia) ||
                string.IsNullOrWhiteSpace(portas) ||
                string.IsNullOrWhiteSpace(quilometragemTexto) ||
                string.IsNullOrWhiteSpace(bancos))
            {
                MessageBox.Show("Preencha todos os campos das especificações.");
                return;
            }

           
            string numerosQuilometragem = new string(
                quilometragemTexto.Where(char.IsDigit).ToArray()
            );

            if (!long.TryParse(numerosQuilometragem, out long quilometragem))
            {
                MessageBox.Show("Digite uma quilometragem válida.");
                return;
            }

            
            if (CodigoVeiculo <= 0)
            {
                MessageBox.Show("Não foi possível identificar o veículo cadastrado.");
                return;
            }

            try
            {
                DAO bd = new DAO();

               
                bd.CadastrarEspecificacoesVeiculo(
                    CodigoVeiculo,
                    combustivel,
                    direcao,
                    arCondicionado,
                    centralMultimidia,
                    portas,
                    quilometragem,
                    bancos
                );

                veiculoCadastroSucesso novatela =
                    new veiculoCadastroSucesso();

                novatela.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar as especificações:\n" + ex.Message
                );
            }
        }

    
        private void textBox1_TextChanged(object sender, EventArgs e) //campo de texto de combustivel
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //campo de texto de tipo de direçãp
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//campo de texto de ar condicionado
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //campo de texto de multimidia
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//campo de texto de quantidade de portas
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e) //campo de texto de quilometragem
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e) //campo de texto de bancos
        {

        }
    }
}
