﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();

            OpenRegistrationForm();
            FillRegistrationForm(account);

            SubmitRegistration();

            String url = GetConfirmationURL(account); //Читаем почту
            FillPasswordForm(url, account);
            SubmitPasswordForm();

        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;

            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);

        }

        private string GetConfirmationURL(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void OpenRegistrationForm()
        {
            driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-1.2.17/login_page.php";
        }
    }
}
