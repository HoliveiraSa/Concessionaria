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
    public partial class tela02 : Form
    {
        public tela02()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void botao5_Click(object sender, EventArgs e)//botao de avancar
        {
          
            botao5.BorderStyle = BorderStyle.Fixed3D;
            botao5.BorderStyle = BorderStyle.None;
           
            tela03 novatela = new tela03();
            
            novatela.Show();
        }

        private void botao4_Click(object sender, EventArgs e) // botao de cancelar
        {
            this.Close();
        }

        private void menu2_Click(object sender, EventArgs e) //botao menu
        {
            
            menu2.BorderStyle = BorderStyle.Fixed3D;
            menu2.BorderStyle = BorderStyle.None;
         
            menu novatela = new menu();
           
            novatela.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //texto onde vai o nome pra cadastro do cliente
        {

        }


        private void textBox4_TextChanged(object sender, EventArgs e)//texto onde vai o email pra cadastro do cliente
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//texto onde vai o telefone pra cadastro do cliente
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//texto onde vai o cpf pra cadastro do cliente
        {

        }

        private void titulo_Click(object sender, EventArgs e)
        {

        }
    }
}
