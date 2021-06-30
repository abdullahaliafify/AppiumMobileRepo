using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;
using SauceLabFramework;
using System;

namespace SauceLabScreens.Pages
{
    public class Login
    {
        private readonly LoginMap Map;
        public Login()
        {
            Map = new LoginMap();
            
        }

        // Initializing Elements Actions By Methods
        public void EnterUserName(string userName)
        {
           
         Map.InputUserName.SendKeys(userName);
        }
        public void EnterPassword(string password)
        {
            Map.InputPassword.SendKeys(password);
        }
        public void ClickOnLogin()
        {
            Map.LoginBtn.Click();
        }

        public void ClearSpecifiedField(string fieldName) {

            fieldName = fieldName.ToLower();
            if (fieldName == "username")
            {
                Map.InputUserName.Clear();
            }
            else if(fieldName == "password")
            {
                Map.InputPassword.Clear();
            }
            else
                {
                throw new Exception("Specified Field Name is wrong");
            }
  
        }

        public string GetUserNameWarningMessage() {
            return Map.UserNameWarningMessage.Text;
        }
        public string GetPasswordWarningMessage()
        {
            return Map.PasswordWarningMessage.Text;
        }
    }


    // Initializing Elements By Locators
    internal class LoginMap
    {
        public AppiumWebElement InputUserName => Driver.Current.FindElement(By.XPath("//android.widget.EditText[@text='Username']"));
        public AppiumWebElement InputPassword => Driver.Current.FindElement(By.XPath("//android.widget.EditText[@text='Password']"));
        public AppiumWebElement LoginBtn => Driver.Current.FindElement(By.XPath("//android.widget.TextView[@text='LOGIN']"));
        public AppiumWebElement UserNameWarningMessage => Driver.Current.FindElement(By.XPath("//android.widget.TextView[@text='Username is required']"));
        public AppiumWebElement PasswordWarningMessage => Driver.Current.FindElement(By.XPath("//android.widget.TextView[@text='Password is required']"));
    }
}
