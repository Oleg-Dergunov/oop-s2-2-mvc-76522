using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectionTracker.Domain
{
    public class Inspection
    {
        public int Id { get; set; }
        public int PremisesId { get; set; }
        public Premises? Premises { get; set; }

        public DateOnly InspectionDate { get; set; }
        [Range(0, 100, ErrorMessage = "Score must be between 0 and 100.")]
        public int Score { get; set; }
        [NotMapped]
        public string Outcome => Score >= 70 ? "Pass" : "Fail";
        public string? Notes { get; set; }

        public List<FollowUp> FollowUps { get; set; } = new();
    }

}
