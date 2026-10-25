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
    public partial class AtualizarCliente : Form
    {
        private long cpfOriginal;
        private DAO bd = new DAO();
        public AtualizarCliente()
        {
            InitializeComponent();
        }
        public AtualizarCliente(DataRow cliente) : this()
        {
            cpfOriginal = Convert.ToInt64(cliente["cpf"]);

            textBox1.Text = cliente["nome"].ToString();
            textBox2.Text = cliente["email"].ToString();

            maskedTextBox1.Text = cliente["telefone"].ToString();
            maskedTextBox2.Text = cpfOriginal.ToString();

            textBox3.Text = cliente["bairro"].ToString();
            textBox4.Text = cliente["numero"].ToString();
            textBox5.Text = cliente["cep"].ToString();
            textBox6.Text = cliente["estado"].ToString();
            textBox7.Text = cliente["cidade"].ToString();
            textBox8.Text = cliente["logradouro"].ToString();
        }

        private void AtualizarCliente_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//NOME
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//bairro
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//numero
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//cep
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e) //estado
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)//cidade
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)//logradouro
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//email
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//cpf
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//telefone
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string cpfTexto = new string(
                maskedTextBox2.Text
                    .Where(char.IsDigit)
                    .ToArray()
            );

           
            if (cpfTexto.Length != 11 ||
                !long.TryParse(cpfTexto, out long cpfNovo))
            {
                MessageBox.Show("Digite um CPF com 11 números.");
                return;
            }

            
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            try
            {
             
                int alterados = bd.AtualizarCliente(
                    cpfOriginal,
                    cpfNovo,
                    textBox1.Text.Trim(),          
                    textBox2.Text.Trim(),          
                    maskedTextBox1.Text.Trim(),    
                    textBox8.Text.Trim(),          
                    textBox4.Text.Trim(),         
                    textBox3.Text.Trim(),          
                    textBox7.Text.Trim(),      
                    textBox6.Text.Trim(),         
                    textBox5.Text.Trim()          
                );

                if (alterados > 0)
                {
                    MessageBox.Show("Cliente atualizado com sucesso!");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Nenhuma alteração foi realizada. " +
                        "Confira se os dados foram modificados."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao atualizar cliente:\n" + ex.Message
                );
            }
        }
    }
}
