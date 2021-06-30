using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SauceLabFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceLabScreens.Pages
{
    public class ItemDetails
    {
        private readonly ItemDetailsMap Map;
        public ItemDetails()
        {
            Map = new ItemDetailsMap();
        }


        // Initializing Elements Actions By Methods
        public string GetItemName(string name)
        {
            return Map.ItemName(name).Text;
        }

        public void ClickOnBackToProducts()
        {
            Map.BacktoProductsBtn.Click();
        }

        public void ClickOnAddToCart()
        {
            Map.AddtoCartBtn.Click();
        }
    }

    // Initializing Elements By Locators
    internal class ItemDetailsMap
    {
        public AppiumWebElement AddtoCartBtn => Driver.Current.FindElementByAccessibilityId("test-ADD TO CART");
        public AppiumWebElement BacktoProductsBtn => Driver.Current.FindElementByAccessibilityId("test-BACK TO PRODUCTS");
        public AppiumWebElement ItemName (string item) => Driver.Current.FindElement(By.XPath($"//android.widget.TextView[@text='Sauce Labs {item}']"));
    }
}
