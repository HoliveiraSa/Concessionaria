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
    public partial class cadastroVeiculo : Form
    {
        public cadastroVeiculo()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void botao27_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botao28_Click(object sender, EventArgs e) //botao que avanca pras especificações do veiculo
        {
            
            botao28.BorderStyle = BorderStyle.Fixed3D;
            botao28.BorderStyle = BorderStyle.None;
          
            cadastroVeiculoEspecificacoes novatela = new cadastroVeiculoEspecificacoes();
            
            novatela.Show();
        }

        private void menu12_Click(object sender, EventArgs e) //botao que vai pro menu
        {
            
            menu12.BorderStyle = BorderStyle.Fixed3D;
            menu12.BorderStyle = BorderStyle.None;
            
            tela10 novatela = new tela10();
         
            novatela.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //campo de texto do modelo
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //campo de texto do ano
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //campo de texto do chassi
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) //campo de texto da cor
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //campo de texto do valor
        {

        }
    }
}
