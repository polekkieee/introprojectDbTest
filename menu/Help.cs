﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FitBuddyApp
{
    public partial class Help : Form
    {
        public Help()
        {
            this.Text = "Help";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label Helplabel = new Label();
            Helplabel.Text = "Help";
            Helplabel.Font = new Font("Arial", 25, FontStyle.Bold | FontStyle.Italic);
            Helplabel.ForeColor = Color.White;
            Helplabel.BackColor = Color.Transparent;
            Helplabel.Location = new Point(370, 20);
            Helplabel.Size = new Size(400, 80);
            this.Controls.Add(Helplabel);

            this.Paint += new PaintEventHandler(HelpForm_Paint);

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


        private void HelpForm_Paint(object sender, PaintEventArgs e)
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
