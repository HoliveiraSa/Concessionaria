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
    public partial class iniciarVenda : Form
    {
        public iniciarVenda()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e) //botao que cancela a venda
        {
            this.Close();

        }

        private void botao10_Click(object sender, EventArgs e) //botao que vai pro cadastro de cliente
        {
  
            botao10.BorderStyle = BorderStyle.Fixed3D;
            botao10.BorderStyle = BorderStyle.None;
           
            tela02 novatela = new tela02();
          
            novatela.Show();
        }

        private void botao11_Click(object sender, EventArgs e) //botao que continua a venda caso cliente ja tenha cadastro
        {
            
            botao11.BorderStyle = BorderStyle.Fixed3D;
            botao11.BorderStyle = BorderStyle.None;
            
            vendaMeio novatela = new vendaMeio();
           
            novatela.Show();
        }

        private void menu5_Click(object sender, EventArgs e) //botao pro menu
        {
         
            menu5.BorderStyle = BorderStyle.Fixed3D;
            menu5.BorderStyle = BorderStyle.None;
   
            menu novatela = new menu();
        
            novatela.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
