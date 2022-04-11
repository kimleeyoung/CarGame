namespace CarGame
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lblChoic = new System.Windows.Forms.Label();
            this.lblChoic2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.car3 = new CarGame.Car();
            this.car2 = new CarGame.Car();
            this.car1 = new CarGame.Car();
            this.SuspendLayout();
            // 
            // lblChoic
            // 
            this.lblChoic.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChoic.Location = new System.Drawing.Point(304, 21);
            this.lblChoic.Name = "lblChoic";
            this.lblChoic.Size = new System.Drawing.Size(72, 23);
            this.lblChoic.TabIndex = 3;
            this.lblChoic.Text = "선택:";
            // 
            // lblChoic2
            // 
            this.lblChoic2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChoic2.Location = new System.Drawing.Point(372, 21);
            this.lblChoic2.Name = "lblChoic2";
            this.lblChoic2.Size = new System.Drawing.Size(203, 23);
            this.lblChoic2.TabIndex = 4;
            this.lblChoic2.Text = "롤스로이스";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.Location = new System.Drawing.Point(670, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(140, 31);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "게임시작";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // car3
            // 
            this.car3.BackColor = System.Drawing.SystemColors.Info;
            this.car3.CarLimit = "30(목숨3개)";
            this.car3.CarName = "렉스턴 스포츠";
            this.car3.CarNum = "3";
            this.car3.CarSpeed = "5";
            this.car3.Location = new System.Drawing.Point(563, 64);
            this.car3.Name = "car3";
            this.car3.Size = new System.Drawing.Size(247, 380);
            this.car3.TabIndex = 2;
            this.car3.UserCar = ((System.Drawing.Image)(resources.GetObject("car3.UserCar")));
            // 
            // car2
            // 
            this.car2.BackColor = System.Drawing.SystemColors.Info;
            this.car2.CarLimit = "20(목숨:2개)";
            this.car2.CarName = "폭스바겐 티구안";
            this.car2.CarNum = "2";
            this.car2.CarSpeed = "10";
            this.car2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.car2.Location = new System.Drawing.Point(288, 64);
            this.car2.Name = "car2";
            this.car2.Size = new System.Drawing.Size(247, 380);
            this.car2.TabIndex = 1;
            this.car2.UserCar = ((System.Drawing.Image)(resources.GetObject("car2.UserCar")));
            // 
            // car1
            // 
            this.car1.BackColor = System.Drawing.SystemColors.Info;
            this.car1.CarLimit = "10(목숨:1개)";
            this.car1.CarName = "롤스로이스";
            this.car1.CarNum = "1";
            this.car1.CarSpeed = "25";
            this.car1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.car1.Location = new System.Drawing.Point(15, 64);
            this.car1.Name = "car1";
            this.car1.Size = new System.Drawing.Size(247, 380);
            this.car1.TabIndex = 0;
            this.car1.UserCar = ((System.Drawing.Image)(resources.GetObject("car1.UserCar")));
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 485);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblChoic2);
            this.Controls.Add(this.lblChoic);
            this.Controls.Add(this.car3);
            this.Controls.Add(this.car2);
            this.Controls.Add(this.car1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private Car car1;
        private Car car2;
        private Car car3;
        private System.Windows.Forms.Label lblChoic;
        private System.Windows.Forms.Label lblChoic2;
        private System.Windows.Forms.Button btnStart;
    }
}