using System;

namespace TestFitNesse
{
    public class RowFixtureTest : fit.RowFixture
    {
        public override Type GetTargetClass()
        {
            return typeof(Player);
        }
        public override object[] Query()
        {
            return Player.Players.ToArray();
        }
    }
}
