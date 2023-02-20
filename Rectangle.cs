using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static laba_8_oaip.Form1;

namespace laba_8_oaip
{
    internal class Rectangle : Figure
    {
        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public Rectangle()
        {
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, this.x, this.y, this.width, this.height);
            Init.pictureBox.Image = Init.bitmap;
        }
        public override void Selection()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(new Pen(Color.White, 5), this.x, this.y, this.width, this.height);
            Init.pictureBox.Image = Init.bitmap;
        }
        public override void MoveTo(int x, int y)
        {
            this.Selection();
            this.x = x;
            this.y = y;
            this.Draw();
        }
    }
}

