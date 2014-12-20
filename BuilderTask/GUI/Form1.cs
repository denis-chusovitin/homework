using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        private Convex.Point[] points = null;
        Random rnd = new System.Random();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Func<Convex.Point> rndPoint = () => new Convex.Point(rnd.Next(10, 300), rnd.Next(10, 200));
            

            do
            {
                points = (from _ in Enumerable.Range(0, 4) select rndPoint()).ToArray();
            } while (Convex.isQuadrilateral(points));

            label1.Text = (Convex.isConvex(points)) ? "yes" : "no";

            this.Invalidate();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (points != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Func<Convex.Point, Point> convert = (p) => new Point((int)p.X, (int)p.Y);
                
                e.Graphics.DrawLine(new Pen(Color.Red), convert(points[0]), convert(points[1]));
                e.Graphics.DrawLine(new Pen(Color.Black), convert(points[1]), convert(points[2]));
                e.Graphics.DrawLine(new Pen(Color.Blue), convert(points[2]), convert(points[3]));
                e.Graphics.DrawLine(new Pen(Color.Green), convert(points[3]), convert(points[0]));
            }
        }

 
    }
}
