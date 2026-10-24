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

namespace Teste
{
    public partial class vendaResumo : Form
    {
        public vendaResumo()
        {
            InitializeComponent();
        }

        private void botao19_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void botao20_Click(object sender, EventArgs e) //conclui a venda e salva todos os dados inseridos no banco de dados, e abre a tela de venda concluida
        {
          
            botao20.BorderStyle = BorderStyle.Fixed3D;
            botao20.BorderStyle = BorderStyle.None;
            
            vendaSucesso novatela = new vendaSucesso();
            
            novatela.Show();
        }

        private void menu8_Click(object sender, EventArgs e)
        {
            //botao de clique, o código aqui dentro roda quando o usuário clica na foto
            menu8.BorderStyle = BorderStyle.Fixed3D;
            menu8.BorderStyle = BorderStyle.None;
            //criamos uma nova instância da tela de destino
            menu novatela = new menu();
            //abrimos a nova tela
            novatela.Show();
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
