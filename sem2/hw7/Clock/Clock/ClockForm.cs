using System;
using System.Windows.Forms;

namespace Clock
{
    public partial class ClockForm : Form
    {
        public ClockForm()
        {
            InitializeComponent();
            updatingTimer.Start();
        }

        private void UpdateTimerTick(object sender, EventArgs e) => timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
    }
}
