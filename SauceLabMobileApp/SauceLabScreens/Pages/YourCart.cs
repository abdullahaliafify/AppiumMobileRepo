using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SauceLabFramework;
using System.Collections.ObjectModel;

namespace SauceLabScreens.Pages
{
    public class YourCart
    {
        private readonly YourCarMap Map;
        
        public YourCart()
        {
            Map = new YourCarMap();
        }


        // Initializing Elements Actions By Methods
        public string GetItemName(string name)
        {
            return Map.ItemName(name).Text;
        }
        public void ClickOnRemoveFromCart()
        {
            Map.RemoveFromCartBtn.Click();
        }


        public int GetItemsQuantity()
        {
            return Map.QuantityItems.Count;
        }

        public void ClickOnCheckout()
        {
            Map.CheckoutBtn.Click();
        }

        public void ClickOncontinueShopping()
        {
            Map.ContinueShoppingBtn.Click(); 
        }


    }




    // Initializing Elements By Locators
    internal class YourCarMap
    {
        ByAndroidUIAutomator CheckoutLocator = new ByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                    + "new UiSelector().text(\"CHECKOUT\"));");

        public AppiumWebElement ItemName(string item) => Driver.Current.FindElement(By.XPath($"//android.widget.TextView[@text='Sauce Labs {item}']"));
        //public ReadOnlyCollection<AppiumWebElement> RemoveFromCartBtn => Driver.Current.FindElements(new ByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
        //            + "new UiSelector().text(\"REMOVE\"));"));
        public AppiumWebElement RemoveFromCartBtn => Driver.Current.FindElementByAccessibilityId("test-REMOVE");
        public AppiumWebElement ContinueShoppingBtn => Driver.Current.FindElementByAccessibilityId("test-CONTINUE SHOPPING");
        public ReadOnlyCollection<AppiumWebElement> QuantityItems => Driver.Current.FindElements(new ByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                    + "new UiSelector().text(\"1\"));"));

        public AppiumWebElement CheckoutBtn => Driver.Current.FindElement(CheckoutLocator);
    }
}
