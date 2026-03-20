using InspectionTracker.Domain;
using InspectionTracker.MVC.Controllers;
using InspectionTracker.MVC.Data;
using InspectionTracker.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InspectionTracker.Tests
{
    public class UnitTest3
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void Dashboard_Counts_Are_Consistent_With_Seed_Data()
        {
            var db = GetDbContext();

            var premises1 = new Premises
            {
                Id = 1,
                Name = "Shop A",
                Address = "123 Main St",
                Town = "Dublin",
                RiskRating = "High"
            };

            var premises2 = new Premises
            {
                Id = 2,
                Name = "Shop B",
                Address = "456 High Rd",
                Town = "Cork",
                RiskRating = "Low"
            };

            db.Premises.AddRange(premises1, premises2);

            var today = DateTime.Today;
            var thisMonth = today.AddDays(-1);
            var lastMonth = today.AddMonths(-1);

            var inspection1 = new Inspection
            {
                Id = 1,
                PremisesId = 1,
                InspectionDate = thisMonth,
                Outcome = "Fail",
                Score = 50
            };

            var inspection2 = new Inspection
            {
                Id = 2,
                PremisesId = 2,
                InspectionDate = lastMonth,
                Outcome = "Pass",
                Score = 90
            };

            db.Inspections.AddRange(inspection1, inspection2);

            var overdueFollowUp = new FollowUp
            {
                Id = 1,
                InspectionId = 1,
                DueDate = today.AddDays(-5), // overdue
                ClosedDate = null            // open
            };

            var okFollowUp = new FollowUp
            {
                Id = 2,
                InspectionId = 1,
                DueDate = today.AddDays(5),  // not overdue
                ClosedDate = null
            };

            db.FollowUps.AddRange(overdueFollowUp, okFollowUp);
            db.SaveChanges();

            var controller = new DashboardController(db);

            var result = controller.Index(null, null) as ViewResult;
            var model = result!.Model as DashboardViewModel;

            Assert.Equal(1, model!.TotalInspectionsThisMonth);
            Assert.Equal(1, model.FailedInspectionsThisMonth);
            Assert.Equal(1, model.OverdueOpenFollowUps);
        }
    }
}
