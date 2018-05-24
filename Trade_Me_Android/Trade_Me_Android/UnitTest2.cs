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

namespace Trade_Me_Android
{
    [TestFixture()]
    public class TradeMe_Android_Login_Test
    {
        private AndroidDriver<AppiumWebElement> app;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            //AppiumServiceBuilder appium_service_builder = new AppiumServiceBuilder()
            // .UsingAnyFreePort();
            //.WithAppiumJS(new System.IO.FileInfo("C:\\Windows\\System32\\node_modules\\appium\\lib\\appium.js"));

            //AppiumLocalService appium_local_service = appium_service_builder.Build();
            //if (!appium_local_service.IsRunning)
            //  appium_local_service.Start();


            Uri server = new Uri("http://localhost:4723/wd/hub");
            
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Pixel_2_API_24");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "7.0");
            capabilities.SetCapability(MobileCapabilityType.App, "D:\\apps\\nz.co.trademe.trademe.apk");
            //app = new AndroidDriver<AppiumWebElement>(appium_local_service, capabilities);
            app = new AndroidDriver<AppiumWebElement>(server,capabilities);

        }

        [SetUp]
        public void SetUp()
        {
           
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            app.CloseApp();
        }

        [Test()]
        public void TradeMe_verify_logged_in()
        {
            AppiumWebElement TradeMe_Login = app.FindElementById("nz.co.trademe.trademe:id/editTextLoginEmail");
            TradeMe_Login.SendKeys("sunjeet81@gmail.com");
            AppiumWebElement TradeMe_Pwd = app.FindElementById("nz.co.trademe.trademe:id/editTextLoginPassword");
            TradeMe_Pwd.SendKeys("yorks64");
            AppiumWebElement Login_Button = app.FindElementById("nz.co.trademe.trademe:id/buttonLogin");
            Login_Button.Tap(1, 1);
            WebDriverWait wait = new WebDriverWait(app, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/menuAccount")));
            AppiumWebElement account_icon = app.FindElementByAccessibilityId("Account");
            account_icon.Tap(1, 1);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("nz.co.trademe.trademe:id/buttonLogout")));
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