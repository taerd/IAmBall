using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAmBall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int h=30,w=30,px,py,dx,dy;
        Random r = new Random();
        Graphics g;
        Pen p = new Pen(Color.GreenYellow, 3);
        Brush b = new SolidBrush(Color.Red);
        private void panel1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            g = panel1.CreateGraphics();
            px = panel1.Height / 2;
            py = panel1.Width / 2;
            dx = r.Next(-5, 5);
            dy = r.Next(-5, 5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();
            px += dx;
            py += dy;
            g.DrawEllipse(p, px, py, w, h);
            g.FillEllipse(b, px, py, w, h);
            if(py>=panel1.Height-dy-h || py < Math.Abs(dy))
            {
                dy *= -1;
                if(py >= panel1.Height - dy - h)
                {
                    panel1.Refresh();
                    py = panel1.Height - Math.Abs(dy) - w;
                    g.DrawEllipse(p, px, py, w, h);
                    g.FillEllipse(b, px, py, w, h);
                }
            }
            if(px >= panel1.Width - dx - w || px < Math.Abs(dx))
            {
                dx *= -1;
                if(px>=panel1.Width - dx- w)
                {
                    panel1.Refresh();
                    px = panel1.Width - Math.Abs(dx) - h;
                    g.DrawEllipse(p, px, py, w, h);
                    g.FillEllipse(b, px, py, w, h);
                }
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Refresh();
        }
    }
}
