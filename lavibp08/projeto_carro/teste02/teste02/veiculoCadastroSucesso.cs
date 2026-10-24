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
    public partial class veiculoCadastroSucesso : Form
    {
        public veiculoCadastroSucesso()
        {
            InitializeComponent();
        }

        private void tela16_Load(object sender, EventArgs e)
        {

        }

        private void botao30_Click(object sender, EventArgs e) //botao de conclyusao que volta pra home
        {
          
            botao30.BorderStyle = BorderStyle.Fixed3D;
            botao30.BorderStyle = BorderStyle.None;
          
            tela01 novatela = new tela01();
           
            novatela.Show();
        }

        private void menu14_Click(object sender, EventArgs e)//botao do menu
        {
          
            menu14.BorderStyle = BorderStyle.Fixed3D;
            menu14.BorderStyle = BorderStyle.None;
           
            tela10 novatela = new tela10();
        
            novatela.Show();
        }
    }
}
