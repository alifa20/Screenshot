using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            var driver = new ChromeDriver(); // Should work in other Browser Drivers

            string baseLink = "http://www.codeproject.com";

            //foreach (var link in links)
            for (int i = 2326; i > 2325; i--)
            {
                string link = baseLink + i.ToString();
                driver.Navigate().GoToUrl(link);
                try
                {
                    var login = driver.FindElementById("Button1");
                    var uName = driver.FindElementByName("lname");
                    var pass = driver.FindElementByName("passw");
                    uName.SendKeys("admin");
                    pass.SendKeys("*******");
                    login.Submit();
                }
                catch
                {
                    //already logged in 

                }
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                //Use it as you want now
                string screenshot = ss.AsBase64EncodedString;
                byte[] screenshotAsByteArray = ss.AsByteArray;
                FileNameFromURL fileNameFromURL = new ConsoleApplication1.FileNameFromURL();
                string filePath = Application.StartupPath + fileNameFromURL.ConvertToWindowsFileName(link) + ".jpg";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                ss.SaveAsFile(filePath, ImageFormat.Png); //use any of the built in image formating
                ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;

            }
            //driver.Dispose();
            driver.Close();
        }
    }
}
