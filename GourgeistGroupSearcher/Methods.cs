using GourgeistGroupSearcher;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumExtras.WaitHelpers;
using System.Threading.Tasks;

namespace GourgeistGroupSearcher
{
    public class Methods
    {
        internal static void click(string p)
        {
            wait(GourgeistBot.driver, p);
            IWebElement button = GourgeistBot.driver.FindElement(By.XPath(p));
            new Actions(GourgeistBot.driver)
                .MoveToElement(button)
                .Click()
                /*.Pause(TimeSpan.FromSeconds(.2))*/
                .Perform();
        }
        internal static void write(string p, string input)
        {
            wait(GourgeistBot.driver, p);
            IWebElement field = GourgeistBot.driver.FindElement(By.XPath(p));
            new Actions(GourgeistBot.driver)
                .MoveToElement(field)
                .Click()
                .SendKeys(input)
                /*.Pause(TimeSpan.FromSeconds(.2))*/
                .Perform();
        }
        internal static string getString(string p)
        {
            wait(GourgeistBot.driver, p);
            IWebElement field = GourgeistBot.driver.FindElement(By.XPath(p));
            Console.WriteLine(GourgeistBot.driver.FindElement(By.XPath(p)).GetAttribute("href"));
            return GourgeistBot.driver.FindElement(By.XPath(p)).GetAttribute("href");
        }
        protected static void wait(ChromeDriver driver, string p)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(p)));
            }
            catch { }
        }
        internal static void delete(ChromeDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl(driver.Url+"/settings");
                Methods.click("//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div/div[5]/div[4]/div/div/button");
                Methods.click("//*[@id=\"home\"]/div[2]/div/div[1]/div/div/div[2]/div/div[2]/div/button");
            }
            catch { }
        }
    }
}
