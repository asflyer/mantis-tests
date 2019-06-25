using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using System.IO;
using System.Threading;
using NUnit.Framework;


namespace mantis_tests
{
    public class ProjectHelper : HelperBase //Чтобы не дублировать OpenMainPage
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }
        //
        

        public void AddMantisProject(ProjectData project)
        {
            OpenManagePage();//Открываем страницу управления
            OpenManageProgectPage(); //Открыли страницу проектов
            InitProjectCreation();//тыкнули CreateNewProject
            FillNewProjectForm(project);//Заполнили форму проекта
            manager.Registration.SubmitOneButtonForm();//Тыкнули AddProject
        }

        public void FillNewProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }

        public void InitProjectCreation()
        {
            driver.FindElement(By.XPath("/html/body/table[3]/tbody/tr[1]/td/form/input[2]")).Click(); //Клик по кнопке Manage Projects
        }

        public void OpenManageProgectPage()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/p/span[2]/a")).Click(); //Клик по кнопке Manage Projects
        }


        public void OpenManagePage()
        {
            driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr/td[1]/a[7]")).Click(); //Клик по кнопке Manage

        }
        
        /*
        public void ChechProjectCreation()
        {
            throw new NotImplementedException();
        }
        */

    }
}
