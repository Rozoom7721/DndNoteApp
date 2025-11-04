namespace DndNoteApps.DTO;
using System.ComponentModel.DataAnnotations;

public record class UpdateQuestDto
(
    [Required][StringLength(50)] string Name,
    [Required] string Objective,
    string Reward,
    string Description,
    [Required] int CampaignId,
    int NpcId
);

