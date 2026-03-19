using System.ComponentModel.DataAnnotations;

namespace InspectionTracker.Domain
{
    public class Inspection
    {
        public int Id { get; set; }
        public int PremisesId { get; set; }
        public Premises? Premises { get; set; }

        public DateTime InspectionDate { get; set; }
        [Range(0, 100, ErrorMessage = "Score must be between 0 and 100.")]
        public int Score { get; set; }
        [RegularExpression("Pass|Fail", ErrorMessage = "Outcome must be Pass or Fail.")]
        public string Outcome { get; set; }
        public string? Notes { get; set; }

        public List<FollowUp> FollowUps { get; set; } = new();
    }

}
