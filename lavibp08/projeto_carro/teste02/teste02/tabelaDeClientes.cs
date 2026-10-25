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
using teste02;


namespace teste02
{
   
    public partial class tabelaDeClientes : Form
    {
        private DAO bd = new DAO();
        public tabelaDeClientes()
        {
            InitializeComponent();

            //impedindo
            tabelaCliente.ReadOnly = true;
            tabelaCliente.AllowUserToAddRows = false;
            tabelaCliente.AllowUserToDeleteRows = false;
            tabelaCliente.EditMode =
                DataGridViewEditMode.EditProgrammatically;

            CarregarClientes();
        }

        private void CarregarClientes()
        {
            try
            {
                tabelaCliente.DataSource = bd.ListarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar clientes: " + ex.Message
                );
            }
        }

        private void botao34_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                bd.TestarConexao();

                MessageBox.Show("Conexão funcionando!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)//botao de atualizar um cliente tabela de clientes
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

           
            if (!long.TryParse(cpfDigitado, out long cpf))
            {
                MessageBox.Show("CPF inválido.");
                return;
            }

            try
            {
               
                DataTable resultado = bd.BuscarClientePorCpf(cpf);

                if (resultado.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Nenhum cliente encontrado com esse CPF."
                    );
                    return;
                }

               
                using (AtualizarCliente tela =
                       new AtualizarCliente(resultado.Rows[0]))
                {
                    tela.ShowDialog(this);
                }

              
                CarregarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao buscar cliente: " + ex.Message
                );
            }
        }







        private void button3_Click(object sender, EventArgs e)
        {
            // abre a janela
            using (digiteCpf janelaCpf = new digiteCpf())
            {
             
                if (janelaCpf.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                // recebendo
                string cpfTexto = janelaCpf.CpfInformado;

                if (!long.TryParse(cpfTexto, out long cpf))
                {
                    MessageBox.Show("CPF inválido.");
                    return;
                }

                // pede a confirmação
                DialogResult resposta = MessageBox.Show(
                    "Deseja realmente excluir o cliente com CPF " +
                    cpfTexto + "?",
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
                    // agora é a exclusão
                    int excluidos = bd.ExcluirCliente(cpf);

                    if (excluidos > 0)
                    {
                        MessageBox.Show("Cliente excluído com sucesso!");

                       
                        CarregarClientes();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Não foi encontrado um cliente com esse CPF."
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao excluir cliente: " + ex.Message
                    );
                }
            }
        }
        private void tabelaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
