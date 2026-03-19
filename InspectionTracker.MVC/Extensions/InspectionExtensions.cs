using InspectionTracker.Domain;
using InspectionTracker.MVC.Models.ViewModels;

namespace InspectionTracker.MVC.Extensions
{
    public static class InspectionExtensions
    {
        public static InspectionDisplayDto ToDisplayDto(this Inspection i)
        {
            return new InspectionDisplayDto
            {
                Id = i.Id,
                Display = $"{(i.Premises?.Name ?? "[No premises]")} – {i.InspectionDate:dd/MM/yyyy}"
            };
        }
    }

}
