using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace V6Practice
{
  
    internal class Appointment
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);

        }
        readonly By frame_CWContent = By.Id("CWContentIFrame");
        readonly By frame_CWNewPerson = By.Id("iframe_CWNewPerson");
        readonly By frame_Lookup = By.Id("iframe_CWLookupForm");
        readonly By searchQueryForLookup = By.Id("CWQuickSearch");

        readonly By quickSearchButton = By.Id("CWQuickSearchButton");

        readonly By CWFrame_04 = By.Id("CWFrame_0417c61a-caff-e811-9c08-1866da1e4209");
        readonly By frame_CaseDropDown = By.XPath("//div[@class='ui-dialog-content ui-widget-content']/child::iframe");
        readonly By monthDropDown = By.XPath("//select[@data-handler='selectMonth']");
        readonly By yearDropDown = By.XPath("//select[@data-handler='selectYear']");
        readonly By workplaceB = By.XPath("//a[@title='Workplace']");
        readonly By peopleB=By.XPath("//a[@title='People']");
        readonly By personRecord = By.XPath("//td[text()='Viladmar']");
        readonly By menu = By.XPath("//a[@title='Menu']");
       readonly By iframe_CWDialogPersonId = By.XPath("//iframe[contains(@id,'iframe_CWDialog_')][contains(@src,'type=person&id')]");
        readonly By appointmentB = By.Id("CWNavItem_Appointment");
        readonly By iframe_Appointment = By.Id("CWNavItem_AppointmentFrame");
        readonly By appointmentNewRecordButton = By.Id("TI_NewRecordButton");

        readonly By subject_Field = By.Id("CWField_subject");


       readonly By iframe_CWDialogAppointment = By.XPath("//iframe[contains(@id,'iframe_CWDialog_')][contains(@src,'type=appointment&pid')]");
        readonly By required_LookUp = By.Id("CWLookupBtn_requiredattendees");
        readonly By addRecord = By.Id("CWAddSelectedButton"); 
        readonly By okButtonLookUp = By.Id("CWOkButton");
        readonly By optional_LookUp = By.Id("CWLookupBtn_optionalattendees");
        readonly By iframe_meetingNotes=By.XPath("//iframe[@title='Rich Text Editor, CWField_notes']");
        readonly By meetingNotesField = By.XPath("(//html[@dir='ltr'])[1]");
        readonly By appointmentType = By.Id("CWLookupBtn_appointmenttypeid");
        readonly By location = By.Id("CWField_location");
        readonly By priority=By.Id("CWLookupBtn_activitypriorityid");
        readonly By catogory_LookUp = By.Id("CWLookupBtn_activitycategoryid");
        readonly By sub_catogory_LookUp = By.Id("CWLookupBtn_activitysubcategoryid");
        readonly By reson_LookUp = By.Id("CWLookupBtn_activityreasonid");
        readonly By outcome_LookUp = By.Id("CWLookupBtn_activityoutcomeid");
        readonly By save_Icon = By.Id("TI_SaveButton");

        string subject = "parker";
        string nameForRequired = "8988 8988";
        string nameForOptional = "Aaron Kirk";
        string meetingNotes = "tfftfhggj";
        string appointmentTypeName = "Meeting";
        string location_text = "london";
        string priority_Text = "high";
        string category_Text = "Advice";
        string sub_category_Text = "home Support";
        string reason_Text= "admitted to hospital";
        string outcome_Text = "Completed";

        public static void TextBoxFilling(IWebElement element, string name)
        {
            element.SendKeys(name);
        }  
       
      
        public static void Click_On_Lookup(IWebElement element)
        {
            element.Click();
            Thread.Sleep(4000);

        }

        public static void TypeSearchQueryForLookup(IWebElement element, string query)
        {
            element.SendKeys(query);
        }
        public static void TapSearchButtonForLookup(IWebElement element)
        {
            element.Click();
        }
        public static void SelectResultElement(IWebElement element)
        {
            Thread.Sleep(3000);
            element.Click();

        }
        public  void WaitForAppointmentPageToGetLoad()
        {
            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(driver.FindElement(frame_CWContent));

            driver.SwitchTo().Frame(driver.FindElement(iframe_CWDialogAppointment));
        }

        public static void DropDownHandlingMonthDatePicker(IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }
        public static void DropDownHandlingYearDatePicker(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText("2021");
        }

        public static void DatePicker(IWebElement element, IWebElement element1)
        {
            element.Click();
            Thread.Sleep(2000);

        }
        public static void Clicking(IWebElement element)
        {
            element.Click();
        }


       
        public void AppointmentCreation()
        {
            //Log into the application
            driver.Url = "https://phoenixqa.careworks.ie/pages/default.aspx";
            driver.Navigate();
            driver.FindElement(By.Id("UserNameTextBox")).SendKeys("finuser_05");
            driver.FindElement(By.Id("LoginPasswordTextBox")).SendKeys("Test@123");
            driver.FindElement(By.Id("CWAdvanceSectionLink")).Click();
            Thread.Sleep(4000);
            //drop down handling has been done to select Environment
            Tests.DropDownHandlingByText(driver.FindElement(By.Id("CWEnvironmentList")), "Health and Local Authority");
            driver.FindElement(By.Id("CWLoginButton")).Click();
            Clicking(driver.FindElement(workplaceB));
            Clicking(driver.FindElement(peopleB));
            driver.SwitchTo().Frame(driver.FindElement(frame_CWContent));
            Clicking(driver.FindElement(personRecord));
            driver.SwitchTo().Frame(driver.FindElement(iframe_CWDialogPersonId));
            Clicking(driver.FindElement(menu));
            Clicking(driver.FindElement(appointmentB));
            driver.SwitchTo().Frame(driver.FindElement(iframe_Appointment));
            Clicking(driver.FindElement(appointmentNewRecordButton));
            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(driver.FindElement(frame_CWContent));

            driver.SwitchTo().Frame(driver.FindElement(iframe_CWDialogAppointment));

            TextBoxFilling(driver.FindElement(subject_Field),subject);

            Tests.Click_On_Lookup(driver.FindElement(required_LookUp));
            driver.SwitchTo().Frame(driver.FindElement(frame_Lookup));
            Thread.Sleep(3000);
            Tests.TypeSearchQueryForLookup(driver.FindElement(searchQueryForLookup),nameForRequired );
            Tests.TapSearchButtonForLookup(driver.FindElement(quickSearchButton));
            Thread.Sleep(2000);
            Tests.SelectResultElement(driver.FindElement(By.Id("cee7c3eb-ea91-eb11-a323-005056926fe4_Primary")));
            Clicking(driver.FindElement(addRecord));
            Clicking(driver.FindElement(okButtonLookUp));
           WaitForAppointmentPageToGetLoad();


            Tests.Click_On_Lookup(driver.FindElement(optional_LookUp));
            driver.SwitchTo().Frame(driver.FindElement(frame_Lookup));
            Thread.Sleep(3000);
            Tests.TypeSearchQueryForLookup(driver.FindElement(searchQueryForLookup),nameForOptional);
            Tests.TapSearchButtonForLookup(driver.FindElement(quickSearchButton));
            Thread.Sleep(2000);
            Tests.SelectResultElement(driver.FindElement(By.Id("30ff227c-48c7-ea11-a2cd-005056926fe4_Primary")));
            Clicking(driver.FindElement(addRecord));
            Clicking(driver.FindElement(okButtonLookUp));
            WaitForAppointmentPageToGetLoad();
            driver.SwitchTo().Frame(driver.FindElement(iframe_meetingNotes));
            TextBoxFilling(driver.FindElement(meetingNotesField),meetingNotes);
            driver.SwitchTo().DefaultContent();


            ///Details
            driver.SwitchTo().Frame(driver.FindElement(frame_CWContent));

            driver.SwitchTo().Frame(driver.FindElement(iframe_CWDialogAppointment));
            Tests.Click_On_Lookup(driver.FindElement(appointmentType));
            driver.SwitchTo().Frame(driver.FindElement(frame_Lookup));
            Thread.Sleep(3000);
            Tests.TypeSearchQueryForLookup(driver.FindElement(searchQueryForLookup),appointmentTypeName);
            Tests.TapSearchButtonForLookup(driver.FindElement(quickSearchButton));
            Thread.Sleep(2000);
            Tests.SelectResultElement(driver.FindElement(By.Id("8cc6d493-a4cc-e811-80dc-0050560502cc_Primary")));

            WaitForAppointmentPageToGetLoad();

            TextBoxFilling(driver.FindElement(location), location_text);


            Tests.Click_On_Lookup(driver.FindElement(priority));
            driver.SwitchTo().Frame(driver.FindElement(frame_Lookup));
            Thread.Sleep(3000);
            Tests.TypeSearchQueryForLookup(driver.FindElement(searchQueryForLookup),priority_Text );
            Tests.TapSearchButtonForLookup(driver.FindElement(quickSearchButton));
            Thread.Sleep(2000);
            Tests.SelectResultElement(driver.FindElement(By.Id("1e164c51-9d45-e911-a2c5-005056926fe4_Primary")));

            WaitForAppointmentPageToGetLoad();
            //Category look up
            Tests.Click_On_Lookup(driver.FindElement(catogory_LookUp));
            driver.SwitchTo().Frame(driver.FindElement(frame_Lookup));
            Thread.Sleep(3000);
            Tests.TypeSearchQueryForLookup(driver.FindElement(searchQueryForLookup), category_Text);
            Tests.TapSearchButtonForLookup(driver.FindElement(quickSearchButton));
            Thread.Sleep(2000);
            Tests.SelectResultElement(driver.FindElement(By.Id("79a81b8a-9d45-e911-a2c5-005056926fe4_Primary")));
            WaitForAppointmentPageToGetLoad();

            //Sub Category look up
            Tests.Click_On_Lookup(driver.FindElement(sub_catogory_LookUp));
            driver.SwitchTo().Frame(driver.FindElement(frame_Lookup));
            Thread.Sleep(3000);
            Tests.TypeSearchQueryForLookup(driver.FindElement(searchQueryForLookup), sub_category_Text);
            Tests.TapSearchButtonForLookup(driver.FindElement(quickSearchButton));
            Thread.Sleep(2000);
            Tests.SelectResultElement(driver.FindElement(By.Id("1515dfdd-9d45-e911-a2c5-005056926fe4_Primary")));
            WaitForAppointmentPageToGetLoad();

            //Reason


            Tests.Click_On_Lookup(driver.FindElement(reson_LookUp));
            driver.SwitchTo().Frame(driver.FindElement(frame_Lookup));
            Thread.Sleep(3000);
            Tests.TypeSearchQueryForLookup(driver.FindElement(searchQueryForLookup), reason_Text);
            Tests.TapSearchButtonForLookup(driver.FindElement(quickSearchButton));
            Thread.Sleep(2000);
            Tests.SelectResultElement(driver.FindElement(By.Id("da210211-8a31-ec11-a32d-f90a4322a942_Primary")));
            WaitForAppointmentPageToGetLoad();

            //Outcome

            Tests.Click_On_Lookup(driver.FindElement(outcome_LookUp));
            driver.SwitchTo().Frame(driver.FindElement(frame_Lookup));
            Thread.Sleep(3000);
            Tests.TypeSearchQueryForLookup(driver.FindElement(searchQueryForLookup), outcome_Text);
            Tests.TapSearchButtonForLookup(driver.FindElement(quickSearchButton));
            Thread.Sleep(2000);
            Tests.SelectResultElement(driver.FindElement(By.Id("4c2bec1c-9e45-e911-a2c5-005056926fe4_Primary")));
            WaitForAppointmentPageToGetLoad();


            Clicking(driver.FindElement(save_Icon));
        }
    }
}
