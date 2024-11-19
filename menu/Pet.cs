using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitBuddyApp
{
    public partial class Pets : Form
    {
        public Pets()
        {
            this.Text = "Pet";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label Petlabel = new Label();
            Petlabel.Text = "Pet";
            Petlabel.Font = new Font("Arial", 25, FontStyle.Bold | FontStyle.Italic);
            Petlabel.ForeColor = Color.White;
            Petlabel.BackColor = Color.Transparent;
            Petlabel.Location = new Point(375, 20);
            Petlabel.Size = new Size(400, 80);
            this.Controls.Add(Petlabel);

            this.Paint += new PaintEventHandler(PetForm_Paint);

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


        private void PetForm_Paint(object sender, PaintEventArgs e)
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
