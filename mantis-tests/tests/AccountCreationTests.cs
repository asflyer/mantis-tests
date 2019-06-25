using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void SetupConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(TestContext.CurrentContext.TestDirectory  + "/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);

            }
            
        }

        /*
        Перед тестом запустить Xampp -> FileZilla (проверить, что создана группа (справа)
        и что SharedFolders смотрит на D:\programs\xampp\htdocs\mantisbt-1.2.17
        Запустить D:\programs\james\james-2.3.1\bin\run.bat
        */
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser3",
                Password = "password",
                Email = "testuser3@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
            
         }

        [TearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
        //D:\programs\xampp\htdocs\mantisbt-1.2.17 - тут лежит config_inc.php

    }
}
