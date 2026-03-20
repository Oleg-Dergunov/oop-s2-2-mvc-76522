namespace InspectionTracker.MVC.Models
{
    public class DashboardViewModel
    {
        public int TotalInspectionsThisMonth { get; set; }
        public int FailedInspectionsThisMonth { get; set; }
        public int OverdueOpenFollowUps { get; set; }

        public string? Town { get; set; }
        public string? RiskRating { get; set; }

        public List<string> Towns { get; set; } = new();
        public List<string> RiskRatings { get; set; } = new();
    }

}
