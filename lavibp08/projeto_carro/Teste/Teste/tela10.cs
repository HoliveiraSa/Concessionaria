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
    public partial class tela10 : Form
    {
        public tela10()
        {
            InitializeComponent();
        }

        private void home_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            home.BorderStyle = BorderStyle.Fixed3D;
            home.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela01 novatela = new tela01();
            //abrimos a nova tela
            novatela.Show();
        }

        private void vendedor_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            vendedor.BorderStyle = BorderStyle.Fixed3D;
            vendedor.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela11 novatela = new tela11();
            //abrimos a nova tela
            novatela.Show();
        }

        private void vendedores_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            vendedores.BorderStyle = BorderStyle.Fixed3D;
            vendedores.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tabela1 novatela = new tabela1();
            //abrimos a nova tela
            novatela.Show();
        }

        private void veiculo_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            veiculo.BorderStyle = BorderStyle.Fixed3D;
            veiculo.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela14 novatela = new tela14();
            //abrimos a nova tela
            novatela.Show();
        }

        private void cliente_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            cliente.BorderStyle = BorderStyle.Fixed3D;
            cliente.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela02 novatela = new tela02();
            //abrimos a nova tela
            novatela.Show();
        }

        private void venda_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            venda.BorderStyle = BorderStyle.Fixed3D;
            venda.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tela05 novatela = new tela05();
            //abrimos a nova tela
            novatela.Show();
        }

        private void veiculos_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            veiculos.BorderStyle = BorderStyle.Fixed3D;
            veiculos.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tabela2 novatela = new tabela2();
            //abrimos a nova tela
            novatela.Show();
        }

        private void clientes_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            clientes.BorderStyle = BorderStyle.Fixed3D;
            clientes.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tabela3 novatela = new tabela3();
            //abrimos a nova tela
            novatela.Show();
        }

        private void vendas_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            vendas.BorderStyle = BorderStyle.Fixed3D;
            vendas.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            tabela4 novatela = new tabela4();
            //abrimos a nova tela
            novatela.Show();
        }
    }
}
