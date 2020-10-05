using NUnit.Framework;

namespace EverestSpecVersion
{
	[TestFixture]
	class IciclesTests
	{
		[Test]
		public void CheckOnFall()
		{
			var g = new Game(new Map(new string[] { "cc ",
													"ii ",
													"iip"}));
			g.Update(-1, 0);
			g.Update(0, 0);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Ice);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Icicle);
			g.Update(1, 0);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Ice);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Ice);
			Assert.IsTrue(Game.map[0, 2] is Ice);
			Assert.IsTrue(Game.map[1, 2] is Icicle);
			Assert.IsTrue(Game.map[2, 2] is Player);
		}

		[Test]
		public void CheckOnCrash()
		{
			var g = new Game(new Map(new string[] { "cc ",
													"ii ",
													"iip"}));
			g.Update(-1, 0);
			g.Update(0, 0);
			g.Update(0, -1);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Ice);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Ice);
			Assert.IsTrue(Game.map[0, 2] is Ice);
			Assert.IsTrue(Game.map[1, 2] is Ice);
		}

		[Test]
		public void TestOnNotFall()
		{
			var g = new Game(new Map(new string[] { "cc ",
													"ii ",
													"ii ",
													"ii ",
													"ii ",
													"iip"}));
			g.Update(-1, 0);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Icicle);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Ice);
			g.Update(-1, 0);
			g.Update(0, 0);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Icicle);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Ice);
			g.Update(0, 0);
			g.Update(0, 0);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Icicle);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Ice);
		}

		[Test]
		public void TestOnNotFall1()
		{
			var g = new Game(new Map(new string[] { "cc ",
													"ii ",
													"   ",
													"iip"}));
			g.Update(-1, 0);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Icicle);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Ice);
			g.Update(-1, 0);
			g.Update(0, 0);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Icicle);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Ice);
			g.Update(0, 0);
			g.Update(0, 0);
			Assert.IsTrue(Game.map[0, 0] is Icicle);
			Assert.IsTrue(Game.map[1, 0] is Icicle);
			Assert.IsTrue(Game.map[0, 1] is Ice);
			Assert.IsTrue(Game.map[1, 1] is Ice);
		}
	}
}
