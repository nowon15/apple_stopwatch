using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using TimeLib;

namespace AppleStopwatch
{
    public enum Status
    {
        Init,
        Run,
        Stop
    }

    public partial class Form1 : Form
    {
        private Status status;
        private int mainLblMinute;
        private int mainLblSecond;
        private int mainLblMilliSecond;

        private ucLapLabel minUcLap;
        private ucLapLabel maxUcLap;
        private int labMinValue;
        private int labMaxValue;

        private ucLapLabel currentUcLap;
        private int curLapMinute;
        private int curLapSecond;
        private int curLapMilliSecond;

        private int[,] START_BTN_COLOR_RGB = new int[2, 3] { {25, 54, 31}, { 69, 200, 99 }};
        private int[,] STOP_BTN_COLOR_RGB = new int[2, 3] { { 51, 19, 20 }, { 216, 75, 74 }};
        private int[,] LAP_BTN_COLOR_RGB = new int[2, 3] { { 21, 21, 21 }, { 95, 95, 98 } };
        private int[,] LAP_BTN_ENABLE_COLOR_RGB = new int[2, 3] { { 62, 62, 62 }, { 253, 253, 253 } };

        private TimeUtility timeUtility;

        public Form1()
        {
            timeUtility = new TimeUtility();
            InitializeComponent();
            InitializeTimeSetting();
        }

        private void initMainLblTime()
        {
            mainLblMinute = 0;
            mainLblSecond = 0;
            mainLblMilliSecond = 0;
        }

        private void initCurrentTime()
        {
            curLapMinute = 0;
            curLapSecond = 0;
            curLapMilliSecond = 0;
        }
        private void initLapMInMax()
        {
            labMinValue = int.MaxValue;
            labMaxValue = int.MinValue;
        }

        public void InitializeTimeSetting()
        {
            flowLayoutPanel1.Controls.Clear();
            status = Status.Init;
            initMainLblTime();
            initCurrentTime();
            initLapMInMax();
            lblMainTime.Text = "00:00.00";
            btnLap.Text = "랩";
            changeControlColor(btnLap, LAP_BTN_COLOR_RGB);
            btnLap.Enabled = false;
        }

        private void changeControlColor(Control control, int[,] btnColorArray)
        {
            control.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(btnColorArray[0, 0])))), 
                                                            ((int)(((byte)(btnColorArray[0, 1])))), ((int)(((byte)(btnColorArray[0, 2])))));
            control.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(btnColorArray[1, 0])))), 
                                                            ((int)(((byte)(btnColorArray[1, 1])))), ((int)(((byte)(btnColorArray[1, 2])))));
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            if (this.status == Status.Run)
            {
                this.status = Status.Stop;
                btnControl.Text = "시작";
                btnLap.Text = "재설정";
                changeControlColor(btnControl, START_BTN_COLOR_RGB);
            }
            else
            {
                if (this.status == Status.Init)
                {
                    btnLap.Enabled = true;
                }
                this.status = Status.Run;
                btnControl.Text = "중단";
                btnLap.Text = "랩";
                changeControlColor(btnControl, STOP_BTN_COLOR_RGB);
                changeControlColor(btnLap, LAP_BTN_ENABLE_COLOR_RGB);

                // 시작 버튼 처음 클릭 시 랩 생성
                if (flowLayoutPanel1.Controls.Count < 1)
                {
                    addUcLapLabel();
                }
            }

            timer.Enabled = !timer.Enabled;
        }

        private void compareMinMax()                // Min, Max 처리
        {
            if (flowLayoutPanel1.Controls.Count == 0) return;

            int curLapTotalMilliSecond = timeUtility.changeMilliSecond(curLapMinute, curLapSecond, curLapMilliSecond);
            if (flowLayoutPanel1.Controls.Count == 1)
            {
                minUcLap = currentUcLap;
                labMinValue = curLapTotalMilliSecond;
                maxUcLap = currentUcLap;
                labMaxValue = curLapTotalMilliSecond;
                return;
            }
            if (flowLayoutPanel1.Controls.Count == 2)
            {
                if (curLapTotalMilliSecond < labMinValue)
                {
                    minUcLap = currentUcLap;
                    labMinValue = curLapTotalMilliSecond;
                }
                else
                {
                    maxUcLap = currentUcLap;
                    labMaxValue = curLapTotalMilliSecond;
                }
                minUcLap.setLapColor(Color.Red);
                maxUcLap.setLapColor(Color.Green);
                return;
            }

            if (curLapTotalMilliSecond < labMinValue)
            {
                minUcLap.setLapColor(Color.White);
                minUcLap = currentUcLap;
                labMinValue = curLapTotalMilliSecond;
                minUcLap.setLapColor(Color.Red);
            }
            else if (curLapTotalMilliSecond > labMaxValue)
            {
                maxUcLap.setLapColor(Color.White);
                maxUcLap = currentUcLap;
                labMaxValue = curLapTotalMilliSecond;
                maxUcLap.setLapColor(Color.Green);
            }
        }

        private void addUcLapLabel()
        {
            compareMinMax();
            
            initCurrentTime();
            currentUcLap = new ucLapLabel($"랩 {flowLayoutPanel1.Controls.Count + 1}",
                                        timeUtility.timeForamt(curLapMinute, curLapSecond, curLapMilliSecond));
            currentUcLap.Width = flowLayoutPanel1.Width;
            currentUcLap.Padding = new Padding(30, 0, 30, 0);
            currentUcLap.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(currentUcLap);

            flowLayoutPanel1.Controls.SetChildIndex(currentUcLap, 0);
            flowLayoutPanel1.Invalidate();
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            if (btnLap.Text.Equals("재설정"))
            {
                InitializeTimeSetting();
            }
            else
            {
                addUcLapLabel();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeUtility.timeUpdate(ref mainLblMinute, ref mainLblSecond, ref mainLblMilliSecond);
            timeUtility.timeUpdate(ref curLapMinute, ref curLapSecond, ref curLapMilliSecond);

            lblMainTime.Text = timeUtility.timeForamt(mainLblMinute, mainLblSecond, mainLblMilliSecond);
            currentUcLap.setLapTime(timeUtility.timeForamt(curLapMinute, curLapSecond, curLapMilliSecond));
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            // 수평 스크롤바 제거를 위한 코드
            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.AutoScroll = true;

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.Width = flowLayoutPanel1.Width;
            }
        }
    }
}
