using System;
using System.Drawing;
using System.Collections.Generic;

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
        int avarageR = 0;
        int avarageG = 0;
        int avarageB = 0;

        int epochs = 0;
        while (epochs < 50)
        {
            epochs++;
            List<(long, long, long, long)> sums = new List<(long, long, long, long)>();
            for (int i = 0; i < K; i++)
                sums.Add((0, 0, 0, 0));

            for(int y = 0; y<bmp.Height; y++)
            {
                for(int x = 0; x<bmp.Width; x++)
                {
                    Color clrPixelBmp = bmp.GetPixel(y, x);

                    int bestcentroidindex = -1;
                    double minDist = double.PositiveInfinity;
                    
                    for(int i = 0; i < K; i++)
                    {
                        int centroidR = centroid[i].R;
                        int centroidG = centroid[i].G;
                        int centroidB = centroid[i].B;
                        
                        int clrPixelBmpR = clrPixelBmp.R;
                        int clrPixelBmpG = clrPixelBmp.G;
                        int clrPixelBmpB = clrPixelBmp.B;

                        int dr = centroidR - clrPixelBmpR;
                        int dg = centroidG - clrPixelBmpG;
                        int db = centroidB - clrPixelBmpB;

                        double pitagoras = dr * dr + dg * dg + db * db;
                        pitagoras = Math.Sqrt(pitagoras);
                        
                        if(minDist > pitagoras)
                        {
                            bestcentroidindex = i;
                            minDist = pitagoras;
                        }
                    }
                    
                    var sum = sums[bestcentroidindex];
                    sums[bestcentroidindex] = (sum.Item1 + clrPixelBmp.R, sum.Item2 + clrPixelBmp.G, sum.Item3 + clrPixelBmp.B, sum.Item4 + 1);
                }
            }
            for(int i = 0; i < K; i++)
            { 
                avarageR = sum[i].Item1 / sum[i].Item4;
                avarageG = sum[i].Item2 / sum[i].Item4;
                avarageB = sum[i].Item3 / sum[i].Item4;
                centroids[i] = new Color((byte)avarageR, (byte)avarageG, (byte)avarageB);
            }
        }
        return centroids;
    }
}