using System;
using System.Windows.Forms;

namespace UIProgram
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void OnStartButtonClick(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (progressBar.Value < 100)
            {
                progressBar.Value++;
            }

            if (progressBar.Value == 100)
            {
                closeButton.Visible = true;
            }
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
