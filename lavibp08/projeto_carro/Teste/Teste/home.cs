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
    public partial class tela01 : Form
    {
        public tela01()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) //botao pro menu de cadastro
        {
           
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.BorderStyle = BorderStyle.None;
            
            menu novatela = new menu();
           
            novatela.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        private void botao2_Click(object sender, EventArgs e) //botao de inicio de venda
        {
          
            botao2.BorderStyle = BorderStyle.Fixed3D;
            botao2.BorderStyle = BorderStyle.None;
            
            iniciarVenda novatela = new iniciarVenda();
            
            novatela.Show();
        }

        private void menu1_Click(object sender, EventArgs e) // botao que abre o menu
        {
          
            menu1.BorderStyle = BorderStyle.Fixed3D;
            menu1.BorderStyle = BorderStyle.None;
           
            menu novatela = new menu();
           
            novatela.Show();
        }

        private void botao3_Click(object sender, EventArgs e) // botao que vai pra tabela veiculos
        {
         
            botao3.BorderStyle = BorderStyle.Fixed3D;
            botao3.BorderStyle = BorderStyle.None;
          
            tabelaDeVeiculos novatela = new tabelaDeVeiculos();
            
            novatela.Show();
        }
    }
}
