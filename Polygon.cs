using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static laba_8_oaip.Form1;


namespace laba_8_oaip
{
    internal class Polygon:Figure
    {
        public List<int> pointsx = new List<int>();
        public List<int> pointsy = new List<int>();
        public int CountOfPoints;
        public bool mg = true;
        public Polygon() { }
        public Polygon(int Count, List<int> pointsx, List<int> pointsy)
        {
            this.pointsx = pointsx;
            this.pointsy = pointsy;
            CountOfPoints = Count;
            mg = true;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            Point[] mas_point = new Point[CountOfPoints];
            for (int i = 0; i < mas_point.Length; i++)
            {
                mas_point[i] = new Point(pointsx[i], pointsy[i]);
            }
            g.DrawPolygon(Init.pen, mas_point);
            Init.pictureBox.Image = Init.bitmap;
        }
        public override void Selection()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            Point[] mas_point = new Point[CountOfPoints];
            for (int i = 0; i < mas_point.Length; i++)
            {
                mas_point[i] = new Point(pointsx[i], pointsy[i]);

            }
            g.DrawPolygon(new Pen(Color.White, 5), mas_point);
            Init.pictureBox.Image = Init.bitmap;
        }
        public override void MoveTo(int x, int y)
        {
            Selection();
            bool flag = true;
            for (int i = 0; i < pointsx.Count; i++)
            {
                
                if (pointsx[i] + x > Init.pictureBox.ClientSize.Width || pointsx[i] + x < 0) { flag = false; break; }
               
                 if (p) { flag = false; break; }
                if (pointsy[i] + y > Init.pictureBox.ClientSize.Height) { flag = false; break; }
                if (pointsy[i] + y < 0) { flag = false; break; }
            }
            if (flag)
            {
                Point[] mas_point = new Point[CountOfPoints];
                for (int i = 0; i < mas_point.Length; i++)
                {
                    pointsx[i] = pointsx[i] + x;
                    pointsy[i] = pointsy[i] + y;
                    mas_point[i] = new Point(pointsx[i], pointsy[i]);
                }
                Graphics g = Graphics.FromImage(Init.bitmap);
                g.DrawPolygon(Init.pen, mas_point);
                Init.pictureBox.Image = Init.bitmap;
            }
            else
            {
                MessageBox.Show("НЕльзя");
            }
        }
    }
}
