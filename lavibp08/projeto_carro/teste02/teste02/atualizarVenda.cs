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
    public partial class atualizarVenda : Form
    {

        private int codigoVenda;
        private int codigoPosVenda;
        private int? codigoSeguro;
        public atualizarVenda()
        {
            InitializeComponent();
        }
        public atualizarVenda(DataRow venda) : this()
        {
            // guardar os códigos originais
            codigoVenda = Convert.ToInt32(venda["codigo"]);
            codigoPosVenda = Convert.ToInt32(venda["posVendaCodigo"]);

            codigoSeguro = venda["seguroCodigo"] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(venda["seguroCodigo"]);

          //datas
            maskedTextBox6.Text =
                Convert.ToDateTime(venda["dataDaVenda"])
                .ToString("dd/MM/yyyy");

          
            maskedTextBox1.Text =
                venda["dataDaCompra"] == DBNull.Value
                ? ""
                : Convert.ToDateTime(venda["dataDaCompra"])
                    .ToString("dd/MM/yyyy");

            // cliente vendedor e codigo
            maskedTextBox4.Text = Convert.ToString(venda["clienteCpf"]);
            maskedTextBox5.Text = Convert.ToString(venda["vendedorCpf"]);
            textBox1.Text = Convert.ToString(venda["veiculoCodigo"]);

         //seguro
            checkBox1.Checked =
                Convert.ToInt32(venda["possuiSeguro"]) == 1;

            checkBox2.Checked =
                venda["parcial"] != DBNull.Value &&
                Convert.ToInt32(venda["parcial"]) == 1;

            checkBox3.Checked =
                venda["total"] != DBNull.Value &&
                Convert.ToInt32(venda["total"]) == 1;

            
            maskedTextBox2.Text =
                venda["dataDeFinal"] == DBNull.Value
                ? ""
                : Convert.ToDateTime(venda["dataDeFinal"])
                    .ToString("dd/MM/yyyy");

            decimal valorSeguro = venda["valorSeguro"] == DBNull.Value
                ? 0m
                : Convert.ToDecimal(venda["valorSeguro"]);

            maskedTextBox3.Text = valorSeguro.ToString(
                "N2",
                System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
            );

            // valor da venda
            decimal valorTotal = Convert.ToDecimal(venda["valorTotal"]);

            maskedTextBox7.Text = valorTotal.ToString(
                "N2",
                System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
            );
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//data do inicio da vigencia ou seja data da venda
        {

        }

        private void maskedTextBox6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//data da venda
        {

        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//cpf do cliente
        {

        }

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//cpf do vendedor
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//codigo do veiculo
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//checkbox do seguro
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)//se for parcial
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) //se for total
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//data do final da vigencia
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//valor do seguro com o do carro
        {

        }

        private void maskedTextBox7_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//valor total somando tudo
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obter os dados dos campos
            string dataVendaTexto = maskedTextBox6.Text.Trim();

            string cpfCliente = new string(
                maskedTextBox4.Text.Where(char.IsDigit).ToArray()
            );

            string cpfVendedor = new string(
                maskedTextBox5.Text.Where(char.IsDigit).ToArray()
            );

            string codigoVeiculoTexto = textBox1.Text.Trim();

            // Validar a data da venda
            if (!DateTime.TryParseExact(
                dataVendaTexto,
                "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime dataVenda))
            {
                MessageBox.Show("Digite uma data de venda válida.");
                return;
            }

            // Validar os CPFs
            if (cpfCliente.Length != 11 ||
                !long.TryParse(cpfCliente, out _))
            {
                MessageBox.Show("Digite um CPF válido para o cliente.");
                return;
            }

            if (cpfVendedor.Length != 11 ||
                !cpfVendedor.All(char.IsDigit))
            {
                MessageBox.Show("Digite um CPF válido para o vendedor.");
                return;
            }

            // Validar o código do veículo
            if (!int.TryParse(
                codigoVeiculoTexto,
                out int codigoVeiculo) ||
                codigoVeiculo <= 0)
            {
                MessageBox.Show("Digite um código de veículo válido.");
                return;
            }

            // Verificar a escolha do seguro
            bool possuiSeguro = checkBox1.Checked;
            bool seguroParcial = checkBox2.Checked;
            bool seguroIntegral = checkBox3.Checked;

            if (possuiSeguro &&
                seguroParcial == seguroIntegral)
            {
                MessageBox.Show(
                    "Escolha somente uma opção: seguro parcial ou integral."
                );
                return;
            }

            DateTime? dataInicioVigencia = null;
            DateTime? dataFinalVigencia = null;

            if (possuiSeguro)
            {
                // Se o início não estiver preenchido, usar a data da venda
                string inicioTexto = maskedTextBox1.Text.Trim();

                string digitosInicio = new string(
                    inicioTexto.Where(char.IsDigit).ToArray()
                );

                DateTime dataInicio;

                if (digitosInicio.Length == 0)
                {
                    dataInicio = dataVenda;
                }
                else if (!DateTime.TryParseExact(
                    inicioTexto,
                    "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out dataInicio))
                {
                    MessageBox.Show("Digite uma data inicial de vigência válida.");
                    return;
                }

                // Validar a data final do seguro
                if (!DateTime.TryParseExact(
                    maskedTextBox2.Text.Trim(),
                    "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime dataFinal))
                {
                    MessageBox.Show("Digite uma data final de vigência válida.");
                    return;
                }

                if (dataFinal.Date < dataInicio.Date)
                {
                    MessageBox.Show(
                        "A data final não pode ser anterior à data inicial."
                    );
                    return;
                }

                dataInicioVigencia = dataInicio;
                dataFinalVigencia = dataFinal;
            }

            // Pedir confirmação antes de salvar
            DialogResult resposta = MessageBox.Show(
                "Deseja salvar as alterações desta venda?",
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

                bd.AtualizarVendaCompleta(
                    codigoVenda,
                    codigoPosVenda,
                    codigoSeguro,
                    dataVenda,
                    dataInicioVigencia,
                    dataFinalVigencia,
                    cpfCliente,
                    cpfVendedor,
                    codigoVeiculo,
                    possuiSeguro,
                    seguroParcial,
                    seguroIntegral
                );

                MessageBox.Show("Venda atualizada com sucesso!");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao atualizar a venda:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
