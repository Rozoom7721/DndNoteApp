using System.ComponentModel.DataAnnotations;

namespace DndNoteApps.DTO;

public record class UpdateCampaignDto(
    [Required][StringLength(100)] string Name,
    DateOnly StartDate,
    int DungeonMasterId
)
{

}
