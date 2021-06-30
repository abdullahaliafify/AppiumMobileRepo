using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SauceLabFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceLabScreens.Pages
{
    public class CheckoutComplete
    {
        private readonly CheckoutCompleteMap Map;
        public CheckoutComplete()
        {
            Map = new CheckoutCompleteMap();
        }


        // Initializing Elements Actions By Methods
        public string GetCompleteCheckoutMessage()
        {
            return Map.CompleteMessage.Text;
        }

        public void ClickOnBackToHome()
        {
            Map.BackToHomeBtn.Click();
        }

    }


    // Initializing Elements By Locators
    internal class CheckoutCompleteMap
    {
        public AppiumWebElement CompleteMessage => Driver.Current.FindElement(By.XPath("//android.widget.TextView[@text='THANK YOU FOR YOU ORDER']"));
        public AppiumWebElement BackToHomeBtn => Driver.Current.FindElementByAccessibilityId("test - BACK HOME");
    }
}


