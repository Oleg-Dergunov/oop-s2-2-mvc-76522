using InspectionTracker.Domain;
using InspectionTracker.MVC.Controllers;
using InspectionTracker.MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionTracker.Tests
{
    public class UnitTest2
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        // Verifies that attempting to close an already closed follow-up
        // does not modify its existing ClosedDate.
        // Ensures the CloseConfirmed action does not overwrite closure history.
        [Fact]
        public async Task CloseConfirmed_DoesNotChangeClosedDate_WhenAlreadyClosed()
        {
            var db = GetDbContext();
            var logger = NullLogger<FollowUpsController>.Instance;
            var controller = new FollowUpsController(db, logger);

            var yesterday = DateTime.Today.AddDays(-1);

            var followUp = new FollowUp
            {
                Id = 1,
                DueDate = DateTime.Today.AddDays(-10),
                ClosedDate = yesterday
            };

            db.FollowUps.Add(followUp);
            db.SaveChanges();

            await controller.CloseConfirmed(1);

            var updated = db.FollowUps.First(f => f.Id == 1);
            Assert.Equal(yesterday, updated.ClosedDate);
        }

    }
}
