using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using NUnit.Framework;
using UnitTestProject1.Core;

namespace UnitTestProject1
{
    [TestFixture]
    public class ParkinsonCafeTests : BaseTest
    {
        [Test]
        public void OpenHomepage()
        {
            // arrange
            CurrentDriver.Navigate().GoToUrl("http://www.parkinsoncafedenbosch.nl/");

            var wait = new WebDriverWait(CurrentDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Parkinson Café 's-Hertogenbosch e.o."));

            Console.WriteLine("bla");
            System.Diagnostics.Debug.WriteLine("Page title is: " + CurrentDriver.Title);
        }
    }
}
