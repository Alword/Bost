using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;

namespace Bost.Utils
{
    public class ImageRotator
    {
        public ImageRotator()
        {
        }

        public void GetLeftSide(string side, string topPath = null)
        {
            int size = 32;

            if (topPath == null)
                topPath = side;

            Matrix leftMatrix = new Matrix();
            leftMatrix.Scale(0.83f / 2, 1f / 2);
            leftMatrix.Shear(0, 0.42447f);
            leftMatrix.Translate(6, 2);

            Matrix rightMatrix = new Matrix();
            rightMatrix.Scale(0.83f / 2, 1f / 2);
            rightMatrix.Translate(37,18);
            rightMatrix.Shear(0, -0.42447f);


            Matrix topMatrix = new Matrix();
            topMatrix.Scale(1f / 1.6f, 0.5f / 1.6f);
            topMatrix.Translate(25, 5);
            topMatrix.Rotate(45);


            using (var bitmap = new Bitmap(size, size))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    //left
                    var left = Image.FromFile(side);
                    g.Transform = leftMatrix;
                    g.DrawImage(left, 0, 10, size, size);
                    //right
                    var right = Image.FromFile(side);
                    g.Transform = rightMatrix;
                    g.DrawImage(right, 0, 10, size, size);
                    //top
                    var topImage = Image.FromFile(topPath);
                    g.Transform = topMatrix;
                    g.DrawImage(topImage, 0, 0, size, size);
                    g.Save();
                }
                bitmap.Save("test.png");
            }

        }
    }
}
