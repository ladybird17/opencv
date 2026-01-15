using System;
using OpenCvSharp;

class Program
{
    static void Main()
    {
        // 이미지 읽기
        using var img = Cv2.ImRead("C:\\workspace-vs\\opencv-study\\sample.jpg", ImreadModes.Color);

        if (img.Empty())
        {
            Console.WriteLine("이미지를 찾을 수 없습니다.");
            return;
        }

        // 그레이스케일 변환
        using var gray = new Mat();
        Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);

        //이미지 픽셀 접근하여 BGR 수정
        Mat only_r = img.Clone();
        Mat only_g = img.Clone();
        Mat only_b = img.Clone();
        for (int y = 0; y < img.Rows; y++)
        {
            for (int x = 0; x < img.Cols; x++)
            {
                Vec3b pixel = img.At<Vec3b>(y, x);
                // pixel.Item0 = Blue, Item1 = Green, Item2 = Red
                // Only Red 
                only_r.At<Vec3b>(y, x)[0] = 0; // zero B
                only_r.At<Vec3b>(y, x)[1] = 0; // zero G
                // Only Green
                only_g.At<Vec3b>(y, x)[0] = 0; // zero B
                only_g.At<Vec3b>(y, x)[2] = 0; // zero R
                // Only Blue
                only_b.At<Vec3b>(y, x)[1] = 0; // zero G
                only_b.At<Vec3b>(y, x)[2] = 0; // zero R
            }
        }

        Cv2.ImShow("원본 이미지", img);
        Cv2.ImShow("Gray", gray);
        Cv2.ImShow("Only Red", only_r);
        Cv2.ImShow("Only Green", only_g);
        Cv2.ImShow("Only Blue", only_b);
        Cv2.WaitKey();
        Cv2.DestroyAllWindows();
    }
}
