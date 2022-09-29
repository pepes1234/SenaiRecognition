namespace SenaiRecognition;
using System.IO;

public partial class Form1 : Form
{
    PictureBox pb1;
    public Form1()
    {
        InitializeComponent();
        Load += delegate
        {
            pb1 = new PictureBox();
            pb1.Image = Image.FromFile(@"TestImages\test1(64x64).png");
            pb1.Dock = DockStyle.Fill;
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb1);
        };
    }
    
}
