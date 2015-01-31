
using System;

namespace TestFitNesse
{
    public class OurSecondTest : fit.Fixture
    {
        public string FirstPart;
        public string SecondPart;
        public string Together;

        public OurSecondTest()
        {
            FirstPart = String.Empty;
            SecondPart = String.Empty;
            Together = String.Empty;
        }
        public void Join()
        {
            Together = FirstPart + " " + SecondPart;
        }
    }
}
