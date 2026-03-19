using System.ComponentModel.DataAnnotations;

namespace InspectionTracker.Domain
{
    public class Premises
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        [RegularExpression("Low|Medium|High", ErrorMessage = "RiskRating must be Low, Medium, or High.")]
        public string RiskRating { get; set; }
        public List<Inspection> Inspections { get; set; } = new();
    }

}
