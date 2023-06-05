using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace RaduProiectSah
{
    public class ClassTimer
    {

        private TablaSah tabla;
        private Timer timer;
        public ClassTimer(TablaSah tabla)
        {
            this.tabla = tabla;
            timer = new Timer
            {
                Interval = 1000,
                Enabled = true,
            };
            timer.Tick += new System.EventHandler(this.TimerTick);
        }
        private void TimerTick(object sender, EventArgs e)
        {
            tabla.timer_Tick(sender,e);
        }
    }
}
