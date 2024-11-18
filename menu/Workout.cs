using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitBuddyApp
{
    public partial class Workout : Form
    {
        public Workout()
        {
            this.Text = "Workout";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label label = new Label
            {
                Text = "Workout Screen",
                Font = new Font("Arial", 24),
                AutoSize = true,
                Location = new Point(300, 250)
            };

            this.Controls.Add(label);
        }
    }
}
