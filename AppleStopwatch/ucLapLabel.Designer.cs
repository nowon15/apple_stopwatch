namespace AppleStopwatch
{
    partial class ucLapLabel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLapSeq = new System.Windows.Forms.Label();
            this.lblLapTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblLapSeq, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLapTime, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblLapSeq
            // 
            this.lblLapSeq.AutoSize = true;
            this.lblLapSeq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLapSeq.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLapSeq.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLapSeq.Location = new System.Drawing.Point(0, 0);
            this.lblLapSeq.Margin = new System.Windows.Forms.Padding(0);
            this.lblLapSeq.Name = "lblLapSeq";
            this.lblLapSeq.Size = new System.Drawing.Size(91, 50);
            this.lblLapSeq.TabIndex = 0;
            this.lblLapSeq.Text = "랩 1";
            this.lblLapSeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLapTime
            // 
            this.lblLapTime.AutoSize = true;
            this.lblLapTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLapTime.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLapTime.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLapTime.Location = new System.Drawing.Point(364, 0);
            this.lblLapTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblLapTime.Name = "lblLapTime";
            this.lblLapTime.Size = new System.Drawing.Size(92, 50);
            this.lblLapTime.TabIndex = 1;
            this.lblLapTime.Text = "00:01.12";
            this.lblLapTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucLapLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucLapLabel";
            this.Size = new System.Drawing.Size(456, 50);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLapSeq;
        private System.Windows.Forms.Label lblLapTime;
    }
}
