using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste02
{

    public partial class digiteCpf : Form
    {
        public string CpfInformado { get; private set; }
        public digiteCpf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // so pega nuemros
            string cpf = new string(
                maskedTextBox1.Text
                    .Where(char.IsDigit)
                    .ToArray()
            );

            // verificando
            if (cpf.Length != 11)
            {
                MessageBox.Show("Digite um CPF com 11 números.");
                return;
            }

           
            CpfInformado = cpf;
       
            this.DialogResult = DialogResult.OK;

            
            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //LOCAL que vai digitar o cpf do cliente 
        {

        }

        private void pergunta_Click(object sender, EventArgs e)
        {

        }
    }
}
