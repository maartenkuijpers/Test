using System;

namespace TestFitNesse
{
    public class TableFixtureTest : fitnesse.fixtures.TableFixture
    {
        protected override void DoStaticTable(int rows)
        {
            var tc = new TaxCalculator();
            decimal totaltax = 0;
            for (int row = 1; row < rows - 3; row++)
            {
                totaltax += tc.GetTax(GetString(row, 1), Decimal.Parse(GetString(row, 2)));
            }
            var taxintable = Decimal.Parse(GetString(rows - 2, 2));
            if (taxintable == totaltax)
                Right(rows - 2, 2);
            else
                Wrong(rows - 2, 2, totaltax.ToString());
        }
    }
}
