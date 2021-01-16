using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace GestionCompte
{
    public partial class Form1 : Form
    {
        public static int numcompte;
        public static double solde;
        public static string titulaire;
       // Compte cp = new Compte();
        ListCompte listCompte = new ListCompte();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mouvements mv = new Mouvements();
            dataGridView3.Rows.Clear();
            DateTime dateFinMouv, dateDebutMouv;
            dateDebutMouv = Convert.ToDateTime( dateTimePicker2.Text);
            dateFinMouv = Convert.ToDateTime(dateTimePicker3.Text);
            if (textBox8.TextLength > 0)
                for (int i = 0; i < Mouvements.listMouvements.Count; i++)
                {
                    if ((Mouvements.listMouvements[i].dateop.Date >= dateDebutMouv.Date)
                        && Mouvements.listMouvements[i].dateop.Date <= dateFinMouv.Date 
                        && Mouvements.listMouvements[i].numC == int.Parse(textBox8.Text))
                    {
                        if (Mouvements.listMouvements[i].typeop.Equals("versement"))
                            dataGridView3.Rows.Add(Mouvements.listMouvements[i].dateop,
                                 Mouvements.listMouvements[i].typeop,
                                 Mouvements.listMouvements[i].montant);
                        else
                            dataGridView3.Rows.Add(Mouvements.listMouvements[i].dateop,
                                 Mouvements.listMouvements[i].typeop, "",
                                 Mouvements.listMouvements[i].montant);

                    }
                   
                }
            else
                MessageBox.Show("veillez donner le numero du compte");
        }
        public void ajout()
        {
            textBox1.Text = titulaire;
            dataGridView2.Rows.Add(23, 56, "rr");

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Form2 f = new Form2();
            f.ShowDialog();
            for (int k = 0; k < ListCompte.lCompte1.Count; k++)
                dataGridView1.Rows.Add(ListCompte.lCompte1.ElementAt(k).numcompte,
                     ListCompte.lCompte1.ElementAt(k).titulaire, ListCompte.lCompte1.ElementAt(k).solde);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            String numc = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            
            String titul = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            String solde = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
           // Compte c = new Compte(int.Parse(numc), double.Parse(solde), titul);
            Compte c = listCompte.rechercher(int.Parse(numc));
            listCompte.supprimer(c);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                Compte cp = listCompte.rechercher(int.Parse(textBox1.Text));
                if (cp != null)
                {
                    textBox2.Text = cp.titulaire;
                    textBox3.Text = cp.solde.ToString();
                }
                else MessageBox.Show("introuvable:" + ListCompte.lCompte1.Count);
            }
            else
                MessageBox.Show("velliez saisir le numero du compte a chercher");

        }
        
                private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
  
        }
            

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox4.TextLength > 0)
            {
          
                    if (e.KeyCode == Keys.Enter)
                {
                    int numc;
                    try { 
                    numc = int.Parse(textBox4.Text);
                        Compte c = listCompte.rechercher(numc);
                    
                    if (c != null)
                    {
                        textBox5.Text = c.titulaire;
                        textBox6.Text = c.solde.ToString();
                    }
                    else
                        MessageBox.Show("compte introuvable");
                    }
                    catch (Exception e1) { MessageBox.Show("les numero de compte sont des nombres entier"); }

                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox7.TextLength > 0)&&(textBox4.TextLength > 0)) { 
                Mouvements mv;
            int numc = int.Parse(textBox4.Text);
            Compte c = listCompte.rechercher(numc);
            
                if (radioButton1.Checked)//retrait
                {
                    if (c.solde >= double.Parse(textBox7.Text))
                    {
                        mv = new Mouvements(dateTimePicker1.Value, double.Parse(textBox7.Text), "retrait", c.numcompte);
                        dataGridView2.Rows.Add(c.numcompte, mv.dateop, mv.typeop, mv.montant);
                        mv.ajoutMouv(mv);
                        c.solde = c.solde - double.Parse(textBox7.Text);
                        int index = ListCompte.lCompte1.IndexOf(c);
                        listCompte.supprimer(c);
                        ListCompte.lCompte1.Insert(index, c);
                    }
                    else
                        MessageBox.Show("solde insuffisant");
                }
                else
                { //versement
                    mv = new Mouvements(dateTimePicker1.Value, double.Parse(textBox7.Text), "versement", c.numcompte);
                    mv.ajoutMouv(mv);
                    c.solde = c.solde + double.Parse(textBox7.Text);
                    int index = ListCompte.lCompte1.IndexOf(c);
                    listCompte.supprimer(c);
                    ListCompte.lCompte1.Insert(index, c);
                    dataGridView2.Rows.Add(c.numcompte, mv.dateop, mv.typeop, mv.montant);
                }
            
            //recharger le datagridview1 par la nouvelle liste
            dataGridView1.Rows.Clear();
            for (int k = 0; k < ListCompte.lCompte1.Count; k++)
                dataGridView1.Rows.Add(ListCompte.lCompte1.ElementAt(k).numcompte,
                     ListCompte.lCompte1.ElementAt(k).titulaire, ListCompte.lCompte1.ElementAt(k).solde);

            }
            else
                MessageBox.Show("*:champs obligatoire");
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int numc = int.Parse(textBox8.Text);
                Compte c = listCompte.rechercher(numc);
                if (c != null)
                {
                    textBox9.Text = c.titulaire;
                    textBox10.Text = c.solde.ToString();
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true; // Set l'evenement comme etant completement fini
                return;
            }
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
    }
}
