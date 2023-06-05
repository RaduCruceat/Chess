using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaduProiectSah
{
    public partial class MeniuJoc : Form
    {
        private TextBox spatiufocusat;
        public TablaSah joc;
        public MeniuJoc()
        {
            InitializeComponent();
            MaximizeBox = false;
            DoubleBuffered = true;
        }
        private void ButtonStartMeniu_Click(object sender, EventArgs e)
        {
            bool isopen = false;
            foreach(Form f in Application.OpenForms)//verifica elementele deschise din aplicatie
            {
                if (f.Name == "TablaSah")
                {
                    isopen = true;
                    f.BringToFront();//se selecteaza ultimul forms deschis ca principal
                    break;
                }
            }
            
            if (isopen==false)
            {
                String nume1;
                String nume2;
                if (TextNumeJucator1.Text.Length==0)
                {
                     nume1 = "Vasile ";
                }
                else
                {
                     nume1 = TextNumeJucator1.Text;
                }
                if (TextNumeJucator2.Text.Length==0)
                {
                    nume2 = "Marinel ";
                }
                else
                {
                    nume2 = TextNumeJucator2.Text;
                }
                if (int.TryParse(TextBoxTimpInitial.Text, out int timp)==false)//bool care verifica daca informatia este de tip int, returneazaa in timp
                {
                    timp = 10;
                }
                TablaSah joc = new TablaSah(nume1,nume2,timp);
                joc.Show();
            }
        }
      
        private void MeniuJoc_Load(object sender, EventArgs e)
        {
            foreach (TextBox box in new TextBox[] { TextNumeJucator1, TextNumeJucator2, TextBoxTimpInitial })
            {
                box.GotFocus += textBoxFocus;
            }
        }
        private void textBoxFocus(object sender, EventArgs e)
        {
            spatiufocusat = (TextBox)sender;
            if (spatiufocusat.Name == "TextBoxTimpInitial")
            {
                this.BackgroundImage = Properties.Resources.pensionari_sah;
            }
            else
            {
                if (spatiufocusat.Name == "TextNumeJucator1")
                {
                    this.BackgroundImage = Properties.Resources.Marinel;
                }
                else
                {
                    this.BackgroundImage = Properties.Resources.Vasile;
                }
            }
        }
    }
   
   

    


}
