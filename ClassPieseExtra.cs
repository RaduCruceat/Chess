using RaduProiectSah.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaduProiectSah
{
    abstract class ClassPieseExtra:ClassP
    {
        protected PictureBox btneTablaAlbe;
        protected PictureBox btneTablaNegre;

        public abstract PictureBox getPictureBoxExtra();

        protected void clickpecasutaAlb(object sender, EventArgs e)
        {
            tabla.BtnCasuta_ClickAlb(sender);
        }
        protected void clickpecasutaNegru(object sender, EventArgs e)
        {
            tabla.BtnCasuta_ClickNegru(sender);
        }
        public ClassPieseExtra(int i, int j,TablaSah tabla, int value) : base(i,j, tabla, value)
        {

        }
    }
}
