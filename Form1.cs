using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace laba_8_oaip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }
        public void Form1_Load()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Pen pen = new Pen(Color.Black, 3);
            Pen penClear = new Pen(Color.White, 3);
            Init.bitmap = bitmap;
            Init.pictureBox = pictureBox1;
            Init.pen = pen;

            ShapeContainer shape = new ShapeContainer();
            
        }

        public static class Init
        {
            public static Bitmap bitmap;
            public static Pen pen;
            public static Pen penClear;
            public static PictureBox pictureBox;
            
        }
        abstract public class Figure
        {
            public int x;
            public int y;
            public int width;
            public int height;

            
            public int CountOfPoints;
            public bool mg;
            
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
                comboBox1.Items.Add("Квадрат " + repit);
                ShapeContainer.AddFigure(square);
            }
            if (radioButton2.Checked)
            {
                check();
                Round round = new Round(X, Y, Width);
                round.Draw();
                comboBox1.Items.Add("Круг "+ repit);
                ShapeContainer.AddFigure(round);
            }
            if (radioButton3.Checked)
            {
                check();
                Figure rectangle = new Rectangle(X,Y,Width,Height);
                rectangle.Draw();
                comboBox1.Items.Add("Прямоугольник " + repit);
                ShapeContainer.AddFigure(rectangle);
            }
            if (radioButton4.Checked )
            {
                check();
                Elips elips = new Elips(X,Y,Width,Height);
                elips.Draw();
                comboBox1.Items.Add("Элипс " + repit);
                ShapeContainer.AddFigure(elips);
            }
            if (radioButton5.Checked )
            {
                List<int> pointsx = new List<int>();
                List<int> pointsy = new List<int>();
                for(int i = 0; i < Cordinate.Text.Split(' ').Length; i++)
                {
                    if(i % 2 == 0)
                    {
                        pointsx.Add(Convert.ToInt32(Cordinate.Text.Split(' ')[i]));
                    }
                    else
                    {
                        pointsy.Add(Convert.ToInt32(Cordinate.Text.Split(' ')[i]));
                    }
                }
                Polygon polygon = new Polygon(Convert.ToInt32(textBoxCountPoints.Text), pointsx, pointsy);
                polygon.Draw();
                comboBox1.Items.Add("Многоугольник " + repit);
                ShapeContainer.AddFigure(polygon);
            }
            if (radioButton6.Checked)
            {
                List<int> pointsx = new List<int>();
                List<int> pointsy = new List<int>();
                for (int i = 0; i < Cordinate.Text.Split(' ').Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        pointsx.Add(Convert.ToInt32(Cordinate.Text.Split(' ')[i]));
                    }
                    else
                    {
                        pointsy.Add(Convert.ToInt32(Cordinate.Text.Split(' ')[i]));
                    }
                }
                Tringular tri = new Tringular(3, pointsx, pointsy);
                tri.Draw();
                comboBox1.Items.Add("Триугольник " + repit);
                ShapeContainer.AddFigure(tri);
            }
            if (radioButton7.Checked)
            {
                check();
                int poinx = Convert.ToInt32(Cordinate.Text.Split(' ')[0]), poiny = Convert.ToInt32(Cordinate.Text.Split(' ')[1]);
                SnowMan snowMan = new SnowMan(poinx, poiny, Width, Height);
                snowMan.Draw();
                comboBox1.Items.Add("Снеговик " + repit);
                ShapeContainer.AddFigure(snowMan);
            }
            repit++;
        }

        private void labelCountPoints_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            labelCountPoints.Visible = false;
            textBoxCountPoints.Visible = true;
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

        private void Form1_Load(object sender, EventArgs e)
        {

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
            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            ShapeContainer.figureList.Remove(figyra);
            for(int i=0; i < ShapeContainer.figureList.Count; i++)
            {
                ShapeContainer.figureList[i].Draw();
            }
            
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            Figure figyra = ShapeContainer.figureList[comboBox1.SelectedIndex];
            int x = Convert.ToInt32(textBoxMove.Text.Split(' ')[0]), y = Convert.ToInt32(textBoxMove.Text.Split(' ')[1]);
            if (pictureBox1.ClientSize.Width >= figyra.x + x + figyra.width && pictureBox1.ClientSize.Height >= figyra.y + y + figyra.height)
                {
                    if (figyra.y + y >= 0 && figyra.x + x >= 0)
                    {
                        figyra.MoveTo(x, y);
                        for (int i = 0; i < ShapeContainer.figureList.Count; i++)
                        {
                            ShapeContainer.figureList[i].Draw();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Невозможно передвинуть фигуру");
                    }
                }
             else
                {
                    MessageBox.Show("Невозможно передвинуть фигуру");
                }
        }
            
    }     
}
