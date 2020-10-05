using System;
using System.Drawing;

namespace EverestSpecVersion
{
	public class Ice : GameObject
	{
		public Point Position { get; private set; }
		
		public Ice() { }

		public Ice(Point v) => Position = v;

		public Ice(int x, int y) => Position = new Point(x, y);

		public void Act() { }

		public string GetImageName() => "Ice.bmp";

		public bool IsBackground() => false;

		public string GetNameBackground() => throw new NotImplementedException();
	}
}
