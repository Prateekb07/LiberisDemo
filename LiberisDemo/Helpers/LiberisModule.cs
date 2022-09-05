using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Remotion.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LiberisDemo.Helpers
{
    public class LiberisModule
    {
        public IWebDriver driver;
        /// <summary>
        /// To launch the URL and Browser
        /// </summary>
        /// <param name="url"></param>
        public void LaunchURL(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

        }
        /// <summary>
        /// Click on a button of Demo
        /// </summary>
        public void ClickDemo()
        {
            driver.FindElement(By.XPath("//a[@class='btn']")).Click();
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Verifying the Page and Partners name
        /// </summary>
        public void VerifyPartnerPage()
        {
            var url = driver.Url;
            Assertion.IsTrue(url.Contains("partner"), "Incorrect Page opened");
            IList<IWebElement> partnerTypes = driver.FindElements(By.XPath("//*[@class='radio_container']//label"));
            List<string> partnerNames = new List<string>();
            List<string> uiPartnerNamesList = new List<string>();
            uiPartnerNamesList.Add("I'm a Broker");     //We can remove these values by passing through feature file or just by checking the count.
            uiPartnerNamesList.Add("I'm an ISO");
            uiPartnerNamesList.Add("I'm a Strategic Partner");

            partnerNames= partnerTypes.Select(x => x.Text.Trim()).ToList();

            Thread.Sleep(5000);
            var flag = CompareTwoList(partnerNames, uiPartnerNamesList);
            Assertion.IsTrue(flag, "Incorrect Partner names displayed");
        }

        /// <summary>
        /// Generic Method for List Comparison
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="toCompare"></param>
        /// <returns></returns>
        public static bool CompareTwoList(List<string> origin, List<string> toCompare)
        {
            bool flag = origin.Count == toCompare.Count && !origin.Except(toCompare).Any() && !toCompare.Except(origin).Any();
            return flag;
        }

        /// <summary>
        /// Verify the PartnerSelection message
        /// </summary>
        public void VerifyPartnerSelection()
        {
            driver.FindElement(By.XPath("//a[contains(@class,'btn btn--medium')]")).Click();
            Thread.Sleep(5000);
            // string warningText = driver.FindElement(By.XPath("//div[contains(@class,'ph-error-inner')]')]")).Text;
            bool flag = driver.FindElement(By.XPath("//div[contains(@class,'ph-error-inner')]")).Displayed;
            Assertion.IsTrue(flag, "Incorrect warning message displayed");
            driver.Quit();
        }
    }
}
