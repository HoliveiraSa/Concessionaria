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
    public partial class tela11 : Form
    {
        public tela11() => InitializeComponent();

        private void botao23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botao22_Click(object sender, EventArgs e) //botao de texto que avança pro endereço do vendedor
        {
          
            botao22.BorderStyle = BorderStyle.Fixed3D;
            botao22.BorderStyle = BorderStyle.None;
           
            enderecoVendedor novatela = new enderecoVendedor();
           
            novatela.Show();
        }

        private void menu9_Click(object sender, EventArgs e) //botao de menu
        {
            
            menu9.BorderStyle = BorderStyle.Fixed3D;
            menu9.BorderStyle = BorderStyle.None;
       
            tela10 novatela = new tela10();
           
            novatela.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //campo de textyo de nome
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //campo de texto de telefone
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //campo de texto de cpf
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//campo de texto de email
        {

        }
    }
}
