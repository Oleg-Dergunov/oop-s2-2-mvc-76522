using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectionTracker.Domain
{
    public class FollowUp
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }
        public Inspection? Inspection { get; set; }

        public DateTime DueDate { get; set; }
        [NotMapped]
        public string Status => ClosedDate == null ? "Open" : "Closed";
        public DateTime? ClosedDate { get; set; }
    }

}
