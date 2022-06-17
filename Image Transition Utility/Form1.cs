namespace Image_Transition_Utility
{
    public partial class Form1 : Form
    {
        public Bitmap IMG_From;
        public Bitmap IMG_To;
        public Bitmap IMG_Mid;
        public int Intercal_Count;
        public int Interval;
        public int v_wip_Indx;
        public int h_wip_Indx;

        public double[,,] Map_Mat = new double[3, 320, 240];

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IMG_From = new Bitmap("C:/NGSoftware/GitHub/Image-Transition-Utility/Images/bmw.jpg");
            pictureBox1.Image = IMG_From;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IMG_To = new Bitmap("C:/NGSoftware/GitHub/Image-Transition-Utility/Images/tiger.jpg");
            pictureBox2.Image = IMG_To;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IMG_To = new Bitmap("C:/NGSoftware/GitHub/Image-Transition-Utility/Images/tiger.jpg");
            pictureBox3.Image = IMG_To;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IMG_From == null) return;

            IMG_Mid = new Bitmap(IMG_From);
            pictureBox3.Image = IMG_Mid;
            Interval = trackBar1.Value;
            Intercal_Count = Interval;

            for (int x = 0; x < pictureBox1.Image.Width; x++)
                for (int y = 0; y < pictureBox1.Image.Height; y++)
                {
                    int FromR, ToR;
                    int FromG, ToG;
                    int FromB, ToB;

                    FromR = IMG_Mid.GetPixel(x, y).R;
                    FromG = IMG_Mid.GetPixel(x, y).G;
                    FromB = IMG_Mid.GetPixel(x, y).B;

                    ToR = IMG_To.GetPixel(x, y).R;
                    ToG = IMG_To.GetPixel(x, y).G;
                    ToB = IMG_To.GetPixel(x, y).B;

                    Map_Mat[0, x, y] = (ToR - FromR) / (double)Intercal_Count;
                    Map_Mat[1, x, y] = (ToG - FromG) / (double)Intercal_Count;
                    Map_Mat[2, x, y] = (ToB - FromB) / (double)Intercal_Count;
                }
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IMG_Mid = new Bitmap(IMG_From);
            pictureBox3.Image = IMG_Mid;
            Interval = trackBar1.Value;
            Intercal_Count = Interval;
            v_wip_Indx = 0;

            timer2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IMG_Mid = new Bitmap(IMG_From);
            pictureBox3.Image = IMG_Mid;
            Interval = trackBar1.Value;
            Intercal_Count = Interval;
            h_wip_Indx = 0;

            timer3.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Intercal_Count <= 0) timer1.Enabled = false;
            else
            {
                for (int x = 0; x < pictureBox1.Image.Width; x++)
                    for (int y = 0; y < pictureBox1.Image.Height; y++)
                    {
                        int MidR, FromR;
                        int MidG, FromG;
                        int MidB, FromB;

                        FromR = IMG_From.GetPixel(x, y).R;
                        FromG = IMG_From.GetPixel(x, y).G;
                        FromB = IMG_From.GetPixel(x, y).B;

                        MidR = (int)(FromR + (Interval - Intercal_Count + 1) * Map_Mat[0, x, y]);
                        MidG = (int)(FromG + (Interval - Intercal_Count + 1) * Map_Mat[1, x, y]);
                        MidB = (int)(FromB + (Interval - Intercal_Count + 1) * Map_Mat[2, x, y]);



                        IMG_Mid.SetPixel(x, y, Color.FromArgb(MidR, MidG, MidB));
                    }
                pictureBox3.Image = IMG_Mid;
                Intercal_Count--;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (v_wip_Indx >= IMG_From.Width) timer2.Enabled = false;
            else
            {

                for (int i = 0; i < Intercal_Count; i++)
                {
                    if (v_wip_Indx < IMG_From.Width)
                    {
                        for (int j = 0; j < IMG_From.Height; j++)
                        {
                            int ToR;
                            int ToG;
                            int ToB;

                            ToR = IMG_To.GetPixel(v_wip_Indx, j).R;
                            ToG = IMG_To.GetPixel(v_wip_Indx, j).G;
                            ToB = IMG_To.GetPixel(v_wip_Indx, j).B;

                            IMG_Mid.SetPixel(v_wip_Indx, j, Color.FromArgb(ToR, ToG, ToB));
                        }
                        v_wip_Indx++;
                    }

                }
                pictureBox3.Image = IMG_Mid;

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (h_wip_Indx >= IMG_From.Height) timer3.Enabled = false;
            else
            {

                for (int i = 0; i < Intercal_Count; i++)
                {
                    if (h_wip_Indx < IMG_From.Height)
                    {
                        for (int j = 0; j < IMG_From.Width; j++)
                        {
                            int ToR;
                            int ToG;
                            int ToB;

                            ToR = IMG_To.GetPixel(j, h_wip_Indx).R;
                            ToG = IMG_To.GetPixel(j, h_wip_Indx).G;
                            ToB = IMG_To.GetPixel(j, h_wip_Indx).B;

                            IMG_Mid.SetPixel(j, h_wip_Indx, Color.FromArgb(ToR, ToG, ToB));
                        }
                        h_wip_Indx++;
                    }

                }
                pictureBox3.Image = IMG_Mid;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}