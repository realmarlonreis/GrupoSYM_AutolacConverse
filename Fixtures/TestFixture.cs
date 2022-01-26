using GRUPOSYM_ProjetoConverse.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GRUPOSYM_ProjetoConverse.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TestFixture()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox", "--start-maximized", "--disable-dev-shm-usage");


            Driver = new ChromeDriver(TestHelper.Chromedriver, options, TimeSpan.FromMinutes(3));
            Driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        }

        //TearDown
        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
    }
}
