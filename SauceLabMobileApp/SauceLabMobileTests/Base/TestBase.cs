using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SauceLabFramework;
using SauceLabScreens.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceLabMobileTests.Base
{
    public class TestBase
    {
        static bool testResault;

        [OneTimeSetUp]
        public virtual void BeforeAll()
        {

            FwConfig.SetConfig();

        }

        [SetUp]
        public virtual void BeforeEach()
        {
            switch (testResault)
            {
                case false:
                    Driver.InitDriver(FwConfig.Configuration.DriverTypes[0]);
                    PageFactory.InitPages();
                    break;
                case true:
                    Console.WriteLine("Previous Test is Passed and Driver is running");
                    break;

            }


        }

        [TearDown]
        public virtual void AfterEach()
        {
            //var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            //if (outcome == TestStatus.Passed)
            //{
            //    testResault = true;
            //}
            //else if (outcome == TestStatus.Failed)
            //{
            //    testResault = false;
            //    Driver.Current.Dispose();
            //    Driver.QuitDriver();
            //}
            Driver.Current.Dispose();
            Driver.QuitDriver();
        }

        [OneTimeTearDown]
        public virtual void AfterAll()
        {
            Driver.QuitDriver();
        }

        public static bool CheckLastTestResualt()
        {
            return testResault;
        }
    }
}
