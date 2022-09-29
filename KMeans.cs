using System;
using System.Drawing;

public class KMeans
{
    public Color[] Fit(Bitmap bmp, int K)
    {
        Color[] centroids = new Color[K];
        Random rando = new Random();

        for (int i = 0; i < K; i++)
        {
            var r = rando.Next(255);
            var g = rando.Next(255);
            var b = rando.Next(255);
            centroids[i] = Color.FromArgb(r, g, b);
        }
        for(int y = 0; y<bmp.Height; y++)
        {
            for(int x = 0; x<bmp.Width; x++)
            {
                                                                                                                                                                                                                                                                                       
            }
        }


        return centroids;
    }
}