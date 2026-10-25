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

namespace Teste
{
    public partial class vendaSeguro : Form
    {
        public DateTime DataVenda { get; private set; }
        public string CpfCliente { get; private set; }
        public string CpfVendedor { get; private set; }
        public int CodigoVeiculo { get; private set; }
        public decimal ValorVeiculo { get; private set; }
        public vendaSeguro()
        {
            InitializeComponent();
        }
        public vendaSeguro(
       DateTime dataVenda,
       string cpfCliente,
       string cpfVendedor,
       int codigoVeiculo,
       decimal valorVeiculo) : this()
        {
            DataVenda = dataVenda;

           

            CpfCliente = cpfCliente;
            CpfVendedor = cpfVendedor;
            CodigoVeiculo = codigoVeiculo;
            ValorVeiculo = valorVeiculo;

            // Mostrar a data inicial da vigência (data da venda)
            maskedTextBox1.Text = DataVenda.ToString("dd/MM/yyyy");
            maskedTextBox1.ReadOnly = true;

            maskedTextBox1.ReadOnly = true;
            // A data final do seguro será informada pelo usuário
            maskedTextBox2.Clear();
            maskedTextBox2.ReadOnly = false;
            maskedTextBox2.Enabled = true;
            AtualizarSeguro();
        }


        private void check1_Click(object sender, EventArgs e)
        {

        }

        private void botao17_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        
       

        private void menu7_Click(object sender, EventArgs e) //checkbox de seguro, caso
        {
           
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) // valor total do seguro de acordo com a opção escolhida
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                maskedTextBox2.Clear();
            }

            AtualizarSeguro();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox3.Checked = false;
            }

            AtualizarSeguro();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
            }

            AtualizarSeguro();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //campo que vai ficar a data do inicio da vigencia ou seja data da venda
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //campo de texto que vai ficar a data final do seguro
        {

        }

        private void AtualizarSeguro()
        {
            // campos ligados so se tiver seguro
            checkBox2.Enabled = checkBox1.Checked;
            checkBox3.Enabled = checkBox1.Checked;
            maskedTextBox2.Enabled = checkBox1.Checked;

            decimal valorAdicional = 0;

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    valorAdicional = ValorVeiculo * 0.05m;
                }
                else if (checkBox3.Checked)
                {
                    valorAdicional = ValorVeiculo * 0.10m;
                }
            }

            decimal valorTotal = ValorVeiculo + valorAdicional;

            maskedTextBox3.Text = valorTotal.ToString(
                "N2",
                System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
            );

            maskedTextBox3.ReadOnly = true;
            
        }

        private void botao18_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked &&
                !checkBox2.Checked &&
                !checkBox3.Checked)
            {
                MessageBox.Show(
                    "Escolha o seguro parcial ou integral."
                );
                return;
            }

            bool possuiSeguro = checkBox1.Checked;
            string tipoSeguro = "Sem seguro";
            DateTime? dataFinalVigencia = null;

         
            if (checkBox2.Checked)
            {
                tipoSeguro = "Parcial";
            }
            else if (checkBox3.Checked)
            {
                tipoSeguro = "Integral";
            }

            
            if (possuiSeguro)
            {
                if (!DateTime.TryParseExact(
                     maskedTextBox2.Text.Trim(),
                      "dd/MM/yyyy",
                     System.Globalization.CultureInfo.InvariantCulture,
                      System.Globalization.DateTimeStyles.None,
                      out DateTime dataFinal))
                {
                    MessageBox.Show(
                        "Digite uma data final válida para o seguro."
                    );
                    return;
                }

                if (dataFinal.Date < DataVenda.Date)
                {
                    MessageBox.Show(
                        "A data final do seguro não pode ser anterior à data da venda."
                    );
                    return;
                }

                dataFinalVigencia = dataFinal;
            }

            // Calcular novamente o valor total
            decimal valorAdicional = 0;

            if (checkBox2.Checked)
            {
                valorAdicional = ValorVeiculo * 0.05m;
            }
            else if (checkBox3.Checked)
            {
                valorAdicional = ValorVeiculo * 0.10m;
            }

            decimal valorTotal = ValorVeiculo + valorAdicional;

            // Abrir o resumo enviando os dados da venda
            vendaResumo novatela = new vendaResumo(
                DataVenda,
                CpfCliente,
                CpfVendedor,
                CodigoVeiculo,
                ValorVeiculo,
                valorTotal,
                possuiSeguro,
                tipoSeguro,
                dataFinalVigencia
            );

            novatela.Show();
        }

        private void maskedTextBox2_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)//data que vai inserir pro final da vigencia
        {

        }
    }
}
