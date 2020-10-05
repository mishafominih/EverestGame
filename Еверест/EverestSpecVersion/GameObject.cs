using System.Drawing;

namespace EverestSpecVersion
{
	public interface GameObject
	{
		void Act();
		string GetImageName();
		Point Position { get; }
		bool IsBackground();
		string GetNameBackground();
	}

	public interface Anim
	{
		bool IsAnimation { get; }
		Point PositionOnWindow { get; set; }
	}
}
