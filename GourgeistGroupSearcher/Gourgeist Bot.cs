//array of targeted IDs to itterate through.
using GourgeistGroupSearcher;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public class HelloSelenium
{
    public static void Main()
    {
        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://VRChat.com");
        Console.WriteLine("Click any key after you did login.");
        Console.ReadKey();
        while (true)
        {
            try
            {
                bool found = false;
                Methods.click(driver, "//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div[1]/div/div/a/div/button");
                Methods.write(driver, "//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div[2]/div[1]/div[2]/div/div/div/input", Variables.groupName);
                for (int i = 0; i < 9; i++)
                {
                    Methods.click(driver, "//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div[3]/button");
                }
                string ID = Methods.getID(Methods.getString(driver, "//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div/div[2]/div/div/div/a"));
                for (int i = 0; i < ID.Length; i++)
                {
                    if (Variables.target[i] == ID) { found = true; }
                }
                if (!found)
                {
                    Thread.Sleep(300);
                    Methods.click(driver, "//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div/div[4]/div[7]/button");
                    Methods.click(driver, "//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div/div[5]/div[7]/div/div[3]/div/div/div/button");
                    Thread.Sleep(1000);
                    Methods.click(driver, "//*[@id=\"home\"]/div[2]/div/div[1]/div/div/div[2]/div/div[2]/div/button");
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                driver.Navigate().GoToUrl("https://vrchat.com/home/groups");
                Thread.Sleep(2000);
            }
        }
    }
}

