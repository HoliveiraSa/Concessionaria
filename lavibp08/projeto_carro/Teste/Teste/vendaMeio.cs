
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using teste02;

namespace Teste
{
    public partial class vendaMeio : Form
    {
        private DAO bd = new DAO();

        public vendaMeio()
        {
            InitializeComponent();
        }

        // Botão para voltar
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botão para avançar para a tela do seguro
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // Ler e validar a data da venda
            if (!DateTime.TryParseExact(
                maskedTextBox1.Text.Trim(),
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dataVenda))
            {
                MessageBox.Show(
                    "Digite uma data válida no formato DD/MM/AAAA."
                );
                return;
            }

            // Obter somente os números dos CPFs
            string cpfCliente = new string(
                maskedTextBox2.Text.Where(char.IsDigit).ToArray()
            );

            string cpfVendedor = new string(
                maskedTextBox3.Text.Where(char.IsDigit).ToArray()
            );

            if (cpfCliente.Length != 11 ||
                !long.TryParse(cpfCliente, out long cpfClienteNumero))
            {
                MessageBox.Show("Digite um CPF válido para o cliente.");
                return;
            }

            if (cpfVendedor.Length != 11)
            {
                MessageBox.Show("Digite um CPF válido para o vendedor.");
                return;
            }

            // Validar o código do veículo
            if (!int.TryParse(textBox3.Text.Trim(), out int codigoVeiculo)
                || codigoVeiculo <= 0)
            {
                MessageBox.Show("Digite um código de veículo válido.");
                return;
            }

            try
            {
                // Verificar se o cliente está cadastrado
                DataTable cliente =
                    bd.BuscarClientePorCpf(cpfClienteNumero);

                if (cliente.Rows.Count == 0)
                {
                    MessageBox.Show("Cliente não encontrado no banco de dados.");
                    return;
                }

                // Verificar se o vendedor está cadastrado
                DataTable vendedor =
                    bd.BuscarVendedorPorCpf(cpfVendedor);

                if (vendedor.Rows.Count == 0)
                {
                    MessageBox.Show("Vendedor não encontrado no banco de dados.");
                    return;
                }

                // Verificar se o veículo está cadastrado
                DataTable veiculo =
                    bd.BuscarVeiculoPorCodigo(codigoVeiculo);

                if (veiculo.Rows.Count == 0)
                {
                    MessageBox.Show("Veículo não encontrado no banco de dados.");
                    return;
                }

                // Obter o valor do veículo no banco
                decimal valorVeiculo = Convert.ToDecimal(
                    veiculo.Rows[0]["valor"]
                );

                // Avançar levando os dados para a próxima tela
                vendaSeguro novatela = new vendaSeguro(
                    dataVenda,
                    cpfCliente,
                    cpfVendedor,
                    codigoVeiculo,
                    valorVeiculo
                );

                novatela.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao preparar a venda:\n" + ex.Message
                );
            }
        }

        // Botão para consultar o CPF do cliente
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string cpfTexto = new string(
                maskedTextBox2.Text.Where(char.IsDigit).ToArray()
            );

            if (cpfTexto.Length != 11 ||
                !long.TryParse(cpfTexto, out long cpf))
            {
                MessageBox.Show("Digite um CPF válido para o cliente.");
                return;
            }

            try
            {
                DataTable resultado = bd.BuscarClientePorCpf(cpf);

                if (resultado.Rows.Count > 0)
                {
                    string nome = resultado.Rows[0]["nome"].ToString();

                    MessageBox.Show(
                        "Cliente encontrado!\n\nNome: " + nome
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Nenhum cliente foi encontrado com esse CPF."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao consultar cliente:\n" + ex.Message
                );
            }
        }

        // Botão para consultar o CPF do vendedor
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string cpf = new string(
                maskedTextBox3.Text.Where(char.IsDigit).ToArray()
            );

            if (cpf.Length != 11)
            {
                MessageBox.Show("Digite um CPF válido para o vendedor.");
                return;
            }

            try
            {
                DataTable resultado = bd.BuscarVendedorPorCpf(cpf);

                if (resultado.Rows.Count > 0)
                {
                    string nome = resultado.Rows[0]["nome"].ToString();

                    MessageBox.Show(
                        "Vendedor encontrado!\n\nNome: " + nome
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Nenhum vendedor foi encontrado com esse CPF."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao consultar vendedor:\n" + ex.Message
                );
            }
        }

        // Botão para consultar o código do veículo
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(
                textBox3.Text.Trim(),
                out int codigoVeiculo
            ) || codigoVeiculo <= 0)
            {
                MessageBox.Show("Digite um código de veículo válido.");
                return;
            }

            try
            {
                DataTable resultado =
                    bd.BuscarVeiculoPorCodigo(codigoVeiculo);

                if (resultado.Rows.Count > 0)
                {
                    DataRow veiculo = resultado.Rows[0];

                    string modelo = veiculo["modelo"].ToString();

                    decimal valor = Convert.ToDecimal(
                        veiculo["valor"]
                    );

                    string valorFormatado = valor.ToString(
                        "C2",
                        CultureInfo.GetCultureInfo("pt-BR")
                    );

                    MessageBox.Show(
                        "Veículo encontrado!\n\n" +
                        "Modelo: " + modelo + "\n" +
                        "Código: " + codigoVeiculo + "\n" +
                        "Valor: " + valorFormatado
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Nenhum veículo foi encontrado com esse código."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao consultar veículo:\n" + ex.Message
                );
            }
        }

        // Eventos dos campos de texto
        private void maskedTextBox1_MaskInputRejected(
            object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void maskedTextBox2_MaskInputRejected(
            object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void maskedTextBox3_MaskInputRejected(
            object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void textBox3_TextChanged(
            object sender, EventArgs e)
        {
        }
    }
}
