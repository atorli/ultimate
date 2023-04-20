using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ultimate
{
    public partial class ModeBase : UserControl
    {
        public ModeBase()
        {
            InitializeComponent();
        }

        private void up_arrow_blink_timer_Tick(object sender, EventArgs e)
        {
            if (up_arrow.PaintColor == Color.Transparent)
            {
                up_arrow.PaintColor = Color.Green;
            }
            else if (up_arrow.PaintColor == Color.Green)
            {
                up_arrow.PaintColor = Color.Transparent;
            }
        }

        public void start_up_arrow_blink()
        {
            up_arrow_blink_timer.Enabled = true;
        }

        public void stop_up_arrow_blink()
        {
            up_arrow_blink_timer.Enabled = false;
            up_arrow.PaintColor = Color.Green;
        }

        private void down_arrow_blink_timer_Tick(object sender, EventArgs e)
        {
            if (down_arrow.PaintColor == Color.Transparent)
            {
                down_arrow.PaintColor = Color.Green;
            }
            else if (down_arrow.PaintColor == Color.Green)
            {
                down_arrow.PaintColor = Color.Transparent;
            }
        }

        public void start_down_arrow_blink()
        {
            down_arrow_blink_timer.Enabled = true;
        }

        public void stop_down_arrow_blink()
        {
            down_arrow_blink_timer.Enabled = false;
            down_arrow.PaintColor = Color.Green;
        }
    }
}
