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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            car1.Click += Car1_Click;
            car2.Click += Car2_Click;
            car3.Click += Car3_Click;
            btnStart.Click += BtnStart_Click;
            
        }

        //자동차 이름 받는 프로퍼티(읽기 전용)
        public string CarName
        {
            get { return Name; }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (lblChoic2.Text == "롤스로이스")
            {
                CarChoic();
            }
            else if (lblChoic2.Text == "폭스바겐 티구안")
            {
                CarChoic();
            }
            else if (lblChoic2.Text == "렉스턴 스포츠")
            {
                CarChoic();
            }

        }
        private void CarChoic()
        {
            GameForm game = new GameForm();
            GameForm.CarName = lblChoic2.Text;
            this.Hide();
            game.Show();
        }

        private void Car3_Click(object sender, EventArgs e)
        {
            lblChoic2.Text = "렉스턴 스포츠";
        }

        private void Car2_Click(object sender, EventArgs e)
        {
            lblChoic2.Text = "폭스바겐 티구안";
        }

        private void Car1_Click(object sender, EventArgs e)
        {
            lblChoic2.Text = "롤스로이스";
        }
    }
}
