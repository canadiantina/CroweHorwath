using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CroweHorwathAssignment.WebAPI.Controllers;
using System.Collections.Generic;
using CroweHorwathAssignment.Service.Services;
using CroweHorwathAssignment.Service.Interfaces;
using CroweHorwathAssignment.Data.Models.DTO;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Results;
using CroweHorwathAssignment.Data.Core.Mapping;

namespace CroweHorwathAssignment.WebAPI.Tests.Controllers
{
    [TestClass]
    public class MessageControllerTest
    {

        [TestMethod]
        public void GetDBMessageWeb()
        {
            // Arrange
            InitializeMapping();
            var controller = new MessageController();

            //Act
            var actionResult = controller.GetMessage(1);

            // Assert
            var response = actionResult as OkNegotiatedContentResult<tblTagDTO>;

            Assert.IsNotNull(response);
            Assert.AreEqual("Hello World Web DB", response.Content.tagDescription);
        }
        [TestMethod]
        public void GetDBMessageConsole()
        {
            // Arrange
            InitializeMapping();
            var controller = new MessageController();

            //Act
            var actionResult = controller.GetMessage(2);

            // Assert
            var response = actionResult as OkNegotiatedContentResult<tblTagDTO>;

            Assert.IsNotNull(response);
            Assert.AreEqual("Hello World Console DB", response.Content.tagDescription);
        }
        [TestMethod]
        public void GetAllMessages()
        {
            // Arrange
            InitializeMapping();
            var controller = new MessageController();

            //Act
            IEnumerable<tblTagDTO> actionResult = controller.GetMessages();

            // Assert
            Assert.IsNotNull(actionResult);
        }
        [TestMethod]
        public void GetDefaultMessage()
        {
            // Arrange
            InitializeMapping();
            var controller = new MessageController();

            //Act
            tblTagDTO actionResult = controller.GetDefault();

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual("Hello World", actionResult.tagDescription);
        }

        private static void InitializeMapping()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile<CroweHorwathAssigmentDataMappingProfile>();
            });
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
