﻿using System;
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
            using (Stream localFile = File.Open("C:/Users/Александр/source/repos/mantis-tests/mantis-tests/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);

            }
            
        }

        //System.IO.FileNotFoundException: "Файл 'E:\config_inc.php' не найден."

        //C:/Users/Александр/source/repos/mantis-tests/mantis-tests

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

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
