using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static laba_8_oaip.Form1;

namespace laba_8_oaip
{
    internal class SnowMan : Figure
    {
        public Figure[] shape = new Figure[5];
        public int poinx, poiny;
        public int widht = 1;
        public int height = 1;


        public SnowMan( int x, int y, int w, int h)
        {
            poinx = x;
            poiny = y;
            widht = w;
            height = h;
        }
        public override void Draw()
        {
            
            // два элипса

            Elips elipsForSnowMan1 = new Elips(poinx, poiny+(height*6/9), widht, height * 1/3);
            elipsForSnowMan1.Draw();
            shape[0] = (elipsForSnowMan1);

            Elips elipsForSnowMan2 = new Elips(poinx+(widht*1/8), poiny+(height*3/9), widht*4/5, height*1/3);
            elipsForSnowMan2.Draw();
            shape[1] = (elipsForSnowMan2);
            

            // треугольник 

            List<int> pointsx = new List<int>();
            List<int> pointsy = new List<int>();
            pointsx.Add((poinx) + widht*2/4 + widht * 1/ 10);
            pointsx.Add((poinx) + widht*3/4 + widht * 1 / 10);
            pointsx.Add((poinx) + widht*2/4 + widht * 1 / 10);
            pointsy.Add((poiny) + height*4/10);
            pointsy.Add((poiny) + height*5/10);
            pointsy.Add((poiny) + height*6/10);
            Tringular triForSnowMan = new Tringular(3, pointsx, pointsy);
            triForSnowMan.Draw();
            shape[2] = (triForSnowMan);

            // Прямоугольник
            
            Figure rectangleForSnowMan = new Rectangle(poinx+widht*2/15, poiny+(height*1/6),widht*8/10, height*1/6);
            rectangleForSnowMan.Draw();
            shape[3] = (rectangleForSnowMan);

            int xa = poinx + widht * 4 / 11;
            Figure rectangleForSnowMan2 = new Rectangle(xa, poiny ,widht*1/3, height*1/3);
            rectangleForSnowMan2.Draw();
            shape[4] = (rectangleForSnowMan2);
        
        }
        public override void Selection()
        {
            for(int i=0; i < 5; i++)
            {
                shape[i].Selection();
            }
        }
        public override void MoveTo(int x, int y)
        {
            this.Selection();
            this.poinx += x;
            this.poiny += y;
            this.Draw();
        }
        public void Koef(int W, int H)
        {
            height = W;
            widht = H;
        }
    }
}
