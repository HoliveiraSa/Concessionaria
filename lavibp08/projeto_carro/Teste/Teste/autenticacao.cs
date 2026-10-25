using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using teste02;

namespace Teste
{
    public partial class autenticacao : Form
    {
        public autenticacao()
        {
            InitializeComponent();
        }

        private void botao22_Click(object sender, EventArgs e)
        {
            string entrada = textBox1.Text.Trim();

           
            if (entrada == "0000")
            {
                AbrirTelaPrincipal();
                return;
            }

            // Remove pontos, traços e outros caracteres do CPF
            string cpf = new string(
                entrada.Where(char.IsDigit).ToArray()
            );

            // Verifica se o CPF possui 11 números
            if (cpf.Length != 11)
            {
                MessageBox.Show(
                    "Digite o código ou um CPF válido de vendedor"
                );
                return;
            }

            try
            {
                DAO bd = new DAO();

                // Consulta se o CPF pertence a um vendedor cadastrado
                DataTable resultado = bd.BuscarVendedorPorCpf(cpf);

                if (resultado.Rows.Count > 0)
                {
                    AbrirTelaPrincipal();
                }
                else
                {
                    MessageBox.Show(
                        "CPF não encontrado! Acesso negado"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao verificar o acesso:\n" + ex.Message
                );
            }
        }

        private void AbrirTelaPrincipal()
        {
            tela01 novatela = new tela01();

            this.Hide();

            novatela.ShowDialog();

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//texto onde vai a senha 0000 ou o cpf de algum vendedor
        {

        }
    }
}
