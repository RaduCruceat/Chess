using RaduProiectSah.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace RaduProiectSah
{

    public partial class TablaSah : Form
    {
        ClassTimer timer;
        ClassP[][] btneTabla;
        List <ClassPieseExtra> btneTablaExtra=new List<ClassPieseExtra>();
        private int contor;
        private int ipoz;
        private int jpoz;
        private int timeleft1;
        private int timeleft2;

        private void initBtnTablaNegre()
        {
            int value = 0;
            for (int k = 0; k < 4; k++)
            {
                btneTablaExtra.Add(new ClassPiesaNeagra(k, this, value));
                Controls.Add(btneTablaExtra.Last().getPictureBoxExtra());
            }
        }
        private void initBtnTablaAlbe()
        {
            int value = 0;
            for (int k = 0; k < 4; k++)
            {
                btneTablaExtra.Add(new ClassPiesaAlba(k, this, value));
                Controls.Add(btneTablaExtra.Last().getPictureBoxExtra());
            }
        }
        private void initBtnTabla()
        {
            int value=0;

         //   0-Spatiu Gol
         //   1-Pion Alb
         //   2-Pion Negru
         //   3-Regina Alb
         //   4-Regina Negru
         //   5-Nebun Alb
         //   6-Nebun Negru 
         //   7-Cal Alb
         //   8-Cal Negru
         //   9-Tura Alb
         //   10-Tura Negur
         //   11-Rege Alb
         //   12-Rege Negru
       
            btneTabla = new ClassP[8][];
            for(int i=0; i<8; i++)
            {
                btneTabla[i] = new ClassP[8];
            }
            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    btneTabla[i][j] = new ClassP(i, j, this, value);
                    Controls.Add(btneTabla[i][j].getPictureBox()); 
                }
            }
        }
        private void initTimer()
        {
            timer = new ClassTimer(this);
        }
        public TablaSah(String nume1, String nume2,int timp)
        {
            ipoz = 9;
            jpoz = 9;
            contor = 0;
            MaximizeBox = false;
            //
            initBtnTabla();
            initBtnTablaNegre();
            initBtnTablaAlbe();
            InitializeComponent();
            initTimer();
            //
            LabelJucator1.Text = nume2;
            LabelJucator2.Text = nume1;
            label2.Text = LabelJucator2.Text + " muta";
            label2.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            //
            timeleft1 = timp*60;
            timeleft2 = timp*60;
            LabelTimer1.Text = (timeleft1 / 60) + ":00";
            LabelTimer2.Text = (timeleft2 / 60) + ":00";
        }
        private void VerificaLabel(int contor)
        {
            if (contor % 4 == 0)
            {
                label2.Text = LabelJucator2.Text + " muta";
                label2.BackColor = Color.White;
                label2.ForeColor = Color.Black;
            }
            else
            {
                label2.Text = LabelJucator1.Text + " muta";
                label2.BackColor = Color.Black;
                label2.ForeColor = Color.White;
            }
        }
        private void SchimbaImaginea(int i,int j,int ipoz,int jpoz)
        {
            
            btneTabla[i][j].getPictureBox().BackgroundImage = btneTabla[ipoz][jpoz].getPictureBox().BackgroundImage;
            btneTabla[ipoz][jpoz].getPictureBox().BackgroundImage = null;
            btneTabla[ipoz][jpoz].getPictureBox().BackColor = Color.Transparent;

        }
        private void tablacurata()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    btneTabla[i][j].getPictureBox().BackColor = Color.Transparent;
                }
            }
        }
        private void ReseteazaMutarea(int ipoz,int jpoz)
        {
           
            btneTabla[ipoz][jpoz].getPictureBox().BackColor = Color.Transparent;
            contor -= 2;
        }
        private void SchimbaValoarea(int i,int j,int ipoz,int jpoz)
        {
            btneTabla[i][j].setvalue(btneTabla[ipoz][jpoz].getvalue());
            btneTabla[ipoz][jpoz].setvalue(0);
        }
        private void ActiveazaButoaneTabla()
        {
            for (int m = 0; m < 8; m++)
                for (int n = 0; n < 8; n++)
                {
                    btneTabla[m][n].getPictureBox().Enabled = true;
                }
        }
        private void DezactiveazaButoaneTabla()
        {
            for (int m = 0; m < 8; m++)
                for (int n = 0; n < 8; n++)
                {
                    btneTabla[m][n].getPictureBox().Enabled = false;
                }
        }
        private async void ButtonAbandoneaza_Click(object sender, EventArgs e)
        {
            ButtonAbandoneaza.Enabled = false;
            for(int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                {
                    btneTabla[i][j].getPictureBox().Enabled = false;
                }
            if (label2.BackColor == Color.White)
            {
                label2.Text = LabelJucator1.Text + " a Castigat";
                ButtonAbandoneaza.Text = LabelJucator2.Text + " a Pierdut";
                label2.BackColor = Color.DarkGreen;
                label2.ForeColor = Color.White;
            }
            else 
            {
                label2.Text = LabelJucator2.Text + " a Castigat";
                ButtonAbandoneaza.Text = LabelJucator1.Text + " a Pierdut";
                label2.BackColor = Color.DarkGreen;
                label2.ForeColor = Color.White;
            }
            await Task.Delay(TimeSpan.FromSeconds(5));
            Application.Exit();
        }
        private bool verificafinalpionNegru(int i,int j)
        {
            if (btneTabla[i][j].getvalue() == 2 && i == 7)
                return true;
            else
                return false;
         }
        private bool verificafinalpionAlb (int i, int j)
        {
            if (btneTabla[i][j].getvalue() == 1 && i == 0)
                return true;
            else
                return false;
        }
        private void mutapiesa(int i, int j, int value)
        {
            //pion alb
            if (value == 1)
            {
                if (j+1<8)
                {
                    if(btneTabla[i - 1][j + 1].getvalue() != 0&& btneTabla[i - 1][j + 1].getvalue()%2!=1)
                    btneTabla[i - 1][j+1].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (j-1>-1)
                {
                    if(btneTabla[i - 1][j - 1].getvalue() != 0&& btneTabla[i - 1][j - 1].getvalue() % 2 != 1)
                        btneTabla[i - 1][j - 1].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (btneTabla[i - 1][j].getvalue() == 0)
                {
                    btneTabla[i - 1][j].getPictureBox().BackColor = Color.YellowGreen;
                }
                if(i==6)
                if (btneTabla[i - 1][j].getvalue() == 0 && btneTabla[i - 2][j].getvalue() == 0)
                {
                    btneTabla[i - 2][j].getPictureBox().BackColor = Color.YellowGreen;
                }
            }
            //pion negru
            if (value == 2)
            {
                if (j + 1 < 8)
                {
                    if (btneTabla[i + 1][j + 1].getvalue() != 0 && btneTabla[i + 1][j + 1].getvalue() % 2 != 0)
                        btneTabla[i + 1][j + 1].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (j - 1 > -1)
                {
                    if (btneTabla[i + 1][j - 1].getvalue() != 0 && btneTabla[i + 1][j - 1].getvalue() % 2 != 0)
                        btneTabla[i + 1][j - 1].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (btneTabla[i + 1][j].getvalue() == 0)
                {
                    btneTabla[i + 1][j].getPictureBox().BackColor = Color.YellowGreen;
                }
                if(i==1)
                if (btneTabla[i + 1][j].getvalue() == 0 && btneTabla[i + 2][j].getvalue() == 0)
                {
                    btneTabla[i + 2][j].getPictureBox().BackColor = Color.YellowGreen;
                }
            }
            //cal
            if (value == 8 | value == 7)
            {
                for (int k = 0; k < 8; k++)
                 for (int m = 0; m < 8; m++)
                if (i+2<8&& j + 1 < 8&& (btneTabla[i][j].getvalue() % 2 != btneTabla[i+2][j+1].getvalue() % 2|| btneTabla[i + 2][j + 1].getvalue()==0))                    
                {
                    btneTabla[i + 2][j+1].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (i + 2 < 8&& j - 1 > -1 && (btneTabla[i][j].getvalue() % 2 != btneTabla[i + 2][j - 1].getvalue() % 2|| btneTabla[i + 2][j - 1].getvalue()==0))
                {
                    btneTabla[i + 2][j - 1].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (i+1<8&&j+2<8 && (btneTabla[i][j].getvalue() % 2 != btneTabla[i + 1][j + 2].getvalue() % 2|| btneTabla[i + 1][j + 2].getvalue()==0))
                {
                    btneTabla[i + 1][j + 2].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (i-1>-1&&j+2<8 && (btneTabla[i][j].getvalue() % 2 != btneTabla[i - 1][j + 2].getvalue() % 2|| btneTabla[i - 1][j + 2].getvalue()==0))
                {
                    btneTabla[i - 1][j + 2].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (i - 2 > -1 && j + 1 < 8 && (btneTabla[i][j].getvalue() % 2 != btneTabla[i - 2][j + 1].getvalue() % 2|| btneTabla[i - 2][j + 1].getvalue()==0))
                {
                    btneTabla[i - 2][j + 1].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (i - 2 > -1 && j -1 > -1 && (btneTabla[i][j].getvalue() % 2 != btneTabla[i - 2][j - 1].getvalue() % 2|| btneTabla[i - 2][j - 1].getvalue()==0))
                {
                    btneTabla[i - 2][j -1].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (i + 1 < 8 && j - 2 > -1 && (btneTabla[i][j].getvalue() % 2 != btneTabla[i + 1][j - 2].getvalue() % 2|| btneTabla[i + 1][j - 2].getvalue()==0))
                {
                    btneTabla[i + 1][j - 2].getPictureBox().BackColor = Color.YellowGreen;
                }
                if (i - 1 > -1 && j - 2 > -1 && (btneTabla[i][j].getvalue() % 2 != btneTabla[i - 1][j - 2].getvalue() % 2|| btneTabla[i - 1][j - 2].getvalue()==0))
                {
                    btneTabla[i - 1][j - 2].getPictureBox().BackColor = Color.YellowGreen;
                }
            }
            //regina + tura
            if (value == 4 | value == 3 | value == 10 | value == 9)
            {

                int row = i+1;
                int column = j;
                while (row < 8)
                {
                    if (btneTabla[row][column].getvalue() != 0)
                    {
                        if(btneTabla[row][column].getvalue() % 2 != btneTabla[i][j].getvalue()%2)
                            btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                        break;
                    }
                       
                    btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                    row++;
                    
                }

                row = i-1;
                column = j;
                while (row >= 0)
                {
                    if (btneTabla[row][column].getvalue() != 0)
                    {
                        if (btneTabla[row][column].getvalue() % 2 != btneTabla[i][j].getvalue() % 2)
                            btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                        break;
                    }
                        
                    btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                    row--;
                    
                }

                row = i;
                column = j + 1;
                while (column < 8)
                {
                    if (btneTabla[row][column].getvalue() != 0)
                    {
                        if (btneTabla[row][column].getvalue() % 2 != btneTabla[i][j].getvalue() % 2)
                            btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                        break;
                    }
                    btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                    
                    column++;
                }

                row = i;
                column = j - 1;
                while (column >= 0)
                {
                    if (btneTabla[row][column].getvalue() != 0)
                    {
                        if (btneTabla[row][column].getvalue() % 2 != btneTabla[i][j].getvalue() % 2)
                            btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                        break;
                    }
                    btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                    
                    column--;
                }
            }
            //rege
            if (value == 11 || value == 12)
                {
                for (int k = i - 1; k < i + 2; k++)
                    for (int m = j - 1; m < j + 2; m++)
                    {
                        if (k < 8 && m < 8 && k > -1 && m > -1)
                        {
                          if(btneTabla[k][m].getvalue()%2!= btneTabla[i][j].getvalue()%2|| btneTabla[k][m].getvalue() == 0)
                            btneTabla[k][m].getPictureBox().BackColor = Color.YellowGreen;
                        }
                      
                    }
                }
            //regina + nebun
            if (value == 3 || value == 4 || value == 5 || value == 6)
            {

                int row = i - 1;
                int column = j - 1;
                while (row >= 0 && column >= 0)
                {
                    if (btneTabla[row][column].getvalue() != 0)
                    {
                        if (btneTabla[row][column].getvalue() % 2 != btneTabla[i][j].getvalue() % 2)
                            btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                        break;
                    }
                    btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                    row--;
                    column--;
                }

                row = i + 1;
                column = j + 1;
                while (row < 8 && column < 8)
                {
                    if (btneTabla[row][column].getvalue() != 0)
                    {
                        if (btneTabla[row][column].getvalue() % 2 != btneTabla[i][j].getvalue() % 2)
                            btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                        break;
                    }
                    btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                    row++;
                    column++;
                }

                row = i - 1;
                column = j + 1;
                while (row >= 0 && column < 8)
                {
                    if (btneTabla[row][column].getvalue() != 0)
                    {
                        if (btneTabla[row][column].getvalue() % 2 != btneTabla[i][j].getvalue() % 2)
                            btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                        break;
                    }
                    btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                    row--;
                    column++;
                }

                row = i + 1;
                column = j - 1;
                while (row < 8 && column >= 0)
                {
                    if (btneTabla[row][column].getvalue() != 0)
                    {
                        if (btneTabla[row][column].getvalue() % 2 != btneTabla[i][j].getvalue() % 2)
                            btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                        break;
                    }
                    btneTabla[row][column].getPictureBox().BackColor = Color.YellowGreen;
                    row++;
                    column--;
                }



            }
        }
        public void BtnCasuta_Click(object sender)
        {
            contor++;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (sender == btneTabla[i][j].getPictureBox())
                    {
                        if (contor % 2 != 0)//Piesa care se va muta
                        {
                            ipoz = i;
                            jpoz = j;
                            btneTabla[i][j].getPictureBox().BackColor = Color.YellowGreen;
                            mutapiesa(i, j, btneTabla[i][j].getvalue());
                            
                        }
                        else//Locul unde se va muta piesa
                        {
                            if (btneTabla[ipoz][jpoz].getvalue() == 0 || btneTabla[ipoz][jpoz].getvalue()%2==0 && ( contor % 4)!=0 || (btneTabla[ipoz][jpoz].getvalue())%2 == 1 && (contor % 4) == 0 || (btneTabla[ipoz][jpoz].getvalue()%2 == btneTabla[i][j].getvalue()%2 && btneTabla[i][j].getvalue()!=0)|| btneTabla[i][j].getvalue()==12|| btneTabla[i][j].getvalue()==11|| btneTabla[i][j].getPictureBox().BackColor==Color.Transparent)
                            {
                               ReseteazaMutarea(ipoz, jpoz);
                                tablacurata();  
                            }
                            // mutarea se reseteaza
                            // 1 daca incepe de pe spatiu gol,
                            // 2 daca se muta peste o piesa de aceeasi culoare,
                            // 3 daca se muta cand nu e randul jucatorului
                            // 4 daca se muta peste rege
                            // 5 daca se muta pe un patrat transparent(pe o mutare ilegala a piesei individuale)
                            else
                            {
                               SchimbaImaginea(i, j, ipoz, jpoz);
                               SchimbaValoarea(i, j, ipoz, jpoz);
                               VerificaLabel(contor);
                                if (verificafinalpionAlb(i, j) == true|| verificafinalpionNegru(i, j) == true)
                                {
                                    DezactiveazaButoaneTabla();
                                    ButtonAbandoneaza.Enabled = false;
                                    //
                                    int x=0;
                                    if (verificafinalpionAlb(i, j) == true)
                                    {
                                       x = 7;
                                       label2.Text = LabelJucator2.Text + " alege piesa"; 
                                    }
                                    if (verificafinalpionNegru(i, j) == true)
                                    {
                                       x = 3;
                                       label2.Text = LabelJucator1.Text + " alege piesa";      
                                    }
                                    for (int z=0;z<4;z++)
                                    {
                                        btneTablaExtra[x-z].getPictureBoxExtra().Enabled = true;
                                        btneTablaExtra[x-z].getPictureBoxExtra().BackColor = Color.YellowGreen;
                                        label2.BackColor = Color.YellowGreen;
                                        label2.ForeColor = Color.Black;
                                    }
                                }
                                tablacurata();
                            }
                        }
                    }
                }
            }
        }
        public void BtnCasuta_ClickNegru(object sender)
        {
            for (int x = 0; x < 4; x++)
                if (sender == btneTablaExtra[x].getPictureBoxExtra())
                {
                    for (int i = 0; i < 8; i++)
                        if (btneTabla[7][i].getvalue() == 2)//verifica coloana pionului
                        {
                            btneTabla[7][i].getPictureBox().BackgroundImage = btneTablaExtra[x].getPictureBoxExtra().BackgroundImage;
                            btneTabla[7][i].setvalue(2+2*(4-x));
                        }
                }
            for (int x = 0; x < 4; x++)
            {
                btneTablaExtra[x].getPictureBoxExtra().Enabled = false;
                btneTablaExtra[x].getPictureBoxExtra().BackColor = Color.Transparent;
            }
            VerificaLabel(contor);
            ActiveazaButoaneTabla();
            ButtonAbandoneaza.Enabled = true;
        }
        public void BtnCasuta_ClickAlb(object sender)
        {
            for (int x = 0; x < 4; x++)
                if (sender == btneTablaExtra[x+4].getPictureBoxExtra())
                {
                    for (int i = 0; i < 8; i++)
                        if (btneTabla[0][i].getvalue() == 1)//verifica coloana pionului
                        {
                            btneTabla[0][i].getPictureBox().BackgroundImage = btneTablaExtra[x+4].getPictureBoxExtra().BackgroundImage;
                            btneTabla[0][i].setvalue(1 + 2 * (4 - x));
                        }
                }
            for (int x = 0; x < 4; x++)
            {
                btneTablaExtra[x + 4].getPictureBoxExtra().Enabled = false;
                btneTablaExtra[x + 4].getPictureBoxExtra().BackColor = Color.Transparent;
            }
            VerificaLabel(contor);
            ActiveazaButoaneTabla();
            ButtonAbandoneaza.Enabled = true;
        }
          public void timer_Tick(object sender, EventArgs e)
            {
                String secunde;
                if(label2.BackColor == Color.Black)
                {
                    if (timeleft1 > 0)
                    {
                        timeleft1 = timeleft1 - 1;
                        secunde = (timeleft1 % 60).ToString();
                        if (secunde.Length == 1)
                            secunde = "0"+secunde ;
                        LabelTimer1.Text = (timeleft1/60) + ":" + secunde;
                    }
                    else
                    { 
                        ButtonAbandoneaza_Click(sender, e);  
                    }
                }
                if(label2.BackColor==Color.White)
                {
                    if (timeleft2 > 0)
                    {
                        timeleft2 = timeleft2 - 1;
                        secunde = (timeleft2 % 60).ToString();
                        if (secunde.Length == 1)
                            secunde = "0" + secunde;
                        LabelTimer2.Text = (timeleft2 / 60) + ":" + secunde;
                    }
                    else
                    {
                        ButtonAbandoneaza_Click(sender, e);   
                    }
                }
             }

       
    }
}

