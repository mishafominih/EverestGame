using System;
using System.Collections.Generic;

namespace EverestSpecVersion
{
	public class Map
	{
		private string[] map;
		public int Height { get; set; }
		public int Width { get; set; }
		private Dictionary<char, Func<int, int, GameObject>> dict =
			new Dictionary<char, Func<int, int, GameObject>>
			{
				{'p', (i, j) => new Player(i, j)},
				{' ', (i, j) => new Snow(i, j)  },
				{'i', (i, j) => new Ice(i, j)   },
				{'c', (i, j) => new Icicle(i, j)},
				{'t', (i, j) => new Tree(i, j)  },
				{'T', (i, j) => new Tent(i, j)  },
				{'f', (i, j) => new Finish(i, j)}
			};
		public Map(string[] map)
		{
			this.map = map;
			Height = map.Length;
			Width = map[0].Length;
		}

		public GameObject[,] GetMap()
		{
			var lvl = new GameObject[Width, Height];
			for (int i = 0; i < Height; i++)
				for (int j = 0; j < Width; j++)
					lvl[j,i] = dict[map[i][j]](j, i);
			return lvl;
		}
	}
}
