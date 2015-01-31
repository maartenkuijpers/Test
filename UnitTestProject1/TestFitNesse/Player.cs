using System;
using System.Collections.Generic;

namespace TestFitNesse
{
    public class Player
    {
        public static List<Player> Players = new List<Player>();

        public string Name { get; set; }

        public string PostCode { get; set; }

        public decimal Balance { get; set; }

        public decimal CreditLimit()
        {
            return Balance;
        }
    }

    public class Text
    {
        public String Word;

        public Text(String w)
        {
            Word = w;
        }

        public int TotalLength
        {
            get { return Word.Length; }
        }
    }

    public class TaxCalculator
    {
        public decimal GetTax(String code, decimal price)
        {
            if (code.StartsWith("B")) return 0;
            return 0.1m*price;
        }
    }
}