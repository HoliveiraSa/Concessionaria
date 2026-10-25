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
    public partial class clienteCadastroSucesso : Form
    {
        public clienteCadastroSucesso()
        {
            InitializeComponent();
        }

        private void botao8_Click(object sender, EventArgs e) //botao que conclui e volta pra home
        {
         this.Close();
        }

       
    }
}
