using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestBanque.Model;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TestBanque.Controleur;


namespace TestBanque.Vue
{
    public partial class Form1 : Form
    {

        List<Adherent> List_adherent;
        List<Inscription> List_inscrptions;
        Adherent adherent_Selected = new Adherent(0, null, null);
        Manager monManager = new Manager();
        Inscription Inscription_Selected = null;
        public Form1()
        {
            InitializeComponent();

        }
        private void refreshComboBox(int index)
        {
            
            comboBox1.DataSource = List_adherent;
            comboBox1.DisplayMember = "Description";



        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List_adherent = monManager.getAdherents();
            refreshComboBox(0);
        }


        private void refreshListBox(Adherent unAdh)
        {

            List_Box1.DataSource = null;
            List_Box1.DataSource = List_inscrptions;
            List_Box1.DataSource = monManager.chargementDbInsc(unAdh);


            List_Box1.DisplayMember = "Description";


        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void créditerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            Inscription inscr = List_Box1.SelectedItem as Inscription;
            monManager.valideinscription(inscr.UnAdherent.Numero, inscr.UnCours.Idcours);
            refreshListBox(inscr.UnAdherent);






        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void débiterToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = comboBox1.SelectedIndex;


            adherent_Selected = List_adherent[i];
            List_inscrptions = monManager.chargementDbInsc(adherent_Selected);

            refreshListBox(adherent_Selected);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (List_Box1.SelectedItem != null)
            {
                Inscription supp = List_Box1.SelectedItem as Inscription;
                monManager.supprinscri(supp.UnAdherent.Numero, supp.UnCours.Idcours);

                refreshListBox(supp.UnAdherent);
            }


            else
            {
                MessageBox.Show("Erreur");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
               
            var student = comboBox1.SelectedItem as Adherent;
            monManager.supprstudent(student.Numero);
                List_adherent = monManager.getAdherents();
                refreshComboBox(0);

            }
            catch
            {
                MessageBox.Show("errrur suppr");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Inscription deinscr = List_Box1.SelectedItem as Inscription;
            monManager.devalideinscription(deinscr.UnAdherent.Numero, deinscr.UnCours.Idcours);
            refreshListBox(deinscr.UnAdherent);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button6.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Inscription selectinscr = List_Box1.SelectedItem as Inscription;

                selectinscr.crediter(Convert.ToInt32(textBox1.Text));
                monManager.uptadesolde(selectinscr);
                refreshListBox(selectinscr.UnAdherent);
            }catch(Exception m)
            {
                throw m;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Formulaire form = new Formulaire();
            form.ShowDialog();

        }
    }
}

