using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mcc.Series.DataBase;
using Mcc.Series.Ui;
using Mcc.Series.Controls.Enum;
using Mcc.Series.Common.Enum;

namespace CarGame
{
    public partial class GameForm : Form
    {
        int _score = 0;
        int _speed = 1;
        bool reButton = true;
        int counter = 0;

        public GameForm()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            this.KeyPreview = true;
            tmrMain.Tick += TmrMain_Tick;
            btnStart.Click += BtnStart_Click;
            tmrMove.Tick += TmrMove_Tick;
            btnSave.Click += BtnSave_Click;
            this.Load += GameForm_Load;
            tmrTimer.Tick += TmrTimer_Tick;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.SetGridHeader();
                this.SetInitialize();

                this.GetData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetGridHeader()
        {
            grdData.AddColumn("user_name", "이름", 60, GridColumnStyle.Default, HiddenType.False, ReadOnlyType.NoEdit, GridMaskStyle.None);
            grdData.AddColumn("user_score", "점수", 60, GridColumnStyle.Default, HiddenType.False, ReadOnlyType.NoEdit, GridMaskStyle.None);
            grdData.AddColumn("user_time", "시간", 60, GridColumnStyle.Default, HiddenType.False, ReadOnlyType.NoEdit, GridMaskStyle.None);

            grdData.SetGridHeader();
        }
        private void SetInitialize()
        {
          
        }

        private void GetData()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            DBMessage msg = new DBMessage();

            sb.AppendLine(" select           ");
            sb.AppendLine(" 	user_name    ");
            sb.AppendLine(" ,	user_score   ");
            sb.AppendLine(" ,	user_time    ");
            sb.AppendLine(" from             ");
            sb.AppendLine(" 	car_game     ");

            msg.SqlStatement = sb.ToString();

            FormQuery query = new FormQuery();

            dt = query.FillDataSet(msg).Tables[0];
            if(dt.Rows.Count > 0)
            {
                grdData.FillData(dt);
            }
        }
        private bool SaveData()
        {
            int affectedRow = 0;
            DBMessage msg = new DBMessage();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" insert into car_game  ");
            sb.AppendLine(" (                     ");
            sb.AppendLine(" 	user_name         ");
            sb.AppendLine(" ,	user_score        ");
            sb.AppendLine(" ,	user_time         ");
            sb.AppendLine(" )                     ");
            sb.AppendLine(" values                ");
            sb.AppendLine(" (                     ");
            sb.AppendLine(" 	@user_name        ");
            sb.AppendLine(" ,	@user_score       ");
            sb.AppendLine(" ,	@user_time        ");
            sb.AppendLine(" )                     ");

            msg.SqlStatement = sb.ToString();
            msg.AddParameter("user_name", txtName.Text);
            msg.AddParameter("user_score", lblScore.Text);
            msg.AddParameter("user_time", lblTime.Text);

            FormQuery query = new FormQuery();
            affectedRow = query.ExecuteNonQuery(msg);
            return affectedRow == 1;
        }
            
        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool isSuccess = SaveData();

            if (isSuccess)
            {
                MessageBox.Show("저장완료");
                GetData();
                txtName.Text = "";
                lblScore.Text = "";
                lblTime.Text = "";
            }
            else
            {
                MessageBox.Show("저장 실패");
            }
        }

        private void TmrMove_Tick(object sender, EventArgs e)
        {
            MoveObstacle();

            bool isCrush = CheckCrush();

            if (isCrush)
            {
                GameStop(sender);
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

        private void TmrTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            if(counter == 0)
            {
                tmrTimer.Stop();
                lblTime.Text = counter.ToString();
            }
            // DateTime newTime = new DateTime();
            // TimeSpan t = new TimeSpan();
            // t = newTime = DateTime.Now();
            // newTime = DateTime.Now.AddSeconds(s);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (reButton)
            {
                btnStart.Text = "게임중지";

                tmrMain.Start();
                tmrMove.Start();

                tmrTimer = new Timer();
                tmrTimer.Tick += new EventHandler(TmrTimer_Tick);
                tmrTimer.Interval = 1000;
                tmrTimer.Start();
                lblTime.Text = counter.ToString();

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
            tmrTimer.Stop();

            reButton = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                picCar.Left -= 6;
            }
            else if (e.KeyCode == Keys.Right)
            {
                picCar.Left += 6;
            }
        }


        private void CreateObstacle()
        {
            PictureBox box = new PictureBox();
            Random random = new Random();
            int a = random.Next(1, 5);

            if(a == 1)
            {
                box.Image = CarGame.Properties.Resources.고라니;
            }
            else if(a == 2)
            {
                box.Image = CarGame.Properties.Resources.나무;
            }
            else if(a == 3)
            {
                box.Image = CarGame.Properties.Resources.바위;
            }
            else
            {
                box.Image = CarGame.Properties.Resources.파랑;
            }

            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Tag = 0;

            int max = Math.Abs(pnlRoad.Width - box.Height);
            int b = random.Next(1, max);
            box.Left = b + 60;
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
