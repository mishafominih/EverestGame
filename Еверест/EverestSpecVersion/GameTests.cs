using NUnit.Framework;

namespace EverestSpecVersion
{
	[TestFixture]
	class GameTests
	{
		[Test]
		public void CreateMap()
		{
			var g = new Game(new Map(new string[] { "pi",
													"t "}));
			Assert.IsTrue(Game.map[0, 0] is Player);
			Assert.IsTrue(Game.map[1, 0] is Ice);
			Assert.IsTrue(Game.map[0, 1] is Tree);
			Assert.IsTrue(Game.map[1, 1] is Snow);
		}

		[Test]
		public void ChangeMap()
		{
			var g = new Game(new Map(new string[] { "pi",
													"  "}));
			var p = (Player)Game.map[0, 0];
			p.Move(1, 0);
			p.Move(0, 1);
			Assert.IsTrue(Game.map[0, 0] is Snow);
			Assert.IsTrue(Game.map[1, 0] is Ice);
			Assert.IsTrue(Game.map[0, 1] is Snow);
			Assert.IsTrue(Game.map[1, 1] is Player);
		}

		[Test]
		public void UpdateMap()
		{
			var g = new Game(new Map(new string[] { "pi",
													"  "}));
			g.Update(1,1);
			Assert.IsTrue(Game.map[0, 0] is Snow);
			Assert.IsTrue(Game.map[1, 0] is Ice);
			Assert.IsTrue(Game.map[0, 1] is Snow);
			Assert.IsTrue(Game.map[1, 1] is Player);
		}

		[Test]
		public void IciclesOnMap()
		{
			var g = new Game(new Map(new string[] { "cc ",
													"ii ",
													"iip"}));
			g.Update(0, 0);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Icicle);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Ice);
		}

		[Test]
		public void TentsOnMap()
		{
			var g = new Game(new Map(new string[] { "TT",
													"p "}));
			g.Update(0, 0);
			Assert.IsTrue(Game.map[0, 0] is Tent);
			Assert.IsTrue(Game.map[1, 0] is Tent);
		}

		[Test]
		public void MultyTest()
		{
			var g = new Game(new Map(new string[] { "  cc",
													"  ii",
													"pTii",
													"t i "}));
			var p = (Player)Game.map[0, 2];
			Assert.IsTrue(Game.map[2, 0] is Icicle);
			Assert.IsTrue(Game.map[3, 0] is Icicle);
			Assert.IsTrue(Game.map[0, 2] is Player);
			Assert.IsTrue(Game.map[1, 2] is Tent);
			Assert.IsTrue(Game.map[0, 3] is Tree);
			g.Update(0, 1);
			Assert.IsTrue(Game.map[2, 0] is Icicle);
			Assert.IsTrue(Game.map[3, 0] is Icicle);
			Assert.IsTrue(Game.map[0, 2] is Player);
			Assert.IsTrue(Game.map[1, 2] is Tent);
			Assert.IsTrue(Game.map[0, 3] is Tree);
			g.Update(1, 0);
			g.Update(1, 0);
			g.Update(1, 0);
			g.Update(0, 1);
			Assert.IsTrue(Game.map[2, 0] is Ice);
			Assert.IsTrue(Game.map[3, 0] is Ice);
			Assert.IsTrue(Game.map[2, 2] is Icicle);
			Assert.IsTrue(Game.map[3, 1] is Icicle);
			Assert.IsTrue(Game.map[3, 3] is Player);
			Assert.IsTrue(Game.map[1, 2] is Tent);
			Assert.IsTrue(Game.map[0, 3] is Tree);
			g.Update(0, 0);
			g.Update(0, 0);
			Assert.IsTrue(Game.map[2, 0] is Ice);
			Assert.IsTrue(Game.map[3, 0] is Ice);
			Assert.IsTrue(Game.map[2, 3] is Ice);
			Assert.IsTrue(Game.map[3, 2] is Ice);
			Assert.IsTrue(Game.map[3, 3] is Player);
			Assert.IsTrue(Game.map[1, 2] is Tent);
			Assert.IsTrue(Game.map[0, 3] is Tree);
		}
	}
}
