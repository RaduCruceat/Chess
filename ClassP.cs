using System.Drawing;
using System;
using System.Windows.Forms;
using RaduProiectSah.Properties;

namespace RaduProiectSah
{
     public class ClassP
    {   
        protected int i, j,value;
        public PictureBox btneTabla;
        protected TablaSah tabla;

        private void clickpecasuta(object sender, EventArgs e)
        {
            tabla.BtnCasuta_Click(sender);
        }
        public ClassP(int i, int j,TablaSah tabla,int value)
        {
            this.tabla = tabla;
            this.i = i;
            this.j = j;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablaSah));
            Image tempRes = ((System.Drawing.Image)(resources.GetObject("pictureBox6E.BackgroundImage"))); //imagine default
            if (i == 1 || i == 6) //randuri pioni
            {
                if (i == 1)
                {
                    tempRes = Resources.PionN;
                    value = 2;
                }
                else
                if(i==6)
                {
                    tempRes = Resources.PionA;
                    value = 1;
                }
            }
            else if (i == 0 || i == 7) //randuri piese
            {
               
                switch (j)
                {
                    case 0:
                        if (i == 0)
                        {
                            tempRes = Resources.TuraN;
                            value = 10;
                        }
                        else
                        {
                            tempRes = Resources.TuraA;
                            value = 9;
                        }
                        break;
                    case 1:
                        if (i == 0)
                        {
                            tempRes = Resources.CalN;
                            value = 8;
                        }
                        else
                        {
                            tempRes = Resources.CalA;
                            value = 7;
                        }
                        break;
                    case 2:
                        if (i == 0)
                        {
                            tempRes = Resources.NebunN;
                            value = 6;
                        }
                        else
                        {
                            tempRes = Resources.NebunA;
                            value = 5;
                        }
                        break;
                    case 3:
                        if (i == 0)
                        {
                            tempRes = Resources.ReginaN;
                            value = 4;
                        }
                        else
                        {
                            tempRes = Resources.ReginaA;
                            value = 3;
                        }
                            
                        break;
                    case 4:
                        if (i == 0)
                        {
                            tempRes = Resources.RegeN;
                            value = 12;
                        }
                        else
                        {
                            tempRes = Resources.RegeA;
                            value = 11;
                        }
                        break;
                    case 5:
                        if (i == 0)
                        {
                            tempRes = Resources.NebunN;
                            value = 6;
                        }
                        else
                        {
                            tempRes = Resources.NebunA;
                            value = 5;
                        }
                        break;
                    case 6:
                        if (i == 0)
                        {
                            tempRes = Resources.CalN;
                            value = 8;
                        }
                        else
                        {
                            tempRes = Resources.CalA;
                            value = 7;
                        }
                        break;
                    case 7:
                        if (i == 0)
                        {
                            tempRes = Resources.TuraN;
                            value = 10;
                        }
                        else
                        {
                            tempRes = Resources.TuraA;
                            value = 9;
                        }
                        break;
                }
            }
            this.value = value;
            btneTabla = new PictureBox
            {
                BackColor = System.Drawing.Color.Transparent,
                BackgroundImage = tempRes,
               
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new System.Drawing.Point((29 + j * 79), (83 + i * 77)),
                Name = "pictureBox" + i + j,
                Size = new System.Drawing.Size(68, 68),
                TabIndex = 9,
                TabStop = false,
             };
             btneTabla.Click += new System.EventHandler(this.clickpecasuta); //atribuie functia generala de click de piesa locatiei curente
        }
        public PictureBox getPictureBox()
        {
            return btneTabla;
        }
        public int getvalue()
        {
            return value;
        }
        public void setvalue(int value)
        {
            this.value = value;
           
        }
     }
}

        

    
