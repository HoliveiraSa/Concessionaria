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
    public partial class tabelaDeVeiculos : Form
    {
        private DAO bd = new DAO();
        public tabelaDeVeiculos()
        {
            InitializeComponent();

            //impedindo que de pra alterar pela tabela
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode =
                DataGridViewEditMode.EditProgrammatically;

            CarregarVeiculos();
        }
        private void CarregarVeiculos()
        {
            try
            {
                dataGridView1.DataSource = bd.ListarVeiculos();

                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar veículos:\n" + ex.Message
                );
            }
        }

        private void botao35_Click(object sender, EventArgs e)//botao que fecha a tela
        {
           this.Close();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//area da tabela
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string chassiDigitado;

            // abrir a tela para digitar 
            using (Chassi janelaChassi = new Chassi())
            {
                if (janelaChassi.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                chassiDigitado = janelaChassi.ChassiInformado;
            }

            try
            {
                
                DataTable resultado = bd.BuscarVeiculoPorChassi(chassiDigitado);

                if (resultado.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Nenhum veículo foi encontrado com esse chassi."
                    );
                    return;
                }

                
                using (Atualizar_veiculo tela =
                    new Atualizar_veiculo(resultado.Rows[0]))
                {
                    tela.ShowDialog(this);
                }

                CarregarVeiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao buscar veículo:\n" + ex.Message
                );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string chassiDigitado;

        
            using (Chassi janelaChassi = new Chassi())
            {
                if (janelaChassi.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                chassiDigitado = janelaChassi.ChassiInformado;
            }

            try
            {
                
                int codigoVeiculo = bd.BuscarCodigoVeiculoPorChassi(
                    chassiDigitado
                );

                if (codigoVeiculo == 0)
                {
                    MessageBox.Show(
                        "Nenhum veículo foi encontrado com esse chassi."
                    );
                    return;
                }

               
                DialogResult resposta = MessageBox.Show(
                    "Deseja realmente excluir o veículo com chassi " +
                    chassiDigitado + "?",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resposta != DialogResult.Yes)
                {
                    return;
                }

          
                int excluidos = bd.ExcluirVeiculo(codigoVeiculo);

                if (excluidos > 0)
                {
                    MessageBox.Show("Veículo excluído com sucesso!");

                    
                    CarregarVeiculos();
                }
                else
                {
                    MessageBox.Show(
                        "Não foi possível excluir o veículo."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao excluir veículo:\n" + ex.Message +
                    "\n\nSe ele estiver vinculado a uma venda, " +
                    "o banco poderá impedir a exclusão."
                );
            }
        }
    }
}
