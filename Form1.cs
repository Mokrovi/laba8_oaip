using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace laba_8_oaip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        public void Start()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Pen pen = new Pen(Color.Black, 5);
            Init.bitmap = bitmap;
            Init.pictureBox = pictureBox1;
            Init.pen = pen;
            Init.combo = comboBox1;
            ShapeContainer shape = new ShapeContainer();
            labelCountPoints.Visible = false;
            textBoxCountPoints.Visible = false;
        }
        public void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }

        public static class Init
        {
            public static Bitmap bitmap;
            public static Pen pen;
            public static PictureBox pictureBox;
            public static ComboBox combo;
            public static List<Point> points = new List<Point>();
        }
        abstract public class Figure
        {
            public int x;
            public int y;
            public int width;
            public int height;
            abstract public void Draw();
            abstract public void Selection();
            abstract public void MoveTo(int x, int y);
        }


        public class ShapeContainer
        {
            public static List<Figure> figureList;
            public ShapeContainer()
            {
                figureList = new List<Figure>();
            }
            public static void AddFigure(Figure figure)
            {
                figureList.Add(figure);
            }
            public static void Clear()
            {
                figureList.Clear();
            }
        }

        public int X, Y, Width, Height;
        private bool check()
        {
            if (int.TryParse(Cordinate.Text.Split(' ')[0], out X) && int.TryParse(Cordinate.Text.Split(' ')[1], out Y) && int.TryParse(ColWidth.Text, out Width) && int.TryParse(ColHeight.Text, out Height)) return (true);
            else return false;
        }
        
        private int repit = 0;
        private void button1_Click(object sender, EventArgs e)
        { 
            
            if (radioButton1.Checked)
            {
                check();
                Square square = new Square(X, Y, Width);
                square.Draw();
                Init.combo.Items.Add("Квадрат " + repit);
                ShapeContainer.AddFigure(square);
            }
            if (radioButton2.Checked)
            {
                check();
                Round round = new Round(X, Y, Width);
                round.Draw();
                Init.combo.Items.Add("Круг "+ repit);
                ShapeContainer.AddFigure(round);
            }
            if (radioButton3.Checked)
            {
                check();
                Figure rectangle = new Rectangle(X,Y,Width,Height);
                rectangle.Draw();
                Init.combo.Items.Add("Прямоугольник " + repit);
                ShapeContainer.AddFigure(rectangle);
            }
            if (radioButton4.Checked )
            {
                check();
                Elips elips = new Elips(X,Y,Width,Height);
                elips.Draw();
                Init.combo.Items.Add("Элипс " + repit);
                ShapeContainer.AddFigure(elips);
            }
            if (radioButton5.Checked )
            {
                
                Init.points = new List<Point>();
                for (int i = 0; i < Convert.ToInt32(textBoxCountPoints.Text); i++)
                {
                    int a = Convert.ToInt32(Cordinate.Text.Split(' ')[i]), b = Convert.ToInt32(Cordinate.Text.Split(' ')[i + 1]);
                    Point poin = new Point(a, b);
                    Init.points.Add(poin);
                }
                Polygon polygon = new Polygon();
                polygon.Draw();
                Init.combo.Items.Add("Многоугольник " + repit);
                ShapeContainer.AddFigure(polygon);
            }
            if (radioButton6.Checked)
            {
                Init.points = new List<Point>();
                for (int i = 0; i < 3; i++)
                {
                    int a = Convert.ToInt32(Cordinate.Text.Split(' ')[i]), b = Convert.ToInt32(Cordinate.Text.Split(' ')[i + 1]);
                    Point poin = new Point(a, b);
                    Init.points.Add(poin);
                }
                Polygon polygon = new Polygon();
                polygon.Draw();
                Init.combo.Items.Add("Треугольник " + repit);
                ShapeContainer.AddFigure(polygon);
            }
            if (radioButton7.Checked)
            {
                int poinx = Convert.ToInt32(Cordinate.Text.Split(' ')[0]), poiny = Convert.ToInt32(Cordinate.Text.Split(' ')[1]);

                // два круга
               
                Round round1 = new Round(poinx, poiny + 50, 50);
                round1.Draw();
                Init.combo.Items.Add("Круг " + repit);
                ShapeContainer.AddFigure(round1);
                repit++;
                Round round2 = new Round(poinx-10, poiny + 100, 70);
                round2.Draw();
                Init.combo.Items.Add("Круг " + repit);
                ShapeContainer.AddFigure(round2);
                repit++;

                // треугольник 

                Init.points = new List<Point>();
                Init.points.Add(new Point(poinx + 40, poiny + 65));                
                Init.points.Add(new Point(poinx + 40, poiny + 85));
                Init.points.Add(new Point(poinx + 80, poiny + 75));
                Polygon polygon = new Polygon();
                polygon.Draw();
                Init.combo.Items.Add("Треугольник " + repit);
                ShapeContainer.AddFigure(polygon);

                // Прямоугольник

                Figure rectangle = new Rectangle(poinx+ 12, poiny+5, 25, 45);
                rectangle.Draw();
                Init.combo.Items.Add("Прямоугольник " + repit);
                ShapeContainer.AddFigure(rectangle);
                repit++;
                Figure rectangle1 = new Rectangle(poinx+2, poiny + 35, 45, 15);
                rectangle1.Draw();
                Init.combo.Items.Add("Прямоугольник " + repit);
                ShapeContainer.AddFigure(rectangle1);
            }
            repit++;
        }

        private void labelCountPoints_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            labelCountPoints.Visible = false;
            textBoxCountPoints.Visible = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            labelCountPoints.Visible = false;
            textBoxCountPoints.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            labelCountPoints.Visible = false;
            textBoxCountPoints.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            labelCountPoints.Visible = false;
            textBoxCountPoints.Visible = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            labelCountPoints.Visible = false;
            textBoxCountPoints.Visible = false;
        }

        private void buttonSelectFigure_Click(object sender, EventArgs e)
        {
            Figure figyra = ShapeContainer.figureList[comboBox1.SelectedIndex];
            figyra.Selection();
            Init.combo.Items.Remove(comboBox1.SelectedIndex);
            ShapeContainer.figureList.Remove(figyra);
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            Figure figyra = ShapeContainer.figureList[comboBox1.SelectedIndex];
            if(!radioButton5.Checked && !radioButton6.Checked)
            {
                check();
                figyra.MoveTo(X, Y);
            }
            else
            {
                figyra.Selection();
                Init.points = new List<Point>();
                for (int i = 0; i < Convert.ToInt32(textBoxCountPoints.Text); i++)
                {
                    int a = Convert.ToInt32(Cordinate.Text.Split(' ')[i]), b = Convert.ToInt32(Cordinate.Text.Split(' ')[i + 1]);
                    Point poin = new Point(a, b);
                    Init.points.Add(poin);
                }
                figyra.MoveTo(X, Y);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Init.combo.Items.Clear();
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            labelCountPoints.Visible = true;
            textBoxCountPoints.Visible = true;
            Init.points = new List<Point>();
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            labelCountPoints.Visible = false;
            textBoxCountPoints.Visible = false;
        }

        
    }
}
