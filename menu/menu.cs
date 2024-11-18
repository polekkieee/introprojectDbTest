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
            Label Gebruiker = new Label();
            Gebruiker.Text = "Gebruikersinfo";
            Gebruiker.Font = new Font("Arial", 8, FontStyle.Bold);
            Gebruiker.ForeColor = Color.White;
            Gebruiker.Size = new Size(740, 15);
            Gebruiker.BackColor = Color.Black;
            Gebruiker.Location = new Point(20, 20);
            Gebruiker.TextAlign = ContentAlignment.TopCenter;
            this.Controls.Add(Gebruiker);

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
            this.Show(); // Laat het hoofdformulier zien als het nieuwe formulier wordt gesloten
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

