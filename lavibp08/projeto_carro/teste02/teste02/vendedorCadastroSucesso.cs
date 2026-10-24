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
    public partial class vendedorCadastroSucesso : Form
    {
        public vendedorCadastroSucesso()
        {
            InitializeComponent();
        }

        private void botao26_Click(object sender, EventArgs e) //botao de conclusao que volta pra home
        {
           
            botao26.BorderStyle = BorderStyle.Fixed3D;
            botao26.BorderStyle = BorderStyle.None;
         
            cadastroVeiculo novatela = new cadastroVeiculo();
       
            novatela.Show();
        }

        private void menu11_Click(object sender, EventArgs e) //botao de home
        {
         
            menu11.BorderStyle = BorderStyle.Fixed3D;
            menu11.BorderStyle = BorderStyle.None;
 
            tela10 novatela = new tela10();
         
            novatela.Show();
        }
    }
}
