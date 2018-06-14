using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.PageObjects.Attributes;

namespace Trade_Me_Android.Pages_class
{
    public class Trade_Me_logon
    {
        /*public Trade_Me_logon(AndroidDriver<AppiumWebElement> driver)
        {
            PageFactory.InitElements(driver,this);
        }*/


        [FindsBy(How = How.Id, Using = "nz.co.trademe.trademe:id/editTextLoginEmail")]
        //IMobileElement<AppiumWebElement> LoginField { get; set; }
        IWebElement LoginField { get; set; }

        public void Enter_UserName(string text)
        {
            LoginField.SendKeys(text);
        }


        [FindsBy(How = How.Id, Using = "nz.co.trademe.trademe:id/editTextLoginPassword")]
        IWebElement PasswordField { get; set; }
        //IMobileElement<AppiumWebElement>PasswordField {get;set;}

        public void Enter_Password(string text)
        {
            PasswordField.SendKeys(text);
        }

        //public object loginButton;

        [FindsBy(How = How.Id, Using = "nz.co.trademe.trademe:id/buttonLogin")]
        IWebElement LoginButton { get; set; }
        //IMobileElement<AndroidElement> LoginButton { get; set; }

        public void Tap_LoginButton()
        {
            //IMobileElement<AppiumWebElement> loginButton;
            //loginButton = (IMobileElement<AppiumWebElement>)LoginButton;
            //loginButton.Tap(1, 1);
            LoginButton.Click();
        }

        public void Initialize_Wait(TimeSpan t)
        {

        }

        [FindsBy(How = How.Id, Using = "nz.co.trademe.trademe:id/menuAccount")]
        public IWebElement AccountIcon { get; set; }

        public void Tap_AccountIcon()
        {
            //IMobileElement<AppiumWebElement> loginButton;
            //loginButton = (IMobileElement<AppiumWebElement>)LoginButton;
            //loginButton.Tap(1, 1);
            AccountIcon.Click();
        }

        [FindsBy(How = How.Id, Using = "nz.co.trademe.trademe:id/buttonLogout")]
        public IWebElement LogoutButton { get; set; }

        [FindsBy(How = How.Id, Using = "nz.co.trademe.trademe:id/textViewAboutMemberUsername")]
        IWebElement AccountName { get; set; }

        public string Return_AccountName_UnderTest()
        {
            return (AccountName.Text);
        }


    }
}
