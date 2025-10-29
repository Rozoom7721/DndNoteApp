using System;
using System.ComponentModel.DataAnnotations;

namespace DndNoteApps.DTO;

public record class CreateCampaignDto (
    [Required][StringLength(100)] string Name,
    DateOnly StartDate,
    int DungeonMasterId
);