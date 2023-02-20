using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static laba_8_oaip.Form1;

namespace laba_8_oaip
{
    internal class Round : Elips 
    {
        public Round(int x, int y, int width)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = width;
        }
        public Round()
        {
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
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
