using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace Proiect_Centric
{
    [TestClass]
    public class AddToCart
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Cart()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            IWebElement account_button = driver.FindElement(By.CssSelector(".icon-user"));
            account_button.Click();

            IWebElement register_button = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/contul-meu']"));
            register_button.Click();

            IWebElement email_field = driver.FindElement(By.CssSelector("input[name='email']"));
            email_field.SendKeys("blanarur.rb@gmail.com");

            IWebElement password_field = driver.FindElement(By.CssSelector("input[name='password']"));
            password_field.SendKeys("bbb97bbb");

            IWebElement login_button = driver.FindElement(By.CssSelector("button[data-link-action='sign-in']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", login_button);
            login_button.Click();

            By logoLinkLocator = By.CssSelector("a[href='https://anticariat-odin.ro/']");
            IWebElement logoLink = driver.FindElement(logoLinkLocator);
            logoLink.Click();

            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 500);");

            IWebElement bookLink = driver.FindElement(By.CssSelector("h3.product-title a.product-link"));
            bookLink.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement addToCartButton = driver.FindElement(By.CssSelector("button.btn-default.add-to-cart.product-btn.cart-button[data-button-action='add-to-cart']"));
            addToCartButton.Click();

            IWebElement finalizeazaComandaButton = driver.FindElement(By.CssSelector("a.btn.btn-primary.customBtnTop"));
            finalizeazaComandaButton.Click();

            Thread.Sleep(5000);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }

    [TestClass]
    public class Newsletter
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void News()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            IWebElement account_button = driver.FindElement(By.CssSelector(".icon-user"));
            account_button.Click();

            IWebElement register_button = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/contul-meu']"));
            register_button.Click();

            IWebElement email_field = driver.FindElement(By.CssSelector("input[name='email']"));
            email_field.SendKeys("blanarur.rb@gmail.com");

            IWebElement password_field = driver.FindElement(By.CssSelector("input[name='password']"));
            password_field.SendKeys("bbb97bbb");

            IWebElement login_button = driver.FindElement(By.CssSelector("button[data-link-action='sign-in']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", login_button);
            login_button.Click();

            By link = By.CssSelector("a[href='https://anticariat-odin.ro/']");
            IWebElement home = driver.FindElement(link);
            home.Click();

            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            IWebElement emailInput = driver.FindElement(By.CssSelector(".input-group.newsletter-input-group input[name='email']"));
            emailInput.SendKeys("blanarur.rb@gmail.com");

            IWebElement checkbox = driver.FindElement(By.CssSelector("input#psgdpr_consent_checkbox_21[name='psgdpr_consent_checkbox'][type='checkbox']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);

            Thread.Sleep(1000);
            By news_button = By.XPath("//button[contains(., 'Abonează-te')]");
            IWebElement button = driver.FindElement(news_button);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", button);
            button.Click();

            Thread.Sleep(5000);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
