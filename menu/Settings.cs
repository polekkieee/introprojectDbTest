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
            Settingslabel.Size = new Size(200, 80);
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

            //Money amount and level
            Label money = new Label(); money.Text = "1000"; money.BackColor = Color.Transparent; money.Size = new Size(150, 30); money.Location = new Point(670, 20); Controls.Add(money); money.Font = new Font("Arial", 20, FontStyle.Bold | FontStyle.Italic);
            Label lvl = new Label(); lvl.Text = "50"; lvl.BackColor = Color.Transparent; lvl.Size = new Size(150, 30); lvl.Location = new Point(670, 70); Controls.Add(lvl); lvl.Font = new Font("Arial", 20, FontStyle.Bold | FontStyle.Italic);



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
        }

    }
}
