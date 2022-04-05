using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarGame
{
    public partial class Form1 : Form
    {
        int _score = 0;
        bool reButton = true;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            this.KeyPreview = true;
            tmrMain.Tick += TmrMain_Tick;
            btnStart.Click += BtnStart_Click;
            tmrMove.Tick += TmrMove_Tick;
            playTimer.Tick += PlayTimer_Tick;
        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {

        }

        private void TmrMove_Tick(object sender, EventArgs e)
        {
            MoveObstacle();
        }

        private void TmrMain_Tick(object sender, EventArgs e)
        {
            CreateObstacle();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            lblTime.Text = "00:00:00";
            timer.Tick += new EventHandler(PlayTimer_Tick);
            timer.Start();


            if (reButton)
            {
                Button clickedButton = (Button)sender;
                clickedButton.Text = "게임중지";

                tmrMain.Start();
                tmrMove.Start();

                reButton = false;
            }
            else
            {
                Button clickedButton = (Button)sender;
                clickedButton.Text = "게임시작";

                tmrMain.Stop();
                tmrMove.Stop();
                
                reButton = true;
            }
            
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                picCar.Left -= 4;
            }
            else if(e.KeyCode == Keys.Right)
            {
                picCar.Left += 4;
            }
        }

        private void CreateObstacle()
        {
            PictureBox box = new PictureBox();
            box.Size = new Size(60, 60);
            box.Tag = 0;

            int max = pnlRoad.Width - box.Height; 
            Random random = new Random();
            box.Left = random.Next(1, max);
            box.BackColor = Color.Red;
            pnlRoad.Controls.Add(box);

        }
        private void MoveObstacle()
        {
            foreach (Control item in pnlRoad.Controls)
            {
                bool isGetScore = item.Top >= (picCar.Top + picCar.Height);
                bool isNowScore = Convert.ToInt32(item.Tag) == 0;

                if (item.Top > pnlRoad.Height) item.Dispose();

                if (isGetScore && isNowScore)
                {
                    item.Tag = 1;
                    _score++;
                    lblScore.Text = _score.ToString();
                }

                if (item.Name == picCar.Name) continue;
                item.Top += 10;
            }
        }

        private void CheckCrush()
        {
            int carL = picCar.Left;
            int carR = carL + picCar.Width;

            int carT = picCar.Top;
            int carB = carT + picCar.Height;

            foreach(Control item in pnlRoad.Controls)
            {
                if (Convert.ToInt32(item.Tag) != 0) continue;

                int obstacleL = item.Left;
                int obstacleR = obstacleL + item.Width;

                int obstacleT = item.Top;
                int obstacleB = obstacleT + item.Height;

                if(obstacleL >= carL && obstacleL <= carR)
                {
                    tmrMain.Stop();
                    tmrMove.Stop();
                }
                if(obstacleR >= carL && obstacleR <= carR)
                {
                    tmrMain.Stop();
                    tmrMove.Stop();
                }

            }
        }
    }
}
