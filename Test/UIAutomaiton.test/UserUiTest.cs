using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UIAutomaiton.test
{
    public class UserUiTest
    {
        private IWebDriver webDriver;

        [OneTimeSetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver(".");
        }

        [Test]
        public void Test1()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            webDriver.Url = outPutDirectory + $"\\..\\..\\..\\_ui_automation\\PostUser.html";
            //IWebElement name = webDriver.FindElement(By.Id("Name"));
            //IWebElement name = webDriver.FindElement(By.Name("name"));       
            //IWebElement name = webDriver.FindElement(By.ClassName("Name"));
            IWebElement name = webDriver.FindElement(By.TagName("input[data-type=Name]"));

            name.SendKeys("Abel Lopes (Found By Id)");

            IWebElement anchor = webDriver.FindElement(By.LinkText("Enviar"));

            anchor.Click();

            Assert.Pass();
        }

        [OneTimeTearDown]
        public void CloseTest()
        {
          // webDriver.Close();
        }
    }
}