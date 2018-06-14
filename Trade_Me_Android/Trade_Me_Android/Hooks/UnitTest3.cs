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
    public class TradeMe_Android_Login_Test_2
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
            Trade_Me_PageObject = new Trade_Me_logon();
            PageFactory.InitElements(app,Trade_Me_PageObject);
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
        public void TradeMe_verify_logged_in_POM()
        {

            // Use a Page Object method to enter user name
            Trade_Me_PageObject.Enter_UserName("xxxxxx@gmail.com");
            // Use a Page Object method to enter password
            Trade_Me_PageObject.Enter_Password("xxxxxx");
            // Use a Page Object method to press log in button
            Trade_Me_PageObject.Tap_LoginButton();
            // explicit wait .. this still needs to be refactored ;)
            WebDriverWait wait = new WebDriverWait(app, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/menuAccount")));
            // Use a Page Object method to click account icon
            Trade_Me_PageObject.Tap_AccountIcon();
            // another explicit wait... this needs to be refactored too
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/buttonLogout")));
            // perform an assert on the account name returned by the Page Object class 
            Assert.AreEqual(Trade_Me_PageObject.Return_AccountName_UnderTest(), "sunjeet81_1");
        }

        [Test()]
        public void TradeMe_verify_logged_out_POM()
        {
            /*AppiumWebElement logout_button = app.FindElementById("nz.co.trademe.trademe:id/buttonLogout");
            logout_button.Tap(1, 1);
            WebDriverWait wait = new WebDriverWait(app, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/buttonDialogGenericConfirm")));
            AppiumWebElement confirm_button = app.FindElementByAccessibilityId("Confirm");
            confirm_button.Tap(1, 1);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("Login")));
            Assert.IsNotNull(app.FindElementByAccessibilityId("Login"));*/
        }

    }
}