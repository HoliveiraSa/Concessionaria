using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste
{
    public partial class DeletarVenda : Form
    {
        public int CodigoInformado { get; private set; }
        public DeletarVenda()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//campo do codigo
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = textBox1.Text.Trim();

            if (!int.TryParse(texto, out int codigo) || codigo <= 0)
            {
                MessageBox.Show("Digite um código de venda válido.");
                return;
            }

            CodigoInformado = codigo;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pergunta_Click(object sender, EventArgs e)
        {

        }
    }
}
