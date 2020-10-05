using System;
using System.Drawing;


namespace EverestSpecVersion
{
	public class ScrollMap
	{
		private const int Widht = 14;
		private const int Heigth = 8;
		public static Point Start { get; private set; }
		public static Point End { get; private set; }

		public static void Update()
		{
			var player = Game.FindPlayer();
			var startX = Math.Max(player.Position.X - Widht / 2, 0);
			var endX = Math.Min(startX + Widht , Game.MapWidth);
			var startY = Math.Max(player.Position.Y - Heigth / 2, 0);
			var endY = Math.Min(startY + Heigth, Game.MapHeight);

			if (endX == Game.MapWidth && Game.MapWidth > Widht)
				startX += Game.MapWidth - player.Position.X - Widht / 2;
			if (endY == Game.MapHeight && Game.MapHeight > Heigth)
				startY += Game.MapHeight - player.Position.Y - Heigth / 2 + 1;

			Start = new Point(startX, startY);
			End = new Point(endX, endY);
		}
	}
}
