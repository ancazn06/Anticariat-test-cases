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
    public class Inregistrare
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Test_Inregistrare()
        {
            // var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Accesează pagina principală
            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            // Caută și dă click pe butonul "Contul meu"
            IWebElement contulMeuButton = driver.FindElement(By.CssSelector(".icon-user"));
            contulMeuButton.Click();

            // Caută și dă click pe opțiunea "Inregistreaza-te"
            IWebElement registerButton = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/autentificare?create_account=1']"));
            registerButton.Click();

            // Completează câmpurile cu prenume, nume, email și parolă
            IWebElement numeInput = driver.FindElement(By.CssSelector("input.form-control[name='firstname']"));
            numeInput.SendKeys("Ancuta-Nicoleta");

            IWebElement numeFamilieInput = driver.FindElement(By.CssSelector("input.form-control[name='lastname']"));
            numeFamilieInput.SendKeys("Zamfiroiu");

            IWebElement emailInput = driver.FindElement(By.CssSelector("input.form-control[name='email']"));
            emailInput.SendKeys("anca567@gmail.com");

            IWebElement passwordInput = driver.FindElement(By.CssSelector("input.form-control[name='password']"));
            passwordInput.SendKeys("bbbbbbbb");

            //Bifarea checkbox-ului pentru acceptarea termenilor si conditiilor
            IWebElement checkbox = driver.FindElement(By.CssSelector("input[name='psgdpr'][type='checkbox']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkbox);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);


            // Dă clic pe butonul "Salvați"
            IWebElement saveButton = driver.FindElement(By.CssSelector("footer.form-footer button.btn.btn-outline-primary-2[data-link-action='save-customer']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", saveButton);
            saveButton.Click();

            // Așteaptă până la afișarea paginii de autentificare completă
            Thread.Sleep(5000);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
    [TestClass]
    public class Cautare
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Test_Cautare()
        {
            // var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Accesează pagina principală
            driver.Navigate().GoToUrl("https://anticariat-odin.ro/");

            // Caută și dă click pe butonul "Contul meu"
            IWebElement contulMeuButton = driver.FindElement(By.CssSelector(".icon-user"));
            contulMeuButton.Click();

            // Caută și dă click pe opțiunea "Autentificare"
            IWebElement registerButton = driver.FindElement(By.CssSelector("a.color-dark[href='https://anticariat-odin.ro/contul-meu']"));
            registerButton.Click();

            // Completeaza campul cu emailul corespunzator contului creat
            IWebElement emailInput = driver.FindElement(By.CssSelector("input[name='email']"));
            emailInput.SendKeys("ancuta.zamfiroiu06@gmail.com");

            // Completeaza campul cu parola corespunzatoare contului creat 
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input[name='password']"));
            passwordInput.SendKeys("bbbbbbbb");

            // Autentificare
            IWebElement loginButton = driver.FindElement(By.CssSelector("button[data-link-action='sign-in']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);
            loginButton.Click();

            // Găsirea elementului pentru bara de căutare și introducerea textului "Ion Creangă"
            IWebElement searchInput = driver.FindElement(By.CssSelector("input[name='search_query']"));
            searchInput.SendKeys("Ion Creanga");

            // Apăsarea tastei Enter pentru a iniția căutarea
            searchInput.SendKeys(Keys.Enter);

            // Așteaptă până la afișarea paginii de autentificare completă
            Thread.Sleep(5000);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
