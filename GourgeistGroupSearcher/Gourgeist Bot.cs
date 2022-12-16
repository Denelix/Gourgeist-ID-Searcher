//array of targeted IDs to itterate through.
using GourgeistGroupSearcher;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

public class GourgeistBot
{
    public static ChromeDriver driver = new ChromeDriver();
    public static void Main()
    {
        var untilLocked = 0;
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://VRChat.com");
        Console.WriteLine("Click any key after you did login.");
        Console.ReadKey();
        driver.Navigate().GoToUrl("https://vrchat.com/home/groups");
        while (true)
        {
            try
            {
                string ID = "";
                bool found = false;
                Methods.click("//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div[1]/div/div/a/div/button");
                Methods.write("//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div[1]/div[1]/div[2]/div/div/div/input", Variables.groupName);
                for (int i = 0; i < 11; i++)
                {
                    Methods.click("//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div[2]/div[2]/button");
                }
                ID = Methods.getString("//*[@id=\"app\"]/main/div[2]/div[2]/div/div[2]/div/div/div/div[2]/div/div/div/div[3]/a");
                untilLocked++;
                ID = ID.Substring(ID.Length - 4);
                Console.WriteLine(ID + " " + untilLocked+"/48");
                for (int i = 0; i < Variables.target.Length; i++)
                {
                    if (Variables.target[i] == ID) { found = true; }
                }
                if (!found)
                {
                    Methods.delete(driver);
                }
            }
            catch
            {
                Methods.delete(driver);
            }
            finally
            {
                driver.Navigate().GoToUrl("https://vrchat.com/home/groups");
            }
        }
    }
}

