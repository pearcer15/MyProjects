using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class SurveySqlDAOTests : CapstoneTest
    {
        [TestMethod]
        public void SaveSurvey_Should_Return1Moresurvey()
        {
            SurveySqlDAO dao = new SurveySqlDAO(ConnectionString);
            int startingRows = GetRowCount("survey_result");
            SurveyForm survey = new SurveyForm();
            survey.ParkCode = ParkCode;
            survey.Email = "testing@techelevator.com";
            survey.State = "OH";
            survey.ActivityLevel = "Active";

            dao.SaveSurvey(survey);
            int endingRows = GetRowCount("survey_result");

            Assert.AreEqual(startingRows + 1, endingRows);
        }

        [TestMethod]
        public void GetSurveyResults_ShouldReturn_1_Survey()
        {
            SurveySqlDAO dao = new SurveySqlDAO(ConnectionString);
            IList<SurveyResult> results = dao.GetSurveyResults();
            Assert.AreEqual(1, results.Count);
        }

    }
}
