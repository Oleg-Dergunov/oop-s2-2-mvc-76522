using InspectionTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace InspectionTracker.MVC.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            SeedPremises(builder);
            SeedInspections(builder);
            SeedFollowUps(builder);
        }

        private static void SeedPremises(ModelBuilder builder)
        {
            builder.Entity<Premises>().HasData(
                new Premises { Id = 1, Name = "Cafe Roma", Address = "Main St 1", Town = "Dublin", RiskRating = "High" },
                new Premises { Id = 2, Name = "Fresh Bites", Address = "Main St 2", Town = "Dublin", RiskRating = "Medium" },
                new Premises { Id = 3, Name = "Golden Dragon", Address = "High Rd 5", Town = "Dublin", RiskRating = "Low" },

                new Premises { Id = 4, Name = "Cork Grill", Address = "River St 10", Town = "Cork", RiskRating = "High" },
                new Premises { Id = 5, Name = "Cork Sushi", Address = "Harbour Rd 3", Town = "Cork", RiskRating = "Medium" },
                new Premises { Id = 6, Name = "Cork Bakery", Address = "Market Sq 7", Town = "Cork", RiskRating = "Low" },

                new Premises { Id = 7, Name = "Galway Diner", Address = "Ocean Ave 2", Town = "Galway", RiskRating = "High" },
                new Premises { Id = 8, Name = "Galway Pizza", Address = "Old Town 4", Town = "Galway", RiskRating = "Medium" },
                new Premises { Id = 9, Name = "Galway Cafe", Address = "Harbour St 8", Town = "Galway", RiskRating = "Low" },

                new Premises { Id = 10, Name = "Dublin BBQ", Address = "Main St 9", Town = "Dublin", RiskRating = "High" },
                new Premises { Id = 11, Name = "Cork Vegan", Address = "Green Rd 11", Town = "Cork", RiskRating = "Low" },
                new Premises { Id = 12, Name = "Galway Steakhouse", Address = "Hill Rd 6", Town = "Galway", RiskRating = "Medium" }
            );
        }

        private static void SeedInspections(ModelBuilder builder)
        {
            builder.Entity<Inspection>().HasData(
                new Inspection { Id = 1, PremisesId = 1, InspectionDate = DateTime.Today.AddDays(-2), Score = 90, Outcome = "Pass", Notes = "Good" },
                new Inspection { Id = 2, PremisesId = 1, InspectionDate = DateTime.Today.AddDays(-20), Score = 55, Outcome = "Fail", Notes = "Issues found" },
                new Inspection { Id = 3, PremisesId = 2, InspectionDate = DateTime.Today.AddDays(-5), Score = 70, Outcome = "Pass", Notes = "OK" },
                new Inspection { Id = 4, PremisesId = 3, InspectionDate = DateTime.Today.AddDays(-40), Score = 65, Outcome = "Fail", Notes = "Recheck needed" },
                new Inspection { Id = 5, PremisesId = 4, InspectionDate = DateTime.Today.AddDays(-10), Score = 88, Outcome = "Pass", Notes = "Good" },
                new Inspection { Id = 6, PremisesId = 5, InspectionDate = DateTime.Today.AddDays(-60), Score = 45, Outcome = "Fail", Notes = "Serious issues" },
                new Inspection { Id = 7, PremisesId = 6, InspectionDate = DateTime.Today.AddDays(-1), Score = 92, Outcome = "Pass", Notes = "Excellent" },
                new Inspection { Id = 8, PremisesId = 7, InspectionDate = DateTime.Today.AddDays(-15), Score = 78, Outcome = "Pass", Notes = "OK" },
                new Inspection { Id = 9, PremisesId = 8, InspectionDate = DateTime.Today.AddDays(-3), Score = 82, Outcome = "Pass", Notes = "Good" },
                new Inspection { Id = 10, PremisesId = 9, InspectionDate = DateTime.Today.AddDays(-100), Score = 50, Outcome = "Fail", Notes = "Poor" },

                new Inspection { Id = 11, PremisesId = 10, InspectionDate = DateTime.Today.AddDays(-7), Score = 95, Outcome = "Pass", Notes = "Excellent" },
                new Inspection { Id = 12, PremisesId = 11, InspectionDate = DateTime.Today.AddDays(-200), Score = 60, Outcome = "Pass", Notes = "OK" },
                new Inspection { Id = 13, PremisesId = 12, InspectionDate = DateTime.Today.AddDays(-30), Score = 72, Outcome = "Pass", Notes = "OK" },
                new Inspection { Id = 14, PremisesId = 2, InspectionDate = DateTime.Today.AddDays(-300), Score = 40, Outcome = "Fail", Notes = "Bad" },
                new Inspection { Id = 15, PremisesId = 3, InspectionDate = DateTime.Today.AddDays(-8), Score = 85, Outcome = "Pass", Notes = "Good" },

                new Inspection { Id = 16, PremisesId = 4, InspectionDate = DateTime.Today.AddDays(-12), Score = 90, Outcome = "Pass", Notes = "Good" },
                new Inspection { Id = 17, PremisesId = 5, InspectionDate = DateTime.Today.AddDays(-4), Score = 77, Outcome = "Pass", Notes = "OK" },
                new Inspection { Id = 18, PremisesId = 6, InspectionDate = DateTime.Today.AddDays(-9), Score = 66, Outcome = "Pass", Notes = "OK" },
                new Inspection { Id = 19, PremisesId = 7, InspectionDate = DateTime.Today.AddDays(-11), Score = 58, Outcome = "Fail", Notes = "Issues" },
                new Inspection { Id = 20, PremisesId = 8, InspectionDate = DateTime.Today.AddDays(-6), Score = 80, Outcome = "Pass", Notes = "Good" },

                new Inspection { Id = 21, PremisesId = 9, InspectionDate = DateTime.Today.AddDays(-14), Score = 90, Outcome = "Pass", Notes = "Good" },
                new Inspection { Id = 22, PremisesId = 10, InspectionDate = DateTime.Today.AddDays(-16), Score = 55, Outcome = "Fail", Notes = "Issues" },
                new Inspection { Id = 23, PremisesId = 11, InspectionDate = DateTime.Today.AddDays(-18), Score = 88, Outcome = "Pass", Notes = "Good" },
                new Inspection { Id = 24, PremisesId = 12, InspectionDate = DateTime.Today.AddDays(-22), Score = 60, Outcome = "Pass", Notes = "OK" },
                new Inspection { Id = 25, PremisesId = 1, InspectionDate = DateTime.Today.AddDays(-50), Score = 45, Outcome = "Fail", Notes = "Bad" }
            );
        }

        private static void SeedFollowUps(ModelBuilder builder)
        {
            builder.Entity<FollowUp>().HasData(
                new FollowUp { Id = 1, InspectionId = 2, DueDate = DateTime.Today.AddDays(-5), ClosedDate = null },
                new FollowUp { Id = 2, InspectionId = 4, DueDate = DateTime.Today.AddDays(-20), ClosedDate = null },
                new FollowUp { Id = 3, InspectionId = 6, DueDate = DateTime.Today.AddDays(-1), ClosedDate = null },
                new FollowUp { Id = 4, InspectionId = 10, DueDate = DateTime.Today.AddDays(-15), ClosedDate = null },

                new FollowUp { Id = 5, InspectionId = 3, DueDate = DateTime.Today.AddDays(-10), ClosedDate = DateTime.Today.AddDays(-3) },
                new FollowUp { Id = 6, InspectionId = 7, DueDate = DateTime.Today.AddDays(-30), ClosedDate = DateTime.Today.AddDays(-10) },
                new FollowUp { Id = 7, InspectionId = 9, DueDate = DateTime.Today.AddDays(-40), ClosedDate = DateTime.Today.AddDays(-20) },

                new FollowUp { Id = 8, InspectionId = 11, DueDate = DateTime.Today.AddDays(5), ClosedDate = null },
                new FollowUp { Id = 9, InspectionId = 12, DueDate = DateTime.Today.AddDays(10), ClosedDate = null },
                new FollowUp { Id = 10, InspectionId = 13, DueDate = DateTime.Today.AddDays(20), ClosedDate = null }
            );
        }
    }
}
