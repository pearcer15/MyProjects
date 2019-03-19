using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.DAL;
using WebApplication.Web.Models;
using WebApplication.Web.Providers.Auth;

namespace WebApplication.Web.Controllers
{
    public class UserController : Controller
    {
        private IParkDAO parkDAO;
        private ISurveyDAO surveyDAO;
        private readonly IAuthProvider authProvider;

        public UserController(IParkDAO parkDAO, ISurveyDAO surveyDAO, IAuthProvider authProvider)
        {
            this.parkDAO = parkDAO;
            this.surveyDAO = surveyDAO;
            this.authProvider = authProvider;

        }

        /// <summary>
        /// A view for user information
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var user = authProvider.GetCurrentUser();
            return View(user);
        }

        /// <summary>
        /// A view for the survey. Registered users only.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthorizationFilter]
        public IActionResult Survey()
        {
            SurveyForm survey = new SurveyForm();
            survey.Parks = parkDAO.GetAllParks();
            return View(survey);
        }

        /// <summary>
        /// The method to save survey entries and redirect to results
        /// </summary>
        /// <param name="survey"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Survey(SurveyForm survey)
        {
            bool wasSaved = surveyDAO.SaveSurvey(survey);

            if (wasSaved)
            {
                TempData["SurveySaved"] = "Thank you for participating in our survey!";
            }

            return RedirectToAction("Results");
        }

        /// <summary>
        /// The results of the survey
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Results()
        {
            IList<SurveyResult> results = surveyDAO.GetSurveyResults();

            return View(results);
        }

        /// <summary>
        /// A view to register
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// The method to accept registration forms
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            // Check to see if the data is valid
            if (ModelState.IsValid)
            {
                // Register the user as a new user in the system.
                // Give the user "User" role by default.
                authProvider.Register(model.Email, model.Password, "User");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Not valid, so send the user back to the register view
                return View(model);
            }
        }

        /// <summary>
        /// A view to log in
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// The mehtod to accept login forms
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool validCredentials = authProvider.SignIn(model.Email, model.Password);

                if (!validCredentials)
                {
                    // Take the user to the login page and show an error message
                    // We need to add a customer error, since our model doesn't validate credentials
                    ModelState.AddModelError("AuthenticationFailed", "");
                    return View(model);
                }

                if (!string.IsNullOrEmpty(TempData["redirect"].ToString()))
                {
                    return RedirectToAction(TempData["redirect"].ToString());
                }
                else
                {
                return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }
        }

        /// <summary>
        /// A method for logging off
        /// </summary>
        /// <returns></returns>
        public IActionResult Logoff()
        {
            authProvider.LogOff();

            return RedirectToAction("Index", "Home");
        }

    }
}