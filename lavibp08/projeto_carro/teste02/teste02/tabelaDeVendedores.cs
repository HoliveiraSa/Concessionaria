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
    public partial class tabelaDeVendedores : Form
    {
        private DAO bd = new DAO();
        public tabelaDeVendedores()
        {
            InitializeComponent();

            //impedindo
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode =
                DataGridViewEditMode.EditProgrammatically;

            CarregarVendedores();
        }

        private void CarregarVendedores()
        {
            try
            {
                dataGridView1.DataSource = bd.ListarVendedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar vendedores: " + ex.Message
                );
            }
        }

     

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void menu17_Click(object sender, EventArgs e)//botao menu
        {

        }

        private void botao33_Click(object sender, EventArgs e) //botao que volta
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string cpfDigitado;

            using (digiteCpf janelaCpf = new digiteCpf())
            {
                if (janelaCpf.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                cpfDigitado = janelaCpf.CpfInformado;
            }

            
            if (string.IsNullOrWhiteSpace(cpfDigitado) ||
                cpfDigitado.Length != 11)
            {
                MessageBox.Show("Digite um CPF válido com 11 números.");
                return;
            }

            try
            {
               
                DataTable resultado = bd.BuscarVendedorPorCpf(cpfDigitado);

                if (resultado.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Nenhum vendedor encontrado com esse CPF."
                    );
                    return;
                }

              
                using (atualizarVendedor tela =
                       new atualizarVendedor(resultado.Rows[0]))
                {
                    tela.ShowDialog(this);
                }

                
                CarregarVendedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao buscar vendedor: " + ex.Message
                );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            string cpfDigitado;

            using (digiteCpf janelaCpf = new digiteCpf())
            {
                if (janelaCpf.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                cpfDigitado = janelaCpf.CpfInformado;
            }

            
            if (string.IsNullOrWhiteSpace(cpfDigitado) ||
                cpfDigitado.Length != 11)
            {
                MessageBox.Show("Digite um CPF válido com 11 números.");
                return;
            }

            
            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir o vendedor com CPF " +
                cpfDigitado + "?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            //excluir usando o DAO
            try
            {
                int excluidos = bd.ExcluirVendedor(cpfDigitado);

                if (excluidos > 0)
                {
                    MessageBox.Show("Vendedor excluído com sucesso!");

                    // Atualizar a tabela visual
                    CarregarVendedores();
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
                    "Erro ao excluir vendedor: " + ex.Message
                );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //tabela
        {

        }
    }
}
