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

            List<string> links = new List<string>();
            links.Add("http://www.codeproject.com");
            //links.Add("http://www.google.com");

            foreach (var link in links)
            {
                driver.Navigate().GoToUrl(link);
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                //Use it as you want now
                string screenshot = ss.AsBase64EncodedString;
                byte[] screenshotAsByteArray = ss.AsByteArray;
                FileNameFromURL fileNameFromURL = new ConsoleApplication1.FileNameFromURL();
                string filePath = "C:\\pp\\dotnet\\ConsoleApplication1\\ConsoleApplication1\\bin\\Debug\\"
                    + fileNameFromURL.ConvertToWindowsFileName(link) + ".jpg";
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
