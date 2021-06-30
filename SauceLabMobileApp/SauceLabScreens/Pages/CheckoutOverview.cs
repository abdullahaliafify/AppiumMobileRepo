using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SauceLabFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SauceLabScreens.Pages
{
    public class CheckoutOverview
    {

        private readonly CheckoutOverviewMap Map;
        public CheckoutOverview()
        {
            Map = new CheckoutOverviewMap();
        }


        // Initializing Elements Actions By Methods
        public void ClickOnCancel()
        {
            Map.CancelBtn.Click();
        }
        public void ClickOnFinish()
        {
            Map.FinishBtn.Click();
        }


        public string GetItemName(string name)
        {
            return Map.ItemName(name).Text;
        }

        public int GetItemsQuantity()
        {
            return Map.QuantityItems.Count;
        }

    }


    // Initializing Elements By Locators
    internal class CheckoutOverviewMap
    {

        ByAndroidUIAutomator FinishLocator = new ByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                    + "new UiSelector().text(\"FINISH\"));");

        public AppiumWebElement CancelBtn => Driver.Current.FindElementByAccessibilityId("test-CANCEL");
        public AppiumWebElement FinishBtn => Driver.Current.FindElement(FinishLocator);
        public AppiumWebElement ItemName(string item) => Driver.Current.FindElement(By.XPath($"//android.widget.TextView[@text='Sauce Labs {item}']"));
        public ReadOnlyCollection<AppiumWebElement> QuantityItems => Driver.Current.FindElements(By.XPath("//android.view.ViewGroup[@content-desc='test-Amount']"));
    }
}
