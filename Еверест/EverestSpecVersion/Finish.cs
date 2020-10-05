using System.Drawing;

namespace EverestSpecVersion
{
	public class Finish : GameObject
	{
		public Point Position { get; private set; }
		
		public Finish(int x, int y) => Position = new Point(x, y);

		public void Act() { }

		public string GetImageName() => "Finish.bmp";

		public string GetNameBackground() => new Snow().GetImageName();

		public bool IsBackground() => true;
	}
}
