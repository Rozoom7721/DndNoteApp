using System.ComponentModel.DataAnnotations;

namespace DndNoteApps.DTO;

public record class UpdatePlaceDto(
    [Required][StringLength(50)] string Name,
    string Fraction,
    string PlayerNote,
    string DmNote,
    string Description,
    [Required]int CampaignId,
    int QuestId,
    int NpcId
);