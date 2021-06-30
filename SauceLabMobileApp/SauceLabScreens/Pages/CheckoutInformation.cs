using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SauceLabFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceLabScreens.Pages
{
    public class CheckoutInformation
    {
        private readonly CheckoutInformationMap Map;
        public CheckoutInformation()
        {
            Map = new CheckoutInformationMap();
        }


        // Initializing Elements Actions By Methods
        public void EnterFirstName(string fname)
        {
            Map.InputFirstName.SendKeys(fname);
        }

        public void EnterLastName(string lname)
        {
            Map.InputLastName.SendKeys(lname);
        }

        public void EnterPostalCode(string code)
        {
            Map.InputPostalCode.SendKeys(code);
        }

        public void ClickOnCancel()
        {
            Map.CancelBtn.Click();
        }

        public void ClickOnContinue()
        {
            Map.ContinueBtn.Click();
        }

        public string GetPageTitle()
        {
            return Map.PageTitle.Text;
        }

    }

    // Initializing Elements By Locators
    internal class CheckoutInformationMap
    {
        public AppiumWebElement PageTitle => Driver.Current.FindElement(By.XPath("//android.widget.TextView[@text='CHECKOUT: INFORMATION')"));
        public AppiumWebElement InputFirstName => Driver.Current.FindElementByAccessibilityId("test-First Name");
        public AppiumWebElement InputLastName => Driver.Current.FindElementByAccessibilityId("test-Last Name");
        public AppiumWebElement InputPostalCode => Driver.Current.FindElementByAccessibilityId("test-Zip/Postal Code");
        public AppiumWebElement CancelBtn => Driver.Current.FindElementByAccessibilityId("test-CANCEL");
        public AppiumWebElement ContinueBtn => Driver.Current.FindElementByAccessibilityId("test-CONTINUE");


    }
}
