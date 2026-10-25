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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Teste
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void home_Click(object sender, EventArgs e) //botao que vai pra home
        {
          
            home.BorderStyle = BorderStyle.Fixed3D;
            home.BorderStyle = BorderStyle.None;
            
            tela01 novatela = new tela01();
           
            novatela.Show();
        }



        private void vendedores_Click(object sender, EventArgs e) //botao que vai pra tabela de vendedores
        {

            vendedores.BorderStyle = BorderStyle.Fixed3D;
            vendedores.BorderStyle = BorderStyle.None;
            
            tabelaDeVendedores novatela = new tabelaDeVendedores();
            
            novatela.Show();
        }

        private void veiculo_Click(object sender, EventArgs e)//botao que vai pra cadastrar veiculos
        {
            veiculo.BorderStyle = BorderStyle.Fixed3D;
            veiculo.BorderStyle = BorderStyle.None;

            cadastroVeiculo novatela = new cadastroVeiculo(() =>
            {
                menu novoMenu = new menu();
                novoMenu.Show();
            });

            novatela.Show();
        }

        private void cliente_Click(object sender, EventArgs e) //botao que vai pra cadastrar clientes
        {
           
            cliente.BorderStyle = BorderStyle.Fixed3D;
            cliente.BorderStyle = BorderStyle.None;

            tela02 novatela = new tela02();
          
            novatela.Show();
        }

        private void venda_Click(object sender, EventArgs e) //botao que vai pra iniciar venda
        {
         
            venda.BorderStyle = BorderStyle.Fixed3D;
            venda.BorderStyle = BorderStyle.None;
           
            iniciarVenda novatela = new iniciarVenda();
            //abrimos a nova tela
            novatela.Show();
        }

        private void veiculos_Click(object sender, EventArgs e) //botao que vai pra tabela veiculos
        {

            veiculos.BorderStyle = BorderStyle.Fixed3D;
            veiculos.BorderStyle = BorderStyle.None;

            tabelaDeVeiculos novatela = new tabelaDeVeiculos();

            novatela.Show();
        }

        private void clientes_Click(object sender, EventArgs e) //botao que vai pra tabela de clientes
        {
          
            clientes.BorderStyle = BorderStyle.Fixed3D;
            clientes.BorderStyle = BorderStyle.None;
           
            tabelaDeClientes novatela = new tabelaDeClientes();
           
            novatela.Show();
        }

        private void vendas_Click(object sender, EventArgs e)
        {
            vendas.BorderStyle = BorderStyle.Fixed3D;
            vendas.BorderStyle = BorderStyle.None;

            tabelaDeVendas novatela = new tabelaDeVendas(() =>
            {
                using (DeletarVenda janela = new DeletarVenda())
                {
                    if (janela.ShowDialog() == DialogResult.OK)
                    {
                        return (int?)janela.CodigoInformado;
                    }

                    return null;
                }
            });

            novatela.Show();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.BorderStyle = BorderStyle.None;

            tela11 novatela = new tela11(() =>
            {
                menu novaTela = new menu();
                novaTela.Show();
            });

            novatela.Show();
        }
    }
    
}
