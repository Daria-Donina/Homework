using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void UpdateTimerTick(object sender, EventArgs e) => timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
    }
}
