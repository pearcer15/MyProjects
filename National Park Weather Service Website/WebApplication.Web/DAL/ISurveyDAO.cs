using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface ISurveyDAO
    {
        /// <summary>
        /// A method to save survey entries
        /// </summary>
        /// <param name="survey"></param>
        /// <returns></returns>
        bool SaveSurvey(SurveyForm survey);

        /// <summary>
        /// A mehtod to retrieve survey results
        /// </summary>
        /// <returns></returns>
        IList<SurveyResult> GetSurveyResults();
    }
}
