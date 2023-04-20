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
    public partial class mode4 : ModeBase
    {
        public mode4()
        {
            InitializeComponent();
        }

        private void mode4_SizeChanged(object sender, EventArgs e)
        {
            Point p1 = new Point((int)(0.5 * this.Size.Width), (int)(0.6 * this.Size.Height));
            this.down_arrow.Location = p1;

            Point p2 = new Point(p1.X, (int)(0.4 * this.Size.Height));
            this.up_arrow.Location = p2;
        }
    }
}
