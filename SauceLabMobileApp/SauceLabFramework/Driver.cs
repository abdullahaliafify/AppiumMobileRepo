using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;


namespace SauceLabFramework
{
    public static class Driver
    {
        [ThreadStatic]
        private static AppiumDriver<AppiumWebElement> _driver;
        public static AppiumDriver<AppiumWebElement> Current => _driver ?? throw new NullReferenceException("_driver is null");

        //Initializing Driver
        public static void InitDriver(string driverType)
        {
            _driver = DriverFactory.Build(driverType);

        }

      
        // Close app and quit the driver
        public static void QuitDriver()
        {
            
            Current.Dispose();
            Current.Quit();
        }
    }
}
