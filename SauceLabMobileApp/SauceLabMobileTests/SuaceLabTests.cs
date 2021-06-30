using NUnit.Framework;
using SauceLabFramework;
using SauceLabMobileTests.Base;
using SauceLabScreens.Pages;
using System;
using System.Threading;

namespace SauceLabMobileTests
{
    public class Tests : TestBase
    {
        [Test,Order(1)]
        public void Verify_User_Can_Not_Login_Without_UserName()
        {
            Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PageFactory.login.EnterPassword("secret_sauce");
            PageFactory.login.ClickOnLogin();
            Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.That(PageFactory.login.GetUserNameWarningMessage, Is.EqualTo("Username is required"));
        }

        [Test,Order(2)]
        public void Verify_User_Can_Not_Login_Without_Password()
        {
          
            Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PageFactory.login.EnterUserName("standard_user");
            PageFactory.login.ClickOnLogin();
            Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.That(PageFactory.login.GetPasswordWarningMessage, Is.EqualTo("Password is required"));
        }

        [Test,Order(3)]
        public void Verify_User_Able_To_Login_Successfully()
        {

            Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PageFactory.login.EnterUserName("standard_user");
            PageFactory.login.EnterPassword("secret_sauce");
            PageFactory.login.ClickOnLogin();
            Thread.Sleep(2000);
            Assert.That(PageFactory.products.GetScreenTitle(), Is.EqualTo("PRODUCTS"));
      
        }

        [Test, Order(4)]
        public void Verify_User_Able_To_Add_Items_To_The_Cart_And_Do_Successfully_Checkout()
        {
             int itemAddedCount =0;

            // login to the app
            Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PageFactory.login.EnterUserName("standard_user");
            PageFactory.login.EnterPassword("secret_sauce");
            PageFactory.login.ClickOnLogin();
            Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Assert.That(PageFactory.products.GetScreenTitle(), Is.EqualTo("PRODUCTS"));

            // adding products to the cart

            for (int i = 0; i < FwConfig.Configuration.ItemsNames.Length; i++)
            {
                PageFactory.products.ClickOnSelectedItem(FwConfig.Configuration.ItemsNames[i]);
                Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                PageFactory.itemDetails.ClickOnAddToCart();
                PageFactory.itemDetails.ClickOnBackToProducts();
                itemAddedCount = i + 1;
            }

            // assert on quantity for added products

            PageFactory.headerBar.ClickOnCartIcone();
            Assert.That(PageFactory.yourCart.GetItemsQuantity(), Is.EqualTo(itemAddedCount));
            PageFactory.yourCart.ClickOnCheckout();

            // entering user details

            PageFactory.checkoutInformation.EnterFirstName(FwConfig.Configuration.UserDetails[0]);
            PageFactory.checkoutInformation.EnterLastName(FwConfig.Configuration.UserDetails[1]);
            PageFactory.checkoutInformation.EnterPostalCode(FwConfig.Configuration.UserDetails[2]);
            PageFactory.checkoutInformation.ClickOnContinue();

            // last assert on items quantity

            Assert.That(PageFactory.checkoutOverview.GetItemsQuantity(), Is.EqualTo(itemAddedCount));
            PageFactory.checkoutOverview.ClickOnFinish();

            // assert payment done

            Assert.That(PageFactory.checkoutComplete.GetCompleteCheckoutMessage(), Is.EqualTo("THANK YOU FOR YOU ORDER"));

        }

        [Test, Order(5)]
        public void Verify_User_Able_To_Add_And_Delete_Items_To_The_Cart() 
        {
            int itemAddedCount = 0;

            // login to the app
            Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PageFactory.login.EnterUserName("standard_user");
            PageFactory.login.EnterPassword("secret_sauce");
            PageFactory.login.ClickOnLogin();
            Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Assert.That(PageFactory.products.GetScreenTitle(), Is.EqualTo("PRODUCTS"));

            // adding products to the cart
            for (int i = 0; i <  FwConfig.Configuration.ItemsNames.Length; i++)
            {
                
                PageFactory.products.ClickOnSelectedItem(FwConfig.Configuration.ItemsNames[i]);
                Driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                PageFactory.itemDetails.ClickOnAddToCart();
                PageFactory.itemDetails.ClickOnBackToProducts();
                itemAddedCount = i + 1;
            }

            // assert on quantity for added products
            PageFactory.headerBar.ClickOnCartIcone();
            Assert.That(PageFactory.yourCart.GetItemsQuantity(), Is.EqualTo(itemAddedCount));


            // assert on quantity for deleting products
            PageFactory.yourCart.ClickOnRemoveFromCart();
            var updatedItemCount = PageFactory.yourCart.GetItemsQuantity();
            Assert.That(PageFactory.yourCart.GetItemsQuantity(), Is.EqualTo(updatedItemCount));

        }


    }
}