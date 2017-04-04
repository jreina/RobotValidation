using RobotValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RobotValidation.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ViewResult Submit(Person person)
        {
            // Redirect if submitted person has a value for HiddenField.
            if (!string.IsNullOrEmpty(person.HiddenField))
            {
                ModelState.AddModelError("YOU_ARE_A_BOT", new Exception("Bad robot! Shoo!"));
                return View("ERROR");
            }
            return View("AWESOME");
        }
    }
}