using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;

namespace SauceLabFramework
{
    public class DriverFactory
    {
        private static AppiumDriver<AppiumWebElement> _MobileDriver;
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/wd/hub";
        public static AppiumDriver<AppiumWebElement> Build(string browserName)
        {

            switch (browserName)
            {

                case "Android":
                    var appiumOptions = new AppiumOptions();

                    // Appium capabilities
                    appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                    appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "afcfe42c");
                    appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9");
                    appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
                    appiumOptions.AddAdditionalCapability("skipUnlock", true);

                    // Install and start an app on Android
                    appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.swaglabsmobileapp");
                    appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "com.swaglabsmobileapp.MainActivity");

                    // Use remote Appium driver
                    // initialize Android remote driver
                    _MobileDriver = new AndroidDriver<AppiumWebElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);

                    return _MobileDriver;


                default:
                    throw new System.ArgumentException($"{browserName} not supported"); ;
            }

        }
    }
}
