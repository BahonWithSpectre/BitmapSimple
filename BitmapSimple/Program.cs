using System;
using System.Drawing;
using System.Globalization;

namespace BitmapSimple
{
    class Program
    {
        static void Main(string[] args)
        {

            Bitmap img = new Bitmap("C:\\Users\\bakytzhan.shymkentba.RESMI\\Desktop\\obr.jpg");

            int p1 = 0, p2 = 0;
            int x, y;

            //Color pixelColor = img.GetPixel(48, 49);
            //var res2 = HexConverter(pixelColor);
            //Console.WriteLine("Color: " + res2);

            //Color black = Color.FromArgb(76, 247, 52);

            int argb = Int32.Parse("#FDFDFD".Replace("#", ""), NumberStyles.HexNumber);
            Color clr = Color.FromArgb(argb);

            System.Drawing.Color white = System.Drawing.Color.FromArgb(255, 255, 255);
            System.Drawing.Color black = System.Drawing.Color.FromArgb(0,0,0);



            Color recolor = Color.FromArgb( 255, 254, 254, 254);
            Color recolor2 = Color.FromArgb(255, 253, 253, 253);
            Color recolor3 = Color.FromArgb(255, 1, 1, 1);

            //Console.WriteLine($"X = { p1 } , Y = { p2 }" + $" Color - {black}");
            //Console.WriteLine($"ARGB - {pixelColor}. Hex - {res2}. ARGB Convert - {clr}");

            //Color pixelColor2 = image1.GetPixel(x, y);
            //Color newColor = Color.FromArgb(pixelColor2.R, 0, 0);
            //image1.SetPixel(x, y, newColor);

            var col = img.GetPixel(20, 18);
            var col2 = img.GetPixel(25, 25);

            int number = img.Height * img.Width;
            string[] matrColor = new string[number];
            int p = 0;

            Color color = new Color();
            Program program = new Program();
            string[,] matr = program.Matr(img.Height, img.Width);
            string[,] matrpost = program.Matr(img.Height, img.Width);
            string[,] matrpost2 = program.Matr(img.Height, img.Width);

            for (x = 0; x < img.Height; x++)
            {
                for (y = 0; y < img.Width; y++)
                {
                    color = img.GetPixel(x, y);

                    if (color == col)
                    {
                        matr[x, y] = "*";
                    }
                    else if (color == col2)
                    {
                        matr[x, y] = "|";
                    }
                }
            }

            program.Put(matr, img.Height, img.Width);
            Console.WriteLine("-----------------------------------------------------------------");
            for (x = 0; x < img.Height; x++)
            {
                for (y = 0; y < img.Width; y++)
                {
                    color = img.GetPixel(x, y);

                    if (color == col || color == recolor || color == recolor2)
                    {
                        img.SetPixel(x, y, white);
                    }
                    else if (color == col2 || color == recolor3)
                    {
                        img.SetPixel(x, y, black);
                    }
                }
            }

            string uri = "C:\\Users\\bakytzhan.shymkentba.RESMI\\Desktop\\obr2.jpg";
            img.Save(uri);

            for (x = 0; x < img.Height; x++)
            {
                for (y = 0; y < img.Width; y++)
                {
                    color = img.GetPixel(x, y);

                    if (color == col)
                    {
                        matrpost2[x, y] = "*";
                    }
                    else if (color == col2)
                    {
                        matrpost2[x, y] = "|";
                    }
                }
            }
            program.Put(matrpost2, img.Height, img.Width);
            //Console.WriteLine("-----------------------------------------------------------------\n" + col);
            //Console.WriteLine("-----------------------------------------------------------------\n" + col2);
            Console.WriteLine("-----------------------------------------------------------------");
            Bitmap newimg = new Bitmap(uri);

            for (x = 0; x < newimg.Height; x++)
            {
                for (y = 0; y < newimg.Width; y++)
                {
                    color = newimg.GetPixel(x, y);

                    if (color == col)
                    {
                        matrpost[x, y] = "*";
                    }
                    else if (color == col2)
                    {
                        matrpost[x, y] = "|";
                    }
                }
            }
            program.Put(matrpost, newimg.Height, newimg.Width);




            //string sourcePath = @"C:\\Users\\bakytzhan.shymkentba.RESMI\\Desktop\\obr.jpg";
            //string destPath = @"C:\\Users\\bakytzhan.shymkentba.RESMI\\Desktop\\newP.jpg";
            //Color green = Color.FromArgb(34, 245, 15);
            //Bitmap photo = new Bitmap(sourcePath, true);
            //for (int i = 0; i < photo.Width; i++)
            //{
            //    for (int j = 0; j < photo.Height; j++)
            //    {
            //        System.Drawing.Color pixelColor = photo.GetPixel(i, j);
            //        if (pixelColor == black || pixelColor == recolor3)
            //            photo.SetPixel(i, j, green);
            //    }
            //}
            //photo.Save(destPath);

        }


        private static string HexConverter(Color c)
        {
            return  ColorTranslator.ToHtml(Color.FromArgb(c.R, c.G, c.B));
        }

        public string[,] Matr(int n, int m)
        {
            if((n != 0) && (m != 0))
            {
                Random ran = new Random();
                string[,] a = new string[n, m];
                for(int i=0;i<n;i++)
                {
                    for(int j=0;j<m;j++)
                    {
                        a[i, j] = "0";
                    }
                }
                return a;
            }
            return null;
        }


        public void Put(string [,] b, int x1, int x2)
        {
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < x2; j++)
                {
                    Console.Write($"{b[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        
    }
}
