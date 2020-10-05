using System;
using System.Drawing;


namespace EverestSpecVersion
{
	public class Player : GameObject, Anim
	{
		public Point Position { get; private set; }
		public GameObject OnStay { get; private set; }
		public float Oxygen { get; private set; }
		public float Energy { get; private set; }
		public bool death = false;
		public bool IsAnimation { get; private set; }
		public Point PositionOnWindow { get; set; }

		public float SpeedBreath = 0.3f;

		public float SpeedEnergy = 0.6f;

		public int speed = 50;

		public Player() {
			OnStay = new Snow();
			Oxygen = Energy = 100;
		}

		public Player(Point pos) {
			Position = pos;
			OnStay = new Snow(pos);
			Oxygen = Energy = 100;
		}

		public Player(int x, int y)
		{
			Position = new Point(x, y);
			OnStay = new Snow(x, y);
			Oxygen = Energy = 100;
		}

		public void Move(int horizontal, int vertical)
		{
			IsAnimation = false;
			CheckCorrect(horizontal, vertical);
			var posX = Position.X + horizontal;
			var posY = Position.Y + vertical;
			if (CheckCorrectKordinate(posX, posY) && CheckOnCollision(posX, posY))
			{
				if (horizontal != 0 || vertical != 0)
				{
					Energy -= SpeedEnergy;
					IsAnimation = true;
				}
				Go(posX, posY);
				PlayerAnimation.SetDirection(horizontal, vertical);
			}
		}
		
		public void Act()
		{
			if (OnStay is Tent)
			{
				var t = (Tent)OnStay;
				t.AddEnergyAndOxygen();
			}
			if (Oxygen > 100) Oxygen = 100;
			if (Oxygen < 0) Death();
			if (Energy > 100) Energy = 100;
			if (Energy < 0) Death();
			Oxygen -= SpeedBreath;
			if (OnStay is Ice) speed = 100;
			else speed = 50;
		}

		public string GetImageName() => PlayerAnimation.GetImageName();

		public void Death()
		{
			Game.map[Position.X, Position.Y] = OnStay;
			death = true;
			IsAnimation = false;
		} 

		public void ChangeEnergyAndOxygen(float e, float o)
		{
			Oxygen += o;
			Energy += e;
		}

		public bool IsBackground() => true;

		public string GetNameBackground() => OnStay.GetImageName();


		private bool CheckOnCollision(int posX, int posY) =>
			!((Game.map[posX, posY] is Icicle || Game.map[posX, posY] is Tree));

		private bool CheckCorrectKordinate(int posX, int posY) =>
			posX < Game.MapWidth && posX >= 0 && posY < Game.MapHeight && posY >= 0;

		private void CheckCorrect(int horizontal, int vertical)
		{
			if (Math.Abs(horizontal) != 0 && Math.Abs(horizontal) != 1 &&
				Math.Abs(vertical) != 0 && Math.Abs(vertical) != 1)
				throw new FormatException();
		}

		private void Go(int posX, int posY)
		{
			Replace(posX, posY);
			Position = new Point(posX, posY);
		}

		private void Replace(int posX, int posY)
		{
			Game.map[Position.X, Position.Y] = OnStay;
			OnStay = Game.map[posX, posY];
			Game.map[posX, posY] = this;
		}
	}
}
