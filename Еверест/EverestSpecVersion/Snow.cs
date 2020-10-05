using System;
using System.Drawing;

namespace EverestSpecVersion
{
	public class Snow : GameObject
	{
		public Point Position { get; private set; }
		
		public Snow() { }

		public Snow(Point pos) => Position = pos;

		public Snow(int x, int y) => Position = new Point(x, y);

		public void Act() { }

		public string GetImageName() => "Snow.bmp";

		public bool IsBackground() => false;

		public string GetNameBackground() => throw new NotImplementedException();
	}
}
