using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using AutoIt;
using NUnit.Framework;
using OpenQA.Selenium; 

namespace Csharp_selenium_specflow_nunit.Utility
{
    public class AutoItXCiscoIpCommunicator
    {
        static readonly string ipPhoneTitle = "Cisco IP Communicator";
        static readonly string button_0 = "[ID:2817]";
        static readonly string button_1 = "[ID:257]";
        static readonly string button_2 = "[ID:513]";
        static readonly string button_3 = "[ID:769]";
        static readonly string button_4 = "[ID:1025]";
        static readonly string button_5 = "[ID:1281]";
        static readonly string button_6 = "[ID:1537]";
        static readonly string button_7 = "[ID:1793]";
        static readonly string button_8 = "[ID:2049]";
        static readonly string button_9 = "[ID:2305]";
        static readonly string button_Star = "[ID:2561]";
        static readonly string button_HashTag = "[ID:3073]";
        static readonly string button_Dial = "[ID:261]";
        static readonly string button_Cancel = "[ID:1029]";

        public static void Main(string[] args)
        {
            String pathReport = $"{AppDomain.CurrentDomain.BaseDirectory}";
            Console.WriteLine("TESSSSSSSSSSST NE >>>>>>>>> " + pathReport);
             
        }

        public static void ForceVitualCiscoIpPhone()
        {
            AutoItX.Init();
            //string title = AutoItX.WinGetTitle(ipPhoneTitle);
            //if(AutoItX.WinActivate(ipPhoneTitle).Equals(0))
            //    AutoItX.Run("communicatork9.exe", "C:\\Program Files (x86)\\Cisco Systems\\Cisco IP Communicator\\communicatork9.exe");
            AutoItX.WinWait(ipPhoneTitle);
            AutoItX.WinActivate(ipPhoneTitle);
            AutoItX.WinWaitActive(ipPhoneTitle);
            
        }
         
        public static void InputKeypads(string keypads)
        { 
            for (int i = 0; i < keypads.Length; i++)
            {
                ClickKeypadButton(keypads[i].ToString());
            }
        }

        public static void ClickKeypadButton(string button)
        {
            try
            {
                switch (button.ToLower())
                {
                    case "0":
                        ClickElement(button_0);
                        break;
                    case "1":
                        ClickElement(button_1);
                        break;
                    case "2":
                        ClickElement(button_2);
                        break;
                    case "3":
                        ClickElement(button_3);
                        break;
                    case "4":
                        ClickElement(button_4);
                        break;
                    case "5":
                        ClickElement(button_5);
                        break;
                    case "6":
                        ClickElement(button_6);
                        break;
                    case "7":
                        ClickElement(button_7);
                        break;
                    case "8":
                        ClickElement(button_8);
                        break;
                    case "9":
                        ClickElement(button_9);
                        break;
                    case "*":
                        ClickElement(button_Star);
                        break;
                    case "#":
                        ClickElement(button_HashTag);
                        break;

                }
                Thread.Sleep(300);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element does NOT exist : " + button);
                Console.WriteLine("Class AutoItXCiscoIpCommunicator | Method ClickKeypadButton | Exception desc : " + ex.Message);
            }
        }

        public static void ClickElement(string button)
        {
            try
            {
                AutoItX.ControlClick(ipPhoneTitle, "", button);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element can not clickable : " + button);
                Console.WriteLine("Class AutoItXCiscoIpCommunicator | Method ClickElement | Exception desc : " + ex.Message);
            }
        }

        public static void ClickDialButton()
        {
            ClickElement(button_Dial);
        }

        public static void ClickCancelButton()
        {
            ClickElement(button_Cancel);
        }
    }

    public class AutoItXCiscoJabber
    {
        static readonly string jabberPhoneTitle = "Cisco Jabber";
        static readonly string btn_Search = "[ID:3304]";
        static readonly string button_Dial = "[ID:261]";
        static readonly string button_Cancel = "[ID:1029]"; 

        public static void ForceVitualCiscoJabberPhone()
        {
            AutoItX.Init();
            AutoItX.WinWait(jabberPhoneTitle);
            AutoItX.WinActivate(jabberPhoneTitle);
            AutoItX.WinWaitActive(jabberPhoneTitle);

        } 

        public static void InputHotline(string hotline)
        {
            try
            {
                AutoItX.ControlSetText(jabberPhoneTitle, "", btn_Search, hotline);
                Thread.Sleep(300);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element does NOT exist : " + btn_Search);
                Console.WriteLine("Class AutoItXCiscoJabber | Method InputHotline | Exception desc : " + ex.Message);
            }
        }

        public static void ClickElement(string button)
        {
            try
            {
                AutoItX.ControlClick(jabberPhoneTitle, "", button);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element can not clickable : " + button);
                Console.WriteLine("Class AutoItXCiscoJabber | Method ClickElement | Exception desc : " + ex.Message);
            }
        }

        public static void PressEnterToMakeADial()
        {
            AutoItX.Send("{ENTER}");
        }

        public static void ClickCancelButton()
        {
            ClickElement(button_Cancel);
        }
    }
}