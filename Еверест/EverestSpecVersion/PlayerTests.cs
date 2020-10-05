using NUnit.Framework;

namespace EverestSpecVersion
{
	[TestFixture]
	class PlayerTests
	{
		[Test]
		public void OnMove()
		{
			var g = new Game(new Map(new string[] { "p ",
													"  "}));
			var p = (Player)Game.map[0, 0];
			p.Move(1, 0);
			Assert.AreEqual(p.Position.X, 1);
			Assert.AreEqual(p.Position.Y, 0);
			Assert.IsTrue(Game.map[1, 0] is Player);
		}

		[Test]
		public void MoveInEnd()
		{
			var g = new Game(new Map(new string[] { "p ",
													"  "}));
			var p = (Player)Game.map[0, 0];
			p.Move(1, 0);
			p.Move(1, 0);
			p.Move(1, 0);
			Assert.AreEqual(p.Position.X, 1);
			Assert.AreEqual(p.Position.Y, 0);
			p.Move(0, 1);
			p.Move(0, 1);
			p.Move(0, 1);
			Assert.AreEqual(p.Position.X, 1);
			Assert.AreEqual(p.Position.Y, 1);
			p.Move(-1, -1);
			p.Move(-1, -1);
			p.Move(-1, -1);
			Assert.AreEqual(p.Position.X, 0);
			Assert.AreEqual(p.Position.Y, 0);
			Assert.IsTrue(Game.map[p.Position.X, p.Position.Y] is Player);
		}

		[Test]
		public void OnOxygenAndEnergy()
		{
			var g = new Game(new Map(new string[] { "p ",
													"  "}));
			var p = (Player)Game.map[0, 0];
			g.Update(1, 0);
			Assert.AreEqual(p.Energy, 100 - p.SpeedEnergy);
			Assert.AreEqual(p.Oxygen, 100 - p.SpeedBreath);
			g.Update(0, 0);
			Assert.AreEqual(p.Energy, 100 - p.SpeedEnergy);
			Assert.AreEqual(p.Oxygen, 100 - p.SpeedBreath * 2, 0.00001);
		}

		[Test]
		public void EndOxygen()
		{
			var g = new Game(new Map(new string[] { "p ",
													"  "}));
			var p = (Player)Game.map[0, 0];
			while (p.Oxygen >= 0)
				g.Update(0, 0);
			g.Update(0, 0);
			Assert.IsTrue(Game.map[0, 0] is Snow);
		}

		[Test]
		public void GetEnergyAndOxygen()
		{
			var g = new Game(new Map(new string[] { "pT",
													"  "}));
			var p = (Player)Game.map[0, 0];
			var e = p.Energy;
			var o = p.Oxygen;
			g.Update(1, 0);
			Assert.AreNotEqual(p.Oxygen - p.SpeedBreath, o);
			Assert.AreNotEqual(p.Energy - p.SpeedEnergy, e);
		}
	}
}
