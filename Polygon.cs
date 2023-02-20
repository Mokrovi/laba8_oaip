using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static laba_8_oaip.Form1;

namespace laba_8_oaip
{
    internal class Polygon:Figure
    {
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            Point[] mas_point = new Point[Init.points.Count];
            for (int i = 0; i < mas_point.Length; i++)
            {
                mas_point[i] = Init.points[i];
                
            }
            g.DrawPolygon(Init.pen, mas_point);
            Init.pictureBox.Image = Init.bitmap;
        }
        public override void Selection()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            Point[] mas_point = new Point[Init.points.Count];
            for (int i = 0; i < mas_point.Length; i++)
            {
                mas_point[i] = Init.points[i];

            }
            g.DrawPolygon(new Pen(Color.White, 5), mas_point);
            Init.pictureBox.Image = Init.bitmap;
        }
        public override void MoveTo(int x, int y)
        {
            throw new NotImplementedException();
        }
        public void MoveTo(Point[] points)
        {
            
        }
    }
}
