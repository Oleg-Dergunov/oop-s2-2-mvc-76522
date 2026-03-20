using InspectionTracker.Domain;
using InspectionTracker.MVC.Controllers;
using InspectionTracker.MVC.Data;
using InspectionTracker.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionTracker.Tests
{
    public class UnitTest4
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void FollowUpsController_All_Methods_Have_Correct_Authorization()
        {
            var controllerAuth = typeof(FollowUpsController)
                .GetCustomAttributes(typeof(AuthorizeAttribute), false)
                .Cast<AuthorizeAttribute>()
                .FirstOrDefault();

            Assert.NotNull(controllerAuth);
            Assert.Equal("Admin,Inspector,Viewer", controllerAuth!.Roles);

            string? GetRoles(string methodName, params Type[] parameters)
            {
                var method = typeof(FollowUpsController).GetMethod(methodName, parameters);
                var attr = method!
                    .GetCustomAttributes(typeof(AuthorizeAttribute), false)
                    .Cast<AuthorizeAttribute>()
                    .FirstOrDefault();

                return attr?.Roles; 
            }

            Assert.Null(GetRoles("Index"));
            Assert.Null(GetRoles("Details", typeof(int?)));

            // Create (GET, POST)
            Assert.Equal("Admin,Inspector", GetRoles("Create", Type.EmptyTypes));
            Assert.Equal("Admin,Inspector", GetRoles("Create", typeof(FollowUp)));

            // Edit (GET, POST)
            Assert.Equal("Admin", GetRoles("Edit", typeof(int?)));
            Assert.Equal("Admin", GetRoles("Edit", typeof(int), typeof(FollowUp)));

            // Delete (GET, POST)
            Assert.Equal("Admin", GetRoles("Delete", typeof(int?)));
            Assert.Equal("Admin", GetRoles("DeleteConfirmed", typeof(int)));

            // Close (GET, POST)
            Assert.Equal("Inspector", GetRoles("Close", typeof(int)));
            Assert.Equal("Inspector", GetRoles("CloseConfirmed", typeof(int)));
        }

        [Fact]
        public void InspectionsController_All_Methods_Have_Correct_Authorization()
        {
            var controllerAuth = typeof(InspectionsController)
                .GetCustomAttributes(typeof(AuthorizeAttribute), false)
                .Cast<AuthorizeAttribute>()
                .FirstOrDefault();

            Assert.NotNull(controllerAuth);
            Assert.Equal("Admin,Inspector,Viewer", controllerAuth!.Roles);

            string? GetRoles(string methodName, params Type[] parameters)
            {
                var method = typeof(InspectionsController).GetMethod(methodName, parameters);
                var attr = method!
                    .GetCustomAttributes(typeof(AuthorizeAttribute), false)
                    .Cast<AuthorizeAttribute>()
                    .FirstOrDefault();

                return attr?.Roles; 
            }

            Assert.Null(GetRoles("Index"));
            Assert.Null(GetRoles("Details", typeof(int?)));

            // Create (GET, POST) → Admin, Inspector
            Assert.Equal("Admin,Inspector", GetRoles("Create", Type.EmptyTypes));
            Assert.Equal("Admin,Inspector", GetRoles("Create", typeof(Inspection)));

            // Edit (GET, POST) → Admin
            Assert.Equal("Admin", GetRoles("Edit", typeof(int?)));
            Assert.Equal("Admin", GetRoles("Edit", typeof(int), typeof(Inspection)));

            // Delete (GET, POST) → Admin
            Assert.Equal("Admin", GetRoles("Delete", typeof(int?)));
            Assert.Equal("Admin", GetRoles("DeleteConfirmed", typeof(int)));
        }

        [Fact]
        public void PremisesController_All_Methods_Have_Correct_Authorization()
        {
            var controllerAuth = typeof(PremisesController)
                .GetCustomAttributes(typeof(AuthorizeAttribute), false)
                .Cast<AuthorizeAttribute>()
                .FirstOrDefault();

            Assert.NotNull(controllerAuth);
            Assert.Equal("Admin,Inspector,Viewer", controllerAuth!.Roles);

            string? GetRoles(string methodName, params Type[] parameters)
            {
                var method = typeof(PremisesController).GetMethod(methodName, parameters);
                var attr = method!
                    .GetCustomAttributes(typeof(AuthorizeAttribute), false)
                    .Cast<AuthorizeAttribute>()
                    .FirstOrDefault();

                return attr?.Roles; 
            }

            Assert.Null(GetRoles("Index"));
            Assert.Null(GetRoles("Details", typeof(int?)));

            // Create (GET, POST) → Admin
            Assert.Equal("Admin", GetRoles("Create", Type.EmptyTypes));
            Assert.Equal("Admin", GetRoles("Create", typeof(Premises)));

            // Edit (GET, POST) → Admin
            Assert.Equal("Admin", GetRoles("Edit", typeof(int?)));
            Assert.Equal("Admin", GetRoles("Edit", typeof(int), typeof(Premises)));

            // Delete (GET, POST) → Admin
            Assert.Equal("Admin", GetRoles("Delete", typeof(int?)));
            Assert.Equal("Admin", GetRoles("DeleteConfirmed", typeof(int)));
        }
    }
}
