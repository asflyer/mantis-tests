using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class MantisProjectTests : TestBase

    {

        
        /*
        Перед тестом запустить Xampp -> FileZilla (проверить, что создана группа (справа)
        и что SharedFolders смотрит на D:\programs\xampp\htdocs\mantisbt-1.2.17
        Запустить D:\programs\james\james-2.3.1\bin\run.bat
        */
        [SetUp] //Тут нужно выполнить логин как Администратор

        public void LoginAsAdmin()
        {
            AccountData admin = new AccountData
            {
                Name = "administrator",
                Password = "root"
            };
            app.Registration.OpenMainPage(); //Открыли форму
            app.Registration.FillAuthForm(admin); //Заполнили форму аутентификации
            app.Registration.SubmitOneButtonForm();//Тыкнули кнопку Login

        }



        [Test]
        public void MantisProjectAdding()
        {
            ProjectData project = new ProjectData
            {
                Name = "31",
                Description = "33"
            };

            app.Project.AddMantisProject(project);
            
            //app.Project.ChechProjectCreation();//Проверили, что такой создался


        }



        [TearDown] //Тут нужно делать logout

        public void Loguot()
        {
            app.Registration.InitLogOut();
        }


    }
}
