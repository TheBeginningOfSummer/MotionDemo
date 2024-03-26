using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MotionDemo.Services
{
    public class Match
    {
        string imageWindow = "Source Image";
        string resultWindow = "Result Image";
        int maxTrackbar = 5;

        public static Mat MatchingMethod(Mat img, Mat temp, TemplateMatchModes matchModes = TemplateMatchModes.SqDiff, Mat mask = null)
        {
            Mat imgDisplay = new Mat();
            img.CopyTo(imgDisplay);
            int resultCols = img.Cols - temp.Cols + 1;
            int resultRows = img.Rows - temp.Rows + 1;
            Mat result = new Mat();
            result.Create(resultRows, resultCols, MatType.CV_32FC1);

            if (mask != null)
            {
                Cv2.MatchTemplate(img, temp, result, matchModes, mask);
            }
            else
            {
                Cv2.MatchTemplate(img, temp, result, matchModes);
            }
            Cv2.Normalize(result, result, 0, 1, NormTypes.MinMax);
            Cv2.MinMaxLoc(result, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc);
            if (matchModes == TemplateMatchModes.SqDiff || matchModes == TemplateMatchModes.SqDiffNormed)
            {
                Cv2.Rectangle(imgDisplay, minLoc, new Point(minLoc.X + temp.Cols, minLoc.Y + temp.Rows), Scalar.DarkSeaGreen, 2);
            }
            else
            {
                Cv2.Rectangle(imgDisplay, maxLoc, new Point(maxLoc.X + temp.Cols, maxLoc.Y + temp.Rows), Scalar.DarkSeaGreen, 2);
            }
            //Cv2.ImShow(imageWindow, imgDisplay);
            return imgDisplay;
        }

        float saturate_cast(double val)
        {
            if (val < 0)
                return 0;
            if (val > 255)
                return 255;
            return (float)val;
        }

        //int CreateMatchModel(Mat templateImg, double dMinContrast, double dMaxContrast)
        //{
        //    Size size = new Size();
        //    Mat src = new Mat();
        //    templateImg.CopyTo(src);

        //    nModelHeight = size.Height = templateImg.Size().Height;
        //    nModelWidth = size.Width = templateImg.Size().Width;

        //    nPointCounts = 0;
        //    cordinates = new Point();

        //    Mat gx = new Mat();
        //    Mat gy = new Mat();
        //    gx = new Mat(size.Height, size.Width, MatType.CV_16SC1);
        //    gy = new Mat(size.Height, size.Width, MatType.CV_16SC1);
        //    Cv2.Sobel(templateImg, gx, MatType.CV_16S, 1, 0, 3);
        //    Cv2.Sobel(templateImg, gy, MatType.CV_16S, 0, 1, 3);
        //    Mat tmp = new Mat();
        //    gx = Mat.Zeros(templateImg.Size(), MatType.CV_8U);
        //    Cv2.Normalize(templateImg, tmp, 0, 255, NormTypes.MinMax);
        //    Cv2.ConvertScaleAbs(tmp, gx);
        //    gy = Mat.Zeros(templateImg.Size(), MatType.CV_8U);
        //    Cv2.Normalize(templateImg, tmp, 0, 255, NormTypes.MinMax);
        //    Cv2.ConvertScaleAbs(tmp, gy);
        //    int nRow = 0;
        //    int nCol = 0;
        //    double dx, dy;
        //    double dMagG, dDirG;
        //    double dMaxGradient = -9999999999.0;
        //    Mat nmsEdgesMat = Mat.Zeros(templateImg.Rows, templateImg.Cols, MatType.CV_32FC1);
        //    List<double> directions = new List<double>();
        //    Mat magMat = new Mat();
        //    for (int i = 0; i < size.Height; i++)
        //    {
        //        for (int j = 0; j < size.Width; j++)
        //        {
        //            dx = gx.Get<double>(i, j);
        //            dy = gy.Get<double>(i, j);
        //            dMagG = Math.Sqrt(dx * dx + dy * dy);
        //            dDirG = Math.Atan2(dy, dx);

        //            if (dMagG > dMaxGradient) dMaxGradient = dMagG;
        //            if ((dDirG > 0 && dDirG < 22.5) || (dDirG > 157.5 && dDirG < 202.5) || (dDirG > 337.5 && dDirG < 360))
        //                dDirG = 0;
        //            else if ((dDirG > 22.5 && dDirG < 67.5) || (dDirG > 202.5 && dDirG < 247.5))
        //                dDirG = 45;
        //            else if ((dDirG > 67.5 && dDirG < 112.5) || (dDirG > 247.5 && dDirG < 292.5))
        //                dDirG = 90;
        //            else if ((dDirG > 112.5 && dDirG < 157.5) || (dDirG > 292.5 && dDirG < 337.5))
        //                dDirG = 135;
        //            else dDirG = 0;

        //            directions.Add(dDirG);
        //            magMat.Set(i, j, dMagG);
        //        }
        //    }

        //    int nCount = 0;
        //    double dLeftPixel = 0;
        //    double dRightPixel = 0;
        //    bool bIsRange = true;

        //    for (int i = 0; i < size.Height; i++)
        //    {
        //        for (int j = 0; j < size.Width; j++)
        //        {
        //            bIsRange = false;
        //            switch (directions[nCount])
        //            {
        //                case 0:
        //                    if (j - 1 >= 0 && j + 1 <= size.Width)
        //                    {
        //                        dLeftPixel = magMat.Get<double>(i - 1, j);
        //                        dRightPixel = magMat.Get<double>(i + 1, j);
        //                        bIsRange = true;
        //                    }
        //                    break;
        //                case 45:
        //                    if ((i - 1 >= 0 && i + 1 <= size.Height) && (j - 1 >= 0 && j + 1 <= size.Width))
        //                    {
        //                        dLeftPixel = magMat.Get<double>(i - 1, j + 1);
        //                        dRightPixel = magMat.Get<double>(i + 1, j - 1);
        //                        bIsRange = true;
        //                    }
        //                    break;
        //                case 90:
        //                    if (i - 1 >= 0 && i + 1 <= size.Height)
        //                    {
        //                        dLeftPixel = magMat.Get<double>(i - 1, j);
        //                        dRightPixel = magMat.Get<double>(i + 1, j);
        //                        bIsRange = true;
        //                    }
        //                    break;
        //                case 135:
        //                    if ((j - 1 >= 0 && j + 1 <= size.Width) && (i - 1 >= 0 && i + 1 <= size.Height))
        //                    {
        //                        dLeftPixel = magMat.Get<double>(i - 1, j - 1);
        //                        dRightPixel = magMat.Get<double>(i + 1, j + 1);
        //                        bIsRange = true;
        //                    }
        //                    break;
        //                default: break;
        //            }

        //            if (magMat.Get<double>(i, j) < dLeftPixel || magMat.Get<double>(i, j) < dRightPixel || bIsRange == false)
        //            {
        //                nmsEdgesMat.At<float>(i, j) = 0;
        //            }
        //            else
        //            {
        //                nmsEdgesMat.At<float>(i, j) = saturate_cast(255 * magMat.Get<double>(i, j) / dMaxGradient);
        //            }
        //            nCount++;
        //        }
        //    }

        //    int nFlag = 1;
        //    for (int i = 0; i < size.Height; i++)
        //    {
        //        for (int j = 0; j < size.Width; j++)
        //        {
        //            dx = gx.At<short>(i, j);
        //            dy = gy.At<short>(i, j);
        //            dMagG = Math.Sqrt(dx * dx + dy * dy);
        //            dDirG = Math.Atan2(dy, dx);
        //            nFlag = 1;

        //            if (nmsEdgesMat.At<float>(i, j) < dMaxContrast)
        //            {
        //                if (nmsEdgesMat.At<float>(i, j) < dMinContrast)
        //                {
        //                    nmsEdgesMat.At<float>(i, j) = 0;
        //                    nFlag = 0;
        //                }
        //                else
        //                {
        //                    if (i - 1 <= 0 || i + 1 >= size.Height || j - 1 <= 0 || j + 1 >= size.Width)
        //                    {
        //                        nmsEdgesMat.At<float>(i, j) = 0;
        //                        nFlag = 0;
        //                    }
        //                    else
        //                    {
        //                        if (nmsEdgesMat.At<float>(i - 1, j - 1) < dMaxContrast
        //                            && nmsEdgesMat.At<float>(i, j - 1) < dMaxContrast
        //                            && nmsEdgesMat.At<float>(i + 1, j) < dMaxContrast
        //                            && nmsEdgesMat.At<float>(i - 1, j) < dMaxContrast
        //                            && nmsEdgesMat.At<float>(i - 1, j + 1) < dMaxContrast
        //                            && nmsEdgesMat.At<float>(i, j + 1) < dMaxContrast
        //                            && nmsEdgesMat.At<float>(i + 1, j + 1) < dMaxContrast)
        //                        {
        //                            nmsEdgesMat.At<float>(i, j) = 0;
        //                            nFlag = 0;
        //                        }
        //                    }
        //                }
        //            }

        //            int nCurX = i;
        //            int nCurY = j;
        //            if (nFlag != 0 && (dx != 0 || dy != 0))
        //            {
        //                nRow = nRow + nCurX;
        //                nCol = nCol + nCurY;

        //            }
        //        }
        //    }








        //    return 1;
        //}

        void CreateMatchModel(Mat templateImg)
        {
            Mat result = new Mat();
            Cv2.Canny(templateImg, result, 100, 255);
        }

        struct MODELMSG
        {
            public List<Point> vtPoint;
            public List<double> vdMag;
            public List<float> vdx;
            public List<float> vdy;
            public List<double> vdDirects;
            public Point tPointCenter;

            public void Initialize()
            {
                vtPoint = new List<Point>();
                vdMag = new List<double>();
                vdx = new List<float>();
                vdy = new List<float>();
                vdDirects = new List<double>();
            }
        }

        private static float Min(float num1,float num2)
        {
            if (num1 > num2)
                return num2;
            else
                return num1;
        }

        public static void Matching()
        {
            Mat imgSrc, imgTemplate;
            imgSrc = Cv2.ImRead("C:\\Users\\1\\Desktop\\test\\测试图片\\test1.0.png");
            imgTemplate = Cv2.ImRead("C:\\Users\\1\\Desktop\\test\\测试图片\\test1.1.png");

            if (imgSrc.Empty() || imgTemplate.Empty())
            {
                return;
            }

            Mat imgGray = new Mat();Mat imgTemplateGray = new Mat();
            if (imgSrc.Channels() == 3)
                Cv2.CvtColor(imgSrc, imgGray, ColorConversionCodes.BGR2GRAY);
            else
                imgSrc.CopyTo(imgGray);
            if (imgTemplate.Channels() == 3)
                Cv2.CvtColor(imgTemplate, imgTemplateGray, ColorConversionCodes.BGR2GRAY);
            else
                imgTemplate.CopyTo(imgGray);

            Mat imgCanny = new Mat();
            Cv2.Canny(imgTemplateGray, imgCanny, 20, 100);
            Cv2.ImShow("imgCanny", imgCanny);
            Cv2.FindContours(imgCanny, out Point[][] contours, out HierarchyIndex[] hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxNone);

            Mat dx = new Mat(); Mat dy = new Mat();
            Cv2.Sobel(imgTemplateGray, dx, MatType.CV_16S, 1, 0, 3);
            Cv2.Sobel(imgTemplateGray, dy, MatType.CV_16S, 0, 1, 3);

            Point tPointResult = new Point();
            MODELMSG tModmsg = new MODELMSG(); tModmsg.Initialize();
            Point tPoint;
            int nCount = 0;
            int nSumX = 0;
            int nSumY = 0;
            for (int i = 0; i < contours.Length; i++)
            {
                for (int j = 0; j < contours[i].Length; j++)
                {
                    tModmsg.vtPoint.Add(contours[i][j]);
                    float gx = dx.At<short>(contours[i][j].X, contours[i][j].Y);
                    float gy = dy.At<short>(contours[i][j].X, contours[i][j].Y);
                    double dDirects = Math.Atan2(gy, gx);
                    tModmsg.vdx.Add(gx);
                    tModmsg.vdy.Add(gy);
                    tModmsg.vdDirects.Add(dDirects);
                    double dMag = Math.Sqrt(gx * gx + gy * gy);
                    tModmsg.vdMag.Add(dMag);

                    nSumX += contours[i][j].X;
                    nSumY += contours[i][j].Y;
                    nCount++;
                }
            }

            tPoint.X = nSumX / nCount;
            tPoint.Y = nSumY / nCount;

            Mat dsrcX = new Mat();
            Mat dsrcY = new Mat();
            Cv2.Sobel(imgGray, dsrcX, MatType.CV_16S, 1, 0, 3);
            Cv2.Sobel(imgGray, dsrcY, MatType.CV_16S, 1, 0, 3);
            double dsum;
            double dMinScore = 0.8;
            double dGreed = 0.5;
            double dNormGreed = ((1 - dMinScore) / (1 - dGreed)) / tModmsg.vdMag.Count;
            double dNormMinscore = dMinScore / tModmsg.vdMag.Count;
            double dResultScore = 0;
            int nNum = 0;
            double partSum = 0;
            int nCurX, nCurY;
            for (int i = 0; i < imgGray.Rows; i++)
            {
                for (int j = 0; j < imgGray.Cols; j++)
                {
                    dsum = 0;
                    nNum = 0;
                    for (int m = 0; m < tModmsg.vtPoint.Count; m++)
                    {
                        nCurX = i + tModmsg.vtPoint[m].Y;
                        nCurY = j + tModmsg.vtPoint[m].X;
                        if (nCurX < 0 || nCurY < 0 || nCurX > imgGray.Rows - 1 || nCurY > imgGray.Cols - 1)
                        {
                            continue;
                        }
                        double dImgdx = (double)dsrcX.At<short>(nCurX, nCurY);
                        double dImgdy = (double)dsrcY.At<short>(nCurX, nCurY);
                        double dImgMga = (double)Math.Sqrt(dImgdx * dImgdx + dImgdy * dImgdy);
                        double dx1 = (double)tModmsg.vdx[m];
                        double dy1 = (double)tModmsg.vdy[m];
                        double dMagModle = (double)tModmsg.vdMag[m];

                        if((dx1!=0||dy1!=0)&&(dImgdx!=0||dImgdy!=0))
                        {
                            dsum += (dx1 * dImgdx + dy1 * dImgdy) / (dImgMga * tModmsg.vdMag[m]);
                        }
                        nNum = m + 1;
                        partSum = dsum / nNum;

                        float fJudge = Min(((float)dMinScore - 1) + (float)dNormGreed * nNum, (float)dNormMinscore * nNum);
                        if (partSum < fJudge) break;
                    }
                    if (partSum > dResultScore)
                    {
                        dResultScore = partSum;
                        tPointResult.X = j;
                        tPointResult.Y = i;
                    }
                }
            }

            Cv2.Circle(imgGray, new Point(tPointResult.X, tPointResult.Y), 4, Scalar.White);
            Cv2.Rectangle(imgGray, new Rect(tPointResult.X, tPointResult.Y, imgTemplateGray.Size().Width, imgTemplateGray.Size().Height), Scalar.White);

            Cv2.ImShow("result", imgGray);
            Cv2.WaitKey();

        }


    }
}
