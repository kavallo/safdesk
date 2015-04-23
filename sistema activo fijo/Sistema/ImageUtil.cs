using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace Sistema
{
    class ImageUtil
    {
        public byte[] toArrayByte(Image imageIn)
        {
            MemoryStream MS = new MemoryStream();
            imageIn.Save(MS, System.Drawing.Imaging.ImageFormat.Gif);
            return MS.ToArray();
        }

        public Image toImage(byte[] byteArrayIn)
        {
            MemoryStream MS = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(MS);
            return returnImage;
        }
    }
}
