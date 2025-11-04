using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DndNoteApps.DTO;

public record class CreatePlaceDto(
    [Required][StringLength(50)] string Name,
    string Fraction,
    string PlayerNote,
    string DmNote,
    string Description,
    [Required]int CampaignId,
    int QuestId,
    int NpcId
);
