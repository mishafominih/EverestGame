using System;
using System.Drawing;

namespace EverestSpecVersion
{
	public class Tent : GameObject
	{
		public Point Position { get; private set; }
		bool first = true;

		public Tent() { }

		public Tent(Point v) => Position = v;

		public Tent(int x, int y) => Position = new Point(x, y);

		public void Act() { }

		public void AddEnergyAndOxygen()
		{
			if (first)
			{
				first = false;
				var p = (Player)Game.map[Position.X, Position.Y];
				Random r = new Random();
				p.ChangeEnergyAndOxygen(r.Next(10, 75), r.Next(10, 75));
			}
		}

		public string GetImageName() => "Tent.bmp";

		public bool IsBackground() => true;

		public string GetNameBackground() => new Snow().GetImageName();
	}
}
