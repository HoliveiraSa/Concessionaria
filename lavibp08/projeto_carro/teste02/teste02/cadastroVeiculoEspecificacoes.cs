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
    public partial class cadastroVeiculoEspecificacoes : Form
    {
        public cadastroVeiculoEspecificacoes()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tela15_Load(object sender, EventArgs e)
        {

        }

        private void botao28_Click(object sender, EventArgs e) //botao que fecha
        {
            this.Close();
        }

        private void botao29_Click(object sender, EventArgs e) //botao que conclui o cadastro do veiculo e leva para a tela de sucesso
        {
           
            botao29.BorderStyle = BorderStyle.Fixed3D;
            botao29.BorderStyle = BorderStyle.None;

            veiculoCadastroSucesso novatela = new veiculoCadastroSucesso();
         
            novatela.Show();
        }

        private void menu13_Click(object sender, EventArgs e)//botao do menu
        {
            menu13.BorderStyle = BorderStyle.Fixed3D;
            menu13.BorderStyle = BorderStyle.None;
         
            tela10 novatela = new tela10();
            
            novatela.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //campo de texto de combustivel
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //campo de texto de tipo de direçãp
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//campo de texto de ar condicionado
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //campo de texto de multimidia
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//campo de texto de quantidade de portas
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e) //campo de texto de quilometragem
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e) //campo de texto de bancos
        {

        }
    }
}
