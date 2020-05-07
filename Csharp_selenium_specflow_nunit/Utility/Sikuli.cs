using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;

public enum KeypadCiscoIpPhone
{
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT, 
    NICE,
    STAR,
    HASHTAG,
}

namespace Csharp_selenium_specflow_nunit.Utility
{
    public class SikuliCiscoIpPhone
    {
        static string CiscoIPCommunicatorImages = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\") + "Resources/Images/CiscoIpPhone" + Path.AltDirectorySeparatorChar;
        static Screen scr = new Screen();
        public static void Main(string[] args)
        {
            String pathReport = $"{AppDomain.CurrentDomain.BaseDirectory}";
            Console.WriteLine("TESSSSSSSSSSST NE >>>>>>>>> " + pathReport);
             
        }

        public static void SelectCiscoIpPhoneTaskBar()
        {
            ClickOnCiscoIpPhone(scr, "ICON_TASKBAR");
        }

        public static void Dial(string numberDial)
        { 
            for (int i = 0; i < numberDial.Length; i++)
            {
                ClickOnCiscoIpPhone(scr, numberDial[i].ToString());
            }
        }

        public static void ClickOnCiscoIpPhone(Screen scr, string element)
        {
            try
            {

                //ADD PATH ENV

                APILauncher launcher = new APILauncher();
                launcher.Start();
                Screen s = new Screen();
                Pattern ee = new Pattern(@"D:\CiscoIpPhone\ICON_TASKBAR.png");
                s.Click(ee);
                
                launcher.Stop();
                
                //scr.Click(new Pattern(CiscoIPCommunicatorImages + element + ".png"), true);
                Thread.Sleep(1000);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element does NOT exist or click able : " + element);
                Console.WriteLine("Class SikuliCiscoIpPhone | Method ClickOnCiscoIpPhone | Exception desc : " + ex.Message);
            }
        } 
    }
}