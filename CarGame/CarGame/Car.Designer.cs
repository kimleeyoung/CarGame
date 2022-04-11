namespace CarGame
{
    partial class Car
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblSpeed2 = new System.Windows.Forms.Label();
            this.lblLimit = new System.Windows.Forms.Label();
            this.lblLimit2 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.picCar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.Location = new System.Drawing.Point(33, 311);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(184, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "아반떼";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpeed2
            // 
            this.lblSpeed2.AutoSize = true;
            this.lblSpeed2.Location = new System.Drawing.Point(188, 353);
            this.lblSpeed2.Name = "lblSpeed2";
            this.lblSpeed2.Size = new System.Drawing.Size(11, 12);
            this.lblSpeed2.TabIndex = 2;
            this.lblSpeed2.Text = "5";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(35, 353);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(45, 12);
            this.lblLimit.TabIndex = 3;
            this.lblLimit.Text = "내구성:";
            // 
            // lblLimit2
            // 
            this.lblLimit2.AutoSize = true;
            this.lblLimit2.Location = new System.Drawing.Point(78, 353);
            this.lblLimit2.Name = "lblLimit2";
            this.lblLimit2.Size = new System.Drawing.Size(17, 12);
            this.lblLimit2.TabIndex = 4;
            this.lblLimit2.Text = "10";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(153, 353);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(33, 12);
            this.lblSpeed.TabIndex = 5;
            this.lblSpeed.Text = "속도:";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(15, 15);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(11, 12);
            this.lblNum.TabIndex = 6;
            this.lblNum.Text = "1";
            // 
            // picCar
            // 
            this.picCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCar.Location = new System.Drawing.Point(37, 33);
            this.picCar.Name = "picCar";
            this.picCar.Size = new System.Drawing.Size(168, 265);
            this.picCar.TabIndex = 0;
            this.picCar.TabStop = false;
            // 
            // Car
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblLimit2);
            this.Controls.Add(this.lblLimit);
            this.Controls.Add(this.lblSpeed2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picCar);
            this.Name = "Car";
            this.Size = new System.Drawing.Size(254, 391);
            ((System.ComponentModel.ISupportInitialize)(this.picCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSpeed2;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.Label lblLimit2;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblNum;
    }
}
