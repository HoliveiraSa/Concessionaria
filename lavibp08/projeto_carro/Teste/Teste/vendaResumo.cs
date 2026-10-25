using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using teste02;

namespace Teste
{
    public partial class vendaResumo : Form
    {
        public DateTime DataVenda { get; private set; }
        public string CpfCliente { get; private set; }
        public string CpfVendedor { get; private set; }
        public int CodigoVeiculo { get; private set; }
        public decimal ValorVeiculo { get; private set; }
        public decimal ValorTotal { get; private set; }
        public bool PossuiSeguro { get; private set; }
        public string TipoSeguro { get; private set; }
        public DateTime? DataFinalVigencia { get; private set; }
        public vendaResumo()
        {
            InitializeComponent();
        }

        public vendaResumo(
    DateTime dataVenda,
    string cpfCliente,
    string cpfVendedor,
    int codigoVeiculo,
    decimal valorVeiculo,
    decimal valorTotal,
    bool possuiSeguro,
    string tipoSeguro,
    DateTime? dataFinalVigencia) : this()
        {
            DataVenda = dataVenda;
            CpfCliente = cpfCliente;
            CpfVendedor = cpfVendedor;
            CodigoVeiculo = codigoVeiculo;
            ValorVeiculo = valorVeiculo;
            ValorTotal = valorTotal;
            PossuiSeguro = possuiSeguro;
            TipoSeguro = tipoSeguro;
            DataFinalVigencia = dataFinalVigencia;

            //mostra os campos
            maskedTextBox1.Text = cpfCliente;
            maskedTextBox2.Text = cpfVendedor;

            maskedTextBox3.Text = valorTotal.ToString(
                "N2",
                System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
            );

            // impede alterar manualemnte
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.ReadOnly = true;
            maskedTextBox3.ReadOnly = true;
        }

        private void botao19_Click(object sender, EventArgs e) 
        {
            this.Close();
        }
        private void botao20_Click(object sender, EventArgs e)
        {
            botao20.BorderStyle = BorderStyle.Fixed3D;
            botao20.BorderStyle = BorderStyle.None;

            DialogResult resposta = MessageBox.Show(
                "Deseja confirmar e registrar esta venda?",
                "Confirmar venda",
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

                //salva a venda e registros
                int codigoVenda = bd.RegistrarVendaCompleta(
                    DataVenda,
                    CpfCliente,
                    CpfVendedor,
                    CodigoVeiculo,
                    ValorVeiculo,
                    ValorTotal,
                    PossuiSeguro,
                    TipoSeguro,
                    DataFinalVigencia
                );

                MessageBox.Show(
                    "Venda registrada com sucesso!\n\n" +
                    "Código da venda: " + codigoVenda
                );

                vendaSucesso novatela = new vendaSucesso();
                novatela.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível registrar a venda:\n\n" + ex.Message,
                    "Erro ao registrar venda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //aqui é apenas para mostrar o cpf do cliente nao pode deixar alterar, é uma visualização da info que ja foi colocada
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//aqui é apenas para mostrar o cpf do vendedor nao pode deixar alterar, é uma visualização da info que ja foi colocada
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //aqui é para mostrar o valor total, do veiculo + 5% do valor do veiculo caso seja seguro parcial ou +10% do valor do veiculo caso seja integral o seguro
        {

        }
    }
}
