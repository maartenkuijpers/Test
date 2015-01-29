
namespace TestFitNesse
{
    public class OurFirstTest : fit.ColumnFixture
    {
        public string string1;
        public string string2;

        public string Concatenate()
        {
            return string1 + " " + string2;
        }

        public int WordCount
        {
            get { return Concatenate().Split(' ').Length; }
        }

        public int CharacterCount
        {
            get { return Concatenate().Length; }
        }

    }
}
