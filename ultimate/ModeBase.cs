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

        public double up_arrow_x_ratio { get; set; } = 0.5;

        public double up_arrow_y_ratio { get; set; } = 0.4;

        public double down_arrow_x_ratio { get; set; } = 0.5;

        public double down_arrow_y_ratio { get; set; } = 0.6;


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

        private void ModeBase_SizeChanged(object sender, EventArgs e)
        {
            Point p1 = new Point((int)(down_arrow_x_ratio * Size.Width), (int)(down_arrow_y_ratio * Size.Height));
            this.down_arrow.Location = p1;

            Point p2 = new Point((int)(up_arrow_x_ratio * Size.Width) , (int)(up_arrow_y_ratio * Size.Height));
            this.up_arrow.Location = p2;
        }
    }
}
