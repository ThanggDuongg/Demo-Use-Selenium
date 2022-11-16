using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;

namespace TestProject
{
    public class Tests
    {
        private WebDriver WebDriver { get; set; } = null!;
        private string DriverPath { get; set; } = @"E:\HK1_Nam4\SoftwareTesting\Record\demo\chrome";
        private string BaseUrl { get; set; } = "https://online.hcmute.edu.vn/";

        [SetUp]
        public void Setup()
        {
            WebDriver = GetChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.Quit();
        }

        [Test]
        public void TestAutoClick()
        {
            WebDriver.Navigate().GoToUrl("http://orteil.dashnet.org/cookieclicker/");
            var input = WebDriver.FindElement(By.Id("langSelect-EN"));
            input.Click();
            Thread.Sleep(2000);
            var input0 = WebDriver.FindElement(By.Id("bigCookie"));
            while (true)
            {
                input0.Click();
                var input3 = WebDriver.FindElement(By.Id("cookies"));
                var count = input3.GetAttribute("textContent").Split(" ")[0];
                if (int.Parse(count) > 13)
                {
                    var input1 = WebDriver.FindElement(By.Id("productName0"));
                    IJavaScriptExecutor executor1 = (IJavaScriptExecutor)WebDriver;
                    executor1.ExecuteScript("arguments[0].click()", input1);
                } else if (int.Parse(count) > 18)
                {
                    var input2 = WebDriver.FindElement(By.Id("productName0"));
                    IJavaScriptExecutor executor1 = (IJavaScriptExecutor)WebDriver;
                    executor1.ExecuteScript("arguments[0].click()", input2);
                } else
                {
                    continue;
                }
            }
        }

        [Test]
        public void TestTitle()
        {
            WebDriver.Navigate().GoToUrl(BaseUrl);
            Assert.That(WebDriver.Title, Is.EqualTo("UTE Portal :: HCMC University of Technology and Education"));
        }

        [Test]
        public void LoginTest()
        {
            // Navigate to login page
            WebDriver.Navigate().GoToUrl(BaseUrl);

            // Enter EmailAddress
            //Thread.Sleep(5000);
            // find login button
            var input = WebDriver.FindElement(By.Id("ctl00_lbtDangnhap"));
            input.Click();
            //input.Clear();

            //Thread.Sleep(5000);
            input = WebDriver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctl00_ctl00_txtUserName"));
            input.Clear();
            input.SendKeys("19110461");

            // Enter Password
            //Thread.Sleep(5000);
            input = WebDriver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctl00_ctl00_txtPassword"));
            input.Clear();
            input.SendKeys("0989053642");

            // Click on Login button
            //Thread.Sleep(5000);
            //input = WebDriver.FindElement(By.Id("button_login"));
            input = WebDriver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctl00_ctl00_btLogin"));
            input.Click();

            // Validate login message
            var startTimestamp = DateTime.Now.Millisecond;
            var endTimstamp = startTimestamp + 15000;

            while (true)
            {
                try
                {
                    input = WebDriver.FindElement(By.Id("ctl00_lblFullName"));
                    //SV.Dương Đức  Thắng(Còn học)
                    Assert.That(input.GetAttribute("textContent"), Is.EqualTo("SV.Dương Đức  Thắng(Còn học)"));
                    break;
                }
                catch
                {
                    var currentTimestamp = DateTime.Now.Millisecond;
                    if (currentTimestamp > endTimstamp)
                    {
                        throw;
                    }
                    Thread.Sleep(2000);
                }
            }
        }

        private WebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();

            return new ChromeDriver(DriverPath, options, TimeSpan.FromSeconds(300));
        }
    }
}