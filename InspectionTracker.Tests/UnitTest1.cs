using InspectionTracker.Domain;
using InspectionTracker.MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace InspectionTracker.Tests
{
    public class UnitTest1
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OverdueFollowUps_ReturnsOnlyItemsPastDueAndNotClosed()
        {
            var db = GetDbContext();

            var today = DateTime.Today;

            var overdue = new FollowUp
            {
                Id = 1,
                DueDate = today.AddDays(-5),
                ClosedDate = null
            };

            var notOverdue = new FollowUp
            {
                Id = 2,
                DueDate = today.AddDays(+3),
                ClosedDate = null
            };

            var closed = new FollowUp
            {
                Id = 3,
                DueDate = today.AddDays(-10),
                ClosedDate = today.AddDays(-1)
            };

            db.FollowUps.Add(overdue);
            db.FollowUps.Add(notOverdue);
            db.FollowUps.Add(closed);
            db.SaveChanges();

            var result = db.FollowUps
                .Where(f => f.DueDate < today && f.ClosedDate == null)
                .ToList();

            Assert.Single(result);
            Assert.Equal(1, result[0].Id);
        }
    }
}