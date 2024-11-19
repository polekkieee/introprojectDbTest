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

            // Title label
            Label titleLabel = new Label();
            titleLabel.Text = "FitBuddy";
            titleLabel.Font = new Font("Arial", 50, FontStyle.Bold | FontStyle.Italic);
            titleLabel.ForeColor = Color.White;
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Location = new Point(240, 50);
            titleLabel.TextAlign = ContentAlignment.TopCenter;
            this.Controls.Add(titleLabel);

            //Label userinfo
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
            userInfoLabel.Font = new Font("Arial", 15, FontStyle.Bold | FontStyle.Italic);
            userInfoLabel.ForeColor = Color.White;
            userInfoLabel.AutoSize = false;
            userInfoLabel.Size = new Size(200, 400);
            userInfoLabel.BackColor = Color.FromArgb(70, 200, 0, 0); 
            userInfoLabel.TextAlign = ContentAlignment.TopLeft;
            userInfoLabel.Location = new Point(20, 150);
            this.Controls.Add(userInfoLabel);

            //Label coinsamount and level
            Label coinsamount = new Label();
            coinsamount.Text = "1000";
            coinsamount.Font = new Font("Arial", 40, FontStyle.Bold | FontStyle.Italic);
            coinsamount.ForeColor = Color.White;
            coinsamount.Location = new Point(610, 160);
            coinsamount.BackColor = Color.Transparent;
            coinsamount.Size = new Size(300, 80);
            this.Controls.Add(coinsamount);
            Label Level = new Label();
            Level.Text = "50";
            Level.Font = new Font("Arial", 40, FontStyle.Bold | FontStyle.Italic);
            Level.ForeColor = Color.White;
            Level.Location = new Point(610, 260);
            Level.BackColor = Color.Transparent;
            Level.Size = new Size(150, 50);
            this.Controls.Add(Level);



            // fist button
            Button button1 = new Button();
            button1.Text = "Start Workout";
            button1.Font = new Font("Arial", 14);
            button1.Size = new Size(200, 50);
            button1.Location = new Point((this.Width - button1.Width) / 2, 180);
            button1.Click += (s, e) => OpenForm(new Workout());
            this.Controls.Add(button1);

            // second button
            Button button5 = new Button();
            button5.Text = "My stats";
            button5.Font = new Font("Arial", 14);
            button5.Size = new Size(200, 50);
            button5.Location = new Point((this.Width - button5.Width) / 2, 250);
            button5.Click += (s, e) => OpenForm(new Stats());
            this.Controls.Add(button5);

            // second button
            Button button2 = new Button();
            button2.Text = "Pet";
            button2.Font = new Font("Arial", 14);
            button2.Size = new Size(200, 50);
            button2.Location = new Point((this.Width - button2.Width) / 2, 320);
            button2.Click += (s, e) => OpenForm(new Pets());
            this.Controls.Add(button2);

            // third button
            Button button3 = new Button();
            button3.Text = "Settings";
            button3.Font = new Font("Arial", 14);
            button3.Size = new Size(200, 50);
            button3.Location = new Point((this.Width - button3.Width) / 2, 390);
            button3.Click += (s, e) => OpenForm(new Settings());
            this.Controls.Add(button3);

            // fourth button
            Button button4 = new Button();
            button4.Text = "Help";
            button4.Font = new Font("Arial", 14);
            button4.Size = new Size(200, 50);
            button4.Location = new Point((this.Width - button4.Width) / 2, 460);
            button4.Click += (s, e) => OpenForm(new Help());
            this.Controls.Add(button4);

            this.Paint += new PaintEventHandler(MainForm_Paint);
        }

        //asked chatgpt how to open new screen
        private void OpenForm(Form form)
        {
            this.Hide(); // hide current file
            form.ShowDialog(); // show new file
            this.Show(); 
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {   // Method to show gradient background

            Graphics g = e.Graphics;
            Rectangle rect = this.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Purple, Color.Gold, 120F))
            {
                g.FillRectangle(brush, rect);
            }
           
            //logo fitbuddy
            Brush b = new SolidBrush(Color.FromArgb(150, 255, 0, 0));
            Pen p = new Pen(Color.White, 3);
            g.FillEllipse(b, 230, 35, 340, 110);
            g.DrawEllipse(p, 230, 35, 340, 110);
            g.DrawRectangle(p, 20, 150, 200, 400);

            // draw coin
            int x = 530; 
            int y = 150; 
            int size = 80;

            Brush outerBrush = new SolidBrush(Color.Gold);
            g.FillEllipse(outerBrush, x, y, size, size);

            Brush innerBrush = new SolidBrush(Color.Orange);
            int space = 10; // space between inner and outer cirkle 
            g.FillEllipse(innerBrush, x + space, y + space, size - 2* space, size - 2 * space);

            Pen blackPen = new Pen(Color.Black, 2);
            g.DrawEllipse(blackPen, x, y, size, size); 
            g.DrawEllipse(blackPen, x + space, y + space, size - 2 * space, size - 2 * space); 

            Font dollarFont = new Font("Arial", 35, FontStyle.Bold);
            Brush dollarBrush = Brushes.Black;
            g.DrawString("$", dollarFont, dollarBrush, 549, 163);

            //level logo
            Brush level = new SolidBrush(Color.DarkGreen);
            Brush innerlevel = new SolidBrush(Color.LightGreen);
            g.FillEllipse(level, x, y + 100, size, size);
            g.FillEllipse(innerlevel, x + 8, y + 100 + 8, size - 2 * 8, size - 2 *8);
            Font levelFont = new Font("Arial", 25, FontStyle.Bold | FontStyle.Italic);
            Brush levelBrush = Brushes.Black;
            g.DrawString("LVL", levelFont, levelBrush, 534, 271);

            //shop logo
            Brush Shop = new SolidBrush(Color.White);
            Pen Shopoutline = new Pen(Color.Black, 4);
            g.FillEllipse(Shop,670 , 480, size, 40);
            g.DrawEllipse(Shopoutline, 670, 480, size, 40);
            
            Button shop = new Button();
            shop.Location = new Point(675, 490);
            shop.Size = new Size(70, 20);
            shop.Text = "Shop"; 
            shop.Font = new Font("Arial", 10, FontStyle.Bold | FontStyle.Italic);  
            shop.Click += (s, e) => OpenForm(new Shop());

            Controls.Add(shop);


        }
    }

    // main
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}

