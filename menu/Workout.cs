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
            WorkoutLabel.Size = new Size(200, 80);
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

            //Money amount and level
            Label money = new Label(); money.Text = "1000"; money.BackColor = Color.Transparent; money.Size = new Size(150, 30); money.Location = new Point(670, 20); Controls.Add(money); money.Font = new Font("Arial", 20, FontStyle.Bold | FontStyle.Italic);
            Label lvl = new Label(); lvl.Text = "50"; lvl.BackColor = Color.Transparent; lvl.Size = new Size(150, 30); lvl.Location = new Point(670, 70); Controls.Add(lvl); lvl.Font = new Font ("Arial", 20, FontStyle.Bold | FontStyle.Italic);


            //Standard excercises
            Label sprint = new Label(); sprint.Text = "Sprint"; sprint.Location = new Point(20, 160); sprint.Size = new Size(130, 30); sprint.TextAlign = ContentAlignment.TopCenter; sprint.Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic); sprint.BackColor = Color.FromArgb(80, 255, 0, 0); sprint.ForeColor = Color.White;
            Label run = new Label(); run.Text = "Run"; run.Location = new Point(20, 260); run.Size = new Size(130, 30); run.TextAlign = ContentAlignment.TopCenter; run.Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic); run.BackColor = Color.FromArgb(80, 255, 0, 0); run.ForeColor = Color.White;
            Label situp = new Label(); situp.Text = "Situp"; situp.Location = new Point(20, 360); situp.Size = new Size(130, 30); situp.TextAlign = ContentAlignment.TopCenter; situp.Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic); situp.BackColor = Color.FromArgb(80, 255, 0, 0); situp.ForeColor = Color.White;
            Label pushup = new Label(); pushup.Text = "Pushup"; pushup.Location = new Point(20, 460); pushup.Size = new Size(130, 30); pushup.TextAlign = ContentAlignment.TopCenter; pushup.Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic); pushup.BackColor = Color.FromArgb(80, 255, 0, 0); pushup.ForeColor = Color.White;
            Label plank = new Label();  plank.Text = "Plank"; plank.Location = new Point(500, 160); plank.Size = new Size(130, 30); plank.TextAlign = ContentAlignment.TopCenter; plank.Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic); plank.BackColor = Color.FromArgb(80, 255, 0, 0); plank.ForeColor = Color.White;
            Label burpees = new Label(); burpees.Text = "Burpees"; burpees.Location = new Point(500, 260); burpees.Size = new Size(130, 30); burpees.TextAlign = ContentAlignment.TopCenter; burpees.Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic); burpees.BackColor = Color.FromArgb(80, 255, 0, 0); burpees.ForeColor = Color.White;
            Label cycling = new Label(); cycling.Text = "Cycling"; cycling.Location = new Point(500, 360); cycling.Size = new Size(130, 30); cycling.TextAlign = ContentAlignment.TopCenter; cycling.Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic); cycling.BackColor = Color.FromArgb(80, 255, 0, 0); cycling.ForeColor = Color.White;
            Label swimming = new Label(); swimming.Text = "Swimming"; swimming.Location = new Point(500, 460); swimming.Size = new Size(130, 30); swimming.TextAlign = ContentAlignment.TopCenter; swimming.Font = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic); swimming.BackColor = Color.FromArgb(80, 255, 0, 0); swimming.ForeColor = Color.White;


            //miss nog toevoegen met scrollbar
            Label jumpjack = new Label(); jumpjack.Text = "Jumping Jacks"; 
            Label pullup = new Label(); pullup.Text = "Pullup";
            //Exercises with different weigths 
            Label lift = new Label(); lift.Text = "Lift";
            Label bench = new Label(); bench.Text = "Bench";
            Label dumbbell = new Label(); dumbbell.Text = "Dumbbell";
            Label curls = new Label(); curls.Text = "Curls";

            this.Controls.Add(sprint);
            this.Controls.Add(run);         
            this.Controls.Add(situp);   
            this.Controls.Add(pushup);
            this.Controls.Add(plank);
            this.Controls.Add(burpees);
            this.Controls.Add(cycling);
            this.Controls.Add(swimming);

            //Buttons for the amount of minutes per exercise
           



            this.Paint += new PaintEventHandler(WorkoutForm_Paint);
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

            // draw coin
            int x = 620;
            int y = 15;
            int size = 40;

            Brush outerBrush = new SolidBrush(Color.Gold);
            g.FillEllipse(outerBrush, x, y, size, size);

            Brush innerBrush = new SolidBrush(Color.Orange);
            int space = 5; // space between inner and outer cirkle 
            g.FillEllipse(innerBrush, x + space, y + space, size - 2 * space, size - 2 * space);

            Pen blackPen = new Pen(Color.Black, 2);
            g.DrawEllipse(blackPen, x, y, size, size);
            g.DrawEllipse(blackPen, x + space, y + space, size - 2 * space, size - 2 * space);

            Font dollarFont = new Font("Arial", 20, FontStyle.Bold);
            Brush dollarBrush = Brushes.Black;
            g.DrawString("$", dollarFont, dollarBrush, 628, 20);

            //level logo
            Brush level = new SolidBrush(Color.DarkGreen);
            Brush innerlevel = new SolidBrush(Color.LightGreen);
            g.FillEllipse(level, x, y + 50, size, size);
            g.FillEllipse(innerlevel, x + 4, y + 50 + 4, size - 2 * 4, size - 2 * 4);
            Font levelFont = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);
            Brush levelBrush = Brushes.Black;
            g.DrawString("LVL", levelFont, levelBrush, 622, 77);

            //Box of exercises
            Brush Exercise = new SolidBrush(Color.FromArgb(150,0,0,0));
            g.FillRectangle(Exercise, 0, 140, 800, 600);
        }

    }

}
