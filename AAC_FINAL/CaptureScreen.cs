using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AAC_FINAL
{
    /// <summary>
    /// Captura a tela do jogador usando a API WIN32
    /// </summary>
    /// 
    class CaptureScreen
    {
        // Resolução máxima permitida.
        private Size MAX_ALLOWED_RESOLUTION = new Size(1920, 1080);

        Settings ST = new Settings();

        /// <summary>
        /// Importação de bibliotecas e definição de variáveis WIN32 API.
        /// </summary>
        public class WIN32_API
        {
            public struct SIZE
            {
                public int cx;
                public int cy;
            }

            public const int SRCCOPY = 13369376;
            public const int SM_CXSCREEN = 0;
            public const int SM_CYSCREEN = 1;

            [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
            public static extern IntPtr DeleteDC(IntPtr hDc);

            [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
            public static extern IntPtr DeleteObject(IntPtr hDc);

            [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
            public static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, int RasterOp);

            [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

            [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

            [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

            [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
            public static extern IntPtr GetDesktopWindow();

            [DllImport("user32.dll", EntryPoint = "GetDC")]
            public static extern IntPtr GetDC(IntPtr ptr);

            [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
            public static extern int GetSystemMetrics(int abc);

            [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
            public static extern IntPtr GetWindowDC(Int32 ptr);

            [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        }

        protected static IntPtr m_HBitmap;
        /// <summary>
        /// Processa e armazena a imagem capturada pela função Capture_Desktop_Image()
        /// <param name="path">Diretorio onde a imagem será armazenada.</param>
        /// </summary>
        public void Capture(string path, string username)
        {
            try
            {
                Bitmap captured = Capture_Desktop_Image();

                string time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                using (Graphics g = Graphics.FromImage(captured))
                {
                    g.CopyFromScreen(0, 0, 0, 0, captured.Size);

                    using (Font arialFont = new Font("Arial", 40, FontStyle.Bold))
                    {
                        g.DrawString("[AAC] " + username + " @ " + time, arialFont, Brushes.Yellow, new PointF(20, 990));
                    }

                    var jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                    var encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 30L);

                    int win_size_width = Screen.PrimaryScreen.Bounds.Width;
                    int win_size_height = Screen.PrimaryScreen.Bounds.Height;

                    Bitmap nbmp;

                    if (win_size_width > MAX_ALLOWED_RESOLUTION.Width)
                    {
                        float scale = Math.Min((float)MAX_ALLOWED_RESOLUTION.Height / (float)captured.Height, (float)MAX_ALLOWED_RESOLUTION.Width / (float)captured.Width);
                        nbmp = Resize_Image(captured, new Size((int)(captured.Width * scale), (int)(captured.Height * scale)));
                    } else
                    {
                        nbmp = captured;
                    }

                    nbmp.Save(path, jpegEncoder, encoderParameters);
                }
            }
            catch (Exception e) { }
        }
        public static Bitmap Resize_Image(Bitmap imgToResize, Size size)
        {
            try
            {
                Bitmap b = new Bitmap(size.Width, size.Height);
                using (Graphics g = Graphics.FromImage((Image)b))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
                }
                return b;
            }
            catch
            {
                return imgToResize;
            }
        }

        /// <summary>
        /// Função que realiza a captura por meio da API WIN32
        /// <returns>Bitmap</returns>
        /// </summary>
        public static Bitmap Capture_Desktop_Image()
        {
            WIN32_API.SIZE size;

            IntPtr hDC = WIN32_API.GetDC(WIN32_API.GetDesktopWindow());
            IntPtr hMemDC = WIN32_API.CreateCompatibleDC(hDC);

            size.cx = WIN32_API.GetSystemMetrics(WIN32_API.SM_CXSCREEN);
            size.cy = WIN32_API.GetSystemMetrics(WIN32_API.SM_CYSCREEN);

            m_HBitmap = WIN32_API.CreateCompatibleBitmap(hDC, size.cx, size.cy);

            if (m_HBitmap != IntPtr.Zero)
            {
                IntPtr hOld = (IntPtr)WIN32_API.SelectObject(hMemDC, m_HBitmap);
                WIN32_API.BitBlt(hMemDC, 0, 0, size.cx, size.cy, hDC, 0, 0, WIN32_API.SRCCOPY);
                WIN32_API.SelectObject(hMemDC, hOld);
                WIN32_API.DeleteDC(hMemDC);
                WIN32_API.ReleaseDC(WIN32_API.GetDesktopWindow(), hDC);
                return System.Drawing.Image.FromHbitmap(m_HBitmap);
            }
            return null;
        }

        /// <summary>
        /// Obtém o codec para arquivos de imagem.
        /// <returns>ImageCodecInfo {JPG}</returns>
        /// </summary>
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }
    }
}
