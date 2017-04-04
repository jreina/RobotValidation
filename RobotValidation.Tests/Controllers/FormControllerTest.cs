using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotValidation.Controllers;
using RobotValidation.Models;
using System.Web.Mvc;

namespace RobotValidation.Tests.Controllers
{
    [TestClass]
    public class FormControllerTest
    {
        private FormController _controller;
        private Person _scriptlikeInput;
        private Person _humanLikeInput;

        [TestInitialize] public void Initialize()
        {
            _controller = new FormController();
            _scriptlikeInput = new Person
            {
                FirstName = "Isaac",
                LastName = "Newton",
                HiddenField = "DATA_SUBMITTED_BY_SCRIPT"
            };
            _humanLikeInput = new Person
            {
                FirstName = "Isaac",
                LastName = "Newton"
            };
        }

        // Robot (bad) input.
        [TestMethod] public void should_return_error_view()
        {
            var actual = _controller.Submit(_scriptlikeInput);
        
            Assert.AreEqual("ERROR", actual.ViewName);
        }

        [TestMethod] public void should_have_invalid_model_state()
        {
            var actual = _controller.Submit(_scriptlikeInput);

            Assert.IsFalse(_controller.ModelState.IsValid);
        }

        [TestMethod] public void should_have_invalid_specific_model_error()
        {
            var actual = _controller.Submit(_scriptlikeInput);

            Assert.IsTrue(_controller.ModelState.ContainsKey("YOU_ARE_A_BOT"));
        }

        // Human (good) input.
        [TestMethod] public void should_return_awesome_view()
        {
            var actual = _controller.Submit(_humanLikeInput);

            Assert.AreEqual("AWESOME", actual.ViewName);
        }

        [TestMethod] public void should_have_valid_model_state()
        {
            var actual = _controller.Submit(_humanLikeInput);

            Assert.IsTrue(_controller.ModelState.IsValid);
        }

        [TestMethod] public void should_not_have_invalid_specific_model_error()
        {
            var actual = _controller.Submit(_humanLikeInput);

            Assert.IsFalse(_controller.ModelState.ContainsKey("YOU_ARE_A_BOT"));
        }
    }
}
