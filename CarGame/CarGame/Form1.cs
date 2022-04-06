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
        int _speed = 1;
        bool reButton = true;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            this.KeyPreview = true;
            tmrMain.Tick += TmrMain_Tick;
            btnStart.Click += BtnStart_Click;
            tmrMove.Tick += TmrMove_Tick;
        }

        private void TmrMove_Tick(object sender, EventArgs e)
        {
            MoveObstacle();

            bool isCrush = CheckCrush();

            if (isCrush)
            {
                GameOverLabel();
                tmrMain.Stop();
                tmrMove.Stop();

                btnStart.Text = "다시시작";
            }

        }

        private void TmrMain_Tick(object sender, EventArgs e)
        {
            CreateObstacle();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (reButton)
            {

                btnStart.Text = "게임중지";

                tmrMain.Start();
                tmrMove.Start();

                reButton = false;
            }
            else
            {
                GameStop(sender);
            }

        }

        private void GameStop(object sender)
        {

            btnStart.Text = "게임시작";

            tmrMain.Stop();
            tmrMove.Stop();

            reButton = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                picCar.Left -= 5;
            }
            else if (e.KeyCode == Keys.Right)
            {
                picCar.Left += 5;
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
            box.BackColor = Color.Yellow;
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

                    SetLevel();
                }

                if (item.Name == picCar.Name || item.Name == lblGameOver.Name) continue;
                item.Top += _speed;
            }
        }

        private void SetLevel()
        {
            if (tmrMain.Interval == 500 || Convert.ToInt32(lblScore.Text) == 0 ) return;
            if(Convert.ToInt32(lblScore.Text) % 3 == 0)
            {
                _speed++;
                tmrMain.Interval -= 500;
            }
        }

        //충돌감지(반환값T: 충돌감지, 반환값F: 충돌없음)
        private bool CheckCrush()
        {
            int carL = picCar.Left;
            int carR = carL + picCar.Width;

            int carT = picCar.Top;
            int carB = carT + picCar.Height;

            foreach (Control item in pnlRoad.Controls)
            {
                if (Convert.ToInt32(item.Tag) != 0) continue;

                int obstacleL = item.Left;
                int obstacleR = obstacleL + item.Width;

                int obstacleT = item.Top;
                int obstacleB = obstacleT + item.Height;

                bool isContainL = carL <= obstacleL && obstacleL <= carR;
                bool isContainR = carL <= obstacleR && obstacleR <= carR;

                bool isContainT = carT <= obstacleT && obstacleT <= carB;
                bool isContainB = carT <= obstacleB && obstacleB <= carB;

                //충돌을 감지한 경우
                return (isContainL || isContainR) && (isContainB || isContainT);
            }

            return false;
        }

        public void GameOverLabel()
        {
            lblGameOver.Left = pnlRoad.Width / 2 - lblGameOver.Width / 2;
            lblGameOver.Top = pnlRoad.Height / 2 - lblGameOver.Height / 2;

            lblGameOver.Visible = true;
        }

    }
}
