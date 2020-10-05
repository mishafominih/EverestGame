using System;
using System.Drawing;

namespace EverestSpecVersion
{
	public class Icicle : GameObject, Anim
	{
		public Point Position { get; private set; }

		public bool IsAnimation { get; private set; }

		public Point PositionOnWindow { get; set; }

		private int Height = 5;

		private bool isFall = false;

		public Icicle() { }

		public Icicle(int x, int y) => Position = new Point(x, y);

		public Icicle(Point pos) => Position = pos;

		public void Act()
		{
			IsAnimation = false;
			if (!isFall) CheckOnFall();
			else Fall();
		}

		public string GetImageName() => "Icicle.bmp";
		
		public bool IsBackground() => true;

		public string GetNameBackground() => new Ice().GetImageName();


		private void Fall()
		{
			int x = Position.X;
			int NextY = Position.Y + 1;
			if (NextY >= Game.MapHeight || !(Game.map[x, NextY] is Ice || 
				Game.map[x, NextY] is Player))
			{
				Death();
				return;
			}
			if (Height > 0)
			{
				if (Game.map[x, NextY] is Ice)
				{
					Height--;
					Game.map[x, NextY] = this;
					Game.map[x, Position.Y] = new Ice(Position);
					Position = new Point(x, NextY);
					IsAnimation = true;
				}
				else
				{
					var p = (Player)Game.map[x, NextY];
					if (p.OnStay is Ice) p.Death();
					Death();
				}
			}
			else Death();
		}

		private void CheckOnFall()
		{
			for (int j = Position.Y + 1; j < Math.Min(Position.Y + Height, Game.MapHeight); j++)
			{
				var i = Position.X;
				if (Game.map[i, j] is Ice || Game.map[i, j] is Player)
				{
					if (Game.map[i, j] is Player)
					{
						var p = (Player)Game.map[i, j];
						if (p.OnStay is Ice)
							isFall = true;
					}
				}
				else break;
			}
		}

		private void Death()
		{
			Game.map[Position.X, Position.Y] = new Ice(Position);
			IsAnimation = false;
		}
	}
}
