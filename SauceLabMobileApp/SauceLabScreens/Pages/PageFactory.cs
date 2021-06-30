using System;
using System.Collections.Generic;
using System.Text;

namespace SauceLabScreens.Pages
{

    // // Initializing Pages objects
    public class PageFactory
    {
        [ThreadStatic]
        public static Login login;
        [ThreadStatic]
        public static Products products;
        [ThreadStatic]
        public static ItemDetails itemDetails;
        [ThreadStatic]
        public static HeaderBar headerBar;
        [ThreadStatic]
        public static YourCart yourCart;
        [ThreadStatic]
        public static CheckoutInformation checkoutInformation;
        [ThreadStatic]
        public static CheckoutOverview checkoutOverview;
        [ThreadStatic]
        public static CheckoutComplete checkoutComplete;


        public static void InitPages()
        {
            login = new Login();
            products = new Products();
            itemDetails = new ItemDetails();
            headerBar = new HeaderBar();
            yourCart = new YourCart();
            checkoutInformation = new CheckoutInformation();
            checkoutOverview = new CheckoutOverview();
            checkoutComplete = new CheckoutComplete();
        }
    }
}
