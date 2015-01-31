
namespace TestFitNesse
{
    public class SetUpFixtureTest : fitlibrary.SetUpFixture
    {
        public SetUpFixtureTest()
        {
            Player.Players.Clear();
        }
        public void PlayerPostcodeBalance(string player, string postCode, decimal balance)
        {
            var p = new Player();
            p.Name = player;
            p.PostCode = postCode;
            p.Balance = balance;
            Player.Players.Add(p);
        }
    }
}
