using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionCompte
{
    
    public partial class Form2 : Form
    {
        Form1 f = new Form1();
        ListCompte listCompte = new ListCompte();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.TextLength > 0) && (textBox2.TextLength > 0) && (textBox3.TextLength > 0))
            {
                Compte c = listCompte.rechercher(int.Parse(textBox1.Text));
                Compte cp = new Compte(int.Parse(textBox1.Text), double.Parse(textBox3.Text), textBox2.Text);
                if (ListCompte.lCompte1.Count != 0)
                    if (c == null)
                    {
                        listCompte.ajouter(cp);
                        Form1.solde = double.Parse(textBox3.Text);
                        Form1.numcompte = int.Parse(textBox1.Text);
                        Form1.titulaire = textBox2.Text;
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                    else
                        MessageBox.Show("Compte existe déja");
                else
                {
                    listCompte.ajouter(cp);
                    Form1.solde = double.Parse(textBox3.Text);
                    Form1.numcompte = int.Parse(textBox1.Text);
                    Form1.titulaire = textBox2.Text;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }

                // this.Close();
            }
            else
                MessageBox.Show("*:champs obligagoire");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true; // Set l'evenement comme etant completement fini
                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true; // Set l'evenement comme etant completement fini
                return;
            }
        }
    }
}
