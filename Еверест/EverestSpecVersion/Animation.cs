using System.Collections.Generic;
using System.Drawing;

namespace EverestSpecVersion
{
	public class Animation
	{
		public const int CountFrame = 8;
		public static Dictionary<Anim, AnimationState> Anim =
			new Dictionary<Anim, AnimationState>();
		public static void CheckAnimation()
		{
			Anim.Clear();
			for (int i = 0; i < Game.MapWidth; i++)
				for (int j = 0; j < Game.MapHeight; j++)
				{
					var p = new Point(i * 100, j * 100);
					if (Game.map[i, j] is Anim)
					{
						var a = (Anim)Game.map[i, j];
						Anim[a] = new AnimationState { PreviousPosition = p};
					}
				}
		}

		public static void UpdateAnimation()
		{
			var anim = new Dictionary<Anim, AnimationState>();
			foreach (var a in Anim.Keys)
				if (a.IsAnimation)
				{
					var g = (GameObject)a;
					Anim[a].Dx = (g.Position.X * 100 - Anim[a].PreviousPosition.X) / CountFrame;
					Anim[a].Dy = (g.Position.Y * 100 - Anim[a].PreviousPosition.Y) / CountFrame;
					anim.Add(a, Anim[a]);
				}
			Anim = anim;
		}
	}

	public class AnimationState
	{
		public Point PreviousPosition;
		public Point Position;
		public int Dx;
		public int Dy;

		public void UpdatePosition(int scale)
		{
			if (scale == 0) scale = 8;
			Position = new Point(
				PreviousPosition.X + Dx * scale - ScrollMap.Start.X * 100,
				PreviousPosition.Y + Dy * scale - ScrollMap.Start.Y * 100);
		}
	}
}
