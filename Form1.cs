namespace SenaiRecognition;
using System.IO;

public partial class Form1 : Form
{
    PictureBox pb1;
    List<Panel> pnlist = new List<Panel>();
    Bitmap bmp;
    public Form1()
    {
        InitializeComponent();

        Load += delegate
        {
            pb1 = new PictureBox();
            pb1.Image = Image.FromFile(@"TestImages\penta.jpg");
            pb1.Size = new Size(2 * 246, 2 * 164);
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb1);
            pb1.Location = new Point(10, 10);
            bmp = new Bitmap(@"TestImages\penta.jpg", true);
            for(int i = 0; i < 25; i++)
            {
                pnlist.Add(new Panel());
                pnlist[i].Size = new Size(25, 25);
                pnlist[i].Location = new Point(this.Width - 300, i * 40 + pnlist[i].Height);
                pnlist[i].BackColor = Color.Gray;
                this.Controls.Add(pnlist[i]);
            }
        
            KMeans kms = new KMeans();
            Color[] clr = kms.Fit(bmp, 15);

            for(int i = 0; i < 15; i++)
            {
                pnlist[i].BackColor = clr[i];
            }
        };
    }
}
