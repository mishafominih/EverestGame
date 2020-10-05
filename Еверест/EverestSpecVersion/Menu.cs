using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EverestSpecVersion
{
	public class Menu:Form
	{
		public static int lvl = 0;
		public static bool play = false;
		Bitmap image;
		public Menu()
		{
			Initialise();
			ClientSize = new Size(1500, 750);
			image = (Bitmap)Image.FromFile("Images\\Back.bmp");
		}

		protected override void OnPaint(PaintEventArgs e) => 
			e.Graphics.DrawImage(image, new Point(0, 0));

		private void Initialise()
		{
			var start = new Button();
			start.SetBounds(775, 250, 200, 100);
			SetSettings(start, "Новая игра!");
			start.Click += (a, b) =>
			{
				lvl = 0;
				play = true;
				Close();
			};
			Controls.Add(start);

			var Continue = new Button();
			Continue.SetBounds(1025, 250, 200, 100);
			SetSettings(Continue, "Продолжить!");
			Continue.Click += (a, b) =>
			{
				lvl = int.Parse(File.ReadAllText("lvl.txt"));
				play = true;
				Close();
			};
			Controls.Add(Continue);

			var text = new Button();
			text.SetBounds(0, 0, 1210, 40);
			SetSettings(text, "Жизнь словно гора: либо ты взбираешься наверх, " +
				"либо стремительно падаешь вниз.");
			Controls.Add(text);
		}

		private void SetSettings(Button btn, string str)
		{
			Font fn = new Font(FontFamily.GenericSansSerif, 21, FontStyle.Bold);
			btn.Font = fn;
			btn.Text = str;
			btn.BackColor = Color.Transparent;
			btn.ForeColor = Color.Red;
		}
	}
}
