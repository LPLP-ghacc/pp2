using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp2
{
    public static class ImageConvert
    {
        public static int[] Convert(Bitmap image)
        {
            List<Color> list = new List<Color>();

            var size = image.Size;

            for(int i = 0; i < size.Height; i++)
            {
                for(int j = 0; j < size.Width; j++)
                {
                    list.Add(image.GetPixel(j, i));
                }
            }

            List<int> intsArray = new List<int>();

            list.ForEach(i =>
            {
                if(i.A == 0)
                {
                    intsArray.Add(0);
                }else
                {
                    intsArray.Add(GetIntFromColor(i.R, i.G, i.B, 66));
                }
            });

            return intsArray.ToArray();
        }

        private static int GetIntFromColor(byte r, byte g, byte b, byte _minValue)
        {
            byte minValue = _minValue;

            if(r < minValue)
            {
                return 1;
            }
            if(g < minValue)
            {
                return 1;
            }
            if(b < minValue)
            {
                return 1;
            }

            return 0;
        }
    }
}
