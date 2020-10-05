using System.Collections.Generic;

namespace EverestSpecVersion
{
	public class Game
	{
		public static GameObject[,] map { get; private set; }
		public static int MapHeight { get; private set; }
		public static int MapWidth { get; private set; }
		private static Player player;

		public Game(Map m)
		{
			map = m.GetMap();
			player = null;
			player = FindPlayer();
			MapHeight = m.Height;
			MapWidth = m.Width;
			ScrollMap.Update();
		}

		public static Player FindPlayer()
		{
			if (player != null) return player;
			foreach (var g in map)
				if (g is Player)
					player = (Player)g;
			return player;
		}

		public void Update(int horizontal, int vertical)
		{
			if (player != null && !player.death)
				player.Move(horizontal, vertical);
			ToList().ForEach(g => g.Act());
		}
		
		private List<GameObject> ToList()
		{
			var list = new List<GameObject>();
			foreach (var g in map) list.Add(g);
			return list;
		}
	}
}