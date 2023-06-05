using System.Drawing;
using System;
using System.Windows.Forms;
using RaduProiectSah.Properties;

namespace RaduProiectSah
{
     class ClassPiesaNeagra:ClassPieseExtra
    {
        public override PictureBox getPictureBoxExtra()
        {
            return btneTablaNegre;
        }
        public ClassPiesaNeagra(int i, TablaSah tabla, int value):base(i,0,tabla,value)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablaSah));
            Image tempRes = ((System.Drawing.Image)(resources.GetObject("pictureBox6E.BackgroundImage"))); //imagine default????
            
            switch (i)
            {
                        case 0:
                            {
                                tempRes = Resources.TuraN;
                                value = 0;
                            }
                            break;
                        case 1:
                            {
                                tempRes = Resources.CalN;
                                value = 1;
                            }
                            break;
                        case 2:
                            {
                                tempRes = Resources.NebunN;
                                value = 2;
                            }
                            break;
                        case 3:
                            {
                                tempRes = Resources.ReginaN;
                                 value = 3;
                            }
                            break;
            }
            btneTablaNegre = new PictureBox
            {
                BackColor = System.Drawing.Color.Transparent,
                BackgroundImage = tempRes,
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new System.Drawing.Point(31 + i * 42, 730),
                Name = "pictureBoxNegru" + i,
                Size = new System.Drawing.Size(35, 35),
                TabIndex = 9,
                TabStop = false,
                
            };
            btneTablaNegre.Enabled=false;
            btneTablaNegre.Click += new System.EventHandler(this.clickpecasutaNegru);
        }
    }
}
        
        
        
