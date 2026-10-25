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
    public partial class tabelaDeVendas : Form
    {
        private DAO bd = new DAO();
        private readonly Func<int?> solicitarCodigoVenda;
        public tabelaDeVendas() : this(null)
        {
        }

        public tabelaDeVendas(Func<int?> solicitarCodigoVenda)
        {
            InitializeComponent();

            this.solicitarCodigoVenda = solicitarCodigoVenda;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode =
                DataGridViewEditMode.EditProgrammatically;

            CarregarVendas();
        }

        private void CarregarVendas()
        {
            try
            {
                dataGridView1.DataSource = bd.ListarVendas();

                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar vendas:\n" + ex.Message
                );
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Solicitar o código pela tela DeletarVenda
            if (solicitarCodigoVenda == null)
            {
                MessageBox.Show(
                    "A tela para digitar o código da venda não foi configurada."
                );
                return;
            }

            int? codigoInformado = solicitarCodigoVenda();

            if (!codigoInformado.HasValue)
            {
                return;
            }

            try
            {
                // Buscar a venda pelo código digitado
                DataTable resultado =
                    bd.BuscarVendaPorCodigo(codigoInformado.Value);

                if (resultado.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Nenhuma venda foi encontrada com esse código."
                    );
                    return;
                }

                // Abrir a tela de atualização preenchida
                using (atualizarVenda tela =
                    new atualizarVenda(resultado.Rows[0]))
                {
                    tela.ShowDialog(this);
                }

                // Recarregar a tabela após a atualização
                CarregarVendas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao buscar a venda:\n" + ex.Message
                );
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
        
            if (solicitarCodigoVenda == null)
            {
                MessageBox.Show(
                    "A tela para digitar o código da venda não foi configurada."
                );
                return;
            }

            int? codigoInformado = solicitarCodigoVenda();

           
            if (!codigoInformado.HasValue)
            {
                return;
            }

            // Confirmar a exclusão
            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir a venda de código " +
                codigoInformado.Value + "?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Excluir
                int excluidos = bd.ExcluirVenda(codigoInformado.Value);

                if (excluidos > 0)
                {
                    MessageBox.Show("Venda excluída com sucesso!");

                    // Atualizar a tabela
                    CarregarVendas();
                }
                else
                {
                    MessageBox.Show(
                        "Nenhuma venda foi encontrada com esse código."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao excluir a venda:\n\n" + ex.Message,
                    "Erro na exclusão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
