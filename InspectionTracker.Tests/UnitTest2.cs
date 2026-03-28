using InspectionTracker.Domain;
using InspectionTracker.MVC.Controllers;
using InspectionTracker.MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

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

        [Fact]
        public async Task FollowUp_CannotBeClosed_WithtClosedDateBeforeInspectionDate()
        {
            var db = GetDbContext();
            var logger = NullLogger<FollowUpsController>.Instance;
            var controller = new FollowUpsController(db, logger);

            var inspection = new Inspection
            {
                Id = 10,
                InspectionDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-7)),
                PremisesId = 1,
                Score = 90 // Outcome => Pass
            };

            db.Inspections.Add(inspection);

            var followUp = new FollowUp
            {
                Id = 1,
                InspectionId = 10,
                DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-5)),
                ClosedDate = null
            };

            db.FollowUps.Add(followUp);
            db.SaveChanges();

            var missingDate = default(DateOnly); // 0001-01-01

            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await controller.CloseConfirmed(1, missingDate);
            });
        }

        [Fact]
        public async Task FollowUp_CannotBeClosed_WithClosedDateInFuture()
        {
            var db = GetDbContext();
            var logger = NullLogger<FollowUpsController>.Instance;
            var controller = new FollowUpsController(db, logger);

            var inspection = new Inspection
            {
                Id = 10,
                InspectionDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-7)),
                PremisesId = 1,
                Score = 90
            };

            db.Inspections.Add(inspection);

            var followUp = new FollowUp
            {
                Id = 1,
                InspectionId = 10,
                DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-5)),
                ClosedDate = null
            };

            db.FollowUps.Add(followUp);
            db.SaveChanges();

            var futureDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await controller.CloseConfirmed(1, futureDate);
            });
        }

        [Fact]
        public async Task CloseConfirmed_DoesNotChangeClosedDate_WhenAlreadyClosed()
        {
            var db = GetDbContext();
            var logger = NullLogger<FollowUpsController>.Instance;
            var controller = new FollowUpsController(db, logger);

            var yesterday = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

            var followUp = new FollowUp
            {
                Id = 1,
                DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)),
                ClosedDate = yesterday
            };

            db.FollowUps.Add(followUp);
            db.SaveChanges();

            // Attempt to close again with a different date
            var attemptedDate = DateOnly.FromDateTime(DateTime.Today);
            await controller.CloseConfirmed(1, attemptedDate);

            var updated = db.FollowUps.First(f => f.Id == 1);
            Assert.Equal(yesterday, updated.ClosedDate);
        }
    }
}
