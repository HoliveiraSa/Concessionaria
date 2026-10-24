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
    public partial class vendaSucesso : Form
    {
        public vendaSucesso()
        {
            InitializeComponent();
        }

        private void botao21_Click(object sender, EventArgs e) //botao que conclui e volta pra home
        {
            
            botao21.BorderStyle = BorderStyle.Fixed3D;
            botao21.BorderStyle = BorderStyle.None;
           
            tela01 novatela = new tela01();
            
            novatela.Show();
        }

        private void menu9_Click(object sender, EventArgs e) //botao do menu
        {
      
            menu9.BorderStyle = BorderStyle.Fixed3D;
            menu9.BorderStyle = BorderStyle.None;
            
            menu novatela = new menu();
           
            novatela.Show();
        }
    }
}
