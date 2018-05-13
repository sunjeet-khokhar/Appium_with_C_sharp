using NUnit.Framework;
using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using System.Net;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.Threading;

namespace AppiumBasicSetup
{
    [TestFixture()]
    public class BasicTest
    {
        AndroidDriver<AppiumWebElement> driver;
        //AndroidDriver<IWebElement> driver;

        [SetUp()]
        public void SetUp()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            Console.Write("Setting up the test");
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("testobject_api_key", "48702A635B794A6FB8D5B852FE62723A");
            capabilities.SetCapability("platformName","Android");
            capabilities.SetCapability("platformVersion","6.0");
            capabilities.SetCapability("appiumVersion", "1.7.2");
            capabilities.SetCapability("deviceName", "Motorola_Moto_E_2nd_gen_free");
            capabilities.SetCapability("privateDevicesOnly", "false");
            capabilities.SetCapability("testobject_app_id", "1");
            capabilities.SetCapability("phoneOnly", "false");
            capabilities.SetCapability("tabletOnly", "false");
            Uri server = new Uri("https://eu1.appium.testobject.com/wd/hub");
            TimeSpan time_out = TimeSpan.FromMinutes(2);
            driver = new AndroidDriver<AppiumWebElement>(server, capabilities,time_out);
            driver.Manage().Timeouts().ImplicitlyWait(time_out);
        }

        [Test()]
        public void App_should_have_context_Test()
        {
            Assert.IsNotNull(driver.Context);
            driver.GetScreenshot();
        }

        public AppiumWebElement Create_a_NewNote()
        {
            AppiumWebElement new_note = driver.FindElementByAccessibilityId("New note");
            new_note.Tap(1,1);
            AppiumWebElement new_note_screen = driver.FindElementById("android:id/action_bar_title");
            return new_note_screen;
        }

        [Test()]
        public void Verify_Title_of_NewNote_Test()
        {
            AppiumWebElement new_note_screen1 = Create_a_NewNote();
            String new_note_title = new_note_screen1.Text;
            //driver.GetScreenshot();
            Assert.AreEqual(new_note_title,"New note1");
        }

        [Test()]
        public void Verify_Orientation_of_NewNote()
        {
            ScreenOrientation current_orientation = driver.Orientation;
            ScreenOrientation expected_orientation = ScreenOrientation.Landscape;
            //driver.GetScreenshot();
            Assert.AreEqual(expected_orientation,current_orientation);
        }


        [TearDown()]
        public void TearDown()
        {
            driver.Quit();
            Console.Write("Tearing down the test");
        }
    }
}