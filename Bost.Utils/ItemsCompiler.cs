using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Bost.Utils
{
    public class ItemsCompiler : IDisposable
    {
        private readonly string imagePath;
        public ItemsCompiler(string path)
        {
            this.imagePath = path;
        }

        public void Compile()
        {
            string format = ".png";
            int itemSize = 32;
            StringBuilder stringBuilder = new StringBuilder();
            var files = Directory.GetFiles(imagePath).Where(d => d.EndsWith(format)).ToArray();
            int inlineCount = (int)Math.Ceiling(Math.Sqrt(files.Length));
            int atlasSize = itemSize * inlineCount;
            stringBuilder.AppendLine($"{itemSize}");
            stringBuilder.AppendLine($"{inlineCount}");

            using (var bitmap = new Bitmap(atlasSize, atlasSize))
            {
                int i = 0;
                int j = 0;
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    foreach (var file in files)
                    {
                        string name = Path.GetFileName(file).Replace(format, "");
                        stringBuilder.AppendLine(name);
                        var image = Image.FromFile(file);
                        g.DrawImage(image, i, j, itemSize, itemSize);
                        i += itemSize;
                        if (i > atlasSize)
                        {
                            j += itemSize;
                            i = 0;
                        }
                    }
                    g.Save();
                }
                bitmap.Save("items.png");
                File.WriteAllText("items.txt", stringBuilder.ToString());
            }
        }

        public void Dispose()
        {
        }
    }
}
