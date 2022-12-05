using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;

namespace Auto1
{
    class Program
    {
        static IWebDriver driver = new ChromeDriver();
        static IWebElement radioButton;
        static IWebElement dropDownMenu;
        static IWebElement elementFromTheDropDownMenu;
        static IWebElement element;
        static void Main(string[] args)
        {
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            driver.Manage().Window.Maximize();

            exercise1();
            exercise2();
            exercise3();
            exercise4();
            exercise4one();
            exercise4two();
            exercise5();
            switchwindow();
            exercise6();
            exericse7();
            exericse8();
            exericse9();
        }

        public static void exercise1()
        {
            string[] option = { "1", "2", "3" };


            for (int i = 0; i < option.Length; i++)
            {


                radioButton = driver.FindElement(By.XPath("//input[@value='radio" + option[i] + "']"));
                radioButton.Click();

                if (radioButton.GetAttribute("checked") == "true")
                {
                    Console.WriteLine("The " + (i + 1) + " radio button is checked!");
                }
                else
                {
                    Console.WriteLine("This is one of the unchecked radio buttons!");
                }
            }
            Thread.Sleep(2000);
            //driver.Quit();
        }

        public static void exercise2()
        {
            IWebElement select1 = driver.FindElement(By.XPath("//input[@placeholder='Type to Select Countries']"));
            select1.SendKeys("United ");
            IList<IWebElement> selbox = driver.FindElements(By.XPath("//div[@class='ui-menu-item-wrapper']"));
            foreach (var selectelement in selbox)
            {
                if (selectelement.Text.Contains("United Kingdom(UK)"))
                {
                    selectelement.Click();
                }
                //selectelement.Click();
            }

            Thread.Sleep(2000);


        }

        public static void exercise3()
        {

            IWebElement dropd = driver.FindElement(By.Id("dropdown-class-example"));
            dropd.Click();
            Thread.Sleep(2000);
            SelectElement dD = new SelectElement(dropd);
            for (int i = 0; i <= 3; i++)
            {
                dD.SelectByIndex(i);
                Thread.Sleep(2000);

            }

        }

        public static void exercise4()
        {
            for (int i = 1; i <= 3; i++)
            {
                IWebElement check = driver.FindElement(By.Id("checkBoxOption" + i + ""));
                check.Click();
                Thread.Sleep(2000);
                check.Click();
            }
            Thread.Sleep(2000);
        }
        public static void exercise4one()
        {
            for (int i = 1; i <= 3; i++)
            {
                IWebElement check = driver.FindElement(By.Id("checkBoxOption" + i + ""));
                check.Click();
                Thread.Sleep(2000);

            }

        }

        public static void exercise4two()
        {
            for (int i = 1; i <= 3; i++)
            {
                IWebElement check = driver.FindElement(By.Id("checkBoxOption" + i + ""));
                check.Click();


            }
            Thread.Sleep(1000);
        }

        public static void exercise5()
        {
            IWebElement newwindow = driver.FindElement(By.XPath("//button[@onclick= 'openWindow()']"));
            newwindow.Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();

            /*IWebElement practiceLink = driver.FindElement(By.XPath("//a[text()='Practice']"));
            practiceLink.Click();*/


        }
        public static void switchwindow()
        {
            IWebElement switchwindow = driver.FindElement(By.Id("openwindow"));
            switchwindow.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
        }

        public static void exercise6()
        {
            IWebElement switchwindow = driver.FindElement(By.Id("opentab"));
            switchwindow.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(3000);
        }

        public static void exericse7()
        {
            IWebElement enter = driver.FindElement(By.Id("name"));
            enter.SendKeys("Pooja");
            Thread.Sleep(2000);
            IWebElement alert = driver.FindElement(By.Id("alertbtn"));
            alert.Click();
            Thread.Sleep(2000);
            IAlert alt = driver.SwitchTo().Alert();
            alt.Accept();



        }

        public static void exericse8()
        {
            IWebElement table = driver.FindElement(By.Id("product"));

            Actions act = new Actions(driver);
            act.SendKeys(Keys.PageDown).Build().Perform(); //Page Down
            Thread.Sleep(3000);


            //((IJavaScriptExecuter)driver).executeScript("arguments[0].scrollIntoView(True);", table);
            //Actions act = new Actions(driver);
            //act.SendKeys(Keys.PageDown).Build().Perform(); //Page Down

            /*var elem = driver.FindElement(By.Id("product"));
            driver.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
            Thread.Sleep(3000);
            IWebElement table = driver.FindElement(By.Id("product"));
            Actions act = new Actions(driver);*/
        }

        public static void exericse9()
        {
            //IWebElement enter = driver.FindElement(By.Id("mousehover"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("mousehover")));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            Thread.Sleep(4000);
            IWebElement top = driver.FindElement(By.XPath("//a[@href='#top']"));
            action.MoveToElement(top).Perform();
            top.Click();
            //Waiting for the menu to be displayed    
            Thread.Sleep(4000);
            




        }


    }
}   

    
        


