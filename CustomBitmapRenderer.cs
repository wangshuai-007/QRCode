/*
 * Copyright 2013 ZXing.Net authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
//using System.Windows.Media;
using System.IO;
using System.Linq;
using ZXing.Common;
using ZXing.Common.Detector;
using ZXing.Multi.QrCode.Internal;
using ZXing.QrCode.Internal;
using Encoder = ZXing.QrCode.Internal.Encoder;

namespace ZXing.Rendering
{
    public class CustomBitmapRenderer : BitmapRenderer
    {
        public Color BackgroundGradientColor { get; set; }
        public Color ForegroundGradientColor { get; set; }
        public string IconFullName { get; set; }
        public string BackImageFullName { get; set; }
        public bool IsMergeBackColor { get; set; }
        public IconShape IconShape { get; set; }
        public CustomBitmapRenderer()
        {
            BackgroundGradientColor = Color.Aqua;
            Background = Color.GreenYellow;
            ForegroundGradientColor = Color.RoyalBlue;
            //Foreground = Color.MidnightBlue;
            Foreground = Color.FromArgb(3, 76, 2);
        }
        /// <summary>
        /// https://blog.qrstuff.com/2015/09/09/colour-qr-codes
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="format"></param>
        /// <param name="content"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override Bitmap Render(BitMatrix matrix, BarcodeFormat format, string content, EncodingOptions options)
        {
            int width = matrix.Width;
            int height = matrix.Height;
            Foreground = Color.Black;
            bool hasBackImage = false;
            var qrCode = Encoder.encode(content, ErrorCorrectionLevel.L,options.Hints);

            var qrCodeMatrix = qrCode.Matrix;
            Console.WriteLine("-----------------------------");
            foreach (var point in qrCodeMatrix.Array)
            {
                Console.WriteLine(string.Join(string.Empty, point.Select(s =>
                {
                    if (s == 0) return " ";
                    return s.ToString();
                })));
            }

            var det=new Detector(matrix);
            var detPoints = det.detect().Points;


            var backgroundBrush = new LinearGradientBrush(
               new Rectangle(0, 0, width, height), BackgroundGradientColor, BackgroundGradientColor, LinearGradientMode.Vertical);
            var foregroundBrush = new LinearGradientBrush(
               new Rectangle(0, 0, width, height), ForegroundGradientColor, ForegroundGradientColor, LinearGradientMode.ForwardDiagonal);

            var bmp = new Bitmap(width,height);
            var gg = Graphics.FromImage(bmp);
            if (File.Exists(BackImageFullName))
            {
                var backImageTemp=new Bitmap(BackImageFullName);
                bmp= new Bitmap(backImageTemp, new Size(width, height));
                gg=Graphics.FromImage(bmp);
                hasBackImage = true;
            }
            else
            {
                gg.Clear(BackgroundGradientColor);
            }

           
            Point startPoint=new Point(0,0);
            Point endPoint=new Point(0,0);
            bool isStartPoint = false;

            //var foreColor = Color.Black;
            //var backColor = Color.White;
            var foreColor = ForegroundGradientColor;
            var backColor = BackgroundGradientColor;

            if (hasBackImage && IsMergeBackColor)
            {
                var rateX = bmp.Width / qrCodeMatrix.Width;
                var rateY = bmp.Height / qrCodeMatrix.Height;
                if (rateY > rateX)
                {
                    rateY = rateX;
                }
                else
                {
                    rateX = rateY;
                }

                //todo boarder效果
                var defaultBorder = 0;
                var largeImage = new Bitmap(bmp, qrCodeMatrix.Width * rateX+defaultBorder, qrCodeMatrix.Height * rateY+defaultBorder);
                var largeG = Graphics.FromImage(largeImage);
                for (int inputY = 0; inputY < qrCodeMatrix.Height; inputY++)
                {
                    for (int inputX = 0; inputX < qrCodeMatrix.Width; inputX++)
                    {
                        Rectangle foreRectangle = new Rectangle(inputX * rateX+defaultBorder, inputY * rateY+defaultBorder, rateX, rateY);

                        //定点位使用黑白,其它位置使用PathGradientBrush根据module点的坐标画出图形
                        if (IsInDetect(qrCodeMatrix, inputX, inputY))
                        {
                            if (qrCodeMatrix[inputX, inputY] == 1)
                            {
                                largeG.FillRectangle(new SolidBrush(foreColor), foreRectangle);
                            }
                            else
                            {
                                largeG.FillRectangle(new SolidBrush(backColor), foreRectangle);
                            }
                        }
                        else
                        {
                            using (var ellipsePath = new GraphicsPath())
                            {

                                ellipsePath.AddEllipse(foreRectangle);
                                var brush = new PathGradientBrush(ellipsePath);

                                var color = bmp.GetPixel(foreRectangle.X, foreRectangle.Y);

                                brush.CenterPoint = new PointF(foreRectangle.Width / 2 + foreRectangle.X,
                                    foreRectangle.Height / 2 + foreRectangle.Y);
                                brush.SurroundColors = new[] {color};
                                brush.FocusScales = new PointF(0, 0);
                                if (qrCodeMatrix[inputX, inputY] == 1)
                                {

                                    brush.CenterColor = foreColor;
                                }
                                else
                                {
                                    brush.CenterColor = backColor;
                                }

                                largeG.FillRectangle(brush, foreRectangle);
                            }
                        }
                    }
                }

                return largeImage;
            }

            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    if (matrix[x, y])
                    {
                        if (!isStartPoint)
                        {
                            isStartPoint = true;
                            startPoint = new Point(x, y);
                            endPoint = new Point(width - x, height - y);
                        }
                        
                        gg.FillRectangle(foregroundBrush, x, y, 1, 1);
                    }
                    else
                    {
                        if (x < endPoint.X && y < endPoint.Y && x > startPoint.X && y > startPoint.Y)
                        {
                            if (hasBackImage)
                                gg.FillRectangle(backgroundBrush, x, y, 1, 1);

                        }
                    }
                }
            }



            if (File.Exists(IconFullName))
            {
                var icon = new Bitmap(IconFullName);
                Image circleIcon;
                if (IconShape == IconShape.Round)
                {
                    circleIcon = CutCircle(IconFullName, 0, 0, icon.Height);
                }
                else
                {
                    circleIcon = icon;
                }
                circleIcon = new Bitmap(circleIcon, new Size(33, 33));
                gg.DrawImage(circleIcon,
                    new PointF((startPoint.X + endPoint.X) / 2 - circleIcon.Width / 2,
                        (startPoint.Y + endPoint.Y) / 2 - circleIcon.Height / 2));
            }

            if (hasBackImage)
                gg.DrawRectangle(new Pen(Color.White, 5), startPoint.X - 3, startPoint.Y - 3,
                    endPoint.X - startPoint.X + 4,
                    endPoint.Y - startPoint.Y + 4);

            return bmp;
        }
        public System.Drawing.Image CutCircle(string sourceFile, int circleUpperLeftX, int circleUpperLeftY, int circleDiameter)
        {
            Bitmap SourceImage = new Bitmap(System.Drawing.Image.FromFile(sourceFile));
            Rectangle CropRect = new Rectangle(circleUpperLeftX, circleUpperLeftY, circleDiameter, circleDiameter);
            Bitmap CroppedImage = SourceImage.Clone(CropRect, SourceImage.PixelFormat);
            TextureBrush TB = new TextureBrush(CroppedImage);
            Bitmap FinalImage = new Bitmap(circleDiameter, circleDiameter);
            Graphics G = Graphics.FromImage(FinalImage);
            G.FillEllipse(TB, 0, 0, circleDiameter, circleDiameter);
            return FinalImage;
        }
        public Bitmap ClipToCircle(Bitmap original, PointF center, float radius)
        {
            Bitmap copy = new Bitmap(original);
            using (Graphics g = Graphics.FromImage(copy))
            {
                RectangleF r = new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2);
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(r);
                g.Clip = new Region(path);
                g.DrawImage(original, 0, 0);
                return copy;
            }
        }

        public bool AreColorsSimilar(Color c1, Color c2, int tolerance=20)
        {
            return Math.Abs(c1.R - c2.R) < tolerance &&
                   Math.Abs(c1.G - c2.G) < tolerance &&
                   Math.Abs(c1.B - c2.B) < tolerance;
        }
  
        /// <summary>
        /// 坐标是否在坐上、右上、左下的定点位
        /// </summary>
        /// <param name="originMatrix"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool IsInDetect(ByteMatrix originMatrix,int x, int y)
        {
            return IsInRectangel(new Point(0, 0), x, y) ||
                   IsInRectangel(new Point(originMatrix.Array[0].Length - 8, 0), x, y) ||
                   IsInRectangel(new Point(0, originMatrix.Array.Length - 8), x, y);
        }
        public static bool IsInDetect(ResultPoint[] detectPoints, int x, int y)
        {
            int detectR = 10;
            //return (x >= detectPoints[0].X && x < detectPoints[3].X) &&
            //       (y >= detectPoints[1].Y && y < detectPoints[0].Y);
            return IsInRectangel(detectPoints[0], detectR, x, y) || IsInRectangel(detectPoints[1], detectR, x, y) ||
                   IsInRectangel(detectPoints[3], detectR, x, y);
        }

        public static bool IsInRectangel(Point rPoint, int x, int y)
        {
            return IsInRectangel(rPoint, 7, x, y);
        }

        public static bool IsInRectangel(Point rPoint, int r, int x, int y)
        {
            if (x >= rPoint.X && y >= rPoint.Y)
                return ((x - rPoint.X) <= r) && ((y - rPoint.Y) <= r);
            else
            {
                return false;
            }
        }

        public static bool IsInRectangel(ResultPoint point, int r, int x, int y)
        {
            return (x >= (point.X - x) && (x < point.X + x)) && ((y >= (point.Y - r) && (y < point.Y + r)));
        }
        public static Color GetMiddleColor(Color forColor,Color backColor)
        {
            return Color.FromArgb(128,(forColor.R+backColor.R)/2,(forColor.G+backColor.G)/2,(forColor.B+backColor.B)/2);
        }
    }

    public enum IconShape
    {
        Round,
        Square
    }
}
