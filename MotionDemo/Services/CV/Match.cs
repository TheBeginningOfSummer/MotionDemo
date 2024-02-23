using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        int nPointCounts;
        Point cordinates;
        int nModelHeight;
        int nModelWidth;
        double edgeMagnitude;
        double edgeDerivativeX;
        double edgeDerivativeY;
        Point CenterPoint;

        int CreateMatchModel(Mat templateImg, double dMinContrast, double dMaxContrast)
        {
            Size size;
            Mat src = new Mat();
            templateImg.CopyTo(src);

            nModelHeight = size.Height = templateImg.Size().Height;
            nModelWidth = size.Width = templateImg.Size().Width;

            nPointCounts = 0;
            cordinates = new Point();

            Mat gx, gy;
            gx = new Mat(size.Height, size.Width, MatType.CV_16SC1);
            gy = new Mat(size.Height, size.Width, MatType.CV_16SC1);
            Cv2.Sobel(templateImg, gx, MatType.CV_16S, 1, 0, 3);
            Cv2.Sobel(templateImg, gy, MatType.CV_16S, 0, 1, 3);

            return 1;
        }
    }
}
