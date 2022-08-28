using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Utils
{
    static class ImageConvertor
    {
        public static byte[] ConvertImageToBytes(string varFilePath)
        {
            byte[] file;
            using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            return file;
        }

        public static Image BinaryToImage(byte[] binaryData)
        {
            MemoryStream ms = new MemoryStream(binaryData);
            Image img = Image.FromStream(ms);
            return img;
        }
    }
}
