using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using RunningApp.Controllers;
using RunningApp.Data;
using RunningApp.DTO;
using RunningApp.Helpers;
using RunningApp.Interfaces;
using RunningApp.Models;
using RunningApp.Repository;
using RunningApp.Tests.Attributes;
using RunningApp.Tests.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningApp.Tests.Controller
{
  
    public class RunningActivityControllerTests
    {
        private readonly IRunningActivityRepository _runningActivityRepository;
        private readonly ILoggerManager _logger;
        private readonly RunningAppDbContext _context;

        public RunningActivityControllerTests()
        {
            var repo = new UserProfileRepositoryTest();
            _context = repo.GetDatabaseContext();
            _runningActivityRepository = new RunningActivityRepository(_context);
            _logger = A.Fake<ILoggerManager>();
        }

        [Fact, TestPriority(9)]
        public void UserProfileController_GetRunningActivity_ReturnList()
        {
            //Arrange
            var controller = new RunningActivityController(_runningActivityRepository, _logger);

            //Act
            var result = controller.Get();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<IEnumerable<RunningActivityDTO>>));
        }


        [Fact, TestPriority(10)]
        public void RunningActivityController_GetRunningActivityById_ReturnUserProfile()
        {
            //Arrange
            var controller = new RunningActivityController(_runningActivityRepository, _logger);

            //Act
            var result = controller.Get(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<RunningActivityDTO>));
        }


        [Fact, TestPriority(11)]
        public void RunningActivityController_AddRunningActivity_ReturnOk()
        {
            //Arrange
            var activity = new RunningActivity();
            activity.Location = "Makati";
            activity.Distance = 10;
            activity.DateTimeEnded = DateTime.UtcNow.AddHours(1);
            activity.DateTimeStarted = DateTime.UtcNow;
            activity.UserId = 1;

            var controller = new RunningActivityController(_runningActivityRepository, _logger);


            //Act
            var result = controller.Post(activity.ToRunningActivityDTOModel());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact, TestPriority(12)]
        public void RunningActivityController_AddRunningActivity_ReturnBadRequest()
        {
            //Arrange
            var controller = new RunningActivityController(_runningActivityRepository, _logger);
            //var user = A.Fake<UserProfileDTO>();  

            //Act
            var result = controller.Post(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }


        [Fact, TestPriority(13)]
        public void RunningActivityController_UpdateRunningActivity_ReturnOk()
        {
            //Arrange
            var activity = new RunningActivity();
            activity.Location = "Makati";
            activity.Distance = 10;
            activity.DateTimeEnded = DateTime.UtcNow.AddHours(1);
            activity.DateTimeStarted = DateTime.UtcNow;
            activity.UserId = 1;

            _context.ChangeTracker.Clear();
            var _runningActivityRepo = new RunningActivityRepository(_context);
            var controller = new RunningActivityController(_runningActivityRepo, _logger);


            //Act
            var result = controller.Put(2, activity.ToRunningActivityDTOModel());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact, TestPriority(14)]
        public void RunningActivityController_UpdateRunningActivity_ReturnBadRequest()
        {
            //Arrange
            var activity = new RunningActivity();
            activity.Location = "Makati";
            activity.Distance = 10;
            activity.DateTimeEnded = DateTime.UtcNow.AddHours(1);
            activity.DateTimeStarted = DateTime.UtcNow;
            activity.UserId = 1;

            _context.ChangeTracker.Clear();
            var _runningActivityRepo = new RunningActivityRepository(_context);
            var controller = new RunningActivityController(_runningActivityRepo, _logger);


            //Act
            var result = controller.Put(0, activity.ToRunningActivityDTOModel());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }


        [Fact, TestPriority(15)]
        public async void RunningActivityController_DeleteRunningActivity_ReturnOk()
        {
            //Arrange

            _context.ChangeTracker.Clear();
            var _runningActivityRepo = new RunningActivityRepository(_context);
            var controller = new RunningActivityController(_runningActivityRepo, _logger);

            //Act
            var result = await controller.Delete(2);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact, TestPriority(16)]
        public async void RunningActivityController_DeleteRunningActivity_ReturnBadRequest()
        {
            //Arrange

            _context.ChangeTracker.Clear();
            var _runningActivityRepo = new RunningActivityRepository(_context);
            var controller = new RunningActivityController(_runningActivityRepo, _logger);

            //Act
            var result = await controller.Delete(0);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NotFoundResult));
        }
    }
}
