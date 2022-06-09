using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public static class DALToolkit
    {

        /// <summary>
        /// Convierte una imagen en formato VarBinary, devuelto como un string.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string ImgToVarbinary(Image i)
        {
            byte[] bits = new byte[0];
            Bitmap bmp;

            using (MemoryStream ms = new MemoryStream())
            {
                if (i != null)
                    bmp = new Bitmap(i);

                else
                    bmp = new Bitmap(1, 1);

                bmp.Save(ms, ImageFormat.Png);
                bits = ms.ToArray();
            }

            return bits.ToString();
        }


        /// <summary>
        /// Intenta convertir un objeto de tipo byte[] en tipo Image.
        /// </summary>
        /// <param name="arrayBinary"></param>
        /// <returns></returns>
        public static Image ConvertToImage(object arrayBinary)
        {
            if (arrayBinary == null)
                return new Bitmap(1, 1);
            if (arrayBinary.ToString().Length < 5)
                return new Bitmap(1, 1);

            
            Image rImage = null;

            using (MemoryStream ms = new MemoryStream((byte[])arrayBinary))
            {
                rImage = (Image)Bitmap.FromStream(ms).Clone();
            }
            return rImage;
        }





    }
}
