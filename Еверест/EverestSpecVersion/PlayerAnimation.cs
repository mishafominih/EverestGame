using System.Collections.Generic;

namespace EverestSpecVersion
{
	public enum Direction
	{
		Stay,
		Forward,
		Back,
		Right,
		Left
	}

	class PlayerAnimation
	{
		private static Direction dir;
		private static int speed = 5;
		private static int iterator = 0;
		private static int index = 0;
		private static readonly Dictionary<Direction, List<string>> State =
			new Dictionary<Direction, List<string>>
			{
				{ Direction.Forward, new List<string>{ "f1.bmp", "f2.bmp"} },
				{ Direction.Back, new List<string>{ "b1.bmp", "b2.bmp" } },
				{ Direction.Left, new List<string>{ "l1.bmp", "l2.bmp" } },
				{ Direction.Right, new List<string>{ "r1.bmp", "r2.bmp"} },
				{Direction.Stay, new List<string>{ "s.bmp" } }
			};

		public static void SetDirection(int horizontal, int vertical)
		{
			if (horizontal == vertical) dir = Direction.Stay;
			if (vertical == 1) dir = Direction.Back;
			if (vertical == -1) dir = Direction.Forward;
			if (horizontal == 1) dir = Direction.Right;
			if (horizontal == -1) dir = Direction.Left;
		}

		public static string GetImageName()
		{
			if (dir == Direction.Stay) return State[dir][0];
			Iterations();
			return State[dir][index];
		}	

		private static void Iterations()
		{
			iterator++;
			if (iterator >= speed)
			{
				iterator = 0;
				index++;
				if (index >= 2) index = 0;
			}
		}
	}
}
