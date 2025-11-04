using System;
using System.ComponentModel.DataAnnotations;

namespace DndNoteApps.DTO;

public record class CreateQuestDto(
    [Required][StringLength(50)] string Name,
    [Required] string Objective,
    string Reward,
    string Description,
    [Required] int CampaignId,
    int NpcId
);