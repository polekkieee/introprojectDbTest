using System.Drawing;
using System.Windows.Forms;

Form scherm = new Form();
scherm.Text = "menu";
scherm.BackColor = Color.LightYellow;
scherm.ClientSize = new Size(220, 220);

// met een Bitmap kun je een plaatje opslaan in het geheugen
Bitmap plaatje = new Bitmap(200, 200);

// je kunt de losse pixels van het plaatje manipuleren
plaatje.SetPixel(10, 10, Color.Red);

// maar om complexere figuren te tekenen heb je een Graphics nodig
Graphics tekenaar = Graphics.FromImage(plaatje);
tekenaar.FillEllipse(Brushes.Blue, 30, 40, 100, 50);

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

Application.Run(scherm);