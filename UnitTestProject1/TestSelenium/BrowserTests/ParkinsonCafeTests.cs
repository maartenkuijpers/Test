using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject1.Core;

namespace UnitTestProject1.BrowserTests
{
    [TestFixture]
    public class ParkinsonCafeTests : BaseTest
    {
        [Test]
        public void OpenHomepage()
        {
            // arrange
            // act
            CurrentDriver.Navigate().GoToUrl("http://www.parkinsoncafedenbosch.nl/");

            // assert
            var wait = new WebDriverWait(CurrentDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Parkinson Café 's-Hertogenbosch e.o."));

            Console.WriteLine("bla");
            System.Diagnostics.Debug.WriteLine("Page title is: " + CurrentDriver.Title);
        }

        [Test]
        public void CheckDateOnVerslagen()
        {
            CurrentDriver.Navigate().GoToUrl("http://www.parkinsoncafedenbosch.nl/");
            CurrentDriver.FindElement(By.LinkText("Bijeenkomsten")).Click();

            // Arrange
            const int year = 2014;
            var dateStrings = CurrentDriver.FindElements(By.XPath("//div/h5[text()='In " + year + "']/following-sibling::p/strong"));
            var reportDates = new List<DateTime>();
            foreach (var dateString in dateStrings)
            {
                var date = dateString.Text.Replace(":", " " + year);
                reportDates.Add(DateTime.Parse(date));
            }

            // Act
            var actions = new Actions(CurrentDriver);
            var hover = CurrentDriver.FindElement(By.LinkText("Bijeenkomsten"));
            actions.MoveToElement(hover).MoveToElement(CurrentDriver.FindElement(By.LinkText("Verslagen"))).Click().Build().Perform();

            // Assert
            var lis =
                CurrentDriver.FindElements(
                    By.XPath("//div[@class='entry-content']/p[strong[text()='Verslagen " + year + "']]/following-sibling::ul/li"));
            foreach (var reportDate in reportDates)
            {
                var dateToTest = reportDate.ToString("d MMMM");
                Assert.IsTrue(lis.Any(li => li.Text.Contains(dateToTest.ToLower())));
            }
        }
    }
}