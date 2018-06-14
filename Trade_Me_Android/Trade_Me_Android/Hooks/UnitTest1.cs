using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Net;
using System.Threading;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Service;
using Trade_Me_Android.Utilities;
using Trade_Me_Android.Pages_class;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Me_Android
{
    [TestFixture()]
    public class TradeMe_Android_Login_Test_1
    {
        private AndroidDriver<AppiumWebElement> app;
        private Trade_Me_logon Trade_Me_PageObject;
        

        [OneTimeSetUp]
        public void BeforeAll()
        {
            // add a comment for master branch
            string PlatformName = "Android";
            string DeviceName = "Pixel_2_API_24";
            string PlatformVersion = "7.0";
            string AppPath = "D:\\apps\\nz.co.trademe.trademe.apk";
            Uri Server = new Uri("http://localhost:4723/wd/hub");

            Appium_Utilities driver = new Appium_Utilities();
            app = driver.Initialize_Appium_Driver(PlatformName, DeviceName, PlatformVersion, AppPath, Server);

        }

        [SetUp]
        public void SetUp()
        {

        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            Console.Write("Running teatr down.......");
            app.CloseApp();
        }

        [Test()]
        public void TradeMe_verify_logged_in()
        {

            // Find the login input field
            AppiumWebElement TradeMe_Login = app.FindElementById("nz.co.trademe.trademe:id/editTextLoginEmail");
            // key in your user name
            TradeMe_Login.SendKeys("sunjeet81@gmail.com");
            // Find the password field
            AppiumWebElement TradeMe_Pwd = app.FindElementById("nz.co.trademe.trademe:id/editTextLoginPassword");
            // key in the password
            TradeMe_Pwd.SendKeys("yorks64");
            // Find the login button
            AppiumWebElement Login_Button = app.FindElementById("nz.co.trademe.trademe:id/buttonLogin");
            // Tap the login button
            Login_Button.Tap(1, 1);
            // Wait for the account menu item to be displayed
            WebDriverWait wait = new WebDriverWait(app, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/menuAccount")));
            // Find icon for my account
            AppiumWebElement account_icon = app.FindElementByAccessibilityId("Account");
            // tap the icon
            account_icon.Tap(1, 1);
            // confirm that the logout button is visible, this is in turn ensure that the user name isbeing displayed
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/buttonLogout")));
            // find and assert on the text of the user name
            AppiumWebElement account_name = app.FindElementById("nz.co.trademe.trademe:id/textViewAboutMemberUsername");
            Assert.AreEqual(account_name.Text, "sunjeet81");
        }

        [Test()]
        public void TradeMe_verify_logged_out()
        {
            AppiumWebElement logout_button = app.FindElementById("nz.co.trademe.trademe:id/buttonLogout");
            logout_button.Tap(1, 1);
            WebDriverWait wait = new WebDriverWait(app, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/buttonDialogGenericConfirm")));
            AppiumWebElement confirm_button = app.FindElementByAccessibilityId("Confirm");
            confirm_button.Tap(1, 1);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("Login")));
            Assert.IsNotNull(app.FindElementByAccessibilityId("Login"));
        }

    }
}