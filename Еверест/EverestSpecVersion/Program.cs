using System.Windows.Forms;

namespace EverestSpecVersion
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Application.Run(new Menu());
				if (Menu.play)
					LvlDispetcher.Load(Menu.lvl);
				else break;
			}
		}
	}
}
