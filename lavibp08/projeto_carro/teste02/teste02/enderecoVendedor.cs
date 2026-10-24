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
    public partial class enderecoVendedor : Form
    {
        public enderecoVendedor()
        {
            InitializeComponent();
        }

        private void botao25_Click(object sender, EventArgs e) //botao que fecha
        {
           this.Close();
        }

        private void botao24_Click(object sender, EventArgs e) //botao que conclui o cadastro do vendedor e leva para a tela de sucesso
        {
           
            botao24.BorderStyle = BorderStyle.Fixed3D;
            botao24.BorderStyle = BorderStyle.None;
    
            vendedorCadastroSucesso novatela = new vendedorCadastroSucesso();
          
            novatela.Show();
        }

        private void menu10_Click(object sender, EventArgs e) //botao do menu
        {
   
            menu10.BorderStyle = BorderStyle.Fixed3D;
            menu10.BorderStyle = BorderStyle.None;
           
            tela10 novatela = new tela10();
          
            novatela.Show();
        }
    }
}
