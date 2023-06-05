using System.Drawing;
using System;
using System.Windows.Forms;
using RaduProiectSah.Properties;

namespace RaduProiectSah
{
    class ClassPiesaAlba : ClassPieseExtra
    {
        public override PictureBox getPictureBoxExtra()
        {
            return btneTablaAlbe;
        }
        public ClassPiesaAlba(int i, TablaSah tabla, int value):base(0, i, tabla, value)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablaSah));
            Image tempRes = ((System.Drawing.Image)(resources.GetObject("pictureBox6E.BackgroundImage"))); //imagine default????
            switch (i)
            {

                case 0:
                    {
                        tempRes = Resources.TuraA;
                        value = 0;
                    }
                    break;
                case 1:
                    {
                        tempRes = Resources.CalA;
                        value = 1;
                    }
                    break;
                case 2:
                    {
                        tempRes = Resources.NebunA;
                        value = 2;
                    }
                    break;
                case 3:
                    {
                        tempRes = Resources.ReginaA;
                        value = 3;
                    }
                    break;
            }
            btneTablaAlbe = new PictureBox
            {
                BackColor = System.Drawing.Color.Transparent,
                BackgroundImage = tempRes,
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new System.Drawing.Point(31 + i * 42, 30),
                Name = "pictureBoxAlb" + i,
                Size = new System.Drawing.Size(35, 35),
                TabIndex = 9,
                TabStop = false,

            };
            btneTablaAlbe.Enabled = false;
            btneTablaAlbe.Click += new System.EventHandler(this.clickpecasutaAlb);
        }
    }
}



