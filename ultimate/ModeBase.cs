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

        /// <summary>
        /// 上箭头闪烁还是下箭头闪烁，0-下箭头闪烁,1-上箭头闪烁
        /// 默认为上箭头闪烁
        /// </summary>
        private int up_or_down = 0;

        private void blink_timer_Tick(object sender, EventArgs e)
        {
            if (up_or_down == 0)
            {
                //下箭头
                if (DownArrow.PaintColor == Color.Green)
                {
                    DownArrow.PaintColor = Color.Transparent;
                }
                else if (DownArrow.PaintColor == Color.Transparent)
                {
                    DownArrow.PaintColor = Color.Green;
                }
            }
            else if (up_or_down == 1)
            {
                //上箭头
                if (UpArrow.PaintColor == Color.Green)
                {
                    UpArrow.PaintColor = Color.Transparent;
                }
                else if (UpArrow.PaintColor == Color.Transparent)
                {
                    UpArrow.PaintColor = Color.Green;
                }
            }
        }

        public void start_up_blink()
        {
            blink_timer.Enabled = false;
            up_or_down = 1;
            blink_timer.Enabled = true;
        }

        public void start_down_blink()
        {
            blink_timer.Enabled = false;
            up_or_down = 0;
            blink_timer.Enabled = true;
        }

        public void disable_blink()
        {
            blink_timer.Enabled = false;
        }


    }
}
