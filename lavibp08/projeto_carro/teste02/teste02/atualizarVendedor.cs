using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste02
{
    public partial class atualizarVendedor : Form
    {
        private string cpfOriginal;
        private DAO bd = new DAO();
        public atualizarVendedor()
        {
            InitializeComponent();
        }
        public atualizarVendedor(DataRow vendedor) : this()
        {
            // Guardar o CPF original para localizar o registro na atualização
            cpfOriginal = Convert.ToString(vendedor["cpf"]);

            // Dados pessoais
            textBox2.Text = vendedor["nome"].ToString();
            textBox3.Text = vendedor["email"].ToString();
            maskedTextBox3.Text = vendedor["telefone"].ToString();
            maskedTextBox1.Text = cpfOriginal;

            // Endereço
            textBox9.Text = vendedor["logradouro"].ToString();
            textBox5.Text = vendedor["numero"].ToString();
            textBox4.Text = vendedor["bairro"].ToString();
            textBox8.Text = vendedor["cidade"].ToString();
            textBox7.Text = vendedor["estado"].ToString();
            maskedTextBox2.Text = vendedor["cep"].ToString();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)//logradouro
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //cep
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//numero
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //bairro
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e) //estado
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e) //cidade
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//nome
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //telefone
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //cpf
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //email
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Pegar o CPF novo, mantendo somente os números
            string cpfNovo = new string(
                maskedTextBox1.Text
                    .Where(char.IsDigit)
                    .ToArray()
            );

            // 2. Validar o CPF
            if (cpfNovo.Length != 11)
            {
                MessageBox.Show("O CPF deve conter exatamente 11 números.");
                return;
            }

            // 3. Verificar se todos os campos obrigatórios foram preenchidos
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox2.Text))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            // 4. Confirmar as alterações
            DialogResult resposta = MessageBox.Show(
                "Deseja salvar as alterações deste vendedor?",
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
                int alterados = bd.AtualizarVendedor(
                    cpfOriginal,
                    cpfNovo,
                    textBox2.Text.Trim(),        
                    textBox3.Text.Trim(),         
                    maskedTextBox3.Text.Trim(),   
                    textBox9.Text.Trim(),         
                    textBox5.Text.Trim(),
                    textBox4.Text.Trim(),         
                    textBox8.Text.Trim(),         
                    textBox7.Text.Trim().ToUpper(), 
                    maskedTextBox2.Text.Trim()   
                );

                if (alterados > 0)
                {
                    MessageBox.Show("Vendedor atualizado com sucesso!");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Nenhuma alteração foi detectada. " +
                        "Confira os dados ou tente modificar algum campo."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao atualizar vendedor:\n" + ex.Message
                );
            }
        }
    }
}
