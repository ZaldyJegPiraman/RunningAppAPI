using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class UserProfileControllerTests
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ILoggerManager _logger;
        private readonly RunningAppDbContext _context;

        public UserProfileControllerTests()
        {
            var repo = new UserProfileRepositoryTest();
            _context = repo.GetDatabaseContext();
            _userProfileRepository = new UserProfileRepository(_context);
            _logger = A.Fake<ILoggerManager>();
        }

        [Fact, TestPriority(1)]
        public void UserProfileController_GetUserProfile_ReturnList()
        {
            //Arrange
            var controller = new UserProfileController(_userProfileRepository, _logger);

            //Act
            var result = controller.Get();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<IEnumerable<UserProfileDTO>>));
        }


        [Fact, TestPriority(2)]
        public void UserProfileController_GetUserProfileById_ReturnUserProfile()
        {
            //Arrange
            var controller = new UserProfileController(_userProfileRepository, _logger);

            //Act
            var result = controller.Get(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<UserProfileDTO>));
        }


        [Fact, TestPriority(3)]
        public void UserProfileController_AddUserProfile_ReturnOk()
        {
            //Arrange
            var user = new UserProfile();
            user.Age = 10;
            user.Name = "zaldy";
            user.Height = 150;
            user.Weight = 79;

            var controller = new UserProfileController(_userProfileRepository, _logger);


            //Act
            var result = controller.Post(user.ToUserProfileDTOModel());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact, TestPriority(4)]
        public void UserProfileController_AddUserProfile_ReturnBadRequest()
        {
            //Arrange
            var controller = new UserProfileController(_userProfileRepository, _logger);
            //var user = A.Fake<UserProfileDTO>();  

            //Act
            var result = controller.Post(null);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }


        [Fact, TestPriority(5)]
        public void UserProfileController_UpdateUserProfile_ReturnOk()
        {
            //Arrange
            var user = new UserProfile();
            user.Age = 10;
            user.Name = "zaldy";
            user.Height = 150;
            user.Weight = 79;
            user.UserId = 2;


            _context.ChangeTracker.Clear();
            var _userProfileRepo = new UserProfileRepository(_context);
            var controller = new UserProfileController(_userProfileRepo, _logger);

            
            //Act
            var result = controller.Put(2,user.ToUserProfileDTOModel());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact, TestPriority(6)]
        public  void UserProfileController_UpdateUserProfile_ReturnBadRequest()
        {
            //Arrange
            var user = new UserProfile();
            user.Age = 10;
            user.Name = "zaldy";
            user.Height = 150;
            user.Weight = 79;
            user.UserId = 2;


            _context.ChangeTracker.Clear();
            var _userProfileRepo = new UserProfileRepository(_context);
            var controller = new UserProfileController(_userProfileRepo, _logger);


            //Act
            var result = controller.Put(0, user.ToUserProfileDTOModel());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }


        [Fact, TestPriority(7)]
        public async void UserProfileController_DeleteUserProfile_ReturnOk()
        {
            //Arrange
 
            _context.ChangeTracker.Clear();
            var _userProfileRepo = new UserProfileRepository(_context);
            var controller = new UserProfileController(_userProfileRepo, _logger);

            //Act
            var result = await controller.Delete(2);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact, TestPriority(8)]
        public async void UserProfileController_DeleteUserProfile_ReturnBadRequest()
        {
            //Arrange

            _context.ChangeTracker.Clear();
            var _userProfileRepo = new UserProfileRepository(_context);
            var controller = new UserProfileController(_userProfileRepo, _logger);

            //Act
            var result = await controller.Delete(0);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NotFoundResult));
        }
    }
}
