using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarGame
{
    public partial class Car : UserControl
    {
        [Category("Car"), Description("Image")]
        public Image UserCar
        {
            get
            {
                return this.picCar.BackgroundImage;
            }
            set
            {
                this.picCar.BackgroundImage = value;
            }
        }

        [Category("Car"), Description("Number")]
        public string CarNum
        {
            get
            {
                return this.lblNum.Text;
            }
            set
            {
                this.lblNum.Text = value;
            }
        }

        [Category("Car"), Description("자동차 종류")]
        public string CarName
        {
            get
            {
                return this.lblName.Text;
            }
            set
            {
                this.lblName.Text = value;
            }
        }

        [Category("Car"), Description("자동차 속도")]
        public string CarSpeed
        {
            get
            {
                return this.lblSpeed2.Text;
            }
            set
            {
                this.lblSpeed2.Text = value;
            }
        }

        [Category("Car"), Description("자동차 목숨")]
        public string CarLimit
        {
            get
            {
                return this.lblLimit2.Text;
            }
            set
            {
                this.lblLimit2.Text = value;
            }
        }

        public Car()
        {
            InitializeComponent();
        }
    }
}
