using System.Drawing;

namespace EverestSpecVersion
{
	public class Tree : GameObject
	{
		public Point Position { get; private set; }
		
		public Tree() { }

		public Tree(int x, int y) => Position = new Point(x, y);

		public Tree(Point v) => Position = v;

		public void Act() { }

		public string GetImageName() => "Tree.bmp";

		public bool IsBackground() => true;

		public string GetNameBackground() => new Snow().GetImageName();
	}
}
