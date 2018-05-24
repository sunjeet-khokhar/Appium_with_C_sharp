using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using System.Net;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;

namespace AppiumBasicSetup
{
    [TestFixture()]
    public class BasicTest
    {
        private AndroidDriver<AppiumWebElement> app;
        //AndroidDriver<IWebElement> driver;

        [Test()]
        public void SetUp_Tradme_App()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            Console.Write("Setting up the test"); 
            Uri server = new Uri("http://localhost:4723/wd/hub");
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Pixel_2_API_24");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "7.0");
            capabilities.SetCapability(MobileCapabilityType.App, "D:\\apps\\nz.co.trademe.trademe.apk");
            app = new AndroidDriver<AppiumWebElement>(server, capabilities);

            
        }


        [Test()]
        public void TradeMe_verify_logged_account()
        {
            AppiumWebElement TradeMe_Login = app.FindElementById("nz.co.trademe.trademe:id/editTextLoginEmail");
            Assert.IsNotNull(TradeMe_Login);
            TradeMe_Login.SendKeys("sunjeet81@gmail.com");
            AppiumWebElement TradeMe_Pwd = app.FindElementById("nz.co.trademe.trademe:id/editTextLoginPassword");
            TradeMe_Pwd.SendKeys("yorks64");
            AppiumWebElement Login_Button = app.FindElementById("nz.co.trademe.trademe:id/buttonLogin");
            Login_Button.Tap(1, 1);
            WebDriverWait wait = new WebDriverWait(app, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/menuAccount")));
            AppiumWebElement account_icon = app.FindElementByAccessibilityId("Account");
            account_icon.Tap(1, 1);
            WebDriverWait wait1 = new WebDriverWait(app, TimeSpan.FromSeconds(30));
            wait1.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/buttonLogout")));
            AppiumWebElement account_name = app.FindElementById("nz.co.trademe.trademe:id/textViewAboutMemberUsername");
            Assert.AreEqual(account_name.Text, "sunjeet81");
            AppiumWebElement logout_button = app.FindElementById("nz.co.trademe.trademe:id/buttonLogout");
            logout_button.Tap(1, 1);
            WebDriverWait wait2 = new WebDriverWait(app, TimeSpan.FromSeconds(30));
            wait2.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/buttonDialogGenericConfirm")));
            AppiumWebElement confirm_button = app.FindElementByAccessibilityId("Confirm");
            confirm_button.Tap(1, 1);
            Assert.IsNotNull(app.FindElementByAccessibilityId("Login"));

        }


        [Test()]
        public void TradeMe_perform_logout()
        {
            
            
            TearDown();

        }

        //[TearDown()]
        public void TearDown()
        {
            
            app.Quit();
            Console.Write("Tearing down the test");
        }
    }
}
