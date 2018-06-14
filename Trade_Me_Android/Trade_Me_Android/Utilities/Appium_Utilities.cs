using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Net;
using System.Threading;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;



namespace Trade_Me_Android.Utilities
{
    class Appium_Utilities 
    {
       public AndroidDriver<AppiumWebElement> Initialize_Appium_Driver(string _platformName,string _deviceName,string _platformVersion,string _appPath,Uri _server)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability(MobileCapabilityType.PlatformName,_platformName);
            capabilities.SetCapability(MobileCapabilityType.DeviceName,_deviceName);
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion,_platformVersion);
            capabilities.SetCapability(MobileCapabilityType.App,_appPath);
            //AndroidDriver<AppiumWebElement> app;
            /*app = new AndroidDriver<AppiumWebElement>(_server, capabilities);
            return app;*/
            return (new AndroidDriver<AppiumWebElement>(_server, capabilities));
        }
    }
}
