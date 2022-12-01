using GourgeistGroupSearcher;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourgeistGroupSearcher
{
    public class Methods
    {
        internal static void click(ChromeDriver driver, string p)
        {
            IWebElement button = driver.FindElement(By.XPath(p));
            new Actions(driver)
                .MoveToElement(button)
                .Click()
                .Pause(TimeSpan.FromSeconds(.2))
                .Perform();
        }
        internal static void write(ChromeDriver driver, string p, string input)
        {
            IWebElement field = driver.FindElement(By.XPath(p));
            new Actions(driver)
                .MoveToElement(field)
                .Click()
                .SendKeys(input)
                .Pause(TimeSpan.FromSeconds(.2))
                .Perform();
        }
        internal static string getString(ChromeDriver driver, string p)
        {
            IWebElement field = null;
            try
            {
                field = driver.FindElement(By.XPath(p));
                new Actions(driver)
                    .MoveToElement(field)
                    .Click()
                    .Pause(TimeSpan.FromSeconds(.2))
                    .SendKeys(Variables.groupName)
                    .Perform();
            }
            catch { return "Not on right page? Slow internet?"; }
            try
            {
                return driver.FindElement(By.XPath(p)).Text;
            } catch { return "Not on right page? Slow internet?"; }
        }
        internal static string getID(string p)
        {
            return p.Substring(p.Length - 4);
        }
        static string deleteGroup(string p)
        {
            return p.Substring(p.Length - 4);
        }
    }
}
