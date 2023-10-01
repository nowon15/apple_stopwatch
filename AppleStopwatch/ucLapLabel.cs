using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppleStopwatch
{
    public partial class ucLapLabel : UserControl
    {
        public ucLapLabel(string lapSeq, string lapTime)
        {
            InitializeComponent();
            lblLapSeq.Text = lapSeq;
            lblLapTime.Text = lapTime;
        }

        public void setLapTime(string lapTime)
        {
            lblLapTime.Text = lapTime;
        }

        public void setLapColor(Color color)
        {
            lblLapSeq.ForeColor = color;
            lblLapTime.ForeColor = color;
        }
    }
}
