﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ImageResize
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\charles.oh\Downloads\BaramRenderer\images\";
            string outputPath = @"C:\Users\charles.oh\Downloads\BaramRenderer\output\";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] info = dir.GetFiles("*.*");
            foreach (FileInfo f in info)
            {
                ResizeImage(f.FullName, outputPath + f.Name, 100, 100);
            }

        }

        private static void ResizeImage(String filename, String destPath, int maxWidth, int maxHeight)
        {
            using (Image originalImage = Image.FromFile(filename))
            {
                //Caluate new Size
                //int newWidth = originalImage.Width;
                //int newHeight = originalImage.Height;
                //double aspectRatio = (double)originalImage.Width / (double)originalImage.Height;
                //if (aspectRatio <= 1 && originalImage.Width > maxWidth)
                //{
                //    newWidth = maxWidth;
                //    newHeight = (int)Math.Round(newWidth / aspectRatio);
                //}
                //else if (aspectRatio > 1 && originalImage.Height > maxHeight)
                //{
                //    newHeight = maxHeight;
                //    newWidth = (int)Math.Round(newHeight * aspectRatio);
                //}

                int newWidth = originalImage.Width * 2;
                int newHeight = originalImage.Height * 2 ;
                Bitmap newImage = new Bitmap(newWidth, newHeight);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    //--Quality Settings Adjust to fit your application
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);
                }
                newImage.Save(destPath);
            }
        }
    }
}
