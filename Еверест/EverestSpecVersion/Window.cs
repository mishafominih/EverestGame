using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EverestSpecVersion
{
	public class Window : Form
	{
		private Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
		private HashSet<Keys> pressedKeys = new HashSet<Keys>();
		private Dictionary<Keys, int> keys = new Dictionary<Keys, int> {
			{ Keys.W, -1},
			{ Keys.S, 1},
			{ Keys.A, -1},
			{ Keys.D, 1}
		};
		Game game;
		int time;
		Timer timer = new Timer();
		ProgressBar Energy;
		ProgressBar Oxygen;
		public Window(Game g)
		{
			ClientSize = new Size(1500, 750);
			DoubleBuffered = true;
			game = g;

			FormClosing += (a, f) =>
			{
				timer.Stop();
				pressedKeys.Clear();
				File.WriteAllText("lvl.txt", LvlDispetcher.lvl.ToString());
			};
			DirectoryInfo imagesDirectory = new DirectoryInfo("Images");
			foreach (var e in imagesDirectory.GetFiles("*.bmp"))
				bitmaps[e.Name] = (Bitmap)Image.FromFile(e.FullName);

			Initialise();
			TimerRun();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.DrawImage(bitmaps["BackGround.bmp"], new Point(0, 0));
			DrowBackGround(e);
			DrowStaticObject(e);
			DrowDinamicObject(e);
			e.Graphics.ResetTransform();
		}

		private void TimerTick(object sender, EventArgs args)
		{
			if (time == 0)
			{
				Animation.CheckAnimation();
				var horizontal = 0;
				var vertical = 0;
				GetDirection(ref horizontal, ref vertical);
				game.Update(horizontal, vertical);
				timer.Interval = Game.FindPlayer().speed;
				ScrollMap.Update();
				Animation.UpdateAnimation();

				var p = Game.FindPlayer();
				Energy.Value = (int)p.Energy;
				Oxygen.Value = (int)p.Oxygen;
			}
			time++;
			if (time == 8)
			{
				time = 0;
				var p = Game.FindPlayer();
				if (p.OnStay is Finish || p.death)
				{
					if(p.OnStay is Finish) LvlDispetcher.NextLvl();
					Close();
				}
			}
			Invalidate();
		}

		protected override void OnKeyDown(KeyEventArgs e) => pressedKeys.Add(e.KeyCode);

		protected override void OnKeyUp(KeyEventArgs e) => pressedKeys.Remove(e.KeyCode);


		private void Initialise()
		{
			var TextEnergy = new TextBox();
			TextEnergy.SetBounds(1100, 10, 50, 20);
			SetOptions(TextEnergy, "энергия");
			var TextOxygen = new TextBox();
			TextOxygen.SetBounds(1100, 40, 50, 20);
			SetOptions(TextOxygen, "кислород");
			Energy = new ProgressBar();
			Oxygen = new ProgressBar();
			Energy.SetBounds(1150, 10, 200, 20);
			Energy.ForeColor = Color.Green;
			Oxygen.SetBounds(1150, 40, 200, 20);
			Controls.Add(Energy);
			Controls.Add(Oxygen);
			Controls.Add(TextEnergy);
			Controls.Add(TextOxygen);
		}

		private void SetOptions(TextBox Text, string str)
		{
			Text.Text = str;
			Text.BackColor = Color.White;
			Text.ForeColor = Color.Black;
			Text.Enabled = false;
		}

		private void TimerRun()
		{
			timer.Interval = 50;
			timer.Tick += TimerTick;
			timer.Start();
		}

		private void GetDirection(ref int horizontal, ref int vertical)
		{
			if (pressedKeys.Count() != 0)
			{
				horizontal = pressedKeys.Last() == Keys.A || pressedKeys.Last() == Keys.D ?
				keys[pressedKeys.Last()] : 0;
				vertical = pressedKeys.Last() == Keys.W || pressedKeys.Last() == Keys.S ?
				keys[pressedKeys.Last()] : 0;
			}
		}

		private void DrowDinamicObject(PaintEventArgs e)
		{
			foreach (var anim in Animation.Anim)
			{
				var a = (GameObject)anim.Key;
				anim.Value.UpdatePosition(time);
				e.Graphics.DrawImage(bitmaps[a.GetImageName()], anim.Value.Position);
			}
		}

		private void DrowStaticObject(PaintEventArgs e)
		{
			for (int i = ScrollMap.Start.X; i < ScrollMap.End.X; i++)
				for (int j = ScrollMap.Start.Y; j < ScrollMap.End.Y; j++)
					if (Game.map[i, j].IsBackground() && (!(Game.map[i, j] is Anim)
						|| !((Anim)Game.map[i, j]).IsAnimation))
						DrowImage(e, Game.map[i, j].GetImageName(),
							new Point(i - ScrollMap.Start.X, j - ScrollMap.Start.Y));
		}

		private void DrowBackGround(PaintEventArgs e)
		{
			for (int i = ScrollMap.Start.X; i < ScrollMap.End.X; i++)
				for (int j = ScrollMap.Start.Y; j < ScrollMap.End.Y; j++)
					if (Game.map[i, j].IsBackground())
					{
						if (Game.map[i, j] is Player)
						{
							var p = (Player)Game.map[i, j];
							if (p.OnStay is Tent || p.OnStay is Finish)
							{
								DrowImage(e, p.OnStay.GetNameBackground(),
									new Point(i - ScrollMap.Start.X, j - ScrollMap.Start.Y));
							}
						}
						DrowImage(e, Game.map[i, j].GetNameBackground(),
							new Point(i - ScrollMap.Start.X, j - ScrollMap.Start.Y));
						bitmaps[Game.map[i, j].GetImageName()].MakeTransparent(Color.White);
					}
					else
						DrowImage(e, Game.map[i, j].GetImageName(),
							new Point(i - ScrollMap.Start.X, j - ScrollMap.Start.Y));
		}

		private void DrowImage(PaintEventArgs e,string name, Point pos) => 
			e.Graphics.DrawImage(bitmaps[name], new Point(pos.X * 100, pos.Y * 100));
	}
}