using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static laba_8_oaip.Form1;

namespace laba_8_oaip
{
    internal class Square : Rectangle
    {
        public Square(int x, int y, int width)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = width;
            this.mg = false;
        }
        public override void Draw()
        {
            base.Draw();
        }
        public override void Selection()
        {
            base.Selection();
        }
        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);
        }
    }
}

