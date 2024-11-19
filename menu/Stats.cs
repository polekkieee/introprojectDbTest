using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitBuddyApp
{
    public partial class Stats : Form
    {
        public Stats()
        {
            this.Text = "Stats";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label Statslabel = new Label();
            Statslabel.Text = "Stats";
            Statslabel.Font = new Font("Arial", 25, FontStyle.Bold | FontStyle.Italic);
            Statslabel.ForeColor = Color.White;
            Statslabel.BackColor = Color.Transparent;
            Statslabel.Location = new Point(330, 20);
            Statslabel.Size = new Size(300, 80);
            this.Controls.Add(Statslabel);

            this.Paint += new PaintEventHandler(statsForm_Paint);

            //back to workout
            Button workout = new Button();
            workout.Text = "Workout";
            workout.Font = new Font("Arial", 14);
            workout.Size = new Size(120, 25);
            workout.Location = new Point(20, 20);
            workout.ForeColor = Color.White;
            workout.BackColor = Color.DarkRed;
            this.Controls.Add(workout);
            workout.Click += (s, e) => OpenForm(new Workout());

            //back to main menu
            Button main = new Button();
            main.Text = "Main menu";
            main.Font = new Font("Arial", 14);
            main.Size = new Size(120, 25);
            main.Location = new Point(20, 50);
            main.ForeColor = Color.White;
            main.BackColor = Color.DarkRed;
            this.Controls.Add(main);
            main.Click += (s, e) => OpenForm(new MainForm());


        }
        private void OpenForm(Form form)
        {
            this.Hide(); // hide current file
            form.ShowDialog(); // show new file
            this.Show();
        }
        private void statsForm_Paint(object sender, PaintEventArgs e)
        {   // Method to show gradient background

            Graphics g = e.Graphics;
            Rectangle rect = this.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Purple, Color.Gold, 120F))
            {
                g.FillRectangle(brush, rect);
            }
        }
    }
}
