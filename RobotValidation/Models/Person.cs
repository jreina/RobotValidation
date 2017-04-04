using System.ComponentModel.DataAnnotations;

namespace RobotValidation.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// This field is not shown on the UI.
        /// It is used in the controller to indicate that the site
        /// is likely experiencing a submission from a script.
        /// </summary>
        public string HiddenField { get; set; }
    }
}