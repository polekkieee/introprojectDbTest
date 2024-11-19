using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitBuddyApp
{
    public partial class Settings : Form
    {
        public Settings()
        {
            this.Text = "settings";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label Settingslabel = new Label();
            Settingslabel.Text = "settings";
            Settingslabel.Font = new Font("Arial", 25, FontStyle.Bold | FontStyle.Italic);
            Settingslabel.ForeColor = Color.White;
            Settingslabel.BackColor = Color.Transparent;
            Settingslabel.Location = new Point(330, 20);
            Settingslabel.Size = new Size(400, 80);
            this.Controls.Add(Settingslabel);

            this.Paint += new PaintEventHandler(settingsForm_Paint);

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



        private void settingsForm_Paint(object sender, PaintEventArgs e)
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
