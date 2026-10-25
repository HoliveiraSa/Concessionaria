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
           this.Close();
        }


    }
}
