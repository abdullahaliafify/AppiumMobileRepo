using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using SauceLabFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SauceLabScreens.Pages
{
    public class Products
    {
        private readonly ProductsMap Map;
        public Products()
        {
            Map = new ProductsMap();
        }


        // Initializing Elements Actions By Methods
        public void ClickOnSelectedItem(string itemName)
        {
            Map.SelectedItem(itemName).Click();
        }

        public string GetScreenTitle() 
        {
            return Map.ProductsTitle.Text;
        }

        
    }


    // Initializing Elements By Locators
    internal class ProductsMap
    {
        public AppiumWebElement SelectedItem(string item) => Driver.Current.FindElement(By.XPath($"//android.widget.TextView[@text='Sauce Labs {item}']"));
        public AppiumWebElement ProductsTitle => Driver.Current.FindElement(By.XPath("//android.widget.TextView[@text='PRODUCTS']"));


    }
}
