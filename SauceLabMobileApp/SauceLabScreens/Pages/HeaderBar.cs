using OpenQA.Selenium.Appium;
using SauceLabFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceLabScreens.Pages
{
    public class HeaderBar
    {
        private readonly HeaderBarMap Map;
        public HeaderBar()
        {
            Map = new HeaderBarMap();
        }


        // Initializing Elements Actions By Methods
        public void ClickOnCartIcone()
        {
            Map.ShoppingCartIocn.Click();

        }

        public void ClickOnMenuIcone()
        {
            Map.MenuIocn.Click();

        }
    }


    // Initializing Elements By Locators
    internal class HeaderBarMap
    {
        public AppiumWebElement ShoppingCartIocn => Driver.Current.FindElementByAccessibilityId("test-Cart");
        public AppiumWebElement MenuIocn => Driver.Current.FindElementByAccessibilityId("test-Cart");
    }
}
