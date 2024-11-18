using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitBuddyApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            this.Text = "FitBuddy";
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Titel label
            Label titleLabel = new Label();
            titleLabel.Text = "FitBuddy";
            titleLabel.Font = new Font("Arial", 36, FontStyle.Bold | FontStyle.Italic);
            titleLabel.ForeColor = Color.White;
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Location = new Point(290, 50);
            titleLabel.TextAlign = ContentAlignment.TopCenter;
            this.Controls.Add(titleLabel);

            //Label gebruikersinfo
            Label Welcome = new Label();
            Welcome.Text = "       Welcome \n         Name";
            Welcome.ForeColor = Color.White; 
            Welcome.Font = new Font("Verdana", 15, FontStyle.Bold | FontStyle.Italic);
            Welcome.Location = new Point(20, 150);
            Welcome.BackColor = Color.FromArgb(150, 255, 0, 0);
            Welcome.Size = new Size(200, 50);
            this.Controls.Add(Welcome);




            Label userInfoLabel = new Label();
            userInfoLabel.Text = "\n" +
                                 "\n" + "\n" +
                                 "Gender: \n" +
                                 "\n" + "\n" +
                                 "Age: \n" +
                                 "\n" + "\n" + 
                                 "Start Condition:";
            userInfoLabel.Font = new Font("Arial", 15, FontStyle.Bold);
            userInfoLabel.ForeColor = Color.White;
            userInfoLabel.AutoSize = false;
            userInfoLabel.Size = new Size(200, 400);
            userInfoLabel.BackColor = Color.FromArgb(70, 200, 0, 0); 
            userInfoLabel.TextAlign = ContentAlignment.TopLeft;
            userInfoLabel.Location = new Point(20, 150);
            this.Controls.Add(userInfoLabel);

            // Eerste knop
            Button button1 = new Button();
            button1.Text = "Start Workout";
            button1.Font = new Font("Arial", 14);
            button1.Size = new Size(200, 50);
            button1.Location = new Point((this.Width - button1.Width) / 2, 150);
            button1.Click += (s, e) => OpenForm(new Workout());
            this.Controls.Add(button1);

            // Tweede knop  
            Button button2 = new Button();
            button2.Text = "Pet";
            button2.Font = new Font("Arial", 14);
            button2.Size = new Size(200, 50);
            button2.Location = new Point((this.Width - button2.Width) / 2, 230);
            button2.Click += (s, e) => OpenForm(new Pet());
            this.Controls.Add(button2);

            // Derde knop
            Button button3 = new Button();
            button3.Text = "Settings";
            button3.Font = new Font("Arial", 14);
            button3.Size = new Size(200, 50);
            button3.Location = new Point((this.Width - button3.Width) / 2, 310);
            button3.Click += (s, e) => OpenForm(new Settings());
            this.Controls.Add(button3);

            // Vierde knop
            Button button4 = new Button();
            button4.Text = "Help";
            button4.Font = new Font("Arial", 14);
            button4.Size = new Size(200, 50);
            button4.Location = new Point((this.Width - button4.Width) / 2, 390);
            button4.Click += (s, e) => OpenForm(new Help());
            this.Controls.Add(button4);

            this.Paint += new PaintEventHandler(MainForm_Paint);
        }

        private void OpenForm(Form form)
        {
            this.Hide(); // Verberg het huidige formulier
            form.ShowDialog(); // Toon het nieuwe formulier
            this.Show(); 
        }

        // Methode om de achtergrond met een overloop te tekenen
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = this.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Purple, Color.Gold, 120F))
            {
                g.FillRectangle(brush, rect);
            }
        }
    }

    // Hoofdprogramma
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

