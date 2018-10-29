using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MapReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //initial the matrix here
            PrfabIni();
        }


        private bool _once = true;
        int Glavni_stevec = 0;
        int[,] IgralnaMatrika = new int[6, 100];
        int[,] Prefab_1 = new int[4, 2];
        int[,] Prefab_2 = new int[4, 3];
        int[,] Prefab_3 = new int[3, 4];
        int[,] Prefab_4 = new int[3, 4];


        public void ConvertStrToMap(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                {
                    Glavni_stevec++;
                    IgralnaMatrika[5, Glavni_stevec] = 6;
                }
                else if (str[i] == '1')
                {
                    AddNextPart(Prefab_1);
                }
                else if (str[i] == '2')
                {
                    AddNextPart(Prefab_2);
                }
                else if (str[i] == '3')
                {
                    AddNextPart(Prefab_3);
                }
                else if (str[i] == '4')
                {
                    AddNextPart(Prefab_4);
                }

            }
        }

        public void AddNextPart(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = arr.GetLength(0) - 1, temp = 0; j >= 0; j--, temp++)
                {
                    IgralnaMatrika[4 - temp, Glavni_stevec] = arr[j, i];
                }
                Glavni_stevec++;
                IgralnaMatrika[5, Glavni_stevec] = 6;
            }
        }

        public void PrfabIni()
        {
            //Zacetek prve pasti
            Prefab_1[0, 1] = 2;
            Prefab_1[1, 0] = 3;
            Prefab_1[1, 1] = 1;
            Prefab_1[2, 0] = 3;
            Prefab_1[2, 1] = 1;
            Prefab_1[3, 0] = 3;
            Prefab_1[3, 1] = 1;
            //Konec šrve pasti

            //Začetek druge pasti
            Prefab_2[0, 0] = 1;
            Prefab_2[0, 1] = 1;
            Prefab_2[0, 2] = 1;
            Prefab_2[1, 0] = 5;
            Prefab_2[1, 1] = 5;
            Prefab_2[1, 2] = 5;
            Prefab_2[3, 1] = 2;
            Prefab_2[3, 2] = 2;
            //Konec druge pati

            //Začetek tretje pasti
            Prefab_3[0, 1] = 4;
            Prefab_3[0, 3] = 2;
            Prefab_3[1, 1] = 1;
            Prefab_3[1, 2] = 1;
            Prefab_3[1, 3] = 1;
            Prefab_3[2, 0] = 1;
            Prefab_3[2, 1] = 1;
            Prefab_3[2, 2] = 1;
            Prefab_3[2, 3] = 1;
            //Konec tretje pati

            //Začetek četrze pasti
            Prefab_4[0, 2] = 2;
            Prefab_4[1, 1] = 4;
            Prefab_4[1, 2] = 1;
            Prefab_4[2, 0] = 1;
            Prefab_4[2, 1] = 1;
            Prefab_4[2, 2] = 1;
            Prefab_4[2, 3] = 1;
            //Konec četrte pasti
        }


        private void Draw2DArray(object sender, PaintEventArgs e)
        {
            int step = 10;
            int width = 10;
            int height = 10;

            using (Graphics g = this.CreateGraphics())
            {
                if (_once)
                {
                    g.Clear(SystemColors.Control);
                    using (Pen pen = new Pen(Color.Black, 2))
                    {
                        int columns = IgralnaMatrika.GetUpperBound(1) + 1 - IgralnaMatrika.GetLowerBound(1);
                        for (int i = 0; i < IgralnaMatrika.GetLength(0); i++)
                        {
                            for (int j = 0; j < IgralnaMatrika.GetLength(1); j++)
                            {
                                if (IgralnaMatrika[i, j] == 1)
                                {
                                    Rectangle rect = new Rectangle(new Point(5 + step * j, 50 + step * i), new Size(width, height));
                                    g.DrawRectangle(pen, rect);
                                    g.FillRectangle(System.Drawing.Brushes.Green, rect);
                                }
                                //2 = KOVANEC
                                else if (IgralnaMatrika[i, j] == 2)
                                {
                                    Rectangle rect = new Rectangle(new Point(5 + step * j, 50 + step * i), new Size(width - 5, height - 5));
                                    g.DrawEllipse(pen, rect);
                                    g.FillEllipse(System.Drawing.Brushes.Yellow, rect);
                                }
                                // 3 Navpična past |
                                else if (IgralnaMatrika[i, j] == 3)
                                {
                                    Rectangle rect = new Rectangle(new Point(10 + step * j, 50 + step * i), new Size(width / 2, height));
                                    g.DrawRectangle(pen, rect);
                                    g.FillRectangle(System.Drawing.Brushes.Red, rect);
                                }
                                // 4 Vodoravna spodnja past _
                                else if (IgralnaMatrika[i, j] == 4)
                                {
                                    Rectangle rect = new Rectangle(new Point(5 + step * j, 55 + step * i), new Size(width, height / 2));
                                    g.DrawRectangle(pen, rect);
                                    g.FillRectangle(System.Drawing.Brushes.Red, rect);
                                }
                                // 5 Vodoravna zgornja past -
                                else if (IgralnaMatrika[i, j] == 5)
                                {
                                    Rectangle rect = new Rectangle(new Point(5 + step * j, 50 + step * i), new Size(width, height / 2));
                                    g.DrawRectangle(pen, rect);
                                    g.FillRectangle(System.Drawing.Brushes.Red, rect);
                                }
                                //izrisi tla
                                if (IgralnaMatrika[i, j] == 6)
                                {
                                    Rectangle rect = new Rectangle(new Point(5 + step * j, 52 + step * i), new Size(width, height));
                                    g.DrawRectangle(new Pen(Color.Gray, 2), rect);
                                    g.FillRectangle(System.Drawing.Brushes.Gray, rect);
                                }
                            }
                        }
                        _once = false;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            _once = true;
            Glavni_stevec = 0;
            Array.Clear(IgralnaMatrika, 0, IgralnaMatrika.Length);
            string str = textBox1.Text.ToString();
            ConvertStrToMap(str);
            this.Paint += Draw2DArray;
        }
    }
}
