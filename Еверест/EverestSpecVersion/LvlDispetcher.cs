using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EverestSpecVersion
{
	public class LvlDispetcher
	{
		static List<string[]> lvls = new List<string[]>
		{
			Lvls.Lvl1, Lvls.Lvl2, Lvls.Lvl3, Lvls.Lvl4
		};

		public static int lvl { get; private set; }
		static bool end = false;
		static bool change = false;

		public static void NextLvl()
		{
			if (!change)
			{
				lvl++;
				change = true;
			}
		}

		public static void Close() => end = true;

		public static void Load(int level)
		{
			try
			{
				lvl = level;
				while (!end)
				{
					Application.Run(new Window(new Game(new Map(lvls[lvl]))));
					change = false;
				}
			}
			catch(Exception e)
			{
				Menu.play = false;
				return;
			}
		}
	}
}
