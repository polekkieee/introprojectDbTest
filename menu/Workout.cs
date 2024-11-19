using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            //Title
            Label WorkoutLabel = new Label();
            WorkoutLabel.Text = "Workout";
            WorkoutLabel.Font = new Font("Arial", 25, FontStyle.Bold | FontStyle.Italic);
            WorkoutLabel.ForeColor = Color.White;
            WorkoutLabel.BackColor = Color.Transparent;
            WorkoutLabel.Location = new Point(330, 20);
            WorkoutLabel.Size = new Size(400, 80);
            this.Controls.Add(WorkoutLabel);

            //Open stats menu
            Button stats = new Button();
            stats.Text = "Stats";
            stats.Font = new Font("Arial", 14);
            stats.Size = new Size(120, 25);
            stats.Location = new Point(20, 20);
            stats.ForeColor = Color.White;
            stats.BackColor = Color.DarkRed;
            this.Controls.Add(stats);
            stats.Click += (s, e) => OpenForm(new Stats());

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

            this.Paint += new PaintEventHandler(WorkoutForm_Paint);

            //Execises



        }
        private void OpenForm(Form form)
        {
            this.Hide(); // hide current file
            form.ShowDialog(); // show new file
            this.Show();
        }
        private void WorkoutForm_Paint(object sender, PaintEventArgs e)
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
